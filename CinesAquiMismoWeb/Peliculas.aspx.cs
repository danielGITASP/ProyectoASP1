using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using CinesAquiMismoWeb.DataSet1TableAdapters;

namespace CinesAquiMismoWeb
{
    public partial class Default : System.Web.UI.Page
    {
        static CinesTableAdapter cinesAdapter = new CinesTableAdapter();
        static DataSet1.CinesDataTable cinesTabla = new DataSet1.CinesDataTable();

        public void Page_Load(object sender, EventArgs e)
        {
            
            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaCombo();
                    CargaPeliculasCine();
                }
            }
            else if (!Convert.ToBoolean(Session["logeo"]) || Convert.ToBoolean(Session["logeoU"]))
            {
                Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");
                
                Response.Redirect("Login.aspx");
            }
              
        }


        private void CargaCombo()
        {
            List<Cine> listaTodosMasCines = LNyAD.ListaCines();

            listaTodosMasCines.Insert(0, new Cine(0, "Todos", "Todos los cines"));

            ddlCines.DataSource = listaTodosMasCines;
            ddlCines.DataValueField = "IdCine";
            ddlCines.DataTextField = "nombreCine";
            

            ddlCines.DataBind();
            
        }

        protected void ddlCines_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaPeliculasCine();
            rellenaCines();
        }

        public void CargaPeliculasCine()
        {
            int idCine = Convert.ToInt32(ddlCines.SelectedValue);
            String nombre = txtNombreP.Text;
            bool sonTodos = (idCine == 0);

            if(txtNombreP.Text == "")
            {
                dgvAdminP.DataSource = LNyAD.TablaPelis(idCine);
            }
            else
            {
                if(ddlCines.SelectedIndex == 0)
                    dgvAdminP.DataSource = LNyAD.TablaNombres2(nombre);
                else
                    dgvAdminP.DataSource = LNyAD.TablaNombres(idCine, nombre);

            }
            dgvAdminP.DataBind();


            foreach (GridViewRow fila in dgvAdminP.Rows)
            {
                dgvAdminP.HeaderRow.Cells[4].Visible = false;
                fila.Cells[4].Visible = false;

                dgvAdminP.HeaderRow.Cells[1].Visible = false;
                fila.Cells[1].Visible = false;
            }

        }

        private void rellenaCines()
        {
            int idCinecb;
            int idCineUsu;

            String nombre;
            String zona;

            cinesTabla = cinesAdapter.GetData();

            for (int i = 0; i < dgvAdminP.Rows.Count; i++)
            {
                idCineUsu = Convert.ToInt32(dgvAdminP.Rows[i].Cells[4].Text);
                for (int j = 0; j < cinesTabla.Count; j++)
                {
                    idCinecb = cinesTabla[j].idCine;
                    nombre = cinesTabla[j].NombreCine;
                    zona = cinesTabla[j].Zona;
                    if (idCinecb == idCineUsu)
                    {
                        dgvAdminP.Rows[i].Cells[5].Text = nombre;
                        dgvAdminP.Rows[i].Cells[6].Text = zona;
                    }
                }
            }
        }


        protected void dgvAdminP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPelicula = Convert.ToInt32(dgvAdminP.SelectedRow.Cells[1].Text);
            Pelicula peli = LNyAD.DevuelvePelicula(idPelicula);

            Session["Pelicula"] = peli;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('PeliculasDetalle.aspx','Peliculas Detalle','menubar=1,resizable=1,width=900,height=600');", true);
            dgvAdminP.SelectedIndex = -1;

        }


        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            Session["Pelicula"] = new Pelicula();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('PeliculasDetalle.aspx','Peliculas Detalle','menubar=1,resizable=1,width=900,height=600');", true);
        }

        protected void dgvAdminP_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {           
            dgvAdminP.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idPelicula = Convert.ToInt32(dgvAdminP.Rows[dgvAdminP.SelectedIndex].Cells[1].Text);
            LNyAD.EliminarPelicula(idPelicula);

            dgvAdminP.SelectedIndex = -1;

            MostrarConfirmacion(false);
            CargaPeliculasCine();
        }

        void MostrarConfirmacion(bool mostrado)
        {
            if (mostrado)
            {
                dgvAdminP.Enabled = false;
                ddlCines.Enabled = false;
                btnAñadir.Visible = false;
                btnVolver.Visible = false;
                lbConfirmar.Text = "¿Eliminar a " + dgvAdminP.SelectedRow.Cells[2].Text + "?";
                btnSi.Visible = true;
                btnNo.Visible = true;
                lbConfirmar.Visible = true;
                btnCines.Visible = false;
                btnUsuarios.Visible = false;
                btnPaises.Visible = false;
                btnTickets.Visible = false;
                btnGraf.Visible = false;
                btnExcel.Visible = false;
                btnPDF.Visible = false;
                txtNombreP.Enabled = false;
            }
            else
            {
                dgvAdminP.Enabled = true;
                ddlCines.Enabled = true;
                btnAñadir.Visible = true;
                btnVolver.Visible = true;
                btnSi.Visible = false;
                btnNo.Visible = false;
                lbConfirmar.Visible = false;
                btnCines.Visible = true;
                btnUsuarios.Visible = true;
                btnPaises.Visible = true;
                btnTickets.Visible = true;
                btnGraf.Visible = true;
                btnExcel.Visible = true;
                btnPDF.Visible = true;
                txtNombreP.Enabled = true;
            }
        }


        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
            dgvAdminP.SelectedIndex = -1;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaPeliculasCine();
            
            rellenaCines();
        }

        protected void btnGraf_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('Grafico.aspx','Grafico de peliculas','menubar=0,resizable=0,width=1110,height=600');", true);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
           
            Response.AddHeader("content-disposition", "attachment;filename=Peliculas.xls");
            Response.Charset = "";
            Response.ContentType = "application/ms-excel ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            dgvAdminP.AllowPaging = false;
            CargaPeliculasCine();
            foreach (GridViewRow fila in dgvAdminP.Rows)
            {
                dgvAdminP.HeaderRow.Cells[0].Visible = false;
                fila.Cells[0].Visible = false;

                dgvAdminP.HeaderRow.Cells[7].Visible = false;
                fila.Cells[7].Visible = false;
            }
            dgvAdminP.RenderControl(hw);

            Response.Output.Write(sw.ToString());

            Response.Flush();
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment;filename=Peliculas.doc");
            Response.ContentType = "application/ms-word ";
            
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            dgvAdminP.AllowPaging = false;
            
            CargaPeliculasCine();

            foreach (GridViewRow fila in dgvAdminP.Rows)
            {
                dgvAdminP.HeaderRow.Cells[0].Visible = false;
                fila.Cells[0].Visible = false;

                dgvAdminP.HeaderRow.Cells[7].Visible = false;
                fila.Cells[7].Visible = false;
            }

            dgvAdminP.RenderControl(hw);

            Response.Output.Write(sw.ToString());

            Response.Flush();
            Response.End();
        }

        protected void dgvAdminP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}