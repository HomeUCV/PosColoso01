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
namespace Sistema_de_Ventas
{
    public partial class FrmClientes : Form
    {
        ClientesNE obj = new ClientesNE();
     
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            tab_Cliente.DataSource = obj.TablaClientesDisponible();
        }

        private void tablaClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            


        }

        private void TablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tab_Cliente_DoubleClick(object sender, EventArgs e)
        {
            // Reportes_Comprobantes.FRM_comprobante_por_cliente cmm = new Reportes_Comprobantes.FRM_comprobante_por_cliente();
            Documentos cm = new Documentos();


            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "Documentos")
                {
                    cm = (Documentos)frm;
                    cm.txtDatos.Text = tab_Cliente.CurrentRow.Cells[1].Value.ToString() + " " + tab_Cliente.CurrentRow.Cells[2].Value.ToString();
                    cm.txtDocIdentidad.Text = tab_Cliente.CurrentRow.Cells[6].Value.ToString();
                    cm.txtIdcliente.Text = tab_Cliente.CurrentRow.Cells[0].Value.ToString();

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

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
