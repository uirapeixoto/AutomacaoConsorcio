using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Automacao.Domain.Model.ASC
{
    [XmlRoot(ElementName = "consorcios")]
    public class Consorcios
    {
        [XmlElement(ElementName = "consorcio")]
        public Consorcio Consorcio { get; set; }
    }
}
