using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automacao.Api.ViewModel;
using Automacao.Core.Asc;
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
                }
                    ;
            }


        }

        // GET: api/asc
        [HttpPost("[action]")]
        public ResponseViewModel<Ocorrencia> Ocorrencias([FromBody] UsuarioLoginViewModel usuario)
        {
            try
            {
                var page = new AscPage(usuario.Nome, usuario.Senha);
                var ocorrencias = page.GetOcorrencias();

                if (page.Authenticated)
                {
                    return new ResponseViewModel<Ocorrencia>
                    {
                        Message = $@"HttpStatusCod: {System.Net.HttpStatusCode.OK}",
                        Data = ocorrencias
                    };
                }
                else
                {
                    return new ResponseViewModel<Ocorrencia>
                    {
                        Message = $@"HttpStatusCod: {System.Net.HttpStatusCode.Unauthorized}",
                        Data = new List<Ocorrencia>()
                    };
                }
            }
            catch (Exception e)
            {
                return new ResponseViewModel<Ocorrencia>
                {
                    Message = $@"Erro: {e.Message }",
                    Data = new List<Ocorrencia>()
                };
            }
        }
        // GET: api/asc/gethtml
        [HttpPost("[action]")]
        public ResponseViewModel<string> GetHtml([FromBody] UsuarioLoginViewModel usuario)
        {
            try
            {
                using (var bot = new AscPage(usuario.Nome, usuario.Senha))
                {
                    var url = "http://dynamics.caixaseguros.intranet:5555/CRMCAD/AppWebServices/AppGridWebService.ashx?operation=Refresh";
                    var html = bot.GetPage(url);
                    var rs = new ResponseViewModel<string>
                    {
                        Message = $@"Message: {System.Net.HttpStatusCode.OK}",
                        Data = new List<string> { html }
                    };
                    return rs;
                }
            }
            catch (Exception e)
            {
                return new ResponseViewModel<string>
                {
                    Message = $@"Erro: {e.Message }",
                    Data = new List<string>()
                };
            }

        }


        // GET: api/asc/gethtml
        [HttpPost("[action]")]
        public ResponseViewModel<string> GetFrame([FromBody] UsuarioLoginViewModel usuario)
        {
            try
            {
                using (var page = new AscPage(usuario.Nome, usuario.Senha))
                {
                    var url = "http://dynamics.caixaseguros.intranet:5555/CRMCAD/AppWebServices/AppGridWebService.ashx?operation=Refresh";
                    var html = page.GetIframe(url);
                    var rs = new ResponseViewModel<string>
                    {
                        Message = $@"Message: {System.Net.HttpStatusCode.OK}",
                        Data = new List<string>()
                    };
                    return rs;
                }
            }
            catch (Exception e)
            {
                return new ResponseViewModel<string>
                {
                    Message = $@"Erro: {e.Message }",
                    Data = new List<string>()
                };
            }

        }
    }
}