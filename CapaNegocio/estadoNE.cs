using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class estadoNE
    {
        estadoDAO estadoDAO = new estadoDAO();
        public DataTable Tablaestado()
        {
            return estadoDAO.Tablaestado();
        }
    }

}
