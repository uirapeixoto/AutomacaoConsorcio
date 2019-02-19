using System;
using System.Collections.Generic;
using System.Text;

namespace Automacao.Core.Helper.Library
{
    public static class Util
    {
        public static string FormatCPFCNPJ(string cpfcnpj)
        {
            string _formatedString;
            string _cpfStringFormat = @"000\.000\.000\-00";
            string _cnpjStringFormt = @"00\.000\.000\/0000\-00";

            List<string> tags = new List<string>
            {
                "&#13;",
                "&#10;"
            };

            foreach (var str in tags)
                cpfcnpj = cpfcnpj.Replace(str, "");

            //Console.WriteLine($"{cpfcnpj}:{cpfcnpj.Length}");

            if ((int)cpfcnpj.Length > 11)
                _formatedString = Convert.ToUInt64(cpfcnpj).ToString(_cnpjStringFormt);
            else
                _formatedString = Convert.ToUInt64(cpfcnpj).ToString(_cpfStringFormat);

            return _formatedString;
        }
    }
}
