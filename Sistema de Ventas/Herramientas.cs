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
    public partial class Herramientas : Form
    {
        BackupNE bak = new BackupNE();
        public Herramientas()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Copia_Click(object sender, EventArgs e)
        {
            String mensaje = "";

            mensaje = bak.Backup_Minimarket();

            MessageBox.Show("" + mensaje);

        }

        private void Restahurar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
