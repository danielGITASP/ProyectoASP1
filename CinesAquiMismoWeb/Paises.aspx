<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paises.aspx.cs" Inherits="CinesAquiMismoWeb.Paises" EnableEventValidation = "false" MasterPageFile="~/PaginaMaestra.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Paises.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" align="center" runat="server" style="background-image: none; background-repeat: no-repeat;">
        <div>
            <asp:Label ID="Label1" runat="server" BackColor="#6699FF" Text="Filtrado por Nombre:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlPaises" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaises_SelectedIndexChanged">
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnExcel" runat="server" CssClass="mybtn" OnClick="btnExcel_Click" Text="Exportar a Excel" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPDF" runat="server" CssClass="mybtn" OnClick="btnPDF_Click" Text="Exportar a Word" />
        </div>
        <asp:GridView ID="dgvPaises" align="center" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowDeleting="dgvPaises_RowDeleting" OnSelectedIndexChanged="dgvPaises_SelectedIndexChanged" Font-Bold="True" Font-Size="X-Large">
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
        <br />
        <asp:Button ID="btnAñadir" runat="server" OnClick="btnAñadir_Click" Text="Añadir" BorderColor="#FF5050" ForeColor="#CC0066" Height="30px" Width="88px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPeliculas" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Peliculas" BorderColor="#FF5050" CssClass="auto-style1" ForeColor="#CC0066" Height="30px" Width="88px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCines" runat="server" PostBackUrl="~/Cines.aspx" Text="Cines" BorderColor="#FF5050" ForeColor="#CC0066" Height="30px" Width="83px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/Usuarios.aspx" Text="Usuarios" BorderColor="#FF5050" ForeColor="#CC0066" Height="30px" Width="95px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnTicket" runat="server" PostBackUrl="~/Tickets.aspx" Text="Tickets" BorderColor="#FF5050" ForeColor="#FF5050" Height="30px" Width="78px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Volver" BorderColor="#FF5050" ForeColor="#FF5050" Height="30px" />
        
        <br />
        <br />
        <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False" BackColor="#6699FF"></asp:Label>
        <asp:Button ID="btnSi" runat="server" Text="Si" Visible="False" OnClick="btnSi_Click" />
        <asp:Button ID="btnNo" runat="server" Text="No" Visible="False" OnClick="btnNo_Click" />
    </form>
</asp:Content>