using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class ProveedoresE
    {
        private int idProveedor;
        private String nombreCompañia;
        private String nombreContacto;
        private String cargoContacto;
        private String direccion;
        private String ciudad;
        private String region;
        private String codPostal;
        private String pagina;
        private String telefono;
        private int idestado;

        public int IdProveedor
        {
            get
            {
                return idProveedor;
            }

            set
            {
                idProveedor = value;
            }
        }

        public string NombreCompañia
        {
            get
            {
                return nombreCompañia;
            }

            set
            {
                nombreCompañia = value;
            }
        }

        public string NombreContacto
        {
            get
            {
                return nombreContacto;
            }

            set
            {
                nombreContacto = value;
            }
        }

        public string CargoContacto
        {
            get
            {
                return cargoContacto;
            }

            set
            {
                cargoContacto = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return ciudad;
            }

            set
            {
                ciudad = value;
            }
        }

        public string Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
            }
        }

        public string CodPostal
        {
            get
            {
                return codPostal;
            }

            set
            {
                codPostal = value;
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

        public string Pagina
        {
            get
            {
                return pagina;
            }

            set
            {
                pagina = value;
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
