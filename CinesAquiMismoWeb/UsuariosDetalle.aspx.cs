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
    public partial class UsuariosDetalle : System.Web.UI.Page
    {
        Usuario usuario1;

        static UsuariosTableAdapter usuariosAdapter = new UsuariosTableAdapter();
        static DataSet1.UsuariosDataTable usuariosTabla = new DataSet1.UsuariosDataTable();

        public Usuario usuario
        {
            get
            {
                return usuario1;
            }

            set
            {
                usuario1 = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    usuario1 = (Usuario)Session["Usuario"];
                    if (usuario1.IdUsuario != -1) //Si NO es añadir
                    {
                        CargarControles();

                    }
                    else
                    {
                        ddlAccesoD.Items.Insert(0, "Elige un Acceso");
                    }
                }
            }
            else if (!Convert.ToBoolean(Session["logeo"]) || Convert.ToBoolean(Session["logeoU"]))
            {
                Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");
                Response.Redirect("Login.aspx");
            }
            
        }

        private void CargarControles()
        {
            txtNombre.Text = usuario1.Nombre;
            txtPass.Text = usuario1.Password;
            txtAlias.Text = usuario1.Alias;
            txtLogin.Text = usuario1.Login;
            ddlAccesoD.SelectedValue = usuario1.TipoAcceso;
            txtMovil.Text = Convert.ToString(usuario1.Movil1);
            txtEmail.Text = usuario1.Email1;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            usuario1 = new Usuario(((Usuario)Session["Usuario"]).IdUsuario, txtNombre.Text,txtPass.Text, txtAlias.Text, txtLogin.Text, 0, ddlAccesoD.SelectedValue, Convert.ToInt32(txtMovil.Text), txtEmail.Text);

            //Usuario existente
            String nombreU;
            String nombreActual = ((Usuario)Session["Usuario"]).Nombre;

            String aliasU;
            String aliasActual = ((Usuario)Session["Usuario"]).Alias;

            String loginU;
            String loginActual = ((Usuario)Session["Usuario"]).Login;

            bool Repetida = false;

            usuariosTabla = usuariosAdapter.GetData();

            if (usuario1.IdUsuario == -1)
            {
                for (int i = 0; i < usuariosTabla.Count; i++)
                {
                    nombreU = usuariosTabla[i].Nombre;
                    aliasU = usuariosTabla[i].Alias;
                    loginU = usuariosTabla[i].Login;

                    if (txtNombre.Text == nombreU)
                    {
                        if (txtAlias.Text == aliasU)
                            if(txtLogin.Text == loginU)
                            Repetida = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < usuariosTabla.Count - 1; i++)
                {
                    nombreU = usuariosTabla[i].Nombre;
                    aliasU = usuariosTabla[i].Alias;
                    loginU = usuariosTabla[i].Login;

                    if (txtNombre.Text == nombreActual && txtAlias.Text == aliasActual && txtLogin.Text == loginActual)
                    {
                        i++;
                        Repetida = false;
                    }
                    else
                    {
                        if (txtNombre.Text == nombreU)
                        {
                            if (txtAlias.Text == aliasU)
                                if (txtLogin.Text == loginU)
                                    Repetida = true;
                        }
                    }
                }
            }


            if (Repetida)
            {
                Response.Write("<script>alert('YA EXISTE ESE USUARIO')</script>");
                return;
            }
            


            if (usuario1.IdUsuario == -1)
            {
                LNyAD.AddUsuario(usuario1);
            }
            else
            {
                LNyAD.ModificaUsuario(usuario1);
            }

            ddlAccesoD.Items.Remove("Elige un Acceso");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);

        }


        protected void CustomValidatorCBAcceso_ServerValidate(object source, ServerValidateEventArgs args)
        {
            usuario1 = (Usuario)Session["Usuario"];
            if (usuario1.IdUsuario == -1) //Si es añadir
            {
                if (ddlAccesoD.SelectedIndex > 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(txtMovil.Text.Length != 9)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}