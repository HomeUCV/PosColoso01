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
    public partial class FRM_ventas_por_empleado : Form
    {
        string empleado;
       
        public FRM_ventas_por_empleado()
        {
            InitializeComponent();
        }

        private void FRM_ventas_por_empleado_Load(object sender, EventArgs e)
        {
            empleado = textBox1.Text;
            button1.BackColor = Color.DodgerBlue;
           
            // TODO: esta línea de código carga datos en la tabla 'DS_por_cliente.Reporte_por_Vendedor' Puede moverla o quitarla según sea necesario.
            this.Reporte_por_VendedorTableAdapter.Fill(this.DS_por_cliente.Reporte_por_Vendedor,empleado);

            this.reportViewer1.RefreshReport();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Buscar")
            {
                FrmEmpleados FrmEmpleado = new FrmEmpleados();
                FrmEmpleado.ShowDialog();

                button1.Text = "Ver";
                button1.BackColor = Color.Lime;
            }
            else if (button1.Text == "Ver")
            {
                empleado = textBox1.Text;
                this.Reporte_por_VendedorTableAdapter.Fill(this.DS_por_cliente.Reporte_por_Vendedor, empleado);
                this.reportViewer1.RefreshReport();
                button1.Text = "Buscar";
                button1.BackColor = Color.DodgerBlue;

            }
           
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (button1.Text == "Buscar")
            {
                FrmEmpleados FrmEmpleado = new FrmEmpleados();
                FrmEmpleado.ShowDialog();

                button1.Text = "Ver";
                button1.BackColor = Color.Lime;
            }
            else if (button1.Text == "Ver")
            {
                empleado = textBox1.Text;
                this.Reporte_por_VendedorTableAdapter.Fill(this.DS_por_cliente.Reporte_por_Vendedor, empleado);
                this.reportViewer1.RefreshReport();
                button1.Text = "Buscar";
                button1.BackColor = Color.DodgerBlue;

            }
        }
    }
}
