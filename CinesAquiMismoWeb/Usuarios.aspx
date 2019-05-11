<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Theme="TemaU" Inherits="CinesAquiMismoWeb.Usuarios" MasterPageFile="~/PaginaMaestra.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="background-image: url('img/usuadmin.jpg'); background-repeat: repeat">     
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label">Filtrado por Tipo Acceso:</asp:Label>
            <asp:DropDownList ID="ddlTipoAccesos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoAccesos_SelectedIndexChanged">
                <asp:ListItem>Todos los Accesos</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Usuario</asp:ListItem>
                <asp:ListItem>SinRegistro</asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <asp:GridView ID="dgvUsuarios" runat="server" CurrentSortField="IdUsuario" CurrentSortDirection="ASC" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvUsuarios_RowDeleting"  OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" AllowSorting="True" Font-Bold="True" Font-Size="X-Large">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Edit" SelectText="@" ShowSelectButton="True" />
                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Password" HeaderText="Password" />
                <asp:BoundField DataField="Alias" HeaderText="Alias" />
                <asp:BoundField DataField="Login" HeaderText="Login" />
                <asp:BoundField DataField="Acceso" HeaderText="Acceso" />
                <asp:BoundField DataField="TipoAcceso" HeaderText="TipoAcceso" />
                <asp:BoundField DataField="Movil" HeaderText="Movil" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" SelectText="X" ShowDeleteButton="True" >
                <ControlStyle BackColor="Red" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnAñadir" runat="server" OnClick="btnAñadir_Click" Text="Añadir" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnPeliculas" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Peliculas" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCines" runat="server" PostBackUrl="~/Cines.aspx" Text="Cines" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Peliculas.aspx" Text="Volver" />
        <p>
            <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Visible="False" />
            <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" />
    </form>
 </asp:Content>
