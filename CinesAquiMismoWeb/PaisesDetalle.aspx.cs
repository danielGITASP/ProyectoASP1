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
    public partial class PaisesDetalle : System.Web.UI.Page
    {
        Pais pais;
        static PaisesTableAdapter paisesAdapter = new PaisesTableAdapter();
        static DataSet1.PaisesDataTable paisesTabla = new DataSet1.PaisesDataTable();

        public Pais Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaCombo();

                    Pais = (Pais)Session["Pais"];
                    if (Pais.IdPais != -1) //Si NO es añadir
                    {
                        CargarControles();
                    }

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
            List<Pelicula> listaPeliculas = LNyAD.ListaPelis();

            ddlPeli.DataSource = listaPeliculas;
            ddlPeli.DataValueField = "idPelicula";
            ddlPeli.DataTextField = "Nombre";

            ddlPeli.DataBind();
        }

        private void CargarControles()
        {
            ddlNombrePais.SelectedValue = pais.NombrePais;
            txtNumVisitas.Text = pais.NumVisitas.ToString();
            ddlPeli.SelectedValue = pais.PeliculaId.ToString();
            ddlValor.SelectedValue = pais.Valoracion.ToString();           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            pais = new Pais(((Pais)Session["Pais"]).IdPais, ddlNombrePais.SelectedValue, Convert.ToInt32(txtNumVisitas.Text), Convert.ToInt32(ddlPeli.SelectedValue), Convert.ToInt32(ddlValor.SelectedValue));

            //Pais existente (nombre, visitas, pelicula, valoracion)
            bool Repetido = false;

            String nombre;
            String nombreA = ((Pais)Session["Pais"]).NombrePais;

            int numVisitas;
            int numVisitasA = ((Pais)Session["Pais"]).NumVisitas;

            int peliculaId;
            int peliculaIdA = ((Pais)Session["Pais"]).PeliculaId;

            int valoracion;
            int valoracionA = ((Pais)Session["Pais"]).Valoracion;

            paisesTabla = paisesAdapter.GetData();

            if(pais.IdPais == -1)
            {
                for(int i = 0; i < paisesTabla.Count; i++)
                {
                    nombre = paisesTabla[i].NombrePais;
                    numVisitas = paisesTabla[i].NumVisitas;
                    peliculaId = paisesTabla[i].PeliculaId;
                    valoracion = paisesTabla[i].Valoracion;

                    if((ddlNombrePais.SelectedValue == nombre) && (Convert.ToInt32(txtNumVisitas.Text) == numVisitas) && (Convert.ToInt32(ddlPeli.SelectedValue) == peliculaId) && (Convert.ToInt32(ddlValor.SelectedValue) == valoracion))
                    {
                        Repetido = true;
                    }

                }
            }
            else
            {
                for(int i = 0; i < paisesTabla.Count - 1; i++)
                {
                    nombre = paisesTabla[i].NombrePais;
                    numVisitas = paisesTabla[i].NumVisitas;
                    peliculaId = paisesTabla[i].PeliculaId;
                    valoracion = paisesTabla[i].Valoracion;

                    if(ddlNombrePais.SelectedValue == nombreA && Convert.ToInt32(txtNumVisitas.Text) == numVisitasA && Convert.ToInt32(ddlPeli.SelectedValue) == peliculaIdA && Convert.ToInt32(ddlValor.SelectedValue) == valoracionA)
                    {
                        i++;
                        Repetido = false;
                    }
                    else
                    {
                        if ((ddlNombrePais.SelectedValue == nombre) && (Convert.ToInt32(txtNumVisitas.Text) == numVisitas) && (Convert.ToInt32(ddlPeli.SelectedValue) == peliculaId) && (Convert.ToInt32(ddlValor.SelectedValue) == valoracion))
                        {
                            Repetido = true;
                        }
                    }

                }
            }

            if (Repetido)
            {
                Response.Write("<script>alert('YA EXISTE ESA VALORACIÓN EN ESE PAIS')</script>");
            }

            if(pais.IdPais == -1)
            {
                LNyAD.AddPais(pais);
            }
            else
            {
                LNyAD.ModificaPais(pais);
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
        }


    }
}