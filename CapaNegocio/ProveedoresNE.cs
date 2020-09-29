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
    public class ProveedoresNE
    {
        ProveedorDAO objproveedor = new ProveedorDAO();

        public DataTable ListarProveedores()
        {
            return objproveedor.ListadeProveedores();
        }

        public DataTable Tablaproveedores()
        {
            return objproveedor.TablaProveedores();
        }
        public int ID_Proveedor()
        {
            return objproveedor.ID_Proveedor();
        }
        public String AgregarProveedor(ProveedoresE pro)
        {
            return objproveedor.AgregarProvedor(pro);
        }

        public String ActualizarProveedor(ProveedoresE pro)
        {
            return objproveedor.ActualizarProveedor(pro);

        }
        public ProveedoresE Eliminar_Proveedor(int id)
        {
            return objproveedor.Eliminar_Proveedor(id);
        }

        public DataTable ListarProveedoresPorEstado(int id)
        {
            return objproveedor.ListarProveedoresPorEstado(id);
        }
    }
}
