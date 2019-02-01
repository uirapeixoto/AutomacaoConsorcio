using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace Automacao.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TesteController : Controller
    {
        [HttpPost("[action]")]
        public HttpResponseMessage SeuNome(string request)
        {
            var response  = new HttpResponseMessage(HttpStatusCode.Created);

            return response;
        }
    }
}