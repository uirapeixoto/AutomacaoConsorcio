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
                    b.Get("https://loja.uira.com.br/loja/index.php?controller=authentication&back=my-account");
                    b.FormElements["email"] = email;
                    b.FormElements["passwd"] = senha;
                    string response = b.Post("https://loja.uira.com.br/loja/index.php?controller=authentication&back=my-account");

                    return response;
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
