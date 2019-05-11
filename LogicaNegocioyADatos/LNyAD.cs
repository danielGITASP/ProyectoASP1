using LogicaNegocioyADatos.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocioyADatos.Entidades;

namespace LogicaNegocioyADatos
{
    public class LNyAD
    {
        static UsuariosTableAdapter usuariosAdapter = new UsuariosTableAdapter();
        static DataSet1.UsuariosDataTable usuariosTabla = new DataSet1.UsuariosDataTable();

        static PeliculasTableAdapter peliculasAdapter = new PeliculasTableAdapter();
        static DataSet1.PeliculasDataTable peliculasTabla = new DataSet1.PeliculasDataTable();

        static CinesTableAdapter cinesAdapter = new CinesTableAdapter();
        static DataSet1.CinesDataTable cinesTabla = new DataSet1.CinesDataTable();

        static PaisesTableAdapter paisesAdapter = new PaisesTableAdapter();
        static DataSet1.PaisesDataTable paisesTabla = new DataSet1.PaisesDataTable();

        static TicketsTableAdapter ticketsAdapter = new TicketsTableAdapter();
        static DataSet1.TicketsDataTable ticketsTabla = new DataSet1.TicketsDataTable();


        //METODOS DE PELICULAS
        public static List<Cine> ListaCines()
        {
            List<Cine> listaCines = new List<Cine>();

            cinesTabla = cinesAdapter.GetData();
            foreach (DataSet1.CinesRow g in cinesTabla)
                listaCines.Add(new Cine(g));

            return listaCines;
        }

        public static DataSet1.PeliculasDataTable TablaPelis(int idCine)
        {
            if(idCine == 0)
            {
                peliculasTabla = peliculasAdapter.GetDataByCartelera();
            }else
            {
                peliculasTabla = peliculasAdapter.GetDataByCineId(idCine);
            }

            return peliculasTabla;
        }

        public static DataSet1.PeliculasDataTable TablaNombres(int idCine, string Nombre)
        {
            if (idCine == 0)
            {
                peliculasTabla = peliculasAdapter.GetDataByCartelera();
            }
            else
            {
                peliculasTabla = peliculasAdapter.GetDataByNombre(Nombre, idCine);
            }

            return peliculasTabla;
        }



        public static DataSet1.PeliculasDataTable TablaNombres2(string nombre)
        {
           peliculasTabla = peliculasAdapter.GetDataByNombre2(nombre);
            

            return peliculasTabla;
        }


        public static void EliminarPelicula(int idPelicula)
        {
            DataSet1.PeliculasRow regPelicula = peliculasTabla.FindByIdPelicula(idPelicula);
            regPelicula.Delete();

            peliculasAdapter.Update(peliculasTabla);
            peliculasTabla.AcceptChanges();

        }

        public static bool PeliculaRepetida(string nombre, int cb)
        {
            bool hayError = false;

            String titulo;
            int cine;
            peliculasTabla = peliculasAdapter.GetData();

            for (int i = 0; i < peliculasTabla.Rows.Count; i++)
            {
                titulo = peliculasTabla[i].Nombre.ToString();
                cine = peliculasTabla[i].CineId;

                if (nombre.Trim() == titulo.Trim() && cine == cb)
                {
                    hayError = true;
                }
            }

            return hayError;
        }

        private static object Mayus(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public static void AddPelicula(Pelicula peli)
        {
            DataSet1.PeliculasRow regPelicula = peliculasTabla.FindByIdPelicula(peli.IdPelicula);
            regPelicula = peliculasTabla.NewPeliculasRow();

            regPelicula.Nombre = peli.Nombre;
            regPelicula.Precio = peli.Precio;
            regPelicula.CineId = peli.CineId;

            peliculasTabla.AddPeliculasRow(regPelicula);

            peliculasAdapter.Update(regPelicula);
            peliculasTabla.AcceptChanges();
        }


        public static void ModificaPelicula(Pelicula peli)
        {
            DataSet1.PeliculasRow regPelicula = peliculasTabla.FindByIdPelicula(peli.IdPelicula);

            regPelicula.Nombre = peli.Nombre;
            regPelicula.Precio = peli.Precio;
            regPelicula.CineId = peli.CineId;

            peliculasAdapter.Update(regPelicula);
            peliculasTabla.AcceptChanges();
        }

        public static Pelicula DevuelvePelicula(int idPelicula)
        {
            DataSet1.PeliculasRow regPelicula = peliculasTabla.FindByIdPelicula(idPelicula);

            return new Pelicula(idPelicula, regPelicula.Nombre, regPelicula.Precio, regPelicula.CineId);
        }


        //METODOS DE CINES

        public static DataSet1.CinesDataTable TablaCines(int idZona, String Zona)
        {
            if (idZona == 0)
            {
                cinesTabla = cinesAdapter.GetData();
            }
            else
            {
                cinesTabla = cinesAdapter.GetDataByZona(Zona);
            }

            return cinesTabla;
        }


        public static bool CineRepetido(string nombre, string zona)
        {
            bool hayError = false;

            String nombreC;
            String zonaC;
            cinesTabla = cinesAdapter.GetData();

            for (int i = 0; i < cinesTabla.Rows.Count; i++)
            {
                nombreC = cinesTabla[i].Nombre_Cine;
                zonaC = cinesTabla[i].Zona;

                if (nombre == nombreC && zonaC == zona)
                {
                    hayError = true;
                }
            }

            return hayError;
        }


        public static Cine DevuelveCine(int idCine)
        {
            DataSet1.CinesRow regCine = cinesTabla.FindByIdCine(idCine);

            return new Cine(idCine, regCine.Nombre_Cine, regCine.Zona);
        }

        public static void EliminarCine(int idCine)
        {
            DataSet1.CinesRow regCine = cinesTabla.FindByIdCine(idCine);
            regCine.Delete();

            cinesAdapter.Update(cinesTabla);
            cinesTabla.AcceptChanges();
        }

        public static void AddCine(Cine cine)
        {
            DataSet1.CinesRow regCine = cinesTabla.FindByIdCine(cine.IdCine);
            regCine = cinesTabla.NewCinesRow();

            regCine.Nombre_Cine = cine.NombreCine;
            regCine.Zona = cine.Zona;

            cinesTabla.AddCinesRow(regCine);

            cinesAdapter.Update(regCine);
            cinesTabla.AcceptChanges();
        }

        public static void ModificaCine(Cine cine)
        {
            DataSet1.CinesRow regCine = cinesTabla.FindByIdCine(cine.IdCine);

            regCine.Nombre_Cine = cine.NombreCine;
            regCine.Zona = cine.Zona;

            cinesAdapter.Update(regCine);
            cinesTabla.AcceptChanges();
        }

        //METODOS DE USUARIOS 

        public static Usuario DevuelveUsuario(int IdUsuario)
        {
            DataSet1.UsuariosRow regUsuario = usuariosTabla.FindByIdUsuario(IdUsuario);

            return new Usuario(IdUsuario, regUsuario.Nombre, regUsuario.Password, regUsuario.Alias, regUsuario.Login, regUsuario.Acceso, regUsuario.TipoAcceso,  regUsuario.Movil, regUsuario.Email);
        }

        public static bool UsuariosRepetido(string nombreU, string alias, string login)
        {
            bool hayError = false;

            String nombre;
            String aliasU;
            String loginU;
            usuariosTabla = usuariosAdapter.GetData();

            for (int i = 0; i < usuariosTabla.Rows.Count; i++)
            {
                nombre = usuariosTabla[i].Nombre;
                aliasU = usuariosTabla[i].Alias;
                loginU = usuariosTabla[i].Login;

                if (nombre == nombreU && alias == aliasU && login == loginU)
                {
                    hayError = true;
                }
            }

            return hayError;
        }

        public static void EliminarUsuario(int idUsu)
        {
            DataSet1.UsuariosRow regUsuario = usuariosTabla.FindByIdUsuario(idUsu);
            regUsuario.Delete();

            usuariosAdapter.Update(usuariosTabla);
            usuariosTabla.AcceptChanges();
        }

        public static void AddUsuario(Usuario usuario)
        {
            DataSet1.UsuariosRow regUsuario = usuariosTabla.FindByIdUsuario(usuario.IdUsuario);
            regUsuario = usuariosTabla.NewUsuariosRow();

            regUsuario.Nombre = usuario.Nombre;
            regUsuario.Password = usuario.Password;
            regUsuario.Alias = usuario.Alias;
            regUsuario.Login = usuario.Login;
            regUsuario.Acceso = Convert.ToByte(usuario.Acceso);
            regUsuario.TipoAcceso = usuario.TipoAcceso;
            regUsuario.Movil = usuario.Movil1;
            regUsuario.Email = usuario.Email1;

            usuariosTabla.AddUsuariosRow(regUsuario);

            usuariosAdapter.Update(regUsuario);
            usuariosTabla.AcceptChanges();
        }

        public static void ModificaUsuario(Usuario usuario)
        {
            DataSet1.UsuariosRow regUsuario = usuariosTabla.FindByIdUsuario(usuario.IdUsuario);

            regUsuario.Nombre = usuario.Nombre;
            regUsuario.Password = usuario.Password;
            regUsuario.Alias = usuario.Alias;
            regUsuario.Login = usuario.Login;
            regUsuario.Acceso = Convert.ToByte(usuario.Acceso);
            regUsuario.TipoAcceso = usuario.TipoAcceso;
            regUsuario.Movil = usuario.Movil1;
            regUsuario.Email = usuario.Email1;

            usuariosAdapter.Update(regUsuario);
            usuariosTabla.AcceptChanges();
        }

        public static DataSet1.UsuariosDataTable TablaUsuarios(int idAcceso, string acceso)
        {
            if (idAcceso == 0)
            {
                usuariosTabla = usuariosAdapter.GetData();
            }
            else
            {
                usuariosTabla = usuariosAdapter.GetDataByTipoAcceso(acceso);
            }

            return usuariosTabla;
        }

        //Metodos de Paises

        public static List<Pais> ListaPaises()
        {
            List<Pais> listaPais = new List<Pais>();

            paisesTabla = paisesAdapter.GetData();
            foreach (DataSet1.PaisesRow g in paisesTabla)
                listaPais.Add(new Pais(g));

            return listaPais;
        }

        public static DataSet1.PaisesDataTable TablaPaises(int idPais)
        {
            if (idPais == 0)
            {
                paisesTabla = paisesAdapter.GetDataByPaises();
            }
            else
            {
                paisesTabla = paisesAdapter.GetDataByIdPais(idPais);
            }

            return paisesTabla;
        }

        public static Pais DevuelvePais(int idPais)
        {
            DataSet1.PaisesRow regPais = paisesTabla.FindByIdPais(idPais);

            return new Pais(idPais, regPais.NombrePais, regPais.NumVisitas, regPais.PeliculaId, regPais.Valoracion);
        }

        public static void EliminarPais(int idPais)
        {
            DataSet1.PaisesRow regPais = paisesTabla.FindByIdPais(idPais);
            regPais.Delete();

            paisesAdapter.Update(paisesTabla);
            paisesTabla.AcceptChanges();
        }

        public static void ModificaPais(Pais pais)
        {
            DataSet1.PaisesRow regPais = paisesTabla.FindByIdPais(pais.IdPais);

            regPais.NombrePais = pais.NombrePais;
            regPais.NumVisitas = pais.NumVisitas;
            //regPais.Pelicula = pais.
            regPais.PeliculaId = pais.PeliculaId;
            regPais.Valoracion = pais.Valoracion;

            paisesAdapter.Update(regPais);
            paisesTabla.AcceptChanges();
        }

        public static void AddPais(Pais pais)
        {
            DataSet1.PaisesRow regPais = paisesTabla.FindByIdPais(pais.IdPais);
            regPais = paisesTabla.NewPaisesRow();

            regPais.NombrePais = pais.NombrePais;
            regPais.NumVisitas = pais.NumVisitas;
            //regPais.Pelicula = pais.
            regPais.PeliculaId = pais.PeliculaId;
            regPais.Valoracion = pais.Valoracion;

            paisesTabla.AddPaisesRow(regPais);

            paisesAdapter.Update(regPais);
            paisesTabla.AcceptChanges();
        }


        public static List<Pelicula> ListaPelis()
        {
            List<Pelicula> listaPelis = new List<Pelicula>();

            peliculasTabla = peliculasAdapter.GetData();
            foreach (DataSet1.PeliculasRow g in peliculasTabla)
                listaPelis.Add(new Pelicula(g));

            return listaPelis;
        }

        //TICKETS

        public static Ticket DevuelveTicket(int idTicket)
        {
            ticketsTabla = ticketsAdapter.GetData();
            DataSet1.TicketsRow regTicket = ticketsTabla.FindByIdTicket(idTicket);

            return new Ticket(regTicket.IdTicket, regTicket.Codigo, regTicket.Fecha, regTicket.UsuarioId);
        }

        public static List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaUsu = new List<Usuario>();

            usuariosTabla = usuariosAdapter.GetData();
            foreach (DataSet1.UsuariosRow g in usuariosTabla)
                listaUsu.Add(new Usuario(g));

            return listaUsu;
        }

        public static void ModificaTicket(Ticket ticket)
        {
            DataSet1.TicketsRow regTicket = ticketsTabla.FindByIdTicket(ticket.IdTicket);

            regTicket.IdTicket = ticket.IdTicket;
            regTicket.Codigo = ticket.Codigo;
            regTicket.Fecha = ticket.Fecha;
            regTicket.UsuarioId = ticket.UsuarioId;

            ticketsAdapter.Update(regTicket);
            ticketsTabla.AcceptChanges();
        }

        public static void EliminarTicket(int idTicket)
        {
            ticketsAdapter.DeleteTicket(idTicket);

            ticketsAdapter.Update(ticketsTabla);
            ticketsTabla.AcceptChanges();
        }


        public static void AddTicket(Ticket ticket)
        {
            DataSet1.TicketsRow regTicket = ticketsTabla.FindByIdTicket(ticket.IdTicket);
            regTicket = ticketsTabla.NewTicketsRow();

            regTicket.Codigo = ticket.Codigo;
            regTicket.Fecha = ticket.Fecha;
            regTicket.UsuarioId = ticket.UsuarioId;

            ticketsTabla.AddTicketsRow(regTicket);

            ticketsAdapter.Update(regTicket);
            ticketsTabla.AcceptChanges();
        }


    }
}
