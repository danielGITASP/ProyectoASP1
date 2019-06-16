<%@ Page Language="C#" AutoEventWireup="true" Theme="TemaP" CodeBehind="Peliculas.aspx.cs" Inherits="CinesAquiMismoWeb.Default"  MasterPageFile="~/PaginaMaestra.Master"   %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/Peliculas.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>       


 </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1"  runat="server" class="auto-style3" aria-expanded="true">       
        <asp:Label ID="Label1" runat="server" Text="Label">Filtrado por Cine:</asp:Label>
        <asp:DropDownList ID="ddlCines" runat="server" OnSelectedIndexChanged="ddlCines_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Filtrado por Nombre:"></asp:Label>
        <asp:TextBox ID="txtNombreP" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGraf" CssClass="mybtn" runat="server" style="margin-top:25px" Text="Gráfico" OnClick="btnGraf_Click" />            
        &nbsp;&nbsp;&nbsp; <asp:Button ID="btnExcel" CssClass="mybtn" runat="server" OnClick="btnExcel_Click" Text="Exportar a Excel" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPDF" CssClass="mybtn" runat="server" OnClick="btnPDF_Click" Text="Exportar a Word" />

        <br />

        

        <div id="left" class="auto-style5">
            <div class="table-responsive">
        <asp:GridView ID="dgvAdminP" runat="server"  style="margin-top:10px; margin-left:25px"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDeleting="dgvAdminP_RowDeleting" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvAdminP_SelectedIndexChanged" Font-Bold="True" Font-Size="X-Large" Width="1119px">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Sel" SelectText="@" ShowSelectButton="True" >
                <ItemStyle Width="25px" />
                </asp:CommandField>
                <asp:BoundField DataField="idPelicula" HeaderText="idPelicula" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                <FooterStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Precio" HeaderText="Precio" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CineId" HeaderText="CineId" />
                <asp:BoundField DataField="NombreCine" HeaderText="NombreCine" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Zona" HeaderText="Zona" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ButtonType="Button" DeleteText="X" HeaderText="Del" ShowDeleteButton="True">
                <ControlStyle BackColor="Red" Font-Bold="True" />
                <ItemStyle Width="20px" />
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

                </div>


            <br />




        <asp:Button ID="btnAñadir" style="margin-left: 50px" runat="server" Text="Añadir" OnClick="btnAñadir_Click"  />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnCines" runat="server" PostBackUrl="~/Cines.aspx" Text="Ir a Cines" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:Button ID="btnUsuarios" runat="server" PostBackUrl="~/Usuarios.aspx" Text="Ir a Usuarios"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPaises" runat="server" PostBackUrl="~/Paises.aspx" Text="Ir a Paises" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnTickets" runat="server" PostBackUrl="~/Tickets.aspx" Text="Ir a Tickets" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Button ID="btnVolver" runat="server" PostBackUrl="~/Login.aspx" Text="Volver" />

               &nbsp;&nbsp;
        &nbsp; 
        &nbsp;&nbsp;
        
               <p class="auto-style2">
            <asp:Label ID="lbConfirmar" runat="server" Text="Label" Visible="False"></asp:Label>
            <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Si" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" />
        </p>
       </div>

      </div>

         
    </form>
</asp:Content>

