using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class DetalleVenta
    {
        private int idventa;
        private int idproducto;
        private double preciopro;
        private int cantidad;
        private double importe;
        private int iddetalle;


        public int Idventa
        {
            get
            {
                return idventa;
            }

            set
            {
                idventa = value;
            }
        }
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

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }
        public double Importe
        {
            get
            {
                return importe;
            }

            set
            {
                importe = value;
            }
        }
        public int Iddetalle
        {
            get
            {
                return iddetalle;
            }

            set
            {
                iddetalle = value;
            }
        }

        public double Preciopro
        {
            get
            {
                return preciopro;
            }

            set
            {
                preciopro = value;
            }
        }
    }
}
