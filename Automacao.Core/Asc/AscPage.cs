using Automacao.Core.Helper;
using Automacao.Core.Helper.Library;
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

        public string ExportOcorrencias()
        {
            try
            {
                var rnd = new Random();
                var nomeArquivo = $"DadosASC_Ocorrencias_{DateTime.Now.ToString("yyyyMMddmmss")}{rnd.Next(100)}.xlsx";
                string excelFile = Path.Combine($"Content/{nomeArquivo}");

                ExcelPackage pck = new ExcelPackage();
                if (_ocorrencias == null)
                {
                    return "Não foi possível exportar esta lista";
                }

                var listaToExport = (from c in _ocorrencias
                                     select new
                                     {
                                         c.SinistroOnline,
                                         c.Fila,
                                         ASC = c.NumeroOcorrencia,
                                         c.Titulo,
                                         c.ReferenteA,
                                         c.Status,
                                         c.StatusAtividade,
                                         c.CanalEntrada,
                                         c.CPFCNPJ,
                                         c.NomeCliente,
                                         DataCriacao = c.DataCriacao,
                                         DataPrevistaConclusao = c.DataPrevistaConclusao,
                                         AnexoAlteradoPor = c.Anexos != null ? (c.Anexos.Count > 0 ? c.Anexos.FirstOrDefault().AlteradoPor : "") : "",
                                         LinkArquivoComunicado = c.Anexos != null ? (c.Anexos.Count > 0 ? c.Anexos.FirstOrDefault().Url : "") : "",
                                         oID = c.OID,
                                     }).ToList();

                var wsDt = pck.Workbook.Worksheets.Add("Dados");
                wsDt.Cells["A1"].LoadFromCollection(listaToExport, true, TableStyles.Medium9);
                wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();
                var fi = new FileInfo(excelFile);
                if (fi.Exists)
                    fi.Delete();
                pck.SaveAs(fi);
                ProcessStartInfo psi = new ProcessStartInfo(excelFile);
                psi.UseShellExecute = true;
                Process.Start(psi);

                return excelFile;
            }
            catch (Exception ex)
            {
                return $"Falha interna, tente novamente.  {ex.Message}. InnerException.Message: {ex.InnerException.Message}";
            }
        }

        public string GetExcelFileName()
        {
            var excel = new ExcelExport<Ocorrencia>(_ocorrencias);
            return excel.Gerar();
        }

        public void Dispose()
        {
        }
    }
}
