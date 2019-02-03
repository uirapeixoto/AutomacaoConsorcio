using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automacao.Api.ViewModel
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public string Link { get; set; }
        public string ImageUrl { get; set; }
    }
}
