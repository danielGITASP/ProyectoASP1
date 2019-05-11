<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="CinesAquiMismoWeb.Tickets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="dgvTickets" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnRowDeleting="dgvTickets_RowDeleting" OnSelectedIndexChanged="dgvTickets_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Edit" SelectText="@" ShowSelectButton="True" />
                <asp:BoundField DataField="idTicket" HeaderText="idTicket" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="UsuarioId" HeaderText="UsuarioId" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" SelectText="X" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:Button ID="btnPeliculas" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Peliculas" />
        <asp:Button ID="btnCines" runat="server" PostBackUrl="~/Cines.aspx" Text="Cines" />
        <asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/Usuarios.aspx" Text="Usuarios" />
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Volver" />
        
        <br />
        <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Button ID="btnSi" runat="server" Text="Si" Visible="False" OnClick="btnSi_Click" />
        <asp:Button ID="btnNo" runat="server" Text="No" Visible="False" OnClick="btnNo_Click" />
    </form>
</body>
</html>
