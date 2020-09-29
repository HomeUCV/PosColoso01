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
    public class CargoDAO
    {
        Conexion cn = new Conexion();
        SqlCommand cmd;
        public int Id_Cargo()
        {
            int codigo = 0;
            cmd = new SqlCommand("Id_Cargo", cn.conectar_db());
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
            cmd  = new SqlCommand("select c.idcargo[ID],c.nombreCargo[Cargo],c.descripcion[Descripción] from cargo[c]", cn.conectar_db());
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public String AgregarCargos(CargoE cargo)
        {
            string mensaje = "";
            cmd = new SqlCommand();
            cmd.CommandText = "AgregarCargo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn.conectar_db();
            cmd.Parameters.AddWithValue("@id", cargo.Idcargo);
            cmd.Parameters.AddWithValue("@nombre", cargo.Nombre);
            cmd.Parameters.AddWithValue("@descripcion",cargo.Descripcion);
            int fila = cmd.ExecuteNonQuery();
            if (fila > 0)
            {
                mensaje = "Datos ingresados correctamente";
            }else
            {
                mensaje = "No se puede agregar el cargo";
            }
            return mensaje;
        }
        public String ActualizarCargo(CargoE cargo)
        {
            string mensaje = "";
            cmd = new SqlCommand("ActualizarCargo", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", cargo.Idcargo);
            cmd.Parameters.AddWithValue("@nombre", cargo.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", cargo.Descripcion);
            int fila = cmd.ExecuteNonQuery();
            if (fila > 0)
            {
                mensaje = "Los datos de actualizaron correctamente";
            }else
            {
                mensaje = "No se actualizaron los datos";
            }
            return mensaje;

        }
        public CargoE Eliminar_Cargo(int id)
        {
            CargoE cargo = new CargoE();
            cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from cargo where idcargo = @id";
                cmd.Connection = cn.conectar_db();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            return cargo;
        }
        public DataTable BuscarCargo(string nombre)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select c.idcargo[ID],c.nombreCargo[Cargo],c.descripcion[Descripción] from cargo[c] where nombreCargo like '"+nombre +"%'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn.conectar_db();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
