using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class ProductoE
    {
        private int idproducto;
        private string nombreProducto;
        private int idcategoria;
        private int idproveedor;
        private double precioUnidad;
        private int unidadenExistencia;
        private string presentacion;
        private int idestado;


        public int Idproducto
        {
            get
            {
                return idproducto;
            }

            set
            {
                idproducto = value;
            }
        }
        public string NombreProducto
        {
            get
            {
                return nombreProducto;
            }

            set
            {
                nombreProducto = value;
            }
        }
     

        public int UnidadenExistencia
        {
            get
            {
                return unidadenExistencia;
            }

            set
            {
                unidadenExistencia = value;
            }
        }     
        public int Idproveedor
        {
            get
            {
                return idproveedor;
            }

            set
            {
                idproveedor = value;
            }
        }
        public string Presentacion
        {
            get
            {
                return presentacion;
            }

            set
            {
                presentacion = value;
            }
        }

        public double PrecioUnidad1
        {
            get
            {
                return precioUnidad;
            }

            set
            {
                precioUnidad = value;
            }
        }

        public int Idcategoria
        {
            get
            {
                return idcategoria;
            }

            set
            {
                idcategoria = value;
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
