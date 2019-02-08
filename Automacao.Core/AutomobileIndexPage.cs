using Automacao.Domain.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automacao.Core
{
    public class AutomobileIndexPage : IDisposable
    {
        private IEnumerable<CarModel> Cars { get; set; }

        public async Task<IEnumerable<CarModel>> GetCars()
        {

            var url = "https://www.automobile.tn/neuf/bmw.3/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            return Cars = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("article_new_car article_last_modele"))
                .Select(x => new CarModel {
                    Model = x.Descendants("h2").FirstOrDefault().InnerText,
                    Price = x.Descendants("div").FirstOrDefault().InnerText,
                    Link = x.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value,
                    ImageUrl = x.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value,
                })
                .ToList();
        }


        public async Task<IEnumerable<CarModel>> GetCars2()
        {

            var url = "http://dynamics.caixaseguros.intranet:5555/CRMCAD/main.aspx#";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            return Cars = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("article_new_car article_last_modele"))
                .Select(x => new CarModel
                {
                    Model = x.Descendants("h2").FirstOrDefault().InnerText,
                    Price = x.Descendants("div").FirstOrDefault().InnerText,
                    Link = x.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value,
                    ImageUrl = x.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value,
                })
                .ToList();
        }

        public void Dispose()
        {
        }
    }
}
