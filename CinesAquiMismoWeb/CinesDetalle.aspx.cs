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
    public partial class CinesDetalle : System.Web.UI.Page
    {
        Cine cine;
        String nombreActual;
        String zonaActual;

        static CinesTableAdapter cinesAdapter = new CinesTableAdapter();
        static DataSet1.CinesDataTable cinesTabla = new DataSet1.CinesDataTable();

        public Cine Cine
        {
            get
            {
                return cine;
            }

            set
            {
                cine = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {

                    Cine = (Cine)Session["Cine"];
                    if (Cine.IdCine != -1) //Si NO es añadir
                    {
                        CargarControles();
                    }
                    else
                    {
                        ddlZonasD.Items.Insert(0, "Elige una Zona");
                    }
                }
            }
            else if (!Convert.ToBoolean(Session["logeo"]) || Convert.ToBoolean(Session["logeoU"]))
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
            txtNombreCine.Text = Cine.NombreCine;
            ddlZonasD.SelectedValue = Cine.Zona;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            Cine = new Cine(((Cine)Session["Cine"]).IdCine,txtNombreCine.Text, ddlZonasD.SelectedValue);


            //Cine existente
            bool Repetida = false;

            String nombre;
            nombreActual = ((Cine)Session["Cine"]).NombreCine;

            String zona;
            zonaActual = ((Cine)Session["Cine"]).Zona;

            cinesTabla = cinesAdapter.GetData();

            if (cine.IdCine == -1)
            {
                for (int i = 0; i < cinesTabla.Count; i++)
                {
                    nombre = cinesTabla[i].Nombre_Cine;
                    zona = cinesTabla[i].Zona;

                    if (txtNombreCine.Text == nombre)
                    {
                        if (ddlZonasD.SelectedValue == zona)
                            Repetida = true;
                    }

                }
            }
            else
            {
                for (int i = 0; i < cinesTabla.Count - 1; i++)
                {
                    nombre = cinesTabla[i].Nombre_Cine;
                    zona = cinesTabla[i].Zona;

                    if (txtNombreCine.Text == nombreActual && ddlZonasD.SelectedValue == zonaActual)
                    {
                        i++;
                        Repetida = false;
                    }
                    else
                    {
                        if (txtNombreCine.Text == nombre)
                        {
                            if (ddlZonasD.SelectedValue == zona)
                                Repetida = true;
                        }
                    }
                }
            }


            if (Repetida)
            {
                Response.Write("<script>alert('YA EXISTE ESE CINE')</script>");
                return;
            }


            if (Cine.IdCine == -1)
            {
                LNyAD.AddCine(Cine);
            }
            else
            {
                LNyAD.ModificaCine(Cine);
            }

            ddlZonasD.Items.Remove("Elige una Zona");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);

        }


        protected void CustomValidatorCBCine_ServerValidate(object source, ServerValidateEventArgs args)
        {

            Cine = (Cine)Session["Cine"];
            if (Cine.IdCine == -1) //Si es añadir
            {
                if (ddlZonasD.SelectedIndex > 0)
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