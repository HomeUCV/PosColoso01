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
    public partial class Producto_por_categoria : Form
    {
        public Producto_por_categoria()
        {
            InitializeComponent();
        }

        private void Producto_por_categoria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'categoria.categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.categoria.categorias);

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.productos_categoriasTableAdapter.Fill(this.c_producto_por_categoria.productos_categorias,Convert.ToInt32(comboBox1.SelectedValue));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
