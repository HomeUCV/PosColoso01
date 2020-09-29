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
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void Consultas_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cliente_por_nombre r = new cliente_por_nombre();
            r.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            empleado_por_Dni r = new empleado_por_Dni();
            r.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Producto_por_categoria r = new Producto_por_categoria();
            r.ShowDialog();
        }
    }
}
