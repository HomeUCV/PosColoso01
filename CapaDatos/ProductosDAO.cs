using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

using System.Data;
using System.Data.SqlClient;

using CapaConexion;

namespace CapaDatos
{
    public class ProductosDAO
    {
        Conexion cn = new Conexion();
        SqlCommand cmd;

        public int ID_Producto()
        {
            int codigo = 0;
            cmd = new SqlCommand("ID_Producto", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                codigo = (int)(dr[0]);
            }

            return codigo;

        }
        public DataTable TablaPRoductos()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("ListarProductos", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;

        }
        public DataTable BuscarPorletra(string nombre)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select p.idproducto[ID],p.nombreProducto[Producto],p.presentacion[Presentación], p.precioUnidad[Precio],pro.nombreCompañia[Proveedor],c.nombrecategoria[Categoría], p.stock[Stock] ,e.nombreestado[Estado] from productos[p] inner join proveedores[pro] on pro.idProveedor = p.idProveedor inner join categorias[c] on c.idcategoria = p.idCategoria   inner join estado[e] on p.idestado=e.idestado   where nombreProducto like '" + nombre + "%' order by idproducto desc");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn.conectar_db();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public String AgregarProducto(ProductoE p)
        {
            string mensaje = "";
            cmd = new SqlCommand("AgregarProducto", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", p.Idproducto);
            cmd.Parameters.AddWithValue("@nombre", p.NombreProducto);
            cmd.Parameters.AddWithValue("@idproveedor", p.Idproveedor);
            cmd.Parameters.AddWithValue("@idcategoria", p.Idcategoria);
            cmd.Parameters.AddWithValue("@presentacion", p.Presentacion);
            cmd.Parameters.AddWithValue("@precio", p.PrecioUnidad1);
            cmd.Parameters.AddWithValue("@stock", p.UnidadenExistencia);
            cmd.Parameters.AddWithValue("@idestado", p.Idestado);

            int fila = cmd.ExecuteNonQuery();

            if (fila == 1)
            {
                mensaje = "El  Producto de agrego correctamente";
            }
            return mensaje;

        }

        public String ActualizarProducto(ProductoE p)
        {
            string mensaje = "";
            cmd = new SqlCommand("ActualizarProducto", cn.conectar_db());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", p.Idproducto);
            cmd.Parameters.AddWithValue("@nombre", p.NombreProducto);
            cmd.Parameters.AddWithValue("@idproveedor", p.Idproveedor);
            cmd.Parameters.AddWithValue("@idcategoria", p.Idcategoria);
            cmd.Parameters.AddWithValue("@presentacion", p.Presentacion);
            cmd.Parameters.AddWithValue("@precio", p.PrecioUnidad1);
            cmd.Parameters.AddWithValue("@stock", p.UnidadenExistencia);
            cmd.Parameters.AddWithValue("@idestado", p.Idestado);

            int fila = cmd.ExecuteNonQuery();

            if (fila == 1)
            {
                mensaje = "Se actualizaron los datos correctamente";
            }
            return mensaje;

        }

        public ProductoE Eliminar_Producto(int id)
        {
            ProductoE pro = new ProductoE();
            cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from productos where idproducto = @id";
                cmd.Connection = cn.conectar_db();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            return pro;
        }
        public DataTable ListarProductosPorEstado(int id)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select p.idproducto[ID],p.nombreProducto[Producto],p.presentacion[Presentación], p.precioUnidad[Precio], pro.nombreCompañia[Proveedor], c.nombrecategoria[Categoría], p.stock[Stock], e.nombreestado[Estado] from productos[p] inner join proveedores[pro] on pro.idProveedor = p.idProveedor inner join categorias[c] on c.idcategoria = p.idCategoria inner join estado[e] on p.idestado=e.idestado where p.idestado ='" + id+"' order by idproducto desc");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn.conectar_db();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
