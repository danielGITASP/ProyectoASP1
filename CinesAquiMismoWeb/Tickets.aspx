<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="CinesAquiMismoWeb.Tickets" EnableEventValidation = "false" MasterPageFile="~/PaginaMaestra.Master"%>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>       
    <link href="Estilos/Tickets.css" rel="stylesheet" />
 </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" align="center" runat="server" style="background-image: none; background-repeat: no-repeat">
        <div>
            <asp:Label ID="Label1" runat="server" BackColor="#FF0066" ForeColor="#660066" Text="Filtrar por Codigo:"></asp:Label>
            <asp:TextBox ID="txtCodigoF" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="btnBuscar" runat="server" BorderColor="Maroon" ForeColor="#993333" OnClick="btnBuscar_Click" Text="Buscar" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnExcel" runat="server" CssClass="mybtn" OnClick="btnExcel_Click" Text="Exportar a Excel" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPDF" runat="server" CssClass="mybtn" OnClick="btnPDF_Click" Text="Exportar a Word" />
            <br />
            <br />
        </div>
        <asp:GridView ID="dgvTickets" align="center" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnRowDeleting="dgvTickets_RowDeleting" OnSelectedIndexChanged="dgvTickets_SelectedIndexChanged" Font-Bold="True" Font-Size="X-Large" Width="851px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Edit" SelectText="@" ShowSelectButton="True" >
                <ControlStyle Height="40px" Width="40px" />
                <ItemStyle Width="5px" />
                </asp:CommandField>
                <asp:BoundField DataField="idTicket" HeaderText="idTicket" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="UsuarioId" HeaderText="UsuarioId" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" SelectText="X" ShowDeleteButton="True" >
                <ControlStyle Height="40px" Width="40px" />
                <ItemStyle Width="5px" />
                </asp:CommandField>
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
        <br />

        <asp:Button ID="btnPeliculas" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Peliculas" BorderColor="#663300" ForeColor="#996600" Height="42px" Font-Bold="True" Width="133px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCines" runat="server" PostBackUrl="~/Cines.aspx" Text="Cines" BorderColor="#663300" ForeColor="#996600" Height="42px" Font-Bold="True" Width="133px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/Usuarios.aspx" Text="Usuarios" BorderColor="#663300" ForeColor="#996600" Height="42px" Font-Bold="True" Width="133px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPaises" runat="server" PostBackUrl="~/Paises.aspx" Text="Paises" BorderColor="#663300" ForeColor="#996600" Height="42px" Font-Bold="True" Width="133px"  />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Volver" BorderColor="#663300" ForeColor="#996600" Height="42px" Font-Bold="True" Width="133px" />
        
        <br />
        <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Button ID="btnSi" runat="server" Text="Si" Visible="False" OnClick="btnSi_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNo" runat="server" Text="No" Visible="False" OnClick="btnNo_Click" />
    </form>
</asp:Content>
