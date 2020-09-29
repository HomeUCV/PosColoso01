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
  public class UsiariosDAO
    {
        Conexion cn = new Conexion();
        
        SqlCommand cmd;

        public DataTable IniciarSesion(UsuariosE usuario)
        {

            DataTable dt = new DataTable();
            // para hacer un login se hace de esta manera
            SqlCommand cmd = new SqlCommand("IniciarSesion",cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
            cmd.Parameters.AddWithValue("@Contraseña", usuario.Password);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        public String AgregarUsuario(UsuariosE u)
        {
            string mensaje = "";
            cmd = new SqlCommand("insert into usuarios values (@idusuario,@idempleado,@usuario,@contraseña)", cn.conectar_db());
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@idusuario", u.Idusuario);
            cmd.Parameters.AddWithValue("@idempleado", u.Idempleado);
            cmd.Parameters.AddWithValue("@usuario", u.Usuario);
            cmd.Parameters.AddWithValue("@contraseña", u.Password);
            int fila = cmd.ExecuteNonQuery();
            
            if (fila == 1)
            {
                mensaje = "Sea agrego el usuario correctamente";
            }
            return mensaje;
        }
        public DataTable TablaUsuarios()
        {
            DataTable dt = new DataTable();
            // para hacer un login se hace de esta manera
            SqlCommand cmd = new SqlCommand("select e.idempleado[ID],e.Nombre,e.Apellidos,  u.usuario[Usuario] ,u.password[Contraseña] from usuarios[u] right join empleados[e] on e.idempleado = u.idempleado ", cn.conectar_db());
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable ComboUsuario()
        {
            DataTable dt = new DataTable();
            // para hacer un login se hace de esta manera
            SqlCommand cmd = new SqlCommand("select e.IdEmpleado [ID], CONCAT( e.Nombre,+' '+ e.Apellidos ) as [Nombres y Apellidos] from usuarios[u] right join empleados[e] on e.idempleado = u.idempleado where u.usuario is null", cn.conectar_db());
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable TablaUsuariosDisponibles()
        {
            DataTable dt = new DataTable();
            // para hacer un login se hace de esta manera
            SqlCommand cmd = new SqlCommand("select e.idempleado[ID],e.Nombre,e.Apellidos,  u.usuario[Usuario] ,u.password[Contraseña] from usuarios[u] inner join Empleados[e] on u.idempleado = e.IdEmpleado inner join cargo[c] on c.idcargo = e.cargo inner join estado[es] on e.idestado = es.idestado where e.idestado = 1 ", cn.conectar_db());
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
