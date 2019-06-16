<%@ Page Language="C#" AutoEventWireup="true" Theme="TemaPU" CodeBehind="PeliculasUsuario.aspx.cs" Inherits="CinesAquiMismoWeb.PeliculasUsuario" %>
<link href="Estilos/Cartelera.css" rel="stylesheet" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" align="center" runat="server" style="background-image: none; background-repeat: no-repeat">
    <div>
    <h1>
        <asp:Label ID="Label2" runat="server" Text="Cartelera" Font-Bold="True" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="True" ForeColor="White"></asp:Label>
    </h1>
    </div>
        <p>
            &nbsp;<asp:Label ID="Label1" runat="server" Text="Label">Filtrado por nombre de Cine:</asp:Label>
            <asp:DropDownList ID="ddlNombreCine" runat="server" OnSelectedIndexChanged="ddlNombreCine_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <asp:GridView ID="dgvUsuPelis" align="center" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="comprarTicket" Font-Bold="True" Font-Size="X-Large">
            <Columns>
                <asp:BoundField DataField="IdPelicula" HeaderText="IdPelicula" />
                <asp:BoundField DataField="NombreCine" HeaderText="NombreCine" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="CineId" HeaderText="CineId" />
                <asp:BoundField DataField="Zona" HeaderText="Zona" />
                <asp:ButtonField CommandName="comprarTicket" HeaderText="CompraTickets" Text="$$$$$$$$$$$$$" >
                <ControlStyle BackColor="Lime" BorderColor="#FF9933" />
                <ItemStyle BackColor="#FFCC00" />
                </asp:ButtonField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnCambiar" runat="server" BorderColor="Black" Font-Bold="True" OnClick="btnCambiar_Click" Text="Cambiar Contraseña" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Login.aspx" Text="Volver" BorderColor="Black" Font-Bold="True" />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
