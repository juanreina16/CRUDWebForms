<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="CRUDWebForms.Listar_productos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Productos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <h1>Inventario de Productos</h1>
            <p>Lista de productos disponibles en el inventario:</p>

            <!-- GridView con DataSourceID -->
           <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="True" />



            <!-- Configuración de SqlDataSource -->
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                               ConnectionString="<%$ ConnectionStrings:MiConexion %>"
                               SelectCommand="SELECT * FROM productos">
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
