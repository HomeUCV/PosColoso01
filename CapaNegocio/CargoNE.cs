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
   public class CargoNE
    {
        CargoDAO cargoDAO = new CargoDAO();


        public int Id_Cargo()
        {
            return cargoDAO.Id_Cargo();
        }
        public DataTable tablaCargo()
        {
            return cargoDAO.TablaCategorias();
        }

        public String AgregarCargos(CargoE c)
        {
            return cargoDAO.AgregarCargos(c);
        }
        public CargoE EliminarCargo(int cod)
        {
            return cargoDAO.Eliminar_Cargo(cod);
        }
        public String ActualizarCargo(CargoE c)
        {
            return cargoDAO.ActualizarCargo(c);
        }
        public DataTable BuscarCargo(string nombre)
        {
            return cargoDAO.BuscarCargo(nombre);
        }
    }

}
