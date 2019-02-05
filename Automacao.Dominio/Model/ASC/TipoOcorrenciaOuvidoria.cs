using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Automacao.Domain.Model.ASC
{
    [Serializable()]
    [DataContract]
    public class TipoOcorrenciaOuvidoria
    {
        [DataMember] public int iCod { get; set; }
        [DataMember] public string sDescricao { get; set; }
    }
}
