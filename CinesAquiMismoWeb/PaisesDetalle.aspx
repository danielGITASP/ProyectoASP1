<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaisesDetalle.aspx.cs" Inherits="CinesAquiMismoWeb.PaisesDetalle" MasterPageFile="~/PaginaMaestraDetalle.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script>
        function pop() {
            function reloadOpener() {
              if (top.opener && !top.opener.closed) {
                  try {
                      window.opener.location = "Paises.aspx"; 
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
     </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <form id="form1" runat="server" style="background-image: url('img/steampunk-rotation-of-the-gears_rtup4fcl__F0000.png')">
        <div>
            <h1 style="color: #b200ff">PAISES DETALLE </h1>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:DropDownList ID="ddlNombrePais" runat="server">
            <asp:ListItem>España</asp:ListItem>
            <asp:ListItem>Francia</asp:ListItem>
            <asp:ListItem>México</asp:ListItem>
            <asp:ListItem>Londres</asp:ListItem>
            <asp:ListItem>Australia</asp:ListItem>
            <asp:ListItem>Alemania</asp:ListItem>
            <asp:ListItem>Argentina</asp:ListItem>
            <asp:ListItem>Bélgica</asp:ListItem>
            <asp:ListItem>Rusia</asp:ListItem>
            <asp:ListItem>China</asp:ListItem>
            <asp:ListItem>Japón</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNombrePais" ErrorMessage="Falta Nombre." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Pelicula:"></asp:Label>
        <asp:DropDownList ID="ddlPeli" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPeli" ErrorMessage="Falta la pelicula." ForeColor="#CC0000">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Número de visitas:"></asp:Label>
        <asp:TextBox ID="txtNumVisitas" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumVisitas" ErrorMessage="Falta el Numero de Visitas de la Pelicula." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Valoración:"></asp:Label>
        <asp:DropDownList ID="ddlValor" runat="server">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlValor" ErrorMessage="Falta el Numero de Visitas de la Pelicula." ForeColor="Red">*</asp:RequiredFieldValidator>
        <p>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" OnClientClick="pop()" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CausesValidation="False" />
        </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="White" BorderColor="#CC0000" BorderStyle="Solid" ForeColor="Red" />
    </form>
</asp:Content>
