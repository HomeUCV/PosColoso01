using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Ventas
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal(string cargo, string nombre, string apellidos, int idEmpleado)
        {
            InitializeComponent();
            this.cargo = cargo;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idEmpleado = idEmpleado;
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {
            if (PanelLateral.Width == 247)
            {
                PanelLateral.Width = 40;
                PicUser_2.Visible = true;
            }
            else
            {
                PanelLateral.Width = 247;
                PicUser.Visible = true;
                PicUser_2.Visible = false;
            }
        }

        string cargo, nombre, apellidos;
        int idEmpleado;
   

        public void ValidarCargo()
        {
            if (cargo == "Cajero")
            {
                lbl_Rol.Text = cargo;
                lbl_user.Text = nombre + " " + apellidos;
                //btnManto.Enabled = false;
                //btnConsultas.Enabled = false;
                //btnHerramientas.Enabled = false;

            }
            else if (cargo == "Administrador")
            {
                lbl_Rol.Text = cargo;
                lbl_user.Text = nombre + " " + apellidos;
                //lblCargo.Text = cargo;
                ////btnDocumentos.Enabled = false;
                //lblNombre.Text = nombre + " " + apellidos;
            }
            else if (cargo == "Gerente")
            {
                lbl_Rol.Text = cargo;
                lbl_user.Text = nombre + " " + apellidos;
            }

            else if (cargo == "Contador")
            {
                lbl_Rol.Text = cargo;
                lbl_user.Text = nombre + " " + apellidos;
                //lblCargo.Text = cargo;
                ////btnManto.Enabled = false;
                ////btnDocumentos.Enabled = false;
                ////btnHerramientas.Enabled = false;

                //lblNombre.Text = nombre + " " + apellidos;

            }
        }
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelCEntarl.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelCEntarl.Controls.Add(formulario);
                panelCEntarl.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de la aplicación", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            //if (Application.OpenForms["Mantenimiento"] == null)
            //    btnManto.BackColor = Color.DeepSkyBlue;
            //if (Application.OpenForms["Consultas"] == null)
            //    btnConsultas.BackColor = Color.DeepSkyBlue;
            //if (Application.OpenForms["Documentos"] == null)
            //    btnDocumentos.BackColor = Color.DeepSkyBlue;
            //if (Application.OpenForms["Reportes"] == null)
            //    btnResportes.BackColor = Color.DeepSkyBlue;
            //if (Application.OpenForms["Herramientas"] == null)
            //    btnHerramientas.BackColor = Color.DeepSkyBlue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FechaActual();
            HoraAcrual();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string tiempo;
            tiempo = lblhora.Text;
            if (tiempo.Equals("11:01:00"))
            {
                MessageBox.Show("es la hora loca");
            }
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            ValidarCargo();
        }

        private void bt_compras_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Mantenimiento>();
            //btnManto.BackColor = Color.Blue;
            //btnDocumentos.BackColor = Color.DeepSkyBlue;
            //btnConsultas.BackColor = Color.DeepSkyBlue;
            //btnResportes.BackColor = Color.DeepSkyBlue;
            //btnHerramientas.BackColor = Color.DeepSkyBlue;
        }

        private void Bt_cotizar_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Consultas>();
            //btnConsultas.BackColor = Color.Blue;
        }

        private void Bt_ventas_Click(object sender, EventArgs e)
        {
            Documentos r = new Documentos();
            r.ShowDialog();

        }

        private void bt_DocEmitidos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Reportes>();
        }

        private void bt_cliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Herramientas>();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Pnl_Menu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void Bt_EditarCorrelativos_Click(object sender, EventArgs e)
        {

        }

        public void FechaActual()
        {
            DateTime date = DateTime.Today;

            string dia = date.ToString("dddd");
            string fecha = date.ToString("dd");
            string mes = date.ToString("MMMM");
            string year = date.ToString("yyyy");
            lblFecha.Text = dia + ", " + fecha + " de " + mes + " de " + year;
        }
        public void HoraAcrual()
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
