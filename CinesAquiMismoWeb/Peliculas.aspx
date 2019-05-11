<%@ Page Language="C#" AutoEventWireup="true" Theme="TemaP" CodeBehind="Peliculas.aspx.cs" Inherits="CinesAquiMismoWeb.Default"  MasterPageFile="~/PaginaMaestra.Master"   %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="estilos.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>      
    

    <style type="text/css">
        .auto-style1 {
            height: 246px;
        }
        .auto-style2 {
            height: 52px;
        }
        .auto-style3 {
            height: 331px;
        }
        .auto-style4 {
            margin-left: 29px;
        }
        .auto-style5 {
            margin-left: 32px;
        }
    </style>
    

 </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" style="background-image: url('img/Teaser-Cinema-1200-500.jpg'); background-repeat: repeat-y" class="auto-style3">       
        <asp:Label ID="Label1" runat="server" Text="Label">Filtrado por Cine:</asp:Label>
        <asp:DropDownList ID="ddlCines" runat="server" OnSelectedIndexChanged="ddlCines_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Filtrado por Nombre:"></asp:Label>
        <asp:TextBox ID="txtNombreP" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        <br />

        <div id="wrapper">

        <div id="left" style="float:left" class="auto-style1">
        <asp:GridView ID="dgvAdminP" runat="server" style="margin-top:10px; margin-left:25px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDeleting="dgvAdminP_RowDeleting" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvAdminP_SelectedIndexChanged" Font-Bold="True" Font-Size="X-Large">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Sel" SelectText="@" ShowSelectButton="True" />
                <asp:BoundField DataField="idPelicula" HeaderText="idPelicula" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="CineId" HeaderText="CineId" />
                <asp:BoundField DataField="Nombre Cine" HeaderText="Nombre Cine" />
                <asp:BoundField DataField="Zona" HeaderText="Zona" />
                <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" ShowDeleteButton="True">
                <ControlStyle BackColor="Red" Font-Bold="True" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        
        <br />
        <asp:Button ID="btnAñadir" style="margin-left: 50px" runat="server" Text="Añadir" OnClick="btnAñadir_Click"  />
            <asp:Button ID="btnCines" CssClass="auto-style4" runat="server" PostBackUrl="~/Cines.aspx" Text="Ir a Cines" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/Usuarios.aspx" Text="Ir a Usuarios"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPaises" runat="server" PostBackUrl="~/Paises.aspx" Text="Ir a Paises" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnTickets" runat="server" PostBackUrl="~/Tickets.aspx" Text="Ir a Tickets" />
            <asp:Button ID="btnVolver" CssClass="auto-style5" runat="server" Text="Volver" PostBackUrl="~/Login.aspx"  />

               <p class="auto-style2">
            <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" />
        </p>
       </div>

        <div id="right" style="float:left; margin-left:60px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGraf" CssClass="mybtn" runat="server" style="margin-top:25px" Text="Gráfico" OnClick="btnGraf_Click" />            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Button ID="btnExcel" CssClass="mybtn" runat="server" OnClick="btnExcel_Click" Text="Exportar a Excel" />
        &nbsp;&nbsp;<br />
            &nbsp;
        <asp:Button ID="btnPDF" CssClass="mybtn" runat="server" OnClick="btnPDF_Click" Text="Exportar a Word" />
        </div>

      </div>

        

        
     
    </form>
</asp:Content>

