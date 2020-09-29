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
   public class UsuariosNE
    {
        UsiariosDAO objUsuario = new UsiariosDAO();

        public DataTable Login(UsuariosE usuario)
        {
            return objUsuario.IniciarSesion(usuario);
        }

        public String AgregarUsuario(UsuariosE u)
        {
            return objUsuario.AgregarUsuario(u);
        }

        public DataTable ListarUsuarios()
        {
            return objUsuario.TablaUsuarios();
        }
        public DataTable ComboUsuario()
        {
            return objUsuario.ComboUsuario();
        }
        public DataTable TablaUsuariosDisponibles()
        {
            return objUsuario.TablaUsuariosDisponibles();
        }
    }
}
