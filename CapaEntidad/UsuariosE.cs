using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class UsuariosE
    {
        private int idusuario;
        private int idempleado;
        private string usuario;
        private string password;
        private string nomusuario;
        private string apeusuario;
        private int cargo;
     

        public int Idusuario
        {
            get
            {
                return idusuario;
            }

            set
            {
                idusuario = value;
            }
        }
        public int Idempleado
        {
            get
            {
                return idempleado;
            }

            set
            {
                idempleado = value;
            }
        }
        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
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
        public string Nomusuario
        {
            get
            {
                return nomusuario;
            }

            set
            {
                nomusuario = value;
            }
        }
        public string Apeusuario
        {
            get
            {
                return apeusuario;
            }

            set
            {
                apeusuario = value;
            }
        }
        public int Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }


    }
}
