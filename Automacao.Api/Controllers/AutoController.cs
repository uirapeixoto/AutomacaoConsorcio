using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automacao.Api.ViewModel;
using Automacao.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automacao.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AutoController : ControllerBase
    {
        // GET: api/Auto
        [HttpGet]
        public async Task<ResponseViewModel<CarViewModel>> Get()
        {
            try
            {
                using (var robo = new AutomobileIndexPage())
                {
                    var result = await robo.GetCars();

                    var response = new ResponseViewModel<CarViewModel>();
                    response.Message = "";
                    response.Data = result.Select(x => new CarViewModel
                    {
                        Model = x.Model,
                        Price = x.Price,
                        Link = x.Link,
                        ImageUrl = x.ImageUrl
                    }).ToList();

                    return  response;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel<CarViewModel> {
                    Message = ex.Message,
                    Data = new List<CarViewModel>()
                };
            }
        }

        // GET: api/Auto/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auto
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Auto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
