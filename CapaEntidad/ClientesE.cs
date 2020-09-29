using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
   public class ClientesE
    {
        private int idcliente;
        private String nomCliente;
        private String apeCliente;
        private String dirCliente;
        private String telefono;
        private String email;
        private String dni;
        private int idestado;

        public string NomCliente
        {
            get
            {
                return nomCliente;
            }

            set
            {
                nomCliente = value;
            }
        }
        public string ApeCliente
        {
            get
            {
                return apeCliente;
            }

            set
            {
                apeCliente = value;
            }
        }
        public string DirCliente
        {
            get
            {
                return dirCliente;
            }

            set
            {
                dirCliente = value;
            }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }
        
        public int Idcliente
        {
            get
            {
                return idcliente;
            }

            set
            {
                idcliente = value;
            }
        }

        public string Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public int Idestado
        {
            get
            {
                return idestado;
            }

            set
            {
                idestado = value;
            }
        }
    }
}
