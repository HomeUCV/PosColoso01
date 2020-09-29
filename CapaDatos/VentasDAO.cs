using System;
using System.Data.SqlClient;
using System.Data;
using CapaConexion;
using CapaEntidad;

namespace CapaDatos
{
   public class VentasDAO
    {
        Conexion cn = new Conexion();
        SqlCommand cmd; 
        public String RegistrarVenta(VentasE v)
        {
            string mensaje = "";
            cmd = new SqlCommand("RegistrarVenta", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idventa", v.Idventa);
            cmd.Parameters.AddWithValue("@idcliente", v.Idcliente);
            cmd.Parameters.AddWithValue("@idempleado", v.Idempleado);
            cmd.Parameters.AddWithValue("@fechaventa", v.Fechaventa);
            cmd.Parameters.AddWithValue("@total", v.Total);
            cmd.Parameters.AddWithValue("@serie", v.Serie);
            cmd.Parameters.AddWithValue("@numero", v.Numero);
            cmd.Parameters.AddWithValue("@idcomprobante", v.Idcomprobante);
            int fila = cmd.ExecuteNonQuery();
            if (fila  == 1)
            {
                mensaje = "La venta se realizó con éxito";
            }
            else
            {
                mensaje = "No se pudo realizar la venta";
            }
            return mensaje;
        }
        public int ID_Venta()
        {
            int codigo=0;
            cmd = new SqlCommand("Id_Venta", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                codigo = (int)(dr[0]);
            }

            return codigo;
   
        }
        public int Correlativo()
        {
            int codigo = 0;
            cmd = new SqlCommand("Correlativo", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                codigo = (int)(dr[0]);
            }

            return codigo;

        }




    }
}
