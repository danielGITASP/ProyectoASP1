<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContraOlvidada.aspx.cs" Inherits="CinesAquiMismoWeb.ContraOlvidada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 101px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1" style="background-position: -10px -66px; background-image: url('img/contra.jpg'); background-repeat: no-repeat;">
        <div>
                <asp:Label ID="Label1" runat="server" Text="Introduzca su email:" BackColor="#6600CC" ForeColor="Yellow"></asp:Label>
                 <asp:TextBox ID="txtEmail" runat="server" Width="308px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="No tiene formato email." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Enviar" BackColor="White" BorderColor="#660033" ForeColor="#660033" />
        <asp:Label ID="lblCorreo" runat="server" Text="Label" Visible="False"></asp:Label>
    </form>
</body>
</html>
