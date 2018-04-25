using System;
using System.Xml.Serialization;

namespace UpdateStockApp.Models
{
    [XmlRoot(ElementName = "Stoklar")]
    public class Stoklar
    {
        [XmlElement(ElementName = "label")]
        public string Label { get; set; }

        [XmlElement(ElementName = "Barkod")]
        public string Barkod { get; set; }

        [XmlElement(ElementName = "Ozellik")]
        public string Ozellik { get; set; }

        public string UrunID { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public string DownloadedFile { get; set; }
    }
}