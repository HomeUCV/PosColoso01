using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class DetalleVentasNE
    {
        DetalledeVentaDAO objdetalle = new DetalledeVentaDAO();

        public String RegistrarDetalle(DetalleVenta d)
        {
            return objdetalle.RegistrarDetalle(d);
        }

        public int Id_Detalle()
        {
            return objdetalle.ID_Detalle();
        }
    }
}
