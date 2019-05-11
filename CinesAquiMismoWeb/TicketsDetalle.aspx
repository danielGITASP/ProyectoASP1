<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketsDetalle.aspx.cs" Inherits="CinesAquiMismoWeb.TicketsDetalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script>
        function pop() {
            function reloadOpener() {
              if (top.opener && !top.opener.closed) {
                  try {
                      window.opener.location = "Tickets.aspx"; 
                }
                catch(e) {
                }
                window.close();
              }
            }
            window.onunload=function() {
              reloadOpener();
            }
        }
    </script>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="color: #0000FF">TICKETS DETALLE</h1>
        </div>
    <p>Codigo:<asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Falta el Codigo." ForeColor="Red">*</asp:RequiredFieldValidator>
    </p>
        <p>Fecha:
            <asp:Calendar ID="fechaTicket" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
    </p>
        <p>Usuario:<asp:DropDownList ID="ddlUsuario" runat="server">
            </asp:DropDownList>
    </p>
        <p>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" OnClientClick="pop()" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
    </p>
    </form>
    </body>
</html>
