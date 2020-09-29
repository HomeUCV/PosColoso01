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
    public class CategoriasNE
    {
        CategoriasDAO objCategorias = new CategoriasDAO();
       public DataTable listaCategorias()
        {
            return objCategorias.tablaCategorias();
        }

        public int ID_CAtegoria()
        {
            return objCategorias.ID_Categoria();
        }
        public String AgregarCategorias(CategoriasE c)
        {
            return objCategorias.AgregarCategoria(c);
        }

        public String ActualizarCategoria(CategoriasE c)
        {
            return objCategorias.ActualizarCategoria(c);
        }

        public CategoriasE EliminarCategoria(int id)
        {
            return objCategorias.EliminarCategoria(id);
        }
    }
}
