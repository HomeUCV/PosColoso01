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
    public partial class Loader : Form
    {
        int contador = 0;
        public Loader()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Loader_Load(object sender, EventArgs e)
        {
           
            timer1.Start();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            contador++;
         
            circularProgressBar.Value = contador;
            circularProgressBar.Text ="Cargando... "+ contador + " %";
            if (contador == 100)
            {
                timer1.Stop();
               
             
                this.Hide();
                //MessageBox.Show("Minimarket La Fortuna");
                Login l = new Login();
                l.Show();
            }

        }
    }
}
