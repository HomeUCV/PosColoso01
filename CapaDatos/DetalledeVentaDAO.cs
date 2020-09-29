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
   public class DetalledeVentaDAO
    {
        Conexion cn = new Conexion();
       
        SqlCommand cmd;

        public String RegistrarDetalle(DetalleVenta d)
        {
           
            string mensaje = "";
            cmd = new SqlCommand("RegistrarDetalle",cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idventa", d.Idventa);
            cmd.Parameters.AddWithValue("@idproducto", d.Idproducto);
            cmd.Parameters.AddWithValue("@precio", d.Preciopro);
            cmd.Parameters.AddWithValue("@cantidad", d.Cantidad);
            cmd.Parameters.AddWithValue("@importe", d.Importe); ;
            cmd.Parameters.AddWithValue("@iddetalle", d.Iddetalle);
            int fila = cmd.ExecuteNonQuery();
            if (fila > 0)
            {
                mensaje = "Se realizo la venta exitosamente";
            }
            return mensaje;        
        }

        public int ID_Detalle()
        {
            int codigo = 0;
            cmd = new SqlCommand("Detalle", cn.conectar_db());
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
