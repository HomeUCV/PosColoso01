using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Coloso.Configuracion
{
    public partial class ConfiguracionBD : Form
    {
        public ConfiguracionBD()
        {
            InitializeComponent();
        }

        private void ConfiguracionBD_Load(object sender, EventArgs e)
        {
            CargarData();
        }
        private void CargarData()
        {
            // se pinta los valores de la configurcion de la BD por defecto a las Caja de texto.
            //txtServerHost.Text = Settings.Default.ServidorHost;
            //txtDatabase.Text = Settings.Default.BaseDatos;
            //txtUserName.Text = Settings.Default.UsuarioBD;
            //txtPassword.Text = Settings.Default.ContraseñaBD;
            //txtPort.Text = Settings.Default.PuertoBD;

        }
        bool mouseDown; //boolean for mousedown
        Point lastLocation; //variable for the last location of the mouse

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
             mouseDown = true; //sets mousedown to true
             lastLocation = e.Location; //gets the location of the form and sets it to lastlocation
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false; //sets mousedown to false
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) //if mouseDown is true, point to the last location of the mouse
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y); //gets the coordinates of the location of the mouse
                this.Update(); //updates the location of the mouse

            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void ConfiguracionBD_FormClosed(object sender, FormClosedEventArgs e)
        {
            string valor = e.CloseReason.ToString();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
