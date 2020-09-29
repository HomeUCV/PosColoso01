using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaConexion;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public class ProveedorDAO
    {

        Conexion cn = new Conexion();
        SqlCommand cmd;
        public DataTable ListadeProveedores()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select idproveedor[ID],nombreCompañia[Compañia] from proveedores where idestado=1", cn.conectar_db());
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        public DataTable TablaProveedores()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select * from proveedores", cn.conectar_db());
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        public String AgregarProvedor(ProveedoresE pro)
        {
            string mensaje = "";
            cmd = new SqlCommand("AgregarProveedor", cn.conectar_db());
           // cmd.CommandText = "AgregarProveedor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", pro.IdProveedor);
            cmd.Parameters.AddWithValue("@compañia", pro.NombreCompañia);
            cmd.Parameters.AddWithValue("@contacto", pro.NombreContacto);
            cmd.Parameters.AddWithValue("@cargo", pro.CargoContacto);
            cmd.Parameters.AddWithValue("@direccion", pro.Direccion);
            cmd.Parameters.AddWithValue("@ciudad", pro.Ciudad);
            cmd.Parameters.AddWithValue("@region", pro.Region);
            cmd.Parameters.AddWithValue("@telefono", pro.Telefono);
            cmd.Parameters.AddWithValue("@pagina", pro.Pagina);
            cmd.Parameters.AddWithValue("@idestado", pro.Idestado);

            int fila = cmd.ExecuteNonQuery();

            if (fila > 0 )
            {
                mensaje = "Agregado correctamente";
            }

            return mensaje;
        }
        public String ActualizarProveedor(ProveedoresE pro)
        {
            string mensaje = "";
            cmd = new SqlCommand("ActualizarProveedor", cn.conectar_db());
            // cmd.CommandText = "AgregarProveedor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", pro.IdProveedor);
            cmd.Parameters.AddWithValue("@compañia", pro.NombreCompañia);
            cmd.Parameters.AddWithValue("@contacto", pro.NombreContacto);
            cmd.Parameters.AddWithValue("@cargo", pro.CargoContacto);
            cmd.Parameters.AddWithValue("@direccion", pro.Direccion);
            cmd.Parameters.AddWithValue("@ciudad", pro.Ciudad);
            cmd.Parameters.AddWithValue("@region", pro.Region);
            cmd.Parameters.AddWithValue("@telefono", pro.Telefono);
            cmd.Parameters.AddWithValue("@pagina", pro.Pagina);
            cmd.Parameters.AddWithValue("@idestado", pro.Idestado);

            int fila = cmd.ExecuteNonQuery();

            if (fila > 0)
            {
                mensaje = "Actualizado correctamente";
            }

            return mensaje;
        }
        public int ID_Proveedor()
        {
            int codigo = 0;
            cmd = new SqlCommand("ID_Proveedor", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                codigo = (int)(dr[0]);
            }

            return codigo;

        }

        public ProveedoresE Eliminar_Proveedor(int id)
        {
            ProveedoresE cargo = new  ProveedoresE();
            cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarProveedor";
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

        public DataTable ListarProveedoresPorEstado(int id)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select pro.idProveedor[Id],pro.nombreCompañia[Nombre Compañia],pro.cargocontacto[Nombre Contacto],pro.cargocontacto[Cargo contacto],pro.direccion[Direccion],pro.ciudad[Ciudad],pro.region[Region],pro.telefono[Telefono],pro.paginaprincipal[Sitio WEB],e.nombreestado[Estado] from proveedores [pro] inner join estado[e] on pro.idestado=e.idestado where e.idestado='" + id+"'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn.conectar_db();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
