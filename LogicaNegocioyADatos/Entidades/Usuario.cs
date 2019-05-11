using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioyADatos.Entidades
{
    public class Usuario
    {

        int idUsuario;
        String nombre;
        String password;
        String alias;
        String login;
        int acceso;
        String tipoAcceso;
        int Movil;
        string Email;


        public Usuario()
        {
            idUsuario = -1;
            nombre = String.Empty;
            password = String.Empty;
            alias = String.Empty;
            login = String.Empty;
            acceso = 1;
            tipoAcceso = String.Empty;
            Movil1 = -1;
            Email1 = String.Empty;
        }

        public Usuario(int idUsuario, string nombre, string password, string alias, string login, int acceso, string tipoAcceso, int movil, string email)
        {
            this.IdUsuario = idUsuario;
            this.Nombre = nombre;
            this.Password = password;
            this.Alias = alias;
            this.Login = login;
            this.Acceso = acceso;
            this.tipoAcceso = tipoAcceso;
            this.Movil1 = movil;
            this.Email1 = email;
        }

        public Usuario(DataSet1.UsuariosRow regUsuario)
        {
            this.IdUsuario = regUsuario.IdUsuario;
            this.Nombre = regUsuario.Nombre;
            this.Password = regUsuario.Password;
            this.Alias = regUsuario.Alias;
            this.Login = regUsuario.Login;
            this.Acceso = regUsuario.Acceso;
            this.tipoAcceso = regUsuario.TipoAcceso;
            this.Movil1 = regUsuario.Movil;
            this.Email1 = regUsuario.Email;
        }

        #region Propiedades
        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }

        public string TipoAcceso
        {
            get
            {
                return tipoAcceso;
            }

            set
            {
                tipoAcceso = value;
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

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Alias
        {
            get
            {
                return alias;
            }

            set
            {
                alias = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public int Acceso
        {
            get
            {
                return acceso;
            }

            set
            {
                acceso = value;
            }
        }

        public int Movil1 { get => Movil; set => Movil = value; }
        public string Email1 { get => Email; set => Email = value; }

        #endregion




    }

}