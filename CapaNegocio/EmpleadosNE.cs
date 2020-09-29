using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEntidad;

using CapaDatos;

namespace CapaNegocio
{
   public class EmpleadosNE
    {
        EmpleadoDAO objemp = new EmpleadoDAO();
        public DataTable TablaEmpleados()
        {
            return objemp.SelectEmpleados();
        }

        public String AgregarEmpleado(EmpleadosE e)
        {
            return objemp.AgregarEmpleados(e);
        }
        public String ActualizarEmpleado(EmpleadosE e)
        {
            return objemp.ActualizarEmpleados(e);
        }

        public int Id_Empleado()
        {
            return objemp.Id_Empleado();
        }

        public EmpleadosE Eliminar_Empleado(int id)
        {
            return objemp.Eliminar_Empleado(id);
        }
        
            public DataTable ListarEmpleadoPorEstado(int id)
        {
            return objemp.ListarEmpleadoPorEstado(id);
        }
    }

    
}
