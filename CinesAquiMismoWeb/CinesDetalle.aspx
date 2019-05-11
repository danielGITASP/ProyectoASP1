<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CinesDetalle.aspx.cs" Theme="TemaDetalle" Inherits="CinesAquiMismoWeb.CinesDetalle" MasterPageFile="~/PaginaMaestraDetalle.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script>
        function pop() {
            function reloadOpener() {
              if (top.opener && !top.opener.closed) {
                  try {
                      window.opener.location = "Cines.aspx"; 
                }
                catch(e) {
                }
              }
            }
            window.onunload=function() {
              reloadOpener();
            }
         }

         function validarZona() {
             if (ddlZonasD.SelectedIndex > 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
         }



    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="background-image: url('img/steampunk-rotation-of-the-gears_rtup4fcl__F0000.png')">
        <div>
            <h1 style="color: #FF6600">CINES DETALLE
            </h1>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Label">Nombre:</asp:Label>&nbsp;<asp:TextBox ID="txtNombreCine" runat="server" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreCine" ErrorMessage="Falta Nombre." ForeColor="Red">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label">Zona:</asp:Label>&nbsp;<asp:DropDownList ID="ddlZonasD" runat="server">
                <asp:ListItem>Norte</asp:ListItem>
                <asp:ListItem>Sur</asp:ListItem>
                <asp:ListItem>Este</asp:ListItem>
                <asp:ListItem>Oeste</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlZonasD" ErrorMessage="Falta Zona." ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Debe elegir una Zona" ForeColor="Red" OnServerValidate="CustomValidatorCBCine_ServerValidate" ControlToValidate="ddlZonasD" ClientValidationFunction="validarZona"></asp:CustomValidator>
        </p>
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" OnClientClick="pop()" Text="Aceptar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CausesValidation="False" OnClick="btnVolver_Click" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="White" BorderStyle="Solid" ForeColor="#CC0000" Width="309px" />
    </form>
</asp:Content>
