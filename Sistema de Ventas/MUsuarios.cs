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
    public partial class MUsuarios : Form
    {
        UsuariosNE objUsuario = new UsuariosNE();
        EmpleadosNE objemp = new EmpleadosNE();
        UsuariosE u = new UsuariosE();
        public MUsuarios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void MUsuarios_Load(object sender, EventArgs e)
        {
            tablauser.DataSource = objUsuario.TablaUsuariosDisponibles();
            lblregistro.Text = tablauser.Rows.Count.ToString();
            LlenarCombo();
        }

        public void LlenarCombo()
        {
            idEmpleado.DataSource = objUsuario.ComboUsuario();
            idEmpleado.DisplayMember = "Nombres y Apellidos";
            idEmpleado.ValueMember = "ID";
        }

        public void LimpiarCajasdeTexto()
        {
            txtIdusuario.Clear();
            idEmpleado.Text = "";
            txtusuario.Clear();
            txtContraseña.Clear();
            txtRepiteContra.Clear();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(txtContraseña.Text);
            result = Convert.ToBase64String(encryted);

            string mensaje = "";
            u.Idusuario = int.Parse(txtIdusuario.Text);
            u.Idempleado = int.Parse(idEmpleado.SelectedValue.ToString());
            u.Usuario = txtusuario.Text;
            u.Password = result;

            mensaje = objUsuario.AgregarUsuario(u);
            MessageBox.Show(mensaje,"Aviso");

            tablauser.DataSource = objUsuario.TablaUsuariosDisponibles();
            LlenarCombo();
            LimpiarCajasdeTexto();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCajasdeTexto();
            LlenarCombo();
          
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo letras
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
