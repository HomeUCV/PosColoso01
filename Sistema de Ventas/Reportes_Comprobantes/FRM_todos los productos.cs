using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Ventas.Reportes_Comprobantes
{
    public partial class FRM_todos_los_productos : Form
    {
        public FRM_todos_los_productos()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FRM_todos_los_productos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DS_totos_los_productos.productos_Vendidos' Puede moverla o quitarla según sea necesario.
            this.productos_VendidosTableAdapter.Fill(this.DS_totos_los_productos.productos_Vendidos);

            this.reportViewer1.RefreshReport();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
