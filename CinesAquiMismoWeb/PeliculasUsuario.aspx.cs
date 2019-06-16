using CinesAquiMismoWeb.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinesAquiMismoWeb
{
    public partial class PeliculasUsuario : System.Web.UI.Page
    {

        static CinesTableAdapter cinesAdapter = new CinesTableAdapter();
        static DataSet1.CinesDataTable cinesTabla = new DataSet1.CinesDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["logeoU"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaCombo();
                    CargaCines();
                }
            }
            else if(Convert.ToBoolean(Session["logeo"]) || !Convert.ToBoolean(Session["logeoU"]))
            {
                Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");
                Response.Redirect("Login.aspx");
            }
            
        }
       
        private void CargaCombo()
        {
            List<Cine> listaTodosMasCines = LNyAD.ListaCines();

            listaTodosMasCines.Insert(0, new Cine(0, "Todos", "Todos los cines"));

            ddlNombreCine.DataSource = listaTodosMasCines;
            ddlNombreCine.DataValueField = "IdCine";
            ddlNombreCine.DataTextField = "nombreCine";

            ddlNombreCine.DataBind();
        }

        protected void ddlNombreCine_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaCines();
            rellenaCines();
        }

        private void rellenaCines()
        {
            int idCinecb;
            int idCineUsu;

            String nombre;
            String zona;

            cinesTabla = cinesAdapter.GetData();

            for (int i = 0; i < dgvUsuPelis.Rows.Count; i++)
            {
                idCineUsu = Convert.ToInt32(dgvUsuPelis.Rows[i].Cells[4].Text);
                for (int j = 0; j < cinesTabla.Count; j++)
                {
                    idCinecb = cinesTabla[j].idCine;
                    nombre = cinesTabla[j].NombreCine;
                    zona = cinesTabla[j].Zona;
                    if (idCinecb == idCineUsu)
                    {
                        dgvUsuPelis.Rows[i].Cells[1].Text = nombre;
                        dgvUsuPelis.Rows[i].Cells[5].Text = zona;
                    }
                }
            }
        }

        private void CargaCines()
        {
            int idCine = Convert.ToInt32(ddlNombreCine.SelectedValue);
            
            bool sonTodos = (idCine == 0);

            dgvUsuPelis.DataSource = LNyAD.TablaPelis(idCine);
            dgvUsuPelis.DataBind();

            
           

            foreach (GridViewRow fila in dgvUsuPelis.Rows)
            {
                dgvUsuPelis.HeaderRow.Cells[0].Visible = false;
                fila.Cells[0].Visible = false;
                dgvUsuPelis.HeaderRow.Cells[4].Visible = false;
                fila.Cells[4].Visible = false;
            }
        }

        protected void comprarTicket(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "comprarTicket")
            {
                Response.Redirect("ComprarTicket.aspx");
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('ContraCambio.aspx','Cambio de Contraseña','menubar=1,resizable=1,width=600,height=140');", true);
        }
    }
}