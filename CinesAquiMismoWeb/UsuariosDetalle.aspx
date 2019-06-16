<%@ Page Language="C#" AutoEventWireup="true" Theme="TemaDetalle" CodeBehind="UsuariosDetalle.aspx.cs" Inherits="CinesAquiMismoWeb.UsuariosDetalle" MasterPageFile="~/PaginaMaestraDetalle.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script>
        function pop() {
            function reloadOpener() {
              if (top.opener && !top.opener.closed) {
                  try {
                      window.opener.location = "Usuarios.aspx"; 
                }
                catch(e) {
                }
              }
            }
            window.onunload=function() {
              reloadOpener();
            }
        }


        function validarPermiso() {
            if (ddlAccesoD.SelectedIndex > 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
        }


        function validarMovil() {
            if(txtMovil.Text.Length != 9)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="background-image: url('img/steampunk-rotation-of-the-gears_rtup4fcl__F0000.png')">
        <div>
            <h1 style="color: #FF6600">USUARIOS DETALLE</h1>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Label">Nombre:</asp:Label>
            &nbsp;<asp:TextBox ID="txtNombre" runat="server" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Falta Nombre." ForeColor="Red">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Label">Alias:</asp:Label>&nbsp;<asp:TextBox ID="txtAlias" runat="server" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAlias" ErrorMessage="Falta Alias." ForeColor="Red">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Label">Login:</asp:Label> &nbsp;<asp:TextBox ID="txtLogin" runat="server" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLogin" ErrorMessage="Login" ForeColor="Red">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label">Acceso:</asp:Label>&nbsp;<asp:DropDownList ID="ddlAccesoD" runat="server">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Usuario</asp:ListItem>
                <asp:ListItem>SinRegistro</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAccesoD" ErrorMessage="Acceso" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="ddlAccesoD" ErrorMessage="Debe elegir un acceso." ForeColor="Red" OnServerValidate="CustomValidatorCBAcceso_ServerValidate" ClientValidationFunction="validarPermiso" ValidateEmptyText="True"></asp:CustomValidator>
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Movil:"></asp:Label>
            <asp:TextBox ID="txtMovil" runat="server" CausesValidation="True" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMovil" ErrorMessage="Falta Movil." ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtMovil" ErrorMessage="Debe tener 9 cifras." ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate" ValidateEmptyText="True" ClientValidationFunction="validarMovil"></asp:CustomValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtMovil" ErrorMessage="Debe empezar por 6 o 7." ForeColor="Red" MaximumValue="799999999" MinimumValue="600000000"></asp:RangeValidator>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail" ErrorMessage="Falta Email." ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email incorrecto." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>&nbsp;<asp:TextBox ID="txtPass" runat="server" MaxLength="15"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="Falta Contraseña." ForeColor="Red">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="Repetir contraseña: "></asp:Label>
            <asp:TextBox ID="txtRContra" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPass" ControlToValidate="txtRContra" ErrorMessage="Contraseñas distintas." ForeColor="Red">*</asp:CompareValidator>
        </p>
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" OnClientClick="pop()" Text="Aceptar" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CausesValidation="False" OnClick="btnVolver_Click" />
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="White" BorderStyle="Solid" ForeColor="#CC0000" Width="309px" />
    </form>
</asp:Content>