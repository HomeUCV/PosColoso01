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
   public class CategoriasDAO
    {
        Conexion cn = new Conexion();
        SqlCommand cmd;

        public DataTable tablaCategorias()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select c.idcategoria[ID],c.nombrecategoria[Categorias],c.descripcion[Descripcion] from categorias[c] select c.idcategoria[ID],c.nombrecategoria[Categorias],c.descripcion[Descripcion] from categorias[c] order by idcategoria desc", cn.conectar_db());
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        public int ID_Categoria()
        {
            int codigo = 0;
            cmd = new SqlCommand("ID_Categoria", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                codigo = (int)(dr[0]);
            }
            return codigo;

        }
        public DataTable TablaCategorias()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select c.idcargo[ID],c.nombreCargo[Cargo],c.descripcion[Descripción] from cargo[c]", cn.conectar_db());
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public String AgregarCategoria(CategoriasE cat)
        {
            string mensaje = "";
            cmd = new SqlCommand();
            cmd.CommandText = "AgregarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn.conectar_db();
            cmd.Parameters.AddWithValue("@id", cat.Idcategoria);
            cmd.Parameters.AddWithValue("@nombre", cat.Nombrecategoria);
            cmd.Parameters.AddWithValue("@des", cat.Descripcion);
            int fila = cmd.ExecuteNonQuery();
            if (fila > 0)
            {
                mensaje = "Datos ingresados correctamente";
            }
            else
            {
                mensaje = "No se puede agregar el cargo";
            }
            return mensaje;
        }
        public String ActualizarCategoria(CategoriasE cat)
        {
            string mensaje = "";
            cmd.CommandText = "ActualizarCategoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn.conectar_db();
            cmd.Parameters.AddWithValue("@id", cat.Idcategoria);
            cmd.Parameters.AddWithValue("@nombre", cat.Nombrecategoria);
            cmd.Parameters.AddWithValue("@des", cat.Descripcion);
            int fila = cmd.ExecuteNonQuery();
            if (fila > 0)
            {
                mensaje = "Los datos de actualizaron correctamente";
            }
            else
            {
                mensaje = "No se actualizaron los datos";
            }
            return mensaje;

        }
        public CategoriasE EliminarCategoria(int id)
        {
            CategoriasE cat = new CategoriasE();
            cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarCategoria";
                cmd.Connection = cn.conectar_db();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            return cat;
        }
        public DataTable BuscarCategoria(string nombre)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select c.idcargo[ID],c.nombreCargo[Cargo],c.descripcion[Descripción] from cargo[c] where nombreCargo like '" + nombre + "%'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn.conectar_db();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

    }
}
