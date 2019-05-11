<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cines.aspx.cs" Theme="TemaC" Inherits="CinesAquiMismoWeb.Cines" MasterPageFile="~/PaginaMaestra.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

 </asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="background-image: url('img/cineadmin.jpg'); background-repeat: repeat-y" class="auto-style1">
        <div>           
            <asp:Label ID="Label1" runat="server" Text="Label">Filtrado por Zona:</asp:Label>
            <asp:DropDownList ID="ddlZonas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlZonas_SelectedIndexChanged">
                <asp:ListItem>Todas las zonas</asp:ListItem>
                <asp:ListItem>Norte</asp:ListItem>
                <asp:ListItem>Sur</asp:ListItem>
                <asp:ListItem>Oeste</asp:ListItem>
                <asp:ListItem>Este</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </div>
        <asp:GridView ID="dgvCines" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDeleting="dgvCines_RowDeleting" OnSelectedIndexChanged="dgvCines_SelectedIndexChanged" Font-Bold="True" Font-Size="X-Large" OnRowDataBound="dgvCines_RowDataBound">
            <Columns>
                <asp:CommandField ButtonType="Button" EditText="Edit" ShowSelectButton="True" SelectText="@" HeaderText="Edit" NewImageUrl="Edit" />
                <asp:BoundField DataField="IdCine" HeaderText="IdCine" />
                <asp:BoundField DataField="Nombre Cine" HeaderText="Nombre Cine" />
                <asp:BoundField DataField="Zona" HeaderText="Zona" />
                <asp:CommandField ButtonType="Button" DeleteText="X" ShowDeleteButton="True" HeaderText="Del" >
                <ControlStyle BackColor="Red" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btnAñadir" runat="server" OnClick="btnAñadir_Click" Text="Añadir" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnPeliculas" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Peliculas" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/Usuarios.aspx" Text="Usuarios" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnPaises" runat="server" PostBackUrl="~/Paises.aspx" Text="Paises" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnTickets" runat="server" PostBackUrl="~/Tickets.aspx" Text="Tickets" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Volver" />
        
        <p>
            <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" />
        </p>
    </form>
 </asp:Content>


