<%@ Page Language="C#" AutoEventWireup="true" Theme="TemaLogin" CodeBehind="Login.aspx.cs" Inherits="CinesAquiMismoWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 160px;
        }
        .auto-style2 {
            margin-left: 80px;
        }
        .auto-style3 {
            margin-top: 0px;
            margin-left: 0px;
        }
        .auto-style4 {
            margin-left: 187px;
        }
        .auto-style5 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-image: url('img/logincines.jpg'); background-repeat: repeat-y;">
        <div>
            <h1>
                <asp:Label ID="Label13" runat="server" Text="CinesAquiMismoWeb"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label8" runat="server" Text="LOGIN"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </h1>
            <p>
            <asp:Label ID="Label12" runat="server" EnableTheming="False" ForeColor="Red" Text="Usuario/Contraseña erronea." Visible="False"></asp:Label>
            </p>
        </div>
        <p class="auto-style1">
            
            <asp:Label ID="Label10" runat="server" Text="Label">Usuario:</asp:Label>
            <asp:TextBox ID="txtUsu" runat="server" Width="131px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUsu" ErrorMessage="Falta el Nombre de Login." ForeColor="Red" ValidationGroup="login">*</asp:RequiredFieldValidator>
        </p>
        <p class="auto-style2">
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label11" runat="server" Text="Label">Contraseña:</asp:Label>
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="131px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPass" ErrorMessage="Falta la Contraseña." ForeColor="Red" ValidationGroup="login">*</asp:RequiredFieldValidator>
        </p>
        <p class="auto-style2">
            
            <asp:Label ID="Label14" runat="server" Text="Recordar usuario:"></asp:Label>
            <asp:CheckBox ID="checkUsu" runat="server" />
            <a href="" onclick="window.open('ContraOlvidada.aspx','Recordar Contraseña','width=500,height=50,top=300,left=500,fullscreen=no,resizable=0');" style="background-color: #000000">¿Ha olvidado la contraseña?</a>
        </p>
        <p class="auto-style2">
            
            &nbsp;</p>
        <div class="auto-style1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAcceder" runat="server" Text="Acceder" OnClick="btnAcceder_Click" ValidationGroup="login" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Height="38px" Width="109px" />
        </div>
        <h1>
            <asp:Label ID="Label9" runat="server" Text="Label">REGISTRO</asp:Label>
            <asp:Button ID="btnMostrarR" runat="server" Text="Mostrar registro" OnClick="btnMostrarR_Click" CausesValidation="False" />

        </h1>
        <p class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Nombre:" Visible="False"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" Visible="False" ValidationGroup="registro" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Falta Nombre." ForeColor="Red" ValidationGroup="registro">*</asp:RequiredFieldValidator>
        </p>
        <p class="auto-style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Contraseña:" Visible="False"></asp:Label>
            <asp:TextBox ID="txtContra" runat="server" TextMode="Password" Visible="False" ValidationGroup="registro" MaxLength="15" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContra" ErrorMessage="Falta Contraseña." ForeColor="Red" ValidationGroup="registro">*</asp:RequiredFieldValidator>
        </p>
        <p class="auto-style5">
            &nbsp;<asp:Label ID="Label3" runat="server" Text="Repetir Contraseña:" Visible="False"></asp:Label>
            <asp:TextBox ID="txtContraR" runat="server" TextMode="Password" Visible="False" ValidationGroup="registro" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContraR" ErrorMessage="Falta Repetir Contraseña." ForeColor="Red" ValidationGroup="registro">*</asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p class="auto-style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Alias:" Visible="False"></asp:Label>
            <asp:TextBox ID="txtAlias" runat="server" Visible="False" ValidationGroup="registro" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAlias" ErrorMessage="Falta Alias." ForeColor="Red" ValidationGroup="registro">*</asp:RequiredFieldValidator>
        </p>
        <p class="auto-style5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Login:" Visible="False"></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server" Visible="False" ValidationGroup="registro" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLogin" ErrorMessage="Falta Login." ForeColor="Red" ValidationGroup="registro">*</asp:RequiredFieldValidator>
        </p>
        <div class="auto-style4">
            <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" Visible="False" style="margin-bottom:10px" OnClick="btnRegistro_Click" ValidationGroup="registro" CssClass="auto-style3" Font-Bold="True" Font-Size="Medium" Height="38px" />
        </div>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
        </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="White" BorderStyle="Solid" ForeColor="#CC0000" ValidationGroup="registro" Width="309px" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" BackColor="White" BorderStyle="Solid" ForeColor="#CC0000" ValidationGroup="login" Width="309px" />
    </form>
</body>
</html>
