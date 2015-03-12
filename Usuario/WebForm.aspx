<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="UsuarioApp.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Indique un nombre de usuario"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br />
    
    </div>
        <asp:Button ID="botonCreaUsuario" runat="server" OnClick="Button1_Click" Text="Crear" />
        <br />
        <br />
        <asp:Label ID="lblTodos" runat="server"></asp:Label>
    </form>
</body>
</html>
