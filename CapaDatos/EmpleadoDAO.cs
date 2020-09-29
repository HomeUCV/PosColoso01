using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using CapaConexion;
using CapaEntidad;

namespace CapaDatos
{
   public class EmpleadoDAO
    {
       
       
        Conexion cn = new Conexion();
        SqlCommand cmd;
        public DataTable SelectEmpleados()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("TablaEmpleados", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public int Id_Empleado()
        {
            int codigo = 0;
            cmd = new SqlCommand("ID_Empleado", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                codigo = (int)(dr[0]);
            }

            return codigo;

        }
        public String AgregarEmpleados(EmpleadosE e)
        {
            string mensaje = "";
            cmd = new SqlCommand("AgregarEmpleado", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id",e.Idempleado);
            cmd.Parameters.AddWithValue("@apellidos", e.Apellidos);
            cmd.Parameters.AddWithValue("@nombres", e.Nombres);
            cmd.Parameters.AddWithValue("@fechanac", e.Fechanac);
            cmd.Parameters.AddWithValue("@dereccion", e.Direccion);
            cmd.Parameters.AddWithValue("@telefono", e.Telefono);
            cmd.Parameters.AddWithValue("@cargo", e.Cargo);
            cmd.Parameters.AddWithValue("@dni", e.Dni);
            cmd.Parameters.AddWithValue("@idestado", e.Idestado);



            int fila = cmd.ExecuteNonQuery();

            if (fila > 0)
            {
                mensaje = "Empleado registrado";
            }
            return mensaje;
        }
        public String ActualizarEmpleados(EmpleadosE e)
        {
            string mensaje = "";
            cmd = new SqlCommand("ActualizarEmpleado", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", e.Idempleado);
            cmd.Parameters.AddWithValue("@apellidos", e.Apellidos);
            cmd.Parameters.AddWithValue("@nombres", e.Nombres);
            cmd.Parameters.AddWithValue("@fechanac", e.Fechanac);
            cmd.Parameters.AddWithValue("@dereccion", e.Direccion);
            cmd.Parameters.AddWithValue("@telefono", e.Telefono);
            cmd.Parameters.AddWithValue("@cargo", e.Cargo);
            cmd.Parameters.AddWithValue("@dni", e.Dni);
            cmd.Parameters.AddWithValue("@idestado", e.Idestado);

            int fila = cmd.ExecuteNonQuery();

            if (fila > 0)
            {
                mensaje = "Empleado actualizado";
            }
            return mensaje;
        }
        public EmpleadosE Eliminar_Empleado(int id)
        {
            EmpleadosE emp = new EmpleadosE();
            cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarEmpleado";
                cmd.Connection = cn.conectar_db();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            return emp;
        }

       
            public DataTable ListarEmpleadoPorEstado(int id)
         {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select e.IdEmpleado[Id], e.Apellidos[Apellidos], e.Nombre[Nombre], e.FechaNacimiento[Nacimiento], e.direccion[Direccion], e.telefono[Telefono], c.nombreCargo[Cargo], e.dni[Dni], es.nombreestado[Estado] from empleados[e] inner join cargo[c] on e.cargo= c.idcargo    inner join estado[es] on e.idestado= es.idestado where es.idestado= '" + id + "'");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn.conectar_db();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    
   }
}
