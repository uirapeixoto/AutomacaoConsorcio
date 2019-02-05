using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Automacao.Domain.Model.ASC
{
    [Serializable()]
    [DataContract]
    public class PessoaOuvidoria
    {
        [DataMember] public string sCpfCNPJ { get; set; }
        [DataMember] public string sNome { get; set; }
        [DataMember] public TipoPessoa kpTipoPessoa { get; set; }
    }
}
