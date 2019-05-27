<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContraCambio.aspx.cs" Inherits="CinesAquiMismoWeb.ContraCambio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1140px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1" style="background-position: -50px; background-image: url('img/contra.jpg')">
            <asp:Label ID="Label1" runat="server" Text="Usuario:" ForeColor="Yellow"></asp:Label>
            <asp:TextBox ID="txtU" runat="server" Enabled="False" Width="122px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Antigua Contraseña:" ForeColor="Yellow"></asp:Label>
            <asp:TextBox ID="txtContraA" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContraA" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtContraA" ErrorMessage="Esta no es la contraseña antigua." ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nueva Contraseña:" ForeColor="Yellow"></asp:Label>
            <asp:TextBox ID="txtContraN" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContraN" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnCambiar" runat="server" OnClick="btnCambiar_Click" Text="Cambiar" BorderColor="#FF9900" ForeColor="#CC3300" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
