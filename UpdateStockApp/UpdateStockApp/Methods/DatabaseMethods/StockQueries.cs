using System;
using System.Collections.Generic;
using System.Data;
using UpdateStockApp.Methods.XMLMethods;

namespace UpdateStockApp.Methods.DatabaseMethods
{
    public class StockQueries
    {
        #region CategoryQueries

        public static List<string> GetAllCategoryNo()
        {
            List<string> categoriNoList = new List<string>();

            var kategoriNoFromDb = ExecuteMethods.ExecuteReader("SELECT KategoriNo FROM tblKategori");

            foreach (DataRow row in kategoriNoFromDb.Rows)
            {
                categoriNoList.Add(row["KategoriNo"].ToString());
            }

            return categoriNoList;
        }

        public static int InsertCategory(string no, string text, string path)
        {    
            string query= "INSERT INTO [dbo].[tblKategori] ([KategoriNo],[KategoriText],[CreatedDate],[DownloadedFile]) VALUES (@no,@text,@date,@file)";

            string[] parametre = { "@no", "@text", "@date", "@file" };

            string[] veri = { no, text, DateTime.Now.ToString(), path };

            return ExecuteMethods.ExecuteNonQuery(query, veri, parametre);
        }

        public static int UpdateCategory(string no, string text)
        {
            string query= "UPDATE [dbo].[tblKategori] SET [KategoriText] ='" + text + "' WHERE [KategoriNo]='" + no + "'";
            return ExecuteMethods.ExecuteNonQuery(query);
        }

        public static int Category(string path)
        {
            int countCategory = 0;
            foreach (var item in XMLDeserialize.UrunDeserialize(path))
            {
                if (GetAllCategoryNo().Contains(item.Kategori.No))
                {
                    countCategory += UpdateCategory(item.Kategori.No, item.Kategori.Text);
                }
                else
                {
                    countCategory += InsertCategory(item.Kategori.No, item.Kategori.Text,path);
                }
            }
            return countCategory;
        }

        #endregion

        #region ProductQueries
        public static int InsertProduct(string urunID, string urunAdi, string kod, string fiyat, string listFiyat, string kdvOran, string marka, string aciklama, string imageName, string kategoriNo, string renk,string path)
        {
            string query = "INSERT INTO [dbo].[tblUrun]([UrunID],[UrunAdi],[Kod],[Fiyat],[ListFiyat],[KdvOran],[Marka],[Aciklama],[ImageName],[KategoriNo],[Renk],[CreatedDate],[DownloadedFile]) VALUES(@urunID,@urunAdi,@kod,@fiyat,@listFiyat,@kdvOran,@marka,@aciklama,@imageName,@kategoriNo,@renk,@date,@file)";

            string[] parametre = { "@urunID", "@urunAdi", "@kod", "@fiyat", "@listFiyat", "@kdvOran", "@marka", "@aciklama", "@imageName", "@kategoriNo", "@renk", "@date", "@file" };

            string[] veri = { urunID, urunAdi, kod, fiyat, listFiyat, kdvOran, marka, aciklama, imageName, kategoriNo, renk , DateTime.Now.ToString(), path };

            return ExecuteMethods.ExecuteNonQuery(query, veri, parametre);
        }

        public static int UpdateProduct(string urunID, string urunAdi, string kod, string fiyat, string listFiyat, string kdvOran, string marka, string aciklama, string imageName, string renk)
        {
            string query = "UPDATE [dbo].[tblUrun] SET [UrunAdi] =@urunAdi,[Kod]=@kod,[Fiyat] =@fiyat,[ListFiyat]=@listFiyat,[KdvOran] =@kdvOran,[Marka] =@marka,[Aciklama]=@aciklama,[ImageName] =@imageName,[Renk] =@renk WHERE UrunID=@urunID";

            string[] parametre = { "@urunID", "@urunAdi", "@kod", "@fiyat", "@listFiyat", "@kdvOran", "@marka", "@aciklama", "@imageName", "@renk" };

            string[] veri = { urunID, urunAdi, kod, fiyat, listFiyat, kdvOran, marka, aciklama, imageName, renk };

            return ExecuteMethods.ExecuteNonQuery(query, veri, parametre);
        }

        public static List<string> GetAllProductID()
        {
            List<string> productIDList = new List<string>();

            var productIDFromDb = ExecuteMethods.ExecuteReader("select UrunID from tblUrun");

            foreach (DataRow row in productIDFromDb.Rows)
            {
                productIDList.Add(row["UrunID"].ToString());
            }

            return productIDList;
        }

        public static int Product(string path)
        {
            int countProduct = 0;
            foreach (var item in XMLDeserialize.UrunDeserialize(path))
            {
                if (GetAllProductID().Contains(item.UrunID))
                {
                    countProduct += UpdateProduct(item.UrunID, item.UrunAdi, item.Kod, item.Fiyat, item.ListFiyat, item.KdvOran, item.Marka, item.Aciklama, item.ImageName, item.Renk);
                }
                else
                {
                    countProduct += InsertProduct(item.UrunID, item.UrunAdi, item.Kod, item.Fiyat, item.ListFiyat, item.KdvOran, item.Marka, item.Aciklama, item.ImageName, item.Kategori.No, item.Renk,path);
                }
            }
            return countProduct;
        }

        #endregion

        #region StockQueries
        public static List<string> GetAllBarcode()
        {
            List<string> barcodeList = new List<string>();

            var productIDFromDb = ExecuteMethods.ExecuteReader("select Barkod from tblStok");

            foreach (DataRow row in productIDFromDb.Rows)
            {
                barcodeList.Add(row["Barkod"].ToString());
            }

            return barcodeList;
        }

        public static int InsertStock(string label, string barkod, string ozellik, string UrunID, string path)
        {
            string query = "INSERT INTO [dbo].[tblStok]([label],[Barkod],[Ozellik],[UrunID],[CreatedDate],[DownloadedFile]) VALUES(@label,@barkod,@ozellik,@UrunID,@date,@file)";

            string[] parametre = { "@label", "@barkod", "@ozellik", "@UrunID","@date", "@file" };

            string[] veri = { label, barkod, ozellik, UrunID, DateTime.Now.ToString(), path };

            return ExecuteMethods.ExecuteNonQuery(query, veri, parametre);
        }

        public static int UpdateStock(string ozellik, string barkod)
        {
            string query = "UPDATE [dbo].[tblStok] SET [Ozellik] =@ozellik  WHERE Barkod =@barkod";

            string[] parametre = { "@barkod", "@ozellik" };

            string[] veri = { barkod, ozellik };

            return ExecuteMethods.ExecuteNonQuery(query, veri, parametre);
        }

        public static int Stock(string path)
        {
            int countStock = 0;
            foreach (var item in XMLDeserialize.UrunDeserialize(path))
            {
                var stockFromXML = item.Stoklar;
                foreach (var s in stockFromXML)
                {
                    if (GetAllBarcode().Contains(s.Barkod))
                    {
                        countStock += UpdateStock(s.Ozellik, s.Barkod);
                    }
                    else
                    {
                        countStock += InsertStock(s.Label, s.Barkod, s.Ozellik, item.UrunID,path);
                    }
                }
            }
            return countStock;
        }

        #endregion


      



    }
}