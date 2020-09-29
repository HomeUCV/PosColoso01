using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaConexion;

using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
   public class ReportesDAO
    {

        Conexion cn = new Conexion();
        SqlCommand cmd;

        public DataTable Llenardatagrid(int id)
        {
            cmd = new SqlCommand("ReporteVentas",cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.Parameters.AddWithValue("@id",id);
            da.Fill(dt);

            return dt;
        }

        public int UltimoidVenta()
        {
            int ultimo = 0;
           
            cmd = new SqlCommand("select max(idventa) from ventas", cn.conectar_db());
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ultimo = (int)dr[0];
            }

            return ultimo;
        }

        public DataTable BuscarDatos(int id)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("detalles", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
      
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

    }
}
