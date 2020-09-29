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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReporteVentas r = new ReporteVentas();
            r.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Reportes_Comprobantes.FRM_ventas_diarios r = new Reportes_Comprobantes.FRM_ventas_diarios();
            r.ShowDialog();
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            Reportes_Comprobantes.FRM_ventas_por_empleado r = new Reportes_Comprobantes.FRM_ventas_por_empleado();
            r.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Reportes_Comprobantes.FRM_comprobante_por_cliente r = new Reportes_Comprobantes.FRM_comprobante_por_cliente();
            r.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Reportes_Comprobantes.FRM_todos_los_productos r = new Reportes_Comprobantes.FRM_todos_los_productos();
            r.ShowDialog();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
