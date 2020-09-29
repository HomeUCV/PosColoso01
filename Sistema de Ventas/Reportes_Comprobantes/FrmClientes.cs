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
namespace Sistema_de_Ventas.Reportes_Comprobantes
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
            tab_Clienta.DataSource = obj.TablaClientesDisponible();
        }

        private void tablaClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           FRM_comprobante_por_cliente cmm = new FRM_comprobante_por_cliente();
          

            foreach (Form frm in Application.OpenForms)
            {
                if(frm.Name == "FRM_comprobante_por_cliente")
                {
                    cmm = (FRM_comprobante_por_cliente)frm;
                   cmm.textBox1.Text = tab_Clienta.CurrentRow.Cells[1].Value.ToString() +" "+ tab_Clienta.CurrentRow.Cells[2].Value.ToString();
                    //cmm.txtDatos.Text= tablaClientes.CurrentRow.Cells[1].Value.ToString() + " " + tablaClientes.CurrentRow.Cells[2].Value.ToString();

                    this.Close();
                    break;
                }
            }
          

        }

        private void TablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
