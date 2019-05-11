<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paises.aspx.cs" Inherits="CinesAquiMismoWeb.Paises" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Filtrado por Nombre:
            <asp:DropDownList ID="ddlPaises" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaises_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <asp:GridView ID="dgvPaises" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowDeleting="dgvPaises_RowDeleting" OnSelectedIndexChanged="dgvPaises_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Edit" SelectText="@" ShowSelectButton="True" />
                <asp:BoundField DataField="IdPais" HeaderText="IdPais" />
                <asp:BoundField DataField="NombrePais" HeaderText="NombrePais" />
                <asp:BoundField DataField="NumVisitas" HeaderText="NumVisitas" />
                <asp:BoundField DataField="PeliculaId" HeaderText="PeliculaId" />
                <asp:BoundField DataField="Pelicula" HeaderText="Pelicula" />
                <asp:BoundField DataField="Valoracion" HeaderText="Valoracion" />
                <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <asp:Button ID="btnAñadir" runat="server" OnClick="btnAñadir_Click" Text="Añadir" />
        <asp:Button ID="btnPeliculas" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Peliculas" />
        <asp:Button ID="btnCines" runat="server" PostBackUrl="~/Cines.aspx" Text="Cines" />
        <asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/Usuarios.aspx" Text="Usuarios" />
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Volver" />
        
        <br />
        <br />
        <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Button ID="btnSi" runat="server" Text="Si" Visible="False" OnClick="btnSi_Click" />
        <asp:Button ID="btnNo" runat="server" Text="No" Visible="False" OnClick="btnNo_Click" />
    </form>
</body>
</html>
