using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using CapaEntidad;
using CapaConexion;

namespace CapaDatos
{
   
   public class estadoDAO

    {

        Conexion cn = new Conexion();
        SqlCommand cmd;

        public DataTable Tablaestado()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select e.idestado[Id],e.nombreestado[Nombre] from estado[e]", cn.conectar_db());
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
