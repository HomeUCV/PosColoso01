using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using CapaConexion;

namespace CapaDatos
{
    public class BackupDAO
    {

        Conexion cn = new Conexion();
        SqlCommand cmd;
        public String BackupeMinimarket()
        {
            string mensaje = "";

            try
            {

                cmd = new SqlCommand();

                cmd.CommandText = "bacukp";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn.conectar_db();

                cmd.ExecuteNonQuery();
                mensaje = "Copia de seguridad completa realizada";
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }


            return mensaje;


        }
    }
}
