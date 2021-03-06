﻿using Automacao.Api.ViewModel;
using Automacao.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Automacao.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TesteController : Controller
    {
        [HttpGet("[action]")]
        public async Task<IEnumerable<CarViewModel>> GetCars()
        {
            try
            {
                using (var robo = new AutomobileIndexPage())
                {
                    var result = await robo.GetCars();

                    return result.Select(x => new CarViewModel
                    {
                        Model = x.Model,
                        Price = x.Price,
                        Link = x.Link,
                        ImageUrl = x.ImageUrl
                    }).ToList(); ;
                }
            }
            catch (System.Exception ex)
            {
                return new List<CarViewModel>();
            }
        }
    }
}