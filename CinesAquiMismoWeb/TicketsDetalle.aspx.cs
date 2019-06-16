using CinesAquiMismoWeb.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CinesAquiMismoWeb
{
    public partial class TicketsDetalle : System.Web.UI.Page
    {
        Ticket ticket;
        static TicketsTableAdapter ticketsAdapter = new TicketsTableAdapter();
        static DataSet1.TicketsDataTable ticketsTabla = new DataSet1.TicketsDataTable();

        public Ticket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaCombo();

                    Ticket = (Ticket)Session["Ticket"];
                    if (Ticket.IdTicket != -1) //Si NO es añadir
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
            List<Usuario> listaUsuarios = LNyAD.ListaUsuarios();

            ddlUsuario.DataSource = listaUsuarios;
            ddlUsuario.DataValueField = "idUsuario";
            ddlUsuario.DataTextField = "Nombre";

            ddlUsuario.DataBind();
        }

        private void CargarControles()
        {        
            txtCodigo.Text = ticket.Codigo;
            ddlUsuario.SelectedValue = ticket.UsuarioId.ToString();
            fechaTicket.SelectedDate = ticket.Fecha;           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid)
                return;

            bool Repetido = false;
            ticket = new Ticket(((Ticket)Session["Ticket"]).IdTicket, txtCodigo.Text, fechaTicket.SelectedDate, Convert.ToInt32(ddlUsuario.SelectedValue));

            String codigo;
            String codigoA = ((Ticket)Session["Ticket"]).Codigo;

            ticketsTabla = ticketsAdapter.GetData();


                for(int i = 0; i < ticketsTabla.Count; i++)
                {
                    codigo = ticketsTabla[i].Codigo;

                    if(txtCodigo.Text == codigoA)
                    {
                        i++;
                        Repetido = true;
                }
                else
                {
                    if(txtCodigo.Text == codigo)
                    {
                        Repetido = true;
                    }
                }
                }

            if (Repetido)
            {
                Response.Write("<script>alert('YA EXISTE ESE TICKET')</script>");
            }

            LNyAD.ModificaTicket(ticket);

            
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
        }
    }
}