using LogicaNegocioyADatos;
using LogicaNegocioyADatos.DataSet1TableAdapters;
using LogicaNegocioyADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinesAquiMismoWeb
{
    public partial class Paises : System.Web.UI.Page
    {
        static CinesTableAdapter cinesAdapter = new CinesTableAdapter();
        static DataSet1.CinesDataTable cinesTabla = new DataSet1.CinesDataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaCombo();
                    CargaPaises();
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
            List<Pais> listaTodosMasPaises = LNyAD.ListaPaises();

            listaTodosMasPaises.Insert(0, new Pais(0, "Todos",0, 0, 0));

            ddlPaises.DataSource = listaTodosMasPaises;
            ddlPaises.DataValueField = "IdPais";
            ddlPaises.DataTextField = "nombrePais";

            ddlPaises.DataBind();

        }

        protected void ddlPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaPaises();
        }

        private void CargaPaises()
        {
            int idPais = Convert.ToInt32(ddlPaises.SelectedIndex);
            bool sonTodos = (idPais == 0);

            dgvPaises.DataSource = LNyAD.TablaPaises(idPais);
            dgvPaises.DataBind();

            foreach (GridViewRow fila in dgvPaises.Rows)
            {
                dgvPaises.HeaderRow.Cells[1].Visible = false;
                fila.Cells[1].Visible = false;

                dgvPaises.HeaderRow.Cells[4].Visible = false;
                fila.Cells[4].Visible = false;
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            Session["Pais"] = new Pais();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('PaisesDetalle.aspx','Paises Detalle','menubar=1,resizable=1,width=900,height=600');", true);
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idPais = Convert.ToInt32(dgvPaises.Rows[dgvPaises.SelectedIndex].Cells[1].Text);
            LNyAD.EliminarPais(idPais);

            dgvPaises.SelectedIndex = -1;

            MostrarConfirmacion(false);
            CargaPaises();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
            dgvPaises.SelectedIndex = -1;
        }

        protected void dgvPaises_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dgvPaises.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        private void MostrarConfirmacion(bool mostrado)
        {
            if (mostrado)
            {
                dgvPaises.Enabled = false;
                ddlPaises.Enabled = false;
                btnAñadir.Visible = false;
                btnVolver.Visible = false;
                lbConfirmar.Text = "¿Eliminar a " + dgvPaises.SelectedRow.Cells[2].Text + "?";
                btnSi.Visible = true;
                btnNo.Visible = true;
                lbConfirmar.Visible = true;
                btnCines.Visible = false;
                btnUsuarios.Visible = false;
                btnPeliculas.Visible = false;
                btnTicket.Visible = false;
            }
            else
            {
                dgvPaises.Enabled = true;
                ddlPaises.Enabled = true;
                btnAñadir.Visible = true;
                btnVolver.Visible = true;
                btnSi.Visible = false;
                btnNo.Visible = false;
                lbConfirmar.Visible = false;
                btnCines.Visible = true;
                btnUsuarios.Visible = true;
                btnPeliculas.Visible = true;
                btnTicket.Visible = true;
            }
        }

        protected void dgvPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPais = Convert.ToInt32(dgvPaises.SelectedRow.Cells[1].Text);
            Pais pais = LNyAD.DevuelvePais(idPais);

            Session["Pais"] = pais;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('PaisesDetalle.aspx','Paises Detalle','menubar=1,resizable=1,width=900,height=600');", true);
            dgvPaises.SelectedIndex = -1;
        }
    }
}