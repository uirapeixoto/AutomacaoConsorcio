using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automacao.Api.ViewModel
{
    public class ResponseViewModel<T> where T: class
    {
        public  string Message { get; set; }
        public string Anexo { get; set; }
        public List<T> Data { get; set; }
        public ResponseViewModel()
        {
            Data = new List<T>();
        }
    }
}
