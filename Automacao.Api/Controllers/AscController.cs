using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automacao.Api.ViewModel;
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
                var result = new ResponseViewModel<UsuarioLoginViewModel>();
                return new ResponseViewModel<UsuarioLoginViewModel>
                {
                    Message = $@"HttpStatusCod: {System.Net.HttpStatusCode.Created}",
                    Data = new List<UsuarioLoginViewModel> { usuario }
                };
            }
            catch (Exception e)
            {
                return new ResponseViewModel<UsuarioLoginViewModel>
                {
                     Message = $@"HttpStatusCod: {System.Net.HttpStatusCode.BadRequest}"
                }
                    ;
            }
            
             
        }
    }
}