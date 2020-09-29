using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class ReportesNE
    {
        ReportesDAO reporte = new ReportesDAO();
        public DataTable llenardatagrid(int id)
        {
            return reporte.Llenardatagrid(id);
        }
        public int Ultimiidventa()
        {
            return reporte.UltimoidVenta();
        }

        public DataTable BuscarDatos(int id)
        {
            return reporte.BuscarDatos(id);
        }
    }
}
