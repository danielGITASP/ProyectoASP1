using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization;
using CinesAquiMismoWeb.DataSet1TableAdapters;

namespace CinesAquiMismoWeb
{
    public partial class Tickets : System.Web.UI.Page
    {
        static TicketsTableAdapter ticketsAdapter = new TicketsTableAdapter();
        static DataSet1.TicketsDataTable ticketsTabla = new DataSet1.TicketsDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Convert.ToBoolean(Session["logeo"]))
            {
                if (!Page.IsPostBack)
                {
                    CargaTickets();
                }
            }
            else if (!Convert.ToBoolean(Session["logeo"]) || Convert.ToBoolean(Session["logeoU"]))
            {
                Response.Write("<script>alert('NO ACCEDER MEDIANTE URL, USUARIO NO LOGEADO')</script>");

                Response.Redirect("Login.aspx");
            }
        }

        private void CargaTickets()
        {
            string ticket = txtCodigoF.Text;
            if(ticket == "")
            {
                dgvTickets.DataSource = ticketsAdapter.GetData();
            }
            else
            {
                dgvTickets.DataSource = LNyAD.TablaTickets(ticket);
            }

            dgvTickets.DataBind();

            List<Usuario> listaUsuarios = LNyAD.ListaUsuarios();
            int numUsu = listaUsuarios.Count;
            int idU;

            for (int i = 0; i < dgvTickets.Rows.Count; i++)
            {
                string txt = dgvTickets.Rows[i].Cells[3].Text.Substring(0, 10);
                dgvTickets.Rows[i].Cells[3].Text = txt;

                idU = Convert.ToInt32(dgvTickets.Rows[i].Cells[4].Text);

                for (int j = 0; j < listaUsuarios.Count; j++)
                {
                    if (listaUsuarios[j].IdUsuario == idU)
                        
                        dgvTickets.Rows[i].Cells[4].Text = listaUsuarios[j].Nombre;
                }
            }
                       
        }

        protected void dgvTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTicket = Convert.ToInt32(dgvTickets.SelectedRow.Cells[1].Text);
            Ticket ticket = LNyAD.DevuelveTicket(idTicket);

            Session["Ticket"] = ticket;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('TicketsDetalle.aspx','Tickets Detalle','menubar=1,resizable=1,width=900,height=600');", true);
            dgvTickets.SelectedIndex = -1;
        }

        protected void dgvTickets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dgvTickets.SelectedIndex = e.RowIndex;
            MostrarConfirmacion(true);
        }

        private void MostrarConfirmacion(bool mostrado)
        {
            if (mostrado)
            {
                dgvTickets.Enabled = false;
                btnVolver.Visible = false;
                lbConfirmar.Text = "¿Eliminar a " + dgvTickets.SelectedRow.Cells[2].Text + "?";
                btnSi.Visible = true;
                btnNo.Visible = true;
                lbConfirmar.Visible = true;
                btnCines.Visible = false;
                btnUsuarios.Visible = false;
                btnPeliculas.Visible = false;
                btnPaises.Visible = false;
                txtCodigoF.Enabled = false;
            }
            else
            {
                dgvTickets.Enabled = true;
                btnVolver.Visible = true;
                btnSi.Visible = false;
                btnNo.Visible = false;
                lbConfirmar.Visible = false;
                btnCines.Visible = true;
                btnUsuarios.Visible = true;
                btnPeliculas.Visible = true;
                btnPaises.Visible = true;
                txtCodigoF.Enabled = true;

            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int idTicket = Convert.ToInt32(dgvTickets.Rows[dgvTickets.SelectedIndex].Cells[1].Text);
            LNyAD.EliminarTicket(idTicket);

            dgvTickets.SelectedIndex = -1;

            MostrarConfirmacion(false);
            CargaTickets();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            MostrarConfirmacion(false);
            dgvTickets.SelectedIndex = -1;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaTickets();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=Tickets.xls");
            Response.Charset = "";
            Response.ContentType = "application/ms-excel ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            dgvTickets.AllowPaging = false;

            CargaTickets();


            dgvTickets.RenderControl(hw);

            Response.Output.Write(sw.ToString());

            Response.Flush();
            Response.End();
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.AddHeader("content-disposition", "attachment;filename=Tickets.doc");
            Response.ContentType = "application/ms-word ";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            dgvTickets.AllowPaging = false;

            CargaTickets();

            dgvTickets.RenderControl(hw);

            Response.Output.Write(sw.ToString());

            Response.Flush();
            Response.End();
        }


    }
}