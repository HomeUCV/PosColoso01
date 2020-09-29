using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Ventas
{
    public partial class Mantenimiento : Form
    {
        public Mantenimiento()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            MProductos productos = new MProductos();
            productos.ShowDialog();
            
        }

        private void Mantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MClientes cliente = new MClientes();
            cliente.ShowDialog();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            MEmpleados empleados = new MEmpleados();
            empleados.ShowDialog();
        }

        private void btnCargos_Click(object sender, EventArgs e)
        {
            MCargos cargos = new MCargos();
            cargos.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            MCategorias categorias = new MCategorias();
            categorias.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            MUsuarios usuarios = new MUsuarios();
            usuarios.ShowDialog();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            Mproveedores usuarios = new Mproveedores();
            usuarios.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
