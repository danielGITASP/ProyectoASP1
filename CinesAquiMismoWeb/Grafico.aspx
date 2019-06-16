<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafico.aspx.cs" Inherits="CinesAquiMismoWeb.Grafico" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<link href="estilos.css" rel="stylesheet" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 579px;
        }
        .auto-style2 {
            margin-left: 40px;
        }
        .auto-style3 {
            height: 556px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="auto-style1" style="background-color: #00FFFF">
            <p class="auto-style2">
            Seleccione el tipo de Gráfico:
            <asp:DropDownList ID="ddlGraf" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGraf_SelectedIndexChanged">
                <asp:ListItem>Column Chart</asp:ListItem>
                <asp:ListItem>Pie Chart</asp:ListItem>
                <asp:ListItem>Bar Chart</asp:ListItem>                
                <asp:ListItem>BoxPlot Chart</asp:ListItem>
                <asp:ListItem>Funnel Chart</asp:ListItem>
                <asp:ListItem>Point Chart</asp:ListItem>
                <asp:ListItem>Spline Chart</asp:ListItem>
                <asp:ListItem>Bubble Chart</asp:ListItem>
            </asp:DropDownList>

            </p>

            <div id="container" class="auto-style3">
            <div id="left" style="float:left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="467px" Width="519px" BackColor="Aquamarine">
                 <series>
                    <asp:Series Name="Series1" XValueMember="Nombre" YValueMembers="Precio" ChartArea="ChartArea1">
                    </asp:Series>
                </series>
                <chartareas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Title="Peliculas"></AxisX>
                    <AxisY Title="Precio"></AxisY>
                </asp:ChartArea>
                </chartareas>
             </asp:Chart>
                        
               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cinesaquimismoConnectionString1 %>" SelectCommand="SELECT * FROM [Peliculas]"></asp:SqlDataSource>
            </div>
                
            <div id="right" style="float:right;margin-right: 200px;">
                <td>
                    <asp:Button ID="btnExcel" CssClass="mybtn"  runat="server" OnClick="btnExcel_Click" Text="Exportar a Excel" BackColor="#6699FF" Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="Blue" Height="50px" />
                    <br />
                    <asp:Button ID="btnPDF" CssClass="mybtn" runat="server" OnClick="btnPDF_Click" Text="Exportar a Word" BackColor="#6699FF" Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="Blue" Height="50px" />
                    <br />
                    <asp:Button ID="btnVolver" CssClass="mybtn"  runat="server" Text="Volver" OnClick="btnVolver_Click" BackColor="#6699FF" Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="Blue" Height="50px" />  
                </td>
            </div>           

        </div>

        </div>

        

        
    </form>
</body>
</html>
