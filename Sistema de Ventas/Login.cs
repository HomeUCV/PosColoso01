using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using CapaNegocio;
using CapaEntidad;

namespace Sistema_de_Ventas
{
    public partial class Login : Form
    {

        UsuariosE usuarioParam = new UsuariosE();
        UsuariosNE objUsuario = new UsuariosNE();
        int cont;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                txtpassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = false;
            }
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

           
        }
            
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                txtpassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = false;
            }


        }

        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text.Trim() != "")
            {
                if (txtpassword.Text.Trim() != "")
                {

                    string result = string.Empty;
                    byte[] encryted = System.Text.Encoding.Unicode.GetBytes(txtpassword.Text.Trim());
                    result = Convert.ToBase64String(encryted);
                    /*
                     string result = string.Empty;
                    byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
                    //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                    result = System.Text.Encoding.Unicode.GetString(decryted);    
                    // MessageBox.Show("dato: "+result,"Aviso");
                    */
                    DataTable dt = new DataTable();
                    usuarioParam.Usuario = txtusuario.Text;
                    usuarioParam.Password = result;

                    dt = objUsuario.Login(usuarioParam);

                    if (dt.Rows.Count > 0)
                    {

                        string cargo = "", nombre = "", apellidos = "";
                        int idEmpleado = 0;

                        cargo = dt.Rows[0][5].ToString();
                        idEmpleado = int.Parse(dt.Rows[0][2].ToString());
                        nombre = dt.Rows[0][3].ToString();
                        apellidos = dt.Rows[0][4].ToString();

                        Program.Id_Empleado = idEmpleado.ToString();

                        if (MessageBox.Show("Ingreso al sistema", "Bienvenido Sr(a): " + nombre + " " + apellidos, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            this.Hide();
                            MenuPrincipal principal = new MenuPrincipal(cargo, nombre, apellidos, idEmpleado);
                            principal.Show();

                        }

                    }
                    else
                    {
                        cont++;
                        int intentos = 3;
                        intentos = intentos - cont;
                        MessageBox.Show("Datos incorrectos, te quedan: " + intentos + " intentos", "Error");

                        if (intentos == 0)
                        {
                            MessageBox.Show("Se agotaron sus intentos, El sistema se cerrará", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Falta ingresar la contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("El campo usuario esta vacío, Todos los campos son abligatoris", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
