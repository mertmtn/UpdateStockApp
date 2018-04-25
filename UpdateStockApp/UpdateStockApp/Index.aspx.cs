using System;
using UpdateStockApp.Methods.DatabaseMethods;

namespace UpdateStockApp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void btnUpdate_Click(object sender, EventArgs e)
        {            
            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
            {                
                var countCategory = StockQueries.Category(txtUrl.Text);
                var countProduct = StockQueries.Product(txtUrl.Text);
                var countStock = StockQueries.Stock(txtUrl.Text);
                
                if (countCategory > 0 && countProduct > 0 && countStock > 0)
                {
                    lblDurum.Text = string.Empty;
                    Response.Write("<script>alert('Ürün stokları bilgisi başarıyla eklenmiştir');</script>");
                    Backup.CreateBackUpDirectory();
                }
            }
            else
            {
                lblDurum.Text = "Lütfen geçerli bir URL giriniz...";
            }  
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtUrl.Text = string.Empty;
        }
    }
}