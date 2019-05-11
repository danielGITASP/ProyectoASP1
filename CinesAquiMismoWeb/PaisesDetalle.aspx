<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaisesDetalle.aspx.cs" Inherits="CinesAquiMismoWeb.PaisesDetalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="color: #b200ff">PAISES DETALLE </h1>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Falta Nombre." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Pelicula:"></asp:Label>
        <asp:DropDownList ID="ddlPeli" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPeli" ErrorMessage="Falta la pelicula." ForeColor="#CC0000">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Número de visitas:"></asp:Label>
        <asp:TextBox ID="txtNumVisitas" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumVisitas" ErrorMessage="Falta el Numero de Visitas de la Pelicula." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Valoración:"></asp:Label>
        <asp:TextBox ID="txtValoracion" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtValoracion" ErrorMessage="Falta el Numero de Visitas de la Pelicula." ForeColor="Red">*</asp:RequiredFieldValidator>
        <p>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" OnClientClick="pop()" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="White" BorderColor="#CC0000" BorderStyle="Solid" ForeColor="Red" />
    </form>
</body>
</html>
