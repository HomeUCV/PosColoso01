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
    public partial class MCargos : Form
    {
        CargoNE objCargo = new CargoNE();
        CargoE cargoParam = new CargoE();
        public MCargos()
        {
            InitializeComponent();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ID_Cargo()
        {
            txtIdCargo.Text = objCargo.Id_Cargo().ToString();
        }
        private void MCargos_Load(object sender, EventArgs e)
        {
            ID_Cargo();
            tablaCargo.DataSource = objCargo.tablaCargo();
            registros.Text = tablaCargo.Rows.Count.ToString();
            tablaCargo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CajasdesHabilitadas();
            tablaCargo.ReadOnly = true;

            btnGuardar.Enabled = false;
            btnMoficar.Enabled = false;
            btnElimimnar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreCargo.Text != "")
            {
                if (txtDescripcion.Text != "")
                {
                   
                    cargoParam.Idcargo = int.Parse(txtIdCargo.Text);
                    cargoParam.Nombre = txtNombreCargo.Text;
                    cargoParam.Descripcion = txtDescripcion.Text;
                    string mensaje = objCargo.AgregarCargos(cargoParam);
                    MessageBox.Show(mensaje, "Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    tablaCargo.DataSource = objCargo.tablaCargo();
                    registros.Text = tablaCargo.Rows.Count.ToString();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    CajasdesHabilitadas();
                }
                else
                {
                    MessageBox.Show("Escribe una descripción para el cargo", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("El nombre del Cargo Es obligatorio", "Aviso");
            }

        }

        private void btnElimimnar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Information)== DialogResult.Yes)
            {
                CargoE cargo = new CargoE();
                int cod = int.Parse(txtIdCargo.Text);
                cargo = objCargo.EliminarCargo(cod);
              
                limpiar();
                tablaCargo.DataSource = objCargo.tablaCargo();
                registros.Text = tablaCargo.Rows.Count.ToString();
                MessageBox.Show("Se a eliminado el registro correctamente");
            
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnMoficar.Enabled = false;
                btnElimimnar.Enabled = false;
                CajasdesHabilitadas();
                    
            }
            
        }
        public void limpiar()
        {
            txtIdCargo.Clear();
            txtNombreCargo.Clear();
            txtDescripcion.Clear();
        }
        public void CajasdesHabilitadas()
        {
            txtIdCargo.Enabled = false;
            txtNombreCargo.Enabled = false;
            txtDescripcion.Enabled = false;
        }
        public void CajasHabilitadas()
        {
          
            txtNombreCargo.Enabled = true;
            txtDescripcion.Enabled = true;
        }

        private void tablaCargos_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            ID_Cargo();
                
            CajasHabilitadas();

            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
               
        }

        private void btnMoficar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            cargoParam.Idcargo = int.Parse(txtIdCargo.Text);
            cargoParam.Nombre = txtNombreCargo.Text;
            cargoParam.Descripcion = txtDescripcion.Text;
            mensaje = objCargo.ActualizarCargo(cargoParam);
            MessageBox.Show(mensaje, "Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiar();
            tablaCargo.DataSource = objCargo.tablaCargo();
     
            CajasdesHabilitadas();
            btnNuevo.Enabled = true;
            btnMoficar.Enabled = false;
            btnElimimnar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void txtnombreCarogo_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtnombreCargoBuscar.Text;
            tablaCargo.DataSource = objCargo.BuscarCargo(nombre);
        }

        private void txtnombreCargoBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //admite solo letras
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ID_Cargo();
            limpiar();
            CajasdesHabilitadas();
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnElimimnar.Enabled = false;
            btnMoficar.Enabled = false;
        }

        private void tablaCargo_DoubleClick(object sender, EventArgs e)
        {
            txtIdCargo.Text = tablaCargo.CurrentRow.Cells[0].Value.ToString();
            txtNombreCargo.Text = tablaCargo.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = tablaCargo.CurrentRow.Cells[2].Value.ToString();

            btnGuardar.Enabled = false;
            btnElimimnar.Enabled = true;
            btnMoficar.Enabled = true;
            btnNuevo.Enabled = false;
            CajasHabilitadas();
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
