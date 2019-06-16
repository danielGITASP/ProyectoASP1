<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContraCambioLink.aspx.cs" Inherits="CinesAquiMismoWeb.ContraCambioLink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 925px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1" style="background-image: url('img/contra.jpg')">
            <asp:Label ID="Label1" runat="server" Text="Usuario:" ForeColor="Yellow"></asp:Label>
            <asp:TextBox ID="txtU" runat="server" Enabled="False" Width="122px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Nueva Contraseña:" ForeColor="Yellow"></asp:Label>
            <asp:TextBox ID="txtContraN" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContraN" ErrorMessage="Falta contraseña." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Repetir contraseña:" ForeColor="Yellow"></asp:Label>
            <asp:TextBox ID="txtContraNR" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContraNR" ErrorMessage="Repita la contraseña." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContraN" ControlToValidate="txtContraNR" ErrorMessage="Las contraseñas son distintas." ForeColor="Red"></asp:CompareValidator>
            <br />
            <br />
            <asp:Button ID="btnCambiar" runat="server" OnClick="btnCambiar_Click" Text="Cambiar" BorderColor="#FF9900" ForeColor="#CC3300" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="labelMensaje" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
