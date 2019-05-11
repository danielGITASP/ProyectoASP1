<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeliculasDetalle.aspx.cs" theme="TemaDetalle" Inherits="CinesAquiMismoWeb.PeliculasDetalle" MasterPageFile="~/PaginaMaestraDetalle.Master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script>
        function pop() {
            function reloadOpener() {
              if (top.opener && !top.opener.closed) {
                  try {
                      window.opener.location = "Peliculas.aspx"; 
                }
                catch(e) {
                }
                window.close();
              }
            }
            window.onunload=function() {
              reloadOpener();
            }
        }
    </script>

    <style type="text/css">
        .auto-style1 {
            margin-left: 280px;
        }
    </style>

 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <form id="form1" runat="server" style="background-image: url('img/steampunk-rotation-of-the-gears_rtup4fcl__F0000.png')">
        <div>
            <h1 style="color: #FF6600">PELICULAS EN DETALLE</h1>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label">Titulo:</asp:Label>
&nbsp;<asp:TextBox ID="txtTitulo" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Falta el Titulo." ForeColor="Red">*</asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Label">Precio:</asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server" MaxLength="5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Falta el Precio." ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Debe ser un numero entre 1 y 100" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Double"></asp:RangeValidator>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Label">Cine:</asp:Label>&nbsp;
            <asp:DropDownList ID="ddlCinesDetalle" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <asp:CustomValidator ID="CustomDddlCine" runat="server" ControlToValidate="ddlCinesDetalle"  
                 ErrorMessage="Debe elegir un cine." ForeColor="Red" OnServerValidate="CustomValidatorDdlCine_ServerValidate"></asp:CustomValidator>
        </p>
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" OnClientClick="pop()"  Text="Aceptar"  />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CausesValidation="False" OnClick="btnVolver_Click"  />
        <div class="auto-style1">
        </div>
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="White" BorderStyle="Solid" ForeColor="#CC0000" Width="309px" />
    </form>
</asp:Content>
