using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
namespace Sistema_de_Ventas.Reportes_Comprobantes
{
    public partial class FrmEmpleados : Form
    {
        EmpleadosNE objEmp = new EmpleadosNE();


        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void Tablaempleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            TablaEmpleados();
        }
        public void TablaEmpleados()
        {
            tab_empelado.DataSource = objEmp.TablaEmpleados();
        }

        private void Tablaempleado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FRM_ventas_por_empleado cmm = new FRM_ventas_por_empleado();


            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "FRM_ventas_por_empleado")
                {
                    cmm = (FRM_ventas_por_empleado)frm;
                    cmm.textBox1.Text = tab_empelado.CurrentRow.Cells[1].Value.ToString() + " " + tab_empelado.CurrentRow.Cells[2].Value.ToString();
                    //cmm.txtDatos.Text= tablaClientes.CurrentRow.Cells[1].Value.ToString() + " " + tablaClientes.CurrentRow.Cells[2].Value.ToString();

                    this.Close();
                    break;
                }
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnl_titu_MouseHover(object sender, EventArgs e)
        {

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
