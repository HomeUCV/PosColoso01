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

using CapaNegocio;
using CapaEntidad;
namespace Sistema_de_Ventas
{
    public partial class MCategorias : Form
    {
        CategoriasNE obj = new CategoriasNE();
        CategoriasE cat= new CategoriasE();

        public MCategorias()
        {
            InitializeComponent();
        }

        public void ID_Categorias()
        {
            txtidCategoria.Text = obj.ID_CAtegoria().ToString();
        }
        public void TablaCategorias()
        {
            tablaCategorias1.DataSource = obj.listaCategorias();
        }
        public void AgregarCategoria()
        {
            string mensaje = "";

            cat.Idcategoria =int.Parse(txtidCategoria.Text);
            cat.Nombrecategoria = txtNombreCat.Text;
            cat.Descripcion = txtdesc.Text;

            mensaje = obj.AgregarCategorias(cat);

            MessageBox.Show(mensaje);

        }
        public void ActualizarCategoria()
        {
            string mensaje = "";

            cat.Idcategoria = int.Parse(txtidCategoria.Text);
            cat.Nombrecategoria = txtNombreCat.Text;
            cat.Descripcion = txtdesc.Text;

            mensaje = obj.ActualizarCategoria(cat);

            MessageBox.Show(mensaje);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MCategorias_Load(object sender, EventArgs e)
        {
            ID_Categorias();
            CajasDeshabilitadas();
            TablaCategorias();
            lblTotalregistro.Text = tablaCategorias1.Rows.Count.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTotalregistro_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //admite solo letras
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombreCat.Text != "")
            {
                if (txtdesc.Text != "")
                {
                  
                    AgregarCategoria();
                    TablaCategorias();
                    ID_Categorias();
                    limpiar();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Escribe una descripcion para la categoria");
                }
            }
            else
            {
                MessageBox.Show("Escribe el nombre de la categoria");
            }
            


        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            ActualizarCategoria();
            TablaCategorias();
            ID_Categorias();

            limpiar();


            btnEliminar.Enabled = false;
            btnmodificar.Enabled = false;

            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtidCategoria.Text);

            if (MessageBox.Show("Eliminar","",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                CategoriasE c = new CategoriasE();
               
                c=obj.EliminarCategoria(id);

                TablaCategorias();
                lblTotalregistro.Text = tablaCategorias1.Rows.Count.ToString();
                ID_Categorias();
                limpiar();

                btnEliminar.Enabled = false;
                btnmodificar.Enabled = false;

                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;

            }
        }

        private void tablaCategorias_DoubleClick(object sender, EventArgs e)
        {
          
        }

        public void limpiar()
        {
            txtNombreCat.Clear();
            txtdesc.Clear();
        }
        public void CajasDeshabilitadas()
        {
            txtNombreCat.Enabled = false;
            txtdesc.Enabled = false;
        }
        public void CajasHabilitadas()
        {
            txtNombreCat.Enabled = true;
            txtdesc.Enabled = true; 
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            TablaCategorias();
            CajasHabilitadas();
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            
            ID_Categorias();
            limpiar();

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnmodificar.Enabled = false;
        }

        private void tablaCategorias1_MouseMove(object sender, MouseEventArgs e)
        {
           

        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void tablaCategorias1_DoubleClick(object sender, EventArgs e)
        {
            txtidCategoria.Text = tablaCategorias1.CurrentRow.Cells[0].Value.ToString();
            txtNombreCat.Text = tablaCategorias1.CurrentRow.Cells[1].Value.ToString();
            txtdesc.Text = tablaCategorias1.CurrentRow.Cells[2].Value.ToString();

            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;
            btnmodificar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}
