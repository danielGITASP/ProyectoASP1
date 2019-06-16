using CinesAquiMismoWeb.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinesAquiMismoWeb
{
    public partial class ContraCambioLink : System.Web.UI.Page
    {
        static UsuariosTableAdapter usuariosAdapter = new UsuariosTableAdapter();
        static DataSet1.UsuariosDataTable usuariosTabla = new DataSet1.UsuariosDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                String data = url.Split('?')[1].Split('=')[1];

                txtU.Text = data;
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                usuariosTabla = usuariosAdapter.GetData();

                int id = Convert.ToInt32(txtU.Text);

                DataSet1.UsuariosRow regUsuario = usuariosTabla.FindByidUsuario(id);
                regUsuario.Password = txtContraN.Text;

                usuariosTabla[id].Password = txtContraN.Text;

                usuariosAdapter.UpdateUsuario(regUsuario.Nombre, txtContraN.Text, regUsuario.Alias, regUsuario.Login, regUsuario.Acceso,
                regUsuario.TipoAcceso, regUsuario.Movil, regUsuario.Email, id);

                labelMensaje.ForeColor = System.Drawing.Color.Green;
                labelMensaje.Text = "Se ha cambiado la contraseña";
                labelMensaje.Visible = true;
                
           

            }
        }
    }
}
