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
namespace Sistema_de_Ventas
{
    public partial class ReporteVentas : Form
    {
        ReportesNE reportes = new ReportesNE();
       
        public ReporteVentas()
        {
            InitializeComponent();
        }
        public void BuscarDatos()
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                dt = reportes.BuscarDatos(id);

                if (dt.Rows.Count > 0)
                {
                    lblidventa.Text = dt.Rows[0][0].ToString();
                    lblCliente.Text = dt.Rows[0][1].ToString();
                    lblfechaVenta.Text = dt.Rows[0][2].ToString();
                    lbldireccion.Text = dt.Rows[0][3].ToString();
                    lblvendedor.Text = dt.Rows[0][4].ToString();
                }
                else
                {
                    MessageBox.Show("No existe el codigo de venta");
                }
            }
           
               
        }
        public void llenardatagrid()
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                tab_detalle.DataSource = reportes.llenardatagrid(id);

                double sum = 0;
                foreach (DataGridViewRow row in tab_detalle.Rows)
                {
                    sum += Convert.ToDouble(row.Cells[3].Value);
                }

                label21.Text = sum.ToString("00.00");
            }
            else
            {
                MessageBox.Show("Engrese número de id de venta");
            }
          
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenardatagrid();
            BuscarDatos();
           
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            int ultimo = reportes.Ultimiidventa();
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);

                if (id < ultimo)
                {
                    id += 1;
                    textBox1.Text = id.ToString();
                    llenardatagrid();
                    BuscarDatos();
                }
                else
                {
                    MessageBox.Show("es la ultima venta: " + ultimo);
                }
            }
            else
            {
                MessageBox.Show("Escriba el numero de id de venta");
            }
                  
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            id -= 1;
            if (id > 0)
            {         
                textBox1.Text = id.ToString();
                llenardatagrid();
                BuscarDatos();
            }
            else
            {
                MessageBox.Show("1 es el id minimo de la venta");
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            int id = 1;   
            textBox1.Text = id.ToString();
            llenardatagrid();
            BuscarDatos();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            int ultimo = reportes.Ultimiidventa();      
            textBox1.Text = ultimo.ToString();
            llenardatagrid();
            BuscarDatos();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

          
            int  numero = int.Parse(textBox1.Text);
            if (numero >= 1)
            {

                  

                    Reportes_Comprobantes.FRM_comprobantes frm = new Reportes_Comprobantes.FRM_comprobantes();
            frm.Idventa = Convert.ToInt32(this.textBox1.Text);
            frm.ShowDialog();
            }
           
            }
            catch
            {
                errorProvider1.Clear();
                if (textBox1.Text.Trim().Equals(""))
                {
                    errorProvider1.SetError(textBox1, "Debe ingresar un numero para imprimir");
                    textBox1.Focus();
                    return;
                }
                
            }
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
