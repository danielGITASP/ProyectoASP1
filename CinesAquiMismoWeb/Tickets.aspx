<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="CinesAquiMismoWeb.Tickets" MasterPageFile="~/PaginaMaestra.Master"%>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>       
 </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="background-image: url('img/tickets.jpg'); background-repeat: repeat-y">
        <div>
            <asp:Label ID="Label1" runat="server" BackColor="#FF0066" ForeColor="#660066" Text="Filtrar por Codigo:"></asp:Label>
            <asp:TextBox ID="txtCodigoF" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="btnBuscar" runat="server" BorderColor="Maroon" ForeColor="#993333" OnClick="btnBuscar_Click" Text="Buscar" />
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
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCines" runat="server" PostBackUrl="~/Cines.aspx" Text="Cines" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/Usuarios.aspx" Text="Usuarios" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPaises" runat="server" PostBackUrl="~/Paises.aspx" Text="Paises" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Volver" />
        
        <br />
        <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Button ID="btnSi" runat="server" Text="Si" Visible="False" OnClick="btnSi_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNo" runat="server" Text="No" Visible="False" OnClick="btnNo_Click" />
    </form>
</asp:Content>
