using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class VentasE
    {
        private int idventa;
        private int idcliente;
        private int idempleado;
        private string fechaventa;
        private double total;
        private string serie;
        private int numero;
        private int idcomprobante;


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
        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
        public string Serie
        {
            get
            {
                return serie;
            }

            set
            {
                serie = value;
            }
        }
        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }
        public int Idcomprobante
        {
            get
            {
                return idcomprobante;
            }

            set
            {
                idcomprobante = value;
            }
        }
        public string Fechaventa
        {
            get
            {
                return fechaventa;
            }

            set
            {
                fechaventa = value;
            }
        }
    }
}
