using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using UpdateStockApp.Models;

namespace UpdateStockApp.Methods.XMLMethods
{
    public class XMLDeserialize
    {
       
        public static List<Urun> UrunDeserialize(string path)
        {
            List<Urun> urunListesi = new List<Urun>();
            Urunler urun = new Urunler();

            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(Urunler));
               
                WebClient client = new WebClient();

                string data = Encoding.Default.GetString(client.DownloadData(path));

                Stream reader = new MemoryStream(Encoding.Default.GetBytes(data));

                urun = (Urunler)xmlSer.Deserialize(reader);

                urunListesi = urun.Urun;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
            }

            return urunListesi;
        }
    }
}