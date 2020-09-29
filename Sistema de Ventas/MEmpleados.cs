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
    public partial class MEmpleados : Form
    {
        EmpleadosE emp = new EmpleadosE();
        CargoNE cargo = new CargoNE();
        EmpleadosNE objEmp = new EmpleadosNE();
        estadoNE estado = new estadoNE();

        int idestado = 0;
        public MEmpleados()
        {
            InitializeComponent();
        }

        public void TablaEmpleados()
        {
            tablaempleado.DataSource = objEmp.ListarEmpleadoPorEstado(idestado);
        }
        
        public void ID_Empleado()
        {
            txtCodigo.Text = objEmp.Id_Empleado().ToString();
        }
        public void ComboCargo()
        {
            comboCargo.DataSource = cargo.tablaCargo();
            comboCargo.DisplayMember = "Cargo";
            comboCargo.ValueMember = "ID";
        }
        private void MEmpleados_Load(object sender, EventArgs e)
        {
            
            DeshabilitarCajas();
            ComboCargo();

            txtCodigo.Enabled = false;
            ID_Empleado();


            Comboestado();
            Disponibles.Checked = true;
            idestado = 1;
            if (Disponibles.Checked == true)
            {

                radioButton1.Checked = false;
                TablaEmpleados();
                label2.Text = tablaempleado.Rows.Count.ToString();
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbuscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            //admite solo letras...
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

        private void button3_Click(object sender, EventArgs e)
        {

            if (txtNombres.Text != "")
            {
                if (txtapellidos.Text != "")
                {
                    if (txtdireccion.Text != "")
                    {
                        if (txtDni.Text != "")
                        {
                            if (txtTelefono.Text != "")
                            {
                                string mensaje = "";
                                emp.Idempleado = int.Parse(txtCodigo.Text);
                                emp.Apellidos = txtapellidos.Text;
                                emp.Nombres = txtNombres.Text;
                                emp.Direccion = txtdireccion.Text;
                                emp.Telefono = txtTelefono.Text;
                                emp.Dni = txtDni.Text;
                                emp.Cargo = int.Parse(comboCargo.SelectedValue.ToString());
                                emp.Fechanac = fechanac.Text;
                                emp.Idestado = int.Parse(comboBox1.SelectedValue.ToString());

                                mensaje = objEmp.AgregarEmpleado(emp);

                                MessageBox.Show(mensaje);
                                TablaEmpleados();
                                ID_Empleado();
                                Limpiarajas();

                                btnGuardar.Enabled = false;

                                btnNuevo.Enabled = true;
                                btnMoficar.Enabled = false;
                                btnElimimnar.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Ingrese número de telefono");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese número de DNI");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese dirección");
                    }
                }
               
            
                else
                {
                    MessageBox.Show("Ingrese apellidos de empleado");
                }
            }
            else
            {
                MessageBox.Show("Ingrese nombres de empleado");
            }
          

        }

        // bton guardar
        private void btnMoficar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "")
            {
                if (txtapellidos.Text != "")
                {
                    if (txtdireccion.Text != "")
                    {
                        if (txtDni.Text != "")
                        {
                            if (txtTelefono.Text != "")
                            {
                                string mensaje = "";
                                emp.Idempleado = int.Parse(txtCodigo.Text);
                                emp.Apellidos = txtapellidos.Text;
                                emp.Nombres = txtNombres.Text;
                                emp.Direccion = txtdireccion.Text;
                                emp.Telefono = txtTelefono.Text;
                                emp.Dni = txtDni.Text;
                                emp.Cargo = int.Parse(comboCargo.SelectedValue.ToString());
                                emp.Fechanac = fechanac.Text;
                                emp.Idestado= int.Parse(comboBox1.SelectedValue.ToString());

                                mensaje = objEmp.ActualizarEmpleado(emp);

                                MessageBox.Show(mensaje);
                                TablaEmpleados();
                                Limpiarajas();

                                btnMoficar.Enabled = false;
                                btnElimimnar.Enabled = false;
                                btnGuardar.Enabled = false;
                                btnNuevo.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Ingrese número de telefono");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese número de DNI");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese dirección");
                    }
                }


                else
                {
                    MessageBox.Show("Ingrese apellidos de empleado");
                }
            }
            else
            {
                MessageBox.Show("Ingrese nombres de empleado");
            }
        }

        private void tablaempleado_DoubleClick(object sender, EventArgs e)
        {
           

            
        }

        private void btnElimimnar_Click(object sender, EventArgs e)
        {
          
             
            if (btnElimimnar.Text == "Habilitar")
            {
                habilidar();
                TablaEmpleados();
                Limpiarajas();
                DeshabilitarCajas();

                btnGuardar.Enabled = false;
                btnElimimnar.Enabled = false;
                btnNuevo.Enabled = true;
                btnMoficar.Enabled = false;
            }
            else if (btnElimimnar.Text == "Bloquear")
            {
                blockear();
                TablaEmpleados();
                Limpiarajas();
                DeshabilitarCajas();

                btnGuardar.Enabled = false;
                btnElimimnar.Enabled = false;
                btnNuevo.Enabled = true;
                btnMoficar.Enabled = false;
            }



        }

        public void Limpiarajas()
        {
            txtNombres.Clear();
            txtapellidos.Clear();
            txtdireccion.Clear();
            txtTelefono.Clear();
            txtDni.Clear();
            fechanac.Text = "";
            comboCargo.Text = "";
        }
        public void DeshabilitarCajas()
        {
            txtNombres.ReadOnly = true;
            txtapellidos.ReadOnly = true;
            txtdireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtDni.ReadOnly = true;
            fechanac.Enabled = false;
            comboCargo.Enabled = false;
            comboBox1.Enabled = false;
        }
        public void HabilitarCajasTexto()
        {
            txtNombres.ReadOnly = false;
            txtapellidos.ReadOnly = false;
            txtdireccion.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtDni.ReadOnly = false;
            fechanac.Enabled = true;
            comboCargo.Enabled = true;
            comboBox1.Enabled = true;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiarajas();
            HabilitarCajasTexto();

            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnElimimnar.Enabled = false;
            btnMoficar.Enabled = false;
            ID_Empleado();
        }

        private void tablaempleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ID_Empleado();
            Limpiarajas();
            DeshabilitarCajas();
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnElimimnar.Enabled = false;
            btnMoficar.Enabled = false;
        }

        private void ComboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Disponibles_CheckedChanged(object sender, EventArgs e)
        {
            idestado = 1;
            if (Disponibles.Checked == true)
            {
                radioButton1.Checked = false;
                TablaEmpleados();
                btnElimimnar.Text = "Seleccionar";
               
                label2.Text = tablaempleado.Rows.Count.ToString();
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            idestado = 2;
            if (radioButton1.Checked == true)
            {
                Disponibles.Checked = false;
                TablaEmpleados();
                btnElimimnar.Text = "Seleccionar";
                
                label2.Text = tablaempleado.Rows.Count.ToString();
            }
        }
        void habilidar()
        {
            if (txtNombres.Text != "")
            {
                if (txtapellidos.Text != "")
                {
                    if (txtdireccion.Text != "")
                    {
                        if (txtDni.Text != "")
                        {
                            if (txtTelefono.Text != "")
                            {
                                //string mensaje = "";
                                emp.Idempleado = int.Parse(txtCodigo.Text);
                                emp.Apellidos = txtapellidos.Text;
                                emp.Nombres = txtNombres.Text;
                                emp.Direccion = txtdireccion.Text;
                                emp.Telefono = txtTelefono.Text;
                                emp.Dni = txtDni.Text;
                                emp.Cargo = int.Parse(comboCargo.SelectedValue.ToString());
                                emp.Fechanac = fechanac.Text;
                                emp.Idestado = 1;

                              objEmp.ActualizarEmpleado(emp);

                                MessageBox.Show("se bloqueo al empleaado");
                                TablaEmpleados();
                                Limpiarajas();

                                btnMoficar.Enabled = false;
                                btnElimimnar.Enabled = false;
                                btnGuardar.Enabled = false;
                                btnNuevo.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Ingrese número de telefono");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese número de DNI");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese dirección");
                    }
                }


                else
                {
                    MessageBox.Show("Ingrese apellidos de empleado");
                }
            }
            else
            {
                MessageBox.Show("Ingrese nombres de empleado");
            }





        }
        void blockear()
        {
            if (txtNombres.Text != "")
            {
                if (txtapellidos.Text != "")
                {
                    if (txtdireccion.Text != "")
                    {
                        if (txtDni.Text != "")
                        {
                            if (txtTelefono.Text != "")
                            {
                                //string mensaje = "";
                                emp.Idempleado = int.Parse(txtCodigo.Text);
                                emp.Apellidos = txtapellidos.Text;
                                emp.Nombres = txtNombres.Text;
                                emp.Direccion = txtdireccion.Text;
                                emp.Telefono = txtTelefono.Text;
                                emp.Dni = txtDni.Text;
                                emp.Cargo = int.Parse(comboCargo.SelectedValue.ToString());
                                emp.Fechanac = fechanac.Text;
                                emp.Idestado = 2;

                                objEmp.ActualizarEmpleado(emp);

                                MessageBox.Show("se desbloqueo al empleaado");
                                TablaEmpleados();
                                Limpiarajas();

                                btnMoficar.Enabled = false;
                                btnElimimnar.Enabled = false;
                                btnGuardar.Enabled = false;
                                btnNuevo.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Ingrese número de telefono");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese número de DNI");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese dirección");
                    }
                }


                else
                {
                    MessageBox.Show("Ingrese apellidos de empleado");
                }
            }
            else
            {
                MessageBox.Show("Ingrese nombres de empleado");
            }


        }
        public void Comboestado()
        {
            comboBox1.DataSource = estado.Tablaestado();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";

        }

        private void tablaempleado_DoubleClick_1(object sender, EventArgs e)
        {
            HabilitarCajasTexto();
            txtCodigo.Text = tablaempleado.CurrentRow.Cells[0].Value.ToString();
            txtNombres.Text = tablaempleado.CurrentRow.Cells[2].Value.ToString();
            txtapellidos.Text = tablaempleado.CurrentRow.Cells[1].Value.ToString();
            txtdireccion.Text = tablaempleado.CurrentRow.Cells[4].Value.ToString();
            txtTelefono.Text = tablaempleado.CurrentRow.Cells[5].Value.ToString();
            txtDni.Text = tablaempleado.CurrentRow.Cells[7].Value.ToString();
            comboCargo.Text = tablaempleado.CurrentRow.Cells[6].Value.ToString();
            fechanac.Text = tablaempleado.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = tablaempleado.CurrentRow.Cells[8].Value.ToString();

            if (comboBox1.Text == "disponible")
            {
                btnElimimnar.Text = "Bloquear";
            }
            else if (comboBox1.Text == "no disponible")
            {
                btnElimimnar.Text = "Habilitar";
            }
            btnMoficar.Enabled = true;
            btnElimimnar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
