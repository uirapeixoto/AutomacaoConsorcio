﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Automacao.Domain.Model.ASC
{
    [XmlRoot(ElementName = "certificados")]
    public class CertificadosDC
    {
        [XmlElement(ElementName = "certificado")]
        public string Certificado { get; set; }
        public Certificados P()
        {
            Certificados s = new Certificados
            {
                Certificado = this.Certificado,
            };
            return s;
        }
    }
}
