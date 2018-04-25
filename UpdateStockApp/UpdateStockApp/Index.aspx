<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UpdateStockApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style/bootstrap.min.css" rel="stylesheet" />
    <link href="Style/main.css" rel="stylesheet" />
    <title>Stok Güncelleme Uygulaması</title>
</head>
<body >
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1 class="display-4">Tedarikçi Bazında Stok Güncelleme Uygulaması</h1>
            </div>
            <br />
            <div class="row">

                <div class="col-md-4">
                </div>
                <div class="col-md-4">

                    <div>
                        Url Giriniz
                        <br />
                        <asp:TextBox ID="txtUrl" class="form-control" runat="server"></asp:TextBox>
                        <br />   
                        <asp:Button Text="Temizle" runat="server" ID="btnClear" OnClick="btnClear_Click" class="btn btn-danger btn-block"/>                     
                        <asp:Button Text="Stokları Güncelle" runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" class="btn btn-primary btn-block" />
                        <br />
                        <asp:Label ID="lblDurum" runat="server" />
                    </div>

                </div>
                <div class="col-md-4">
                </div>
            </div>
            <footer>
                &copy; Mert Metin - 2018
            </footer>
        </div>

    </form>

</body>
</html>
