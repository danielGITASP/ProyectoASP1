
using CinesAquiMismoWeb.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinesAquiMismoWeb
{
    public partial class Cines : System.Web.UI.Page
    {
        bool encontrado;
        static CinesTableAdapter cinesAdapter = new CinesTableAdapter();
        static DataSet1.CinesDataTable cinesTabla = new DataSet1.CinesDataTable();

        static PeliculasTableAdapter peliculasAdapter = new PeliculasTableAdapter();
        static DataSet1.PeliculasDataTable peliculasTabla = new DataSet1.PeliculasDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
           //abc
            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaZonas();
                }
            }
            else if(!Convert.ToBoolean(Session["logeo"]) || Convert.ToBoolean(Session["logeoU"]))
            {
                Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");

                Response.Redirect("Login.aspx");
            }
        }



        protected void ddlZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaZonas();
        }

        private void CargaZonas()
        {
            int idZona = Convert.ToInt32(ddlZonas.SelectedIndex);
            String zona = ddlZonas.SelectedItem.Text;
            bool sonTodos = (idZona == 0);

            dgvCines.DataSource = LNyAD.TablaCines(idZona, zona);
            dgvCines.DataBind();

            foreach (GridViewRow fila in dgvCines.Rows)
            {
                dgvCines.HeaderRow.Cells[1].Visible = false;
                fila.Cells[1].Visible = false;
            }

        }

        protected void dgvCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCine = Convert.ToInt32(dgvCines.SelectedRow.Cells[1].Text);
            Cine cine = LNyAD.DevuelveCine(idCine);

            Session["Cine"] = cine;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('CinesDetalle.aspx','Cines Detalle','menubar=1,resizable=1,width=900,height=600');", true);
            dgvCines.SelectedIndex = -1;
        }

        protected void dgvCines_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dgvCines.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            Session["Cine"] = new Cine();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('CinesDetalle.aspx','Cines Detalle','menubar=1,resizable=1,width=900,height=600');", true);
        }

        private void MostrarConfirmacion(bool mostrado)
        {
            if (mostrado)
            {
                dgvCines.Enabled = false;
                ddlZonas.Enabled = false;
                btnAñadir.Visible = false;
                btnVolver.Visible = false;
                lbConfirmar.Text = "¿Eliminar a " + dgvCines.SelectedRow.Cells[2].Text + "?";
                btnSi.Visible = true;
                btnNo.Visible = true;
                lbConfirmar.Visible = true;
                btnPeliculas.Visible = false;
                btnUsuarios.Visible = false;
                btnPaises.Visible = false;
                btnTickets.Visible = false;

            }
            else
            {
                dgvCines.Enabled = true;
                ddlZonas.Enabled = true;
                btnAñadir.Visible = true;
                btnVolver.Visible = true;
                btnSi.Visible = false;
                btnNo.Visible = false;
                lbConfirmar.Visible = false;
                btnPeliculas.Visible = true;
                btnUsuarios.Visible = true;
                btnPaises.Visible = true;
                btnTickets.Visible = true;
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idCine = Convert.ToInt32(dgvCines.Rows[dgvCines.SelectedIndex].Cells[1].Text);
            LNyAD.EliminarCine(idCine);

            dgvCines.SelectedIndex = -1;

            MostrarConfirmacion(false);
            CargaZonas();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
            dgvCines.SelectedIndex = -1;
        }

        protected void dgvCines_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            peliculasTabla = peliculasAdapter.GetDataByCartelera();

            string nombreCine;
            string nDgv = e.Row.Cells[2].Text;
            encontrado = false;

            for (int i = 0; i < peliculasTabla.Count; i++)
            {
                nombreCine = peliculasTabla[i].NombreCine;
                foreach(TableCell cell in e.Row.Cells)
                {
                    if (nDgv == nombreCine)
                    {
                        encontrado = true;
                    }
                }
                
            }

            if (!encontrado)
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ToolTip = "Este cine no tiene peliculas.";
            }

        }


        protected void btnExcel_Click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=Cines.xls");
            Response.Charset = "";
            Response.ContentType = "application/ms-excel ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            dgvCines.AllowPaging = false;
            CargaZonas();

            dgvCines.RenderControl(hw);

            Response.Output.Write(sw.ToString());

            Response.Flush();
            Response.End();
        }


        protected void btnPDF_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=Cines.doc");
            Response.Charset = "";
            Response.ContentType = "application/ms-word ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            dgvCines.AllowPaging = false;
            CargaZonas();
          
            dgvCines.RenderControl(hw);

            Response.Output.Write(sw.ToString());

            Response.Flush();
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}