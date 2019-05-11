using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioyADatos.Entidades
{
    public class Pelicula
    {
        int idPelicula;
        String nombre;
        double precio;
        int cineId;

        public Pelicula()
        {
            idPelicula = -1;
            nombre = String.Empty;
            precio = 0;
            cineId = -1;
        }

        public Pelicula(int idPelicula, string nombre, double precio, int cineId)
        {
            this.idPelicula = idPelicula;
            this.nombre = nombre;
            this.precio = precio;
            this.cineId = cineId;
        }

        public Pelicula(DataSet1.PeliculasRow regPelicula)
        {
            this.idPelicula = regPelicula.IdPelicula;
            this.nombre = regPelicula.Nombre;
            this.precio = regPelicula.Precio;
            this.cineId = regPelicula.CineId;
        }

        #region Propiedades
        public int IdPelicula
        {
            get
            {
                return idPelicula;
            }

            set
            {
                idPelicula = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public double Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public int CineId
        {
            get
            {
                return cineId;
            }

            set
            {
                cineId = value;
            }
        }
        #endregion

    }
}
