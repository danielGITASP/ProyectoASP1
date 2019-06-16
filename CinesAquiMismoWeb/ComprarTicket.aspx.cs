using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinesAquiMismoWeb
{
    public partial class ComprarTicket : System.Web.UI.Page
    {

        Ticket ticket;

        public Ticket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        public bool compra = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToBoolean(Session["logeoU"]))
                {
                    ddlTipoTarjeta.Items.Insert(0, "Elige un tipo de tarjeta");
                    Session["compra"] = false;
                }
                else if (!Convert.ToBoolean(Session["logeoU"]) || Convert.ToBoolean(Session["logeo"]))
                {
                    Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");
                    Response.Redirect("Login.aspx");
                }
            }
            

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if(!Convert.ToBoolean(Session["compra"]))
            {
                if (Page.IsValid)
                {
                    for (int i = 0; i < Convert.ToInt32(txtNumT.Text); i++)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        var stringChars = new char[8];
                        var random = new Random();

                        for (int j = 0; j < stringChars.Length; j++)
                        {
                            stringChars[j] = chars[random.Next(chars.Length)];
                        }

                        var finalString = new String(stringChars);
                        txtVCodigo.Text += finalString + " | ";

                        Session["Ticket"] = new Ticket();
                        ticket = new Ticket(((Ticket)Session["Ticket"]).IdTicket, finalString, DateTime.Now, Convert.ToInt32(Session["idUsu"]));
                        LNyAD.AddTicket(ticket);
                    }
                    Session["compra"] = true;
                }
            }
            else
            {
                Response.Write("<script>alert('CODIGO YA GENERADO')</script>");
            }
                          
        }


        protected void CustomValidatorTarjeta_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtNTarjeta.Text.Length == 16)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            ddlTipoTarjeta.Items.Remove("Elige un tipo de tarjeta");
        }

        protected void CustomValidatorDdlTipo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlTipoTarjeta.SelectedIndex != 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime now = DateTime.Now;
            if(txtFecha.Text == String.Empty || txtFecha.Text == "dd/mm/aa")
            {
                args.IsValid = false;
            }
            else if (Convert.ToDateTime(txtFecha.Text) > now){
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }
    }
}