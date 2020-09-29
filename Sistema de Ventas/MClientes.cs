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
    public partial class MClientes : Form
    {
        ClientesNE objClientes = new ClientesNE();
        ClientesE c = new ClientesE();
        estadoNE estado = new estadoNE();

        int idestado = 0;
        public MClientes()
        {
            InitializeComponent();
        }
        public void Comboestado()
        {
            comboCargo.DataSource = estado.Tablaestado();
            comboCargo.DisplayMember = "Nombre";
            comboCargo.ValueMember = "Id";
           
        }

        public void LimpiaCajas()
        {
            //txtCodigo.Clear();
            txtNombre.Clear();
            txtapellidos.Clear();
            txtDireccion.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtemail.Clear();
        }
        public void ID_Cliente()
        {
            txtCodigo.Text = objClientes.ID_Cliente().ToString();
        }
        public void TablaClientes()
        {

            tablacliente.DataSource = objClientes.ListarClientesPorEstado(idestado);
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
            c.Idestado = int.Parse(comboCargo.SelectedValue.ToString());

            men = objClientes.AgregarCliente(c);
            MessageBox.Show(men);
        }
        public void ActualizarCliente()
        {
            string men = "";
            c.Idcliente = int.Parse(txtCodigo.Text);
            c.NomCliente = txtNombre.Text;
            c.ApeCliente = txtapellidos.Text;
            c.DirCliente = txtDireccion.Text;
            c.Dni = txtDni.Text;
            c.Email = txtemail.Text;
            c.Telefono = txtTelefono.Text;
            c.Idestado = int.Parse(comboCargo.SelectedValue.ToString());

            men = objClientes.ActualizarCliente(c);
            MessageBox.Show(men);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MClientes_Load(object sender, EventArgs e)
        {
            idestado = 1;
            Disponibles.Checked = true;
            ID_Cliente();
        
            Comboestado();
            idestado = 1;
            if (Disponibles.Checked == true)
            {
                
                radioButton1.Checked = false;
                TablaClientes();
            }
         

          
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
       
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AgregarCliente();
            TablaClientes();
            LimpiaCajas();
            ID_Cliente();
        }

        private void btnMoficar_Click(object sender, EventArgs e)
        {
            ActualizarCliente();
            TablaClientes();
            LimpiaCajas();
            ID_Cliente();

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;

        }

        private void btnElimimnar_Click(object sender, EventArgs e)
        {
           


                if (btnEliminar.Text == "Habilitar")
                {
                habilidar();
                TablaClientes();
                LimpiaCajas();
                ID_Cliente();

                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;

                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;
            }
                else if (btnEliminar.Text == "Bloquear")
                {
                 blockear();
                TablaClientes();
                LimpiaCajas();
                ID_Cliente();

                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;

                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;
            }


        }

        private void tablaClientes_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ID_Cliente();
            LimpiaCajas();
            
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

        }

       

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            idestado = 2;

            if (radioButton1.Checked == true)
            {
                Disponibles.Checked = false;
                TablaClientes();
                btnEliminar.Text = "Seleccionar";
               
            }
        }

        private void Disponibles_CheckedChanged(object sender, EventArgs e)
        {
            idestado = 1;
            if (Disponibles.Checked == true)
            {
                radioButton1.Checked = false;
                TablaClientes();
                btnEliminar.Text = "Seleccionar";
          
            }

        }
       void habilidar()
        {

            c.Idcliente = int.Parse(txtCodigo.Text);
            c.NomCliente = txtNombre.Text;
            c.ApeCliente = txtapellidos.Text;
            c.DirCliente = txtDireccion.Text;
            c.Dni = txtDni.Text;
            c.Email = txtemail.Text;
            c.Telefono = txtTelefono.Text;
            c.Idestado =1;

            objClientes.ActualizarCliente(c);
            MessageBox.Show("Se Habilito el cliente ahora puede realizar compras");
        }
        void blockear()
        {
            //string men = "";
            c.Idcliente = int.Parse(txtCodigo.Text);
            c.NomCliente = txtNombre.Text;
            c.ApeCliente = txtapellidos.Text;
            c.DirCliente = txtDireccion.Text;
            c.Dni = txtDni.Text;
            c.Email = txtemail.Text;
            c.Telefono = txtTelefono.Text;
            c.Idestado = 2;

            objClientes.ActualizarCliente(c);
            MessageBox.Show("Se Blockeo al cliente no puede realizar compras");
        }

        private void tablacliente_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = tablacliente.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = tablacliente.CurrentRow.Cells[1].Value.ToString();
            txtapellidos.Text = tablacliente.CurrentRow.Cells[2].Value.ToString();
            txtDireccion.Text = tablacliente.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = tablacliente.CurrentRow.Cells[4].Value.ToString();
            txtemail.Text = tablacliente.CurrentRow.Cells[5].Value.ToString();
            txtDni.Text = tablacliente.CurrentRow.Cells[6].Value.ToString();
            comboCargo.Text = tablacliente.CurrentRow.Cells[7].Value.ToString();

            if (comboCargo.Text == "disponible")
            {
                btnEliminar.Text = "Bloquear";
            }
            else if (comboCargo.Text == "no disponible")
            {
                btnEliminar.Text = "Habilitar";
            }

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;

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
    }
}
