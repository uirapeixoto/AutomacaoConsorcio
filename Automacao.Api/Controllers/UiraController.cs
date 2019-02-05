using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Automacao.Api.ViewModel;
using Automacao.Core;
using Microsoft.AspNetCore.Mvc;

namespace Automacao.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UiraController : Controller
    {
        [HttpPost("[action]")]
        public string Login([FromBody] UsuarioLoginViewModel usuario)
        {
            try
            {
                using (var page = new UiraLoginPage())
                {
                    var result = page.Logar(usuario.Email, usuario.Senha);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return string.Format("Message:{0}, StatusCode:{1}", ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}