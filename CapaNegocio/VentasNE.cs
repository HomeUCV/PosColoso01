using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
   public class VentasNE
    {
        VentasDAO objventas = new VentasDAO();

        public String Registrarventas(VentasE v)
        {
            return objventas.RegistrarVenta(v);
        }

        public int ID_Venta()
        {
            return objventas.ID_Venta();
        }

        public int Correlaito()
        {
            return objventas.Correlativo();
        }
    }
}
