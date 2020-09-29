
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaConexion
{
    public class Conexion
    {
        private string cadena = "Server=(local);DataBase=la_fortuna;Integrated Security=True";
        private SqlConnection cn;

        public SqlConnection conectar_db()
        {
            cn = new SqlConnection(cadena);

            if (cn.State == ConnectionState.Open)
            {

                cn.Close();
            }
            else
            {
                cn.Open();
            }

            return cn;

        }

    }
}
