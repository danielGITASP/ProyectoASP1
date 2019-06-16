using CinesAquiMismoWeb.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinesAquiMismoWeb
{
    public partial class ContraCambio : System.Web.UI.Page
    {
        static UsuariosTableAdapter usuariosAdapter = new UsuariosTableAdapter();
        static DataSet1.UsuariosDataTable usuariosTabla = new DataSet1.UsuariosDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(Session["logeoU"]))
            {
                txtU.Text = Convert.ToString(Session["NombreU"]);              
            }
            else if (Convert.ToBoolean(Session["logeo"]) || !Convert.ToBoolean(Session["logeoU"]))
            {
                Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");
                Response.Redirect("Login.aspx");
            }

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            usuariosTabla = usuariosAdapter.GetData();
            String nombre;
            String contra;
            bool hecho = false;

            for (int i = 0; i < usuariosTabla.Rows.Count; i++)
            {
                nombre = usuariosTabla[i].Nombre.ToString();
                contra = usuariosTabla[i].Password.ToString();

                if (txtContraA.Text == contra && txtU.Text == nombre)
                {
                    hecho = true;
                    args.IsValid = true;
                }
            }

            if (!hecho)
                args.IsValid = false;

        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            usuariosTabla = usuariosAdapter.GetData();

            int id;
            String nombre;
            String contra;

            for (int i = 0; i < usuariosTabla.Rows.Count; i++)
            {
                id = usuariosTabla[i].idUsuario;
                nombre = usuariosTabla[i].Nombre.ToString();
                contra = usuariosTabla[i].Password.ToString();

                if (txtContraA.Text == contra && txtU.Text == nombre)
                {
                    DataSet1.UsuariosRow regUsuario = usuariosTabla.FindByidUsuario(id);
                    regUsuario.Password = txtContraN.Text;

                    usuariosTabla[i].Password = txtContraN.Text;

                    usuariosAdapter.Update(regUsuario);
                    usuariosTabla.AcceptChanges();

                    labelMensaje.ForeColor = System.Drawing.Color.Green;
                    labelMensaje.Text = "Se ha cambiado la contraseña";
                    labelMensaje.Visible = true;
                }
            }            
        }


    }
}