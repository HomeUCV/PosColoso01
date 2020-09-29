using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using CapaEntidad;

using CapaNegocio;

namespace Sistema_de_Ventas
{
    public partial class FrmProductos : Form
    {
        ProductosNE obj = new ProductosNE();
        ProductoE parametro = new ProductoE();
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            tab_Producto.DataSource = obj.TablaProducto();
            tab_Producto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tab_Producto.ReadOnly = true;     
        }

        private void tablaProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {         
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtNombrepro.Text;
            tab_Producto.DataSource = obj.BuscarPorNombre(nombre);         
        }

        private void tablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tab_Producto_DoubleClick(object sender, EventArgs e)
        {
            Documentos cm = new Documentos();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "Documentos")
                {

                    cm = (Documentos)frm;
                    cm.txtNombrePro.Text = tab_Producto.CurrentRow.Cells[1].Value.ToString();
                    cm.txtStock.Text = tab_Producto.CurrentRow.Cells[6].Value.ToString();
                    cm.txtprecio.Text = tab_Producto.CurrentRow.Cells[3].Value.ToString();
                    cm.txtidProducto.Text = tab_Producto.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                    break;
                }
            }
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {

        }
    }
}
