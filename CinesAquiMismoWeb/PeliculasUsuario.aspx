<%@ Page Language="C#" AutoEventWireup="true" Theme="TemaPU" CodeBehind="PeliculasUsuario.aspx.cs" Inherits="CinesAquiMismoWeb.PeliculasUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-image: url('img/pelisusuario.jpg'); background-repeat: repeat-y">
    <div>
    <h1>Cartelera</h1>
    </div>
        <p>
            &nbsp;<asp:Label ID="Label1" runat="server" Text="Label">Filtrado por nombre de Cine:</asp:Label>
            <asp:DropDownList ID="ddlNombreCine" runat="server" OnSelectedIndexChanged="ddlNombreCine_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <asp:GridView ID="dgvUsuPelis" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="comprarTicket" Font-Bold="True" Font-Size="X-Large">
            <Columns>
                <asp:BoundField DataField="IdPelicula" HeaderText="IdPelicula" />
                <asp:BoundField DataField="Nombre Cine" HeaderText="Nombre Cine" />
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
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Login.aspx" Text="Volver" />
    </form>
</body>
</html>
