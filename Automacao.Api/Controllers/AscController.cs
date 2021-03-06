﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Automacao.Api.ViewModel;
using Automacao.Core.Asc;
using Automacao.Core.PageObjectModel;
using Automacao.Domain.Model.ASC;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace Automacao.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AscController : Controller
    {
        // GET: api/asc
        [HttpPost("[action]")]
        public ResponseViewModel<UsuarioLoginViewModel> Logar([FromBody] UsuarioLoginViewModel usuario)
        {
            try
            {
                using (var robo = new AscPage(usuario.Nome, usuario.Senha))
                {

                    bool authenticated = robo.Autenticar();

                    if (authenticated)
                    {
                        return new ResponseViewModel<UsuarioLoginViewModel>
                        {
                            Message = $@"HttpStatusCod: {System.Net.HttpStatusCode.OK}",
                            Data = new List<UsuarioLoginViewModel> { usuario }
                        };
                    }
                    else
                    {
                        return new ResponseViewModel<UsuarioLoginViewModel>
                        {
                            Message = $@"HttpStatusCod: {System.Net.HttpStatusCode.Unauthorized}",
                            Data = new List<UsuarioLoginViewModel> { usuario }
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new ResponseViewModel<UsuarioLoginViewModel>
                {
                    Message = $@"Erro: {e}"
                };
            }
        }

        // GET: api/asc
        [HttpPost("[action]")]
        public ResponseViewModel<OcorrenciaExcelObjectModel> Ocorrencias([FromBody] UsuarioLoginViewModel usuario)
        {
            try
            {
                var rnd = new Random();
                var page = new AscPage(usuario.Nome, usuario.Senha);

                var ocorrencias = page.GetOcorrencias().Select(x => new OcorrenciaExcelObjectModel
                {
                    Numero_Ocorrencia = x.NumeroOcorrencia,
                    Assunto = x.ReferenteA,
                    Cliente = x.NomeCliente,
                    Tipo_Ocorrencia = x.Tipo,
                    Canal_Abertura = x.CanalEntrada,
                    E_mail = x.Email,
                    Grupo = x.Grupo,
                    Cota = x.Cota,
                    Data_Criacao = x.DataCriacaoStr,
                    Criado_Por = x.CriadoPor
                }).ToList();

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                if (page.Authenticated)
                {
                    return new ResponseViewModel<OcorrenciaExcelObjectModel>
                    {
                        Message = $@"HttpStatusCod: {HttpStatusCode.OK}",
                        Anexo = page.GetExcelFileName(),
                        Data = ocorrencias
                    };
                }
                else
                {
                    return new ResponseViewModel<OcorrenciaExcelObjectModel>
                    {
                        Message = $@"HttpStatusCod: {System.Net.HttpStatusCode.Unauthorized}",
                        Data = new List<OcorrenciaExcelObjectModel>()
                    };
                }
            }
            catch (Exception e)
            {
                return new ResponseViewModel<OcorrenciaExcelObjectModel>
                {
                    Message = $@"Erro: {e.Message }",
                    Data = new List<OcorrenciaExcelObjectModel>()
                };
            }
        }

        [HttpGet("[action]")]
        public HttpResponseMessage Generate(string fileName)
        {
            var path = $"~/Content/{fileName}";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentLength = stream.Length;
            return result;
        }
    }
}