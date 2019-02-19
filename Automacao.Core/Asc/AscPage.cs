using Automacao.Core.Helper;
using Automacao.Core.Helper.Library;
using Automacao.Core.PageObjectModel;
using Automacao.Domain.Model.ASC;
using HtmlAgilityPack;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automacao.Core.Asc
{
    public class AscPage : IDisposable
    {

        private string _baseurl;
        private bool _authenticated;

        private BrowserSession _bs;
        private Uri _uri;
        private IEnumerable<Ocorrencia> _ocorrencias;

        public bool Authenticated { get { return _authenticated; } set { _authenticated = value; } }
        public string User { get; private set; }
        public string Pass { get; private set; }

        public AscPage(string user, string pass)
        {
            _baseurl = "http://dynamics.caixaseguros.intranet:5555/CRMCAD/";
            _authenticated = false;

            User = user;
            Pass = pass;

            _uri = new Uri($@"{_baseurl}");
            _bs = new BrowserSession();
            _ocorrencias = new List<Ocorrencia>();

            WebProxy p = new WebProxy("localhost", 8888);
            WebRequest.DefaultWebProxy = p;
        }

        /// <summary>
        /// Realiza a autenticação no sistema
        /// </summary>
        /// <returns></returns>
        public bool Autenticar()
        {
            try
            {
                Authenticated = false;
                _bs.UseCredentials = true;
                _bs.Credentials = new NetworkCredential(User, Pass);
                var loged = _bs.Get("http://dynamics.caixaseguros.intranet:5555/CRMCAD/main.aspx");
                if (loged.Contains("Importante:"))
                    Authenticated = true;
                return Authenticated;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar autenticar usuário " + User + ". Message:" + ex.Message + ".  StackTrace: " + ex.StackTrace);
            }
        }

        public string GetPage(string url)
        {
            try
            {
                if (!Authenticated)
                    Autenticar();

                return _bs.Get(url);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Retorna a lista de itens da fila de trabalho 
        /// </summary>
        /// <returns></returns>
        public List<Ocorrencia> GetOcorrencias()
        {
            using (var asc = new ASCSession(User, Pass))
            {
                var ocorrencias = asc.GetOcorrencias();
                _authenticated = asc.Autenticated;
                _ocorrencias = ocorrencias;
                return ocorrencias;
            }
        }

        public string GetExcelFileName()
        {
            var data = _ocorrencias.Select(x => new OcorrenciaExcelObjectModel
            {
                Numero_Ocorrencia = x.NumeroOcorrencia, 
                Assunto = x.ReferenteA, 
                Cliente = x.NomeCliente, 
                Tipo_Ocorrencia = x.Tipo,
                Canal_Abertura = x.CanalEntrada,
                E_mail = x.Email,
                Grupo =x.Grupo,
                Cota = x.Cota,
                Data_Criacao = x.DataCriacaoStr,
                Criado_Por = x.CriadoPor
            });
            var excel = new ExcelExport<OcorrenciaExcelObjectModel>(data);
            return excel.Gerar();
        }

        public void Dispose()
        {
        }
    }
}
