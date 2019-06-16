using CinesAquiMismoWeb.DataSet1TableAdapters;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinesAquiMismoWeb
{
    public partial class Login : System.Web.UI.Page
    {

        //static string connectionString2 = "Server=ftp-eu.site4now.net; Database=cinesaquimismo; Uid=root; Pwd=Akihinata123;";
        //static string connectionString3 = "server=localhost;user id=ftp-eu.site4now.net;password=Akihinata123;persistsecurityinfo=True;database=cinesaquimismo";
        static SqlConnection cn = new SqlConnection("Data Source=servidorcines.database.windows.net;Initial Catalog=cinesaquimismo;Persist Security Info=True;User ID=daniel@servidorcines;Password=Akihinata1");

        static UsuariosTableAdapter usuariosAdapter = new UsuariosTableAdapter();
        static DataSet1.UsuariosDataTable usuariosTabla = new DataSet1.UsuariosDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            cn.Open();
            

            Session["logeo"] = false;
            Session["logeoU"] = false;
            Label6.Text = DateTime.Now.ToString();

            if (!Page.IsPostBack)
            {
                if(Request.Cookies["Usuario"] != null && Request.Cookies["Contra"] != null)
                {
                    txtUsu.Text = Request.Cookies["Usuario"].Value;
                    txtPass.Attributes["value"] = Request.Cookies["Contra"].Value;
                }
            }
            cn.Close();
        }

        protected void btnMostrarR_Click(object sender, EventArgs e)
        {
            txtNombre.Visible = !txtNombre.Visible;
            txtContra.Visible = !txtContra.Visible;
            txtContraR.Visible = !txtContraR.Visible;
            txtAlias.Visible = !txtAlias.Visible;
            txtLogin.Visible = !txtLogin.Visible;
            btnRegistro.Visible = !btnRegistro.Visible;
            txtMovil.Visible = !txtMovil.Visible;
            txtEmail.Visible = !txtEmail.Visible;

            Label1.Visible = !Label1.Visible;
            Label2.Visible = !Label2.Visible;
            Label3.Visible = !Label3.Visible;
            Label4.Visible = !Label4.Visible;
            Label5.Visible = !Label5.Visible;
            Label15.Visible = !Label15.Visible;
            Label16.Visible = !Label16.Visible;
        }

        protected void btnAcceder_Click(object sender, EventArgs e)
        {
            //string connectionString = @"Data Source=localhost; Database=cinesaquimismo; User ID=root; Password=Akihinata123";
                       
            usuariosTabla = usuariosAdapter.GetData();
           

            bool Log = false;
            String usuario;
            String login;
            String contra;
            string acceso = String.Empty;

            Session["idUsu"] = null;

            if (checkUsu.Checked)
            {
                Response.Cookies["Usuario"].Value = txtUsu.Text;
                Response.Cookies["Contra"].Value = txtPass.Text;
                Response.Cookies["Usuario"].Expires = DateTime.Now.AddMinutes(3);
                Response.Cookies["Contra"].Expires = DateTime.Now.AddMinutes(3);
            }
            else
            {
                Response.Cookies["Usuario"].Expires = DateTime.Now.AddMinutes(-1);
                Response.Cookies["Contra"].Expires = DateTime.Now.AddMinutes(-1);
            }

            for (int i = 0; i < usuariosTabla.Rows.Count; i++)
            {
                usuario = usuariosTabla[i].Nombre;
                contra = usuariosTabla[i].Password;
                login = usuariosTabla[i].Login;
                

                if ((txtUsu.Text.Trim() == usuario && txtPass.Text == contra) || (txtUsu.Text.Trim() == login && txtPass.Text == contra))
                {
                    Log = true;
                    acceso = usuariosTabla[i].TipoAcceso;
                    Session["idUsu"] = usuariosTabla[i].idUsuario;

                }

            }

            if (Log == false)
            {
                
                Label12.Visible = true;
                return;
            }

            if (Log && acceso == "Usuario")
            {
                Session["logeoU"] = true;
                Session["NombreU"] = txtUsu.Text;
                Response.Redirect("PeliculasUsuario.aspx");
            }
            else if (Log && acceso == "Admin")
            {
                Session["logeo"] = true;
                Session["nombreL"] = txtUsu.Text;
                Response.Redirect("Peliculas.aspx");
            }
            else if (Log && acceso == "SinRegistro")
            {
                Response.Write("<script>alert('Usuario deshabilitado')</script>");
            }

        }


        protected void btnRegistro_Click(object sender, EventArgs e)
        {
           
            if (!Page.IsValid)
                return;
            usuariosTabla = usuariosAdapter.GetData();

            Label12.Visible = false;
            Label7.Visible = false;
            bool log = false;
            //Crear formulario EditaUsuarios
            Usuario nuevoUsuario = new Usuario();

            // Construimos un registro nuevo
            DataSet1.UsuariosRow regUsuario = usuariosTabla.NewUsuariosRow();
            // rellenamos el registro
            regUsuario.Nombre = txtNombre.Text;
            regUsuario.Password = txtContra.Text;
            regUsuario.Alias = txtAlias.Text;
            regUsuario.Login = txtLogin.Text;
            regUsuario.Acceso = 0;
            regUsuario.TipoAcceso = "SinRegistro";
            regUsuario.Movil = Convert.ToInt32(txtMovil.Text);
            regUsuario.Email = txtEmail.Text;

            //Usuario existente
            String nombreU;

            String aliasU;

            String loginU;

            bool Repetida = false;

            for (int i = 0; i < usuariosTabla.Rows.Count; i++)
            {
                nombreU = usuariosTabla[i].Nombre.ToString();
                aliasU = usuariosTabla[i].Alias.ToString();
                loginU = usuariosTabla[i].Login.ToString();

                if (txtNombre.Text == nombreU)
                {
                    if (txtAlias.Text == aliasU)
                        if (txtLogin.Text == loginU)
                            Repetida = true;
                }

            }
        

            if (Repetida)
            {
                Response.Write("<script>alert('YA EXISTE ESE USUARIO')</script>");
                return;
            }
            else
            {
                usuariosTabla.AddUsuariosRow(regUsuario);

                usuariosAdapter.Update(regUsuario);
                log = true;

                if (log)
                    Label7.Visible = true;
                Label7.Text = "Usuario registrado";
            }

               
        }
    }
}