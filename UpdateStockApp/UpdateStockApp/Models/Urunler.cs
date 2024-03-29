﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace UpdateStockApp.Models
{
    [XmlRoot(ElementName = "Urunler")]
    public class Urunler
    {
        [XmlElement(ElementName = "urun")]
        public List<Urun> Urun { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsd { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
    }
}