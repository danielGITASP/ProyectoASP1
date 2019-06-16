using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinesAquiMismoWeb
{
    public class Cine
    {

        int idCine;
        String nombreCine;
        String zona;


        public Cine()
        {
            idCine = -1;
            nombreCine = String.Empty;
            zona = String.Empty;
        }

        public Cine(int idCine, string nombreCine, string zona)
        {
            this.idCine = idCine;
            this.nombreCine = nombreCine;
            this.zona = zona;
        }


        public Cine(DataSet1.CinesRow regCine)
        {
            this.idCine = regCine.idCine;
            this.nombreCine = regCine.NombreCine;
            this.zona = regCine.Zona;
        }

        #region Propiedades

        public int IdCine
        {
            get
            {
                return idCine;
            }

            set
            {
                idCine = value;
            }
        }

        public string NombreCine
        {
            get
            {
                return nombreCine;
            }

            set
            {
                nombreCine = value;
            }
        }

        public string Zona
        {
            get
            {
                return zona;
            }

            set
            {
                zona = value;
            }
        }


        #endregion
    }
}
