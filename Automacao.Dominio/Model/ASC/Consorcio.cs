using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Automacao.Domain.Model.ASC
{
    [Category("Consorcio")]
    [XmlRoot(ElementName = "consorcio")]
    public class Consorcio
    {
        [XmlAttribute(AttributeName = "grupo")]
        public string Grupo { get; set; }
        [XmlAttribute(AttributeName = "cota")]
        public string Cota { get; set; }
    }
}
