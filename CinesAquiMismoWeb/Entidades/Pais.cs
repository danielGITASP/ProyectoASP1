using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinesAquiMismoWeb
{
    public class Pais
    {
        int idPais;
        String nombrePais;
        int numVisitas;
        int peliculaId;
        int valoracion;

        public int IdPais { get => idPais; set => idPais = value; }
        public string NombrePais { get => nombrePais; set => nombrePais = value; }
        public int NumVisitas { get => numVisitas; set => numVisitas = value; }
        public int PeliculaId { get => peliculaId; set => peliculaId = value; }
        public int Valoracion { get => valoracion; set => valoracion = value; }

        public Pais()
        {
            IdPais = -1;
            NombrePais = String.Empty;
            NumVisitas = 0;
            PeliculaId = -1;
            Valoracion = 0;
        }

        public Pais(int idPais, string nombrePais, int numVisitas, int peliculaId, int valoracion)
        {
            this.IdPais = idPais;
            this.NombrePais = nombrePais;
            this.NumVisitas = numVisitas;
            this.PeliculaId = peliculaId;
            this.Valoracion = valoracion;
        }

        public Pais(DataSet1.PaisesRow regPais)
        {
            this.IdPais = regPais.idPais;
            this.NombrePais = regPais.NombrePais;
            this.NumVisitas = regPais.NumVisitas;
            this.PeliculaId = regPais.PeliculaId;
            this.Valoracion = regPais.Valoracion;
        }





    }




}
