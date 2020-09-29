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
namespace Sistema_de_Ventas
{
    public partial class RegistrarCliente : Form
    {
        ClientesNE objCliente = new ClientesNE();
        ClientesE c = new ClientesE();
        public RegistrarCliente()
        {
            InitializeComponent();
        }

        public void AgregarCliente()
        {
            string men = "";
            c.Idcliente = int.Parse(txtCodigo.Text);
            c.NomCliente = txtNombre.Text;
            c.ApeCliente = txtapellidos.Text;
            c.DirCliente = txtDireccion.Text;
            c.Dni = txtDni.Text;
            c.Email = txtemail.Text;
            c.Telefono = txtTelefono.Text;

           men= objCliente.AgregarCliente(c);
            MessageBox.Show(men);

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            AgregarCliente();
            
            FrmClientes cli = new FrmClientes();
            cli.Show();
            this.Hide();
        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {
           txtCodigo.Text =  objCliente.ID_Cliente().ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¡Salir?","Aviso",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            } 
           
        }
    }
}
