using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaConexion;
using CapaEntidad;

namespace CapaDatos
{
    public class ClientesDAO
    {
        Conexion cn = new Conexion();
        SqlCommand cmd;

        public int ID_Cliente()
        {
            int codigo = 1;
            cmd = new SqlCommand("ID_Cliente", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                codigo = (int)(dr[0]);
            }

            return codigo;
        }
        public ClientesE EliminarCliente(int id)
        {
            ClientesE cargo = new ClientesE();
            cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarCliente";
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
        public DataTable TablaClientes()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("ListarClientes", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        public DataTable TablaClientesDisponible()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("ListarClientesDisponible", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        
        public String AgregarCliente(ClientesE c)
        {
            string mensaje = "";
            try
            {

                cmd = new SqlCommand("AgregarCliente", cn.conectar_db());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", c.Idcliente);
                cmd.Parameters.AddWithValue("@nombres", c.NomCliente);
                cmd.Parameters.AddWithValue("@Direccion", c.DirCliente);
                cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@dni", c.Dni);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@apellidos", c.ApeCliente);
                cmd.Parameters.AddWithValue("@idestado", c.Idestado);

                int fila = cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    mensaje = "Los datos se agregaron correctamente";
                }else
                {
                    mensaje = "el cliente ya se enuentra registrado";
                }

            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }


            return mensaje;
        }
        public String ActualizarCliente(ClientesE c)
        {
            string mensaje = "";
            cmd = new SqlCommand("ActualizarCliente", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", c.Idcliente);
            cmd.Parameters.AddWithValue("@nombres", c.NomCliente);
            cmd.Parameters.AddWithValue("@Direccion", c.DirCliente);
            cmd.Parameters.AddWithValue("@telefono", c.Telefono);
            cmd.Parameters.AddWithValue("@dni", c.Dni);
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@apellidos", c.ApeCliente);
            cmd.Parameters.AddWithValue("@idestado", c.Idestado);

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
       
        public DataTable ListarClientesPorEstado(int id)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select c.idCliente[ID],c.Nombres[Nombres],c.Apellidos[Apellidos], c.Direccion[Dirección], c.Telefono[Teléfono], c.email[Email],c.dni[Documento], e.nombreestado[Estado]  from clientes[c] inner join estado[e] on c.idestado = e.idestado  where c.idestado='" + id + "'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn.conectar_db();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
