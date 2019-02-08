using Automacao.Core.Helper;
using Automacao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Automacao.Core
{
    public class UiraLoginPage : IDisposable
    {

        public string Logar(string email, string senha)
        {
            try
            {
                //http://refactoringaspnet.blogspot.com/2010/04/using-htmlagilitypack-to-get-and-post.html
                BrowserSession b = new BrowserSession();

                var dados = new Dictionary<string, string>()
                    {
                        {"email", email},
                        {"passwd", senha},
                    };

                var result = b.SendDataToService("https://loja.uira.com.br/loja/index.php?controller=authentication&back=my-account", dados);
                return b.FileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Dispose()
        {
        }
    }
}
