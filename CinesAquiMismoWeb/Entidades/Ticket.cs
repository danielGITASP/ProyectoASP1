using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinesAquiMismoWeb
{
    public class Ticket
    {
        int idTicket;
        string codigo;
        DateTime fecha;
        int usuarioId;

        public int IdTicket { get => idTicket; set => idTicket = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int UsuarioId { get => usuarioId; set => usuarioId = value; }

        public Ticket()
        {
            idTicket = -1;
            codigo = String.Empty;
            fecha = DateTime.MinValue;
            usuarioId = -1;
        }

        public Ticket(int idTicket, string codigo, DateTime fecha, int usuarioId)
        {
            this.idTicket = idTicket;
            this.codigo = codigo;
            this.fecha = fecha.Date;
            this.usuarioId = usuarioId;
        }

        public Ticket(DataSet1.TicketsRow regTicket)
        {
            this.idTicket = regTicket.idTicket;
            this.codigo = regTicket.Codigo;
            this.fecha = regTicket.Fecha.Date;
            this.usuarioId = regTicket.UsuarioId;
        }





    }



}
