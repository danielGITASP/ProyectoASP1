using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace CinesAquiMismoWeb
{
    public partial class Grafico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlGraf_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chartType = ddlGraf.SelectedValue;
            switch (chartType)
            {
                case "Column Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                    break;
                case "Pie Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    break;
                case "Bar Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                    break;
                case "BoxPlot Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.BoxPlot;
                    break;
                case "Funnel Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Funnel;
                    break;
                case "Point Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
                    break;
                case "Spline Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
                    break;
                case "Bubble Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bubble;
                    break;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {

            string tmpChartName = "Chart1.jpg";
            string imgPath = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName;

            string chartType = ddlGraf.SelectedValue;
            switch (chartType)
            {
                case "Column Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                    break;
                case "Pie Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    break;
                case "Bar Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                    break;
                case "BoxPlot Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.BoxPlot;
                    break;
                case "Funnel Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Funnel;
                    break;
                case "Point Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
                    break;
                case "Spline Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
                    break;
                case "Bubble Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bubble;
                    break;
            }
            Chart1.SaveImage(imgPath);
            
           
            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=Peliculas&Precio.xls;");

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            string headerTable = @"<Table><tr><td><img src='" + imgPath + @"' \></td></tr></Table>";
            Response.Write(headerTable);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            string tmpChartName = "Chart1.jpg";
            string imgPath = HttpContext.Current.Request.PhysicalApplicationPath + tmpChartName;

            string chartType = ddlGraf.SelectedValue;
            switch (chartType)
            {
                case "Column Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                    break;
                case "Pie Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    break;
                case "Bar Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
                    break;
                case "BoxPlot Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.BoxPlot;
                    break;
                case "Funnel Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Funnel;
                    break;
                case "Point Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Point;
                    break;
                case "Spline Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
                    break;
                case "Bubble Chart":
                    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bubble;
                    break;
            }
            Chart1.SaveImage(imgPath);

            Response.Clear();
            Response.ContentType = "application/vnd.ms-word";
            Response.AddHeader("Content-Disposition", "attachment; filename=Peliculas&Precio.doc;");

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            string headerTable = @"<Table><tr><td><img src='" + imgPath + @"' \></td></tr></Table>";
            Response.Write(headerTable);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
    }
}