<%@ Page Language="C#" AutoEventWireup="true" Theme="TemaPD" CodeBehind="ComprarTicket.aspx.cs" Inherits="CinesAquiMismoWeb.ComprarTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function validarTarjeta() {
            if (ddlTipoTarjeta.SelectedIndex != 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        function validarFecha() {
            if(Convert.ToDateTime(txtFecha.Text) > Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"))){
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }


    </script>
    </head>
<body>
    <form id="form1" runat="server" style="background-image: url('img/taquillas-660x374.jpg'); background-repeat: repeat-x">
    <div>
    
       <asp:Label ID="Label1" runat="server" Text="Label"> Nº de Tarjeta:</asp:Label>
        <asp:TextBox ID="txtNTarjeta" runat="server" MaskType="None" Mask="0000-0000-0000-0000" AutoPostBack="True" MaxLength="16" TextMode="Number" Width="151px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNTarjeta" ErrorMessage="*" ForeColor="Red" BackColor="White"></asp:RequiredFieldValidator>
&nbsp;&nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtNTarjeta" ErrorMessage="Debe ser un número de 16 dígitos." ForeColor="Red" OnServerValidate="CustomValidatorTarjeta_ServerValidate" BackColor="White"></asp:CustomValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label5" runat="server" Text="Label">Tu código:</asp:Label><asp:TextBox ID="txtVCodigo" runat="server" Height="16px" ReadOnly="True" Width="159px"></asp:TextBox>
    
    </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Label">Tipo de Tarjeta:</asp:Label> <asp:DropDownList ID="ddlTipoTarjeta" runat="server">
                <asp:ListItem>VISA</asp:ListItem>
                <asp:ListItem>MasterCard</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTipoTarjeta" ErrorMessage="*" ForeColor="Red" BackColor="White"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" BackColor="White" ControlToValidate="ddlTipoTarjeta" ErrorMessage="Debe elegir un tipo de tarjeta." ForeColor="Red" OnServerValidate="CustomValidatorDdlTipo_ServerValidate" ClientValidationFunction="validarTarjeta" Display="Dynamic"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Label"> Código de Seguridad:</asp:Label><asp:TextBox ID="txtCodigo" runat="server" MaxLength="3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCodigo" ErrorMessage="*" ForeColor="Red" BackColor="White"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Debe ser un numero de 3 cifras." ForeColor="Red" MaximumValue="999" MinimumValue="100" Type="Integer" BackColor="White"></asp:RangeValidator>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Label">Fecha de Caducidad:</asp:Label> <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFecha" ErrorMessage="*" ForeColor="Red" BackColor="White"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator3" runat="server" BackColor="White" ErrorMessage="La fecha no puede ser anterior o igual al dia de hoy." ForeColor="Red" OnServerValidate="CustomValidator3_ServerValidate" ClientValidationFunction="validarFecha" ControlToValidate="txtFecha" Display="Dynamic"></asp:CustomValidator>
        </p>
        <asp:Button ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" Text="Generar" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/PeliculasUsuario.aspx" Text="Volver" CausesValidation="False" OnClick="btnVolver_Click" />
    </form>
</body>
</html>
