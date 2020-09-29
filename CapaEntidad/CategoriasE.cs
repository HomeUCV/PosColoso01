using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class CategoriasE
    {
        private int idcategoria;
        private String nombrecategoria;
        private String descripcion;

        public int Idcategoria
        {
            get
            {
                return idcategoria;
            }

            set
            {
                idcategoria = value;
            }
        }

        public string Nombrecategoria
        {
            get
            {
                return nombrecategoria;
            }

            set
            {
                nombrecategoria = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}
