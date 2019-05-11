using LogicaNegocioyADatos;
using LogicaNegocioyADatos.DataSet1TableAdapters;
using LogicaNegocioyADatos.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CinesAquiMismoWeb
{
    public partial class PeliculasDetalle : System.Web.UI.Page
    {
        String nombreActual;
        int cbA;
        Pelicula peli;

        static PeliculasTableAdapter peliculasAdapter = new PeliculasTableAdapter();
        static DataSet1.PeliculasDataTable peliculasTabla = new DataSet1.PeliculasDataTable();
        private Default HttpContextHandler;

        public Pelicula Peli
        {
            get { return peli; }
            set { peli = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaCombo();

                    Peli = (Pelicula)Session["Pelicula"];
                    if (Peli.IdPelicula != -1) //Si NO es añadir
                    {
                        CargarControles();
                    }
                    else
                    {
                        ddlCinesDetalle.Items.Insert(0, "Elige un Cine");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");
                Response.Redirect("Login.aspx");
            }

        }

        string Mayus(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        private void CargarControles()
        {
            txtTitulo.Text = Peli.Nombre;
            txtPrecio.Text = Peli.Precio.ToString();
            ddlCinesDetalle.SelectedValue = Peli.CineId.ToString();
        }

        private void CargaCombo()
        {
            List<Cine> listaCines = LNyAD.ListaCines();

            ddlCinesDetalle.DataSource = listaCines;
            ddlCinesDetalle.DataValueField = "IdCine";
            ddlCinesDetalle.DataTextField = "nombreCine";


            ddlCinesDetalle.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
                return;

            double precio = Convert.ToDouble(txtPrecio.Text);
            peli = new Pelicula(((Pelicula)Session["Pelicula"]).IdPelicula, txtTitulo.Text, Math.Round(precio, 2), Convert.ToInt32(ddlCinesDetalle.SelectedValue));

            //Pelicula existente
            bool Repetida = false;

            String nombre;
            nombreActual = ((Pelicula)Session["Pelicula"]).Nombre;

            int cb;
            cbA = ((Pelicula)Session["Pelicula"]).CineId;

            peliculasTabla = peliculasAdapter.GetData();

            if(peli.IdPelicula == -1)
            {
                for (int i = 0; i < peliculasTabla.Count; i++)
                {
                    nombre = peliculasTabla[i].Nombre;
                    cb = peliculasTabla[i].CineId;

                    if (txtTitulo.Text == nombre)
                    {
                        if (Convert.ToInt32(ddlCinesDetalle.SelectedValue) == cb)
                            Repetida = true;
                    }

                }
            }
            else
            {
                for (int i = 0; i < peliculasTabla.Count - 1; i++)
                {
                    nombre = peliculasTabla[i].Nombre;
                    cb = peliculasTabla[i].CineId;

                    if (txtTitulo.Text == nombreActual && Convert.ToInt32(ddlCinesDetalle.SelectedValue) == cbA)
                    {
                        i++;
                        Repetida = false;
                    }
                    else
                    {
                        if (txtTitulo.Text == nombre)
                        {
                            if (Convert.ToInt32(ddlCinesDetalle.SelectedValue) == cb)
                                Repetida = true;
                        }
                    }                
                }
            }
                

            
            if (Repetida)
            {
                Response.Write("<script>alert('YA EXISTE ESA PELICULA')</script>");
                return;
            }


            if (peli.IdPelicula == -1)
            {
                LNyAD.AddPelicula(peli);
            }
            else
            {
                LNyAD.ModificaPelicula(peli);
            }

            ddlCinesDetalle.Items.Remove("Elige un Cine");           
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);


        }



        protected void CustomValidatorDdlCine_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Peli = (Pelicula)Session["Pelicula"];
            if (Peli.IdPelicula == -1) //Si es añadir
            {
                if (ddlCinesDetalle.SelectedIndex != 0)
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
    }
}