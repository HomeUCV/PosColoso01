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
   public class ProductosNE
    {
        ProductosDAO proDAO = new ProductosDAO();

        public int ID_Producto()
        {
            return proDAO.ID_Producto();
        }
        public DataTable TablaProducto()
        {
            return proDAO.TablaPRoductos();
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            return proDAO.BuscarPorletra(nombre);
        }
        public String AgregarProducto(ProductoE pro)
        {
            return proDAO.AgregarProducto(pro);
        }
        public String ActualizarProducto(ProductoE pro)
        {
            return proDAO.ActualizarProducto(pro);
        }
        public ProductoE Eliminar_Producto(int id)
        {
            return proDAO.Eliminar_Producto(id);
            
        }
        public DataTable ListarProductosPorEstado(int id)
        {
            return proDAO.ListarProductosPorEstado(id);
           
        }
    }
}
