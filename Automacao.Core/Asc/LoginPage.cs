using Automacao.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automacao.Core.Asc
{
    public class LoginPage : IDisposable
    {
        public bool Authenticated { get; private set; }

        public bool Logar(string User, string Pass)
        {
            Authenticated = false;
            try
            {
                using(var bs = new BrowserSession())
                {
                    bs.UseCredentials = true;
                    bs.Credentials = new System.Net.NetworkCredential(User, Pass);
                    var loged = bs.Get("http://dynamics.caixaseguros.intranet:5555/CRMCAD/main.aspx");
                    if (loged.Contains("Importante:"))
                        Authenticated = true;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao tentar autenticar usuário " + User + " " + ex.Message);
            }
            return Authenticated;

        }

        public void Dispose()
        {
        }
    }
}
