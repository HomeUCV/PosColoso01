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
    public partial class FRM_comprobante_por_cliente : Form
    {
        string cliente;
        public FRM_comprobante_por_cliente()
        {
            InitializeComponent();
        }

        private void FRM_comprobante_por_cliente_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.DodgerBlue;
                cliente = textBox1.Text;
            // TODO: esta línea de código carga datos en la tabla 'DS_reporte_por_empleadoclientes.Reporte_por_Cliente' Puede moverla o quitarla según sea necesario.
            this.Reporte_por_ClienteTableAdapter.Fill(this.DS_reporte_por_empleadoclientes.Reporte_por_Cliente,cliente);
            this.reportViewer1.RefreshReport();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "Buscar")
            {
                FrmClientes frmClientes = new FrmClientes();
                frmClientes.ShowDialog();

                button1.Text = "Ver";
                button1.BackColor = Color.Lime;
            }
            else if(button1.Text == "Ver")
            {
                cliente = textBox1.Text;
                // TODO: esta línea de código carga datos en la tabla 'DS_reporte_por_empleadoclientes.Reporte_por_Cliente' Puede moverla o quitarla según sea necesario.
                this.Reporte_por_ClienteTableAdapter.Fill(this.DS_reporte_por_empleadoclientes.Reporte_por_Cliente, cliente);
                this.reportViewer1.RefreshReport();
                button1.Text = "Buscar";
                button1.BackColor = Color.DodgerBlue;

            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
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
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (button1.Text == "Buscar")
            {
                FrmClientes frmClientes = new FrmClientes();
                frmClientes.ShowDialog();

                button1.Text = "Ver";
                button1.BackColor = Color.Lime;
            }
            else if (button1.Text == "Ver")
            {
                cliente = textBox1.Text;
                // TODO: esta línea de código carga datos en la tabla 'DS_reporte_por_empleadoclientes.Reporte_por_Cliente' Puede moverla o quitarla según sea necesario.
                this.Reporte_por_ClienteTableAdapter.Fill(this.DS_reporte_por_empleadoclientes.Reporte_por_Cliente, cliente);
                this.reportViewer1.RefreshReport();
                button1.Text = "Buscar";
                button1.BackColor = Color.DodgerBlue;

            }

        }
    }
}
