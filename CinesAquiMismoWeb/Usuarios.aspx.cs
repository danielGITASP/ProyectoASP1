using LogicaNegocioyADatos;
using LogicaNegocioyADatos.DataSet1TableAdapters;
using LogicaNegocioyADatos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinesAquiMismoWeb
{
    public partial class Usuarios : System.Web.UI.Page
    {
        static UsuariosTableAdapter usuariosAdapter = new UsuariosTableAdapter();
        static DataSet1.UsuariosDataTable usuariosTabla = new DataSet1.UsuariosDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaAccesos();
                }
            }
            else if (!Convert.ToBoolean(Session["logeo"]) || Convert.ToBoolean(Session["logeoU"]))
            {
                Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");
                Response.Redirect("Login.aspx");
            }
        }
        protected void ddlTipoAccesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaAccesos();
        }

        private void CargaAccesos()
        {

            int idAcceso = Convert.ToInt32(ddlTipoAccesos.SelectedIndex);
            String acceso = ddlTipoAccesos.SelectedItem.Text;
            bool sonTodos = (idAcceso == 0);

            dgvUsuarios.DataSource = LNyAD.TablaUsuarios(idAcceso, acceso);
            dgvUsuarios.DataBind();

            //foreach (GridViewRow fila in dgvUsuarios.Rows)
            //{
            //    dgvUsuarios.HeaderRow.Cells[1].Visible = false;
            //    fila.Cells[1].Visible = false;
            //}
        }


        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRow.Cells[1].Text);
            Usuario usu = LNyAD.DevuelveUsuario(idUsuario);

            Session["Usuario"] = usu;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('UsuariosDetalle.aspx','Usuarios Detalle','menubar=1,resizable=1,width=900,height=600');", true);
            dgvUsuarios.SelectedIndex = -1;
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = new Usuario();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('UsuariosDetalle.aspx','Usuarios Detalle','menubar=1,resizable=1,width=900,height=600');", true);
        }

        protected void dgvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {                    
            dgvUsuarios.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idUsu = Convert.ToInt32(dgvUsuarios.Rows[dgvUsuarios.SelectedIndex].Cells[1].Text);
            LNyAD.EliminarUsuario(idUsu);

            dgvUsuarios.SelectedIndex = -1;

            MostrarConfirmacion(false);
            CargaAccesos();
        }

        private void MostrarConfirmacion(bool mostrado)
        {          
            if (mostrado)
            {
                if (dgvUsuarios.SelectedRow.Cells[2].Text == "11")
                {
                    Response.Write("<script>alert('No puedes borrarte a ti mismo')</script>");
                    return;
                }

                if (dgvUsuarios.SelectedRow.Cells[2].Text == Session["nombreL"].ToString())
                {
                    Response.Write("<script>alert('No puedes borrarte a ti mismo')</script>");
                    return;
                }

                dgvUsuarios.Enabled = false;
                ddlTipoAccesos.Enabled = false;
                btnAñadir.Visible = false;
                btnVolver.Visible = false;
                lbConfirmar.Text = "¿Eliminar a " + dgvUsuarios.SelectedRow.Cells[2].Text + "?";
                btnSi.Visible = true;
                btnNo.Visible = true;
                lbConfirmar.Visible = true;
                btnPeliculas.Visible = false;
                btnCines.Visible = false;
                btnPaises.Visible = false;
                btnTickets.Visible = false;
            }
            else
            {
                dgvUsuarios.Enabled = true;
                ddlTipoAccesos.Enabled = true;
                btnAñadir.Visible = true;
                btnVolver.Visible = true;
                btnSi.Visible = false;
                btnNo.Visible = false;
                lbConfirmar.Visible = false;
                btnPeliculas.Visible = true;
                btnCines.Visible = true;
                btnPaises.Visible = true;
                btnTickets.Visible = true;
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
            dgvUsuarios.SelectedIndex = -1;
        }


    }
}