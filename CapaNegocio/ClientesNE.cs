using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
  public class ClientesNE
    {
        ClientesDAO objcliente = new ClientesDAO();

        public DataTable ListaClientes()
        {
            return objcliente.TablaClientes();
        }
        public int ID_Cliente()
        {
            return objcliente.ID_Cliente();
        }
        public String ActualizarCliente(ClientesE c)
        {
            return objcliente.ActualizarCliente(c);
        }
        public String AgregarCliente(ClientesE c)
        {
            return objcliente.AgregarCliente(c);
        }
        public ClientesE EliminarCliente(int id)
        {
            return objcliente.EliminarCliente(id);
        }
        public DataTable TablaClientesDisponible()
        {
            return objcliente.TablaClientesDisponible();
        }
        public DataTable ListarClientesPorEstado(int id)
        {
            return objcliente.ListarClientesPorEstado(id);

        }

    }
}
