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
    public partial class Mproveedores : Form
    {
        ProveedoresNE objproveedor = new ProveedoresNE();
        estadoNE estado = new estadoNE();

        ProveedoresE pro = new ProveedoresE();

        int idestado=0;
        public Mproveedores()
        {
            InitializeComponent();
        }

        public void ID_Proveedor()
        {
            txtIdProveedor.Text = objproveedor.ID_Proveedor().ToString();
        }
        public void TablaProveedores()
        {
            tablaproveedores1.DataSource = objproveedor.ListarProveedoresPorEstado(idestado);
        }

        public void deshabilitarCajas()
        {
            txtCompania.Enabled = false;
            txtcontacto.Enabled = false;
            txttelefono.Enabled = false;
            txtDireccion.Enabled = false;
            txtciudad.Enabled = false;
            txtpagina.Enabled = false;
            txtCargo.Enabled = false;
            txtregion.Enabled = false;
            comboCargo.Enabled = false;
        }
        public void HabilitarCajas()
        {
            txtCompania.Enabled = true;
            txtcontacto.Enabled = true;
            txttelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtciudad.Enabled = true;
            txtpagina.Enabled = true;
            txtCargo.Enabled = true;
            txtregion.Enabled = true;
            comboCargo.Enabled = true;


        }
        public void LimpiarCajas()
        {
            txtCompania.Clear();
            txtcontacto.Clear();
            txttelefono.Clear();
            txtDireccion.Clear();
            txtciudad.Clear();
            txtpagina.Clear();
            txtCargo.Clear();
            txtregion.Clear();
           

        }
        private void Mproveedores_Load(object sender, EventArgs e)
        {
           
            Comboestado();

            lblregistros.Text = tablaproveedores1.Rows.Count.ToString();
  
            ID_Proveedor();


            Comboestado();
            Disponibles.Checked = true;
            idestado = 1;
            if (Disponibles.Checked == true)
            {

                radioButton1.Checked = false;
                TablaProveedores();
            }
           
        }
        public void AgregarProveedores()
        {
            string mensaje = "";
            pro.IdProveedor = int.Parse(txtIdProveedor.Text);
            pro.NombreCompañia = txtCompania.Text;

            pro.NombreContacto = txtcontacto.Text;
            pro.CargoContacto = txtCargo.Text;
            pro.Direccion = txtDireccion.Text;
            pro.Ciudad = grupo2.Text;
            pro.Region = txtregion.Text;
            pro.Telefono = txttelefono.Text;
            pro.Pagina = txtpagina.Text;
            pro.Idestado = int.Parse(comboCargo.SelectedValue.ToString());

            mensaje = objproveedor.AgregarProveedor(pro);
            MessageBox.Show( mensaje);
            TablaProveedores();
            ID_Proveedor();
            lblregistros.Text = tablaproveedores1.Rows.Count.ToString();
        }
        public void ActualizarProveedor()
        {
            string mensaje = "";
            pro.IdProveedor = int.Parse(txtIdProveedor.Text);
            pro.NombreCompañia = txtCompania.Text;

            pro.NombreContacto = txtcontacto.Text;
            pro.CargoContacto = txtCargo.Text;
            pro.Direccion = txtDireccion.Text;
            pro.Ciudad = grupo2.Text;
            pro.Region = txtregion.Text;
            pro.Telefono = txttelefono.Text;
            pro.Pagina = txtpagina.Text;
            pro.Idestado= int.Parse(comboCargo.SelectedValue.ToString());

            mensaje = objproveedor.ActualizarProveedor(pro);
            MessageBox.Show(""+mensaje);
            TablaProveedores();
            ID_Proveedor();
            lblregistros.Text = tablaproveedores1.Rows.Count.ToString();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AgregarProveedores();
            LimpiarCajas();


            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;

            btnMoficar.Enabled = false;
            btnEliminar.Enabled = false;
           

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarCajas();
            ID_Proveedor();

            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
            btnMoficar.Enabled = false;

        }

        private void btnMoficar_Click(object sender, EventArgs e)
        {
            ActualizarProveedor();


            LimpiarCajas();
            TablaProveedores();
            ID_Proveedor();
            deshabilitarCajas();

            btnNuevo.Enabled = true;
            btnEliminar.Enabled = false;
            btnMoficar.Enabled = false;
            btnGuardar.Enabled = false;
            
        }

        private void tablaproveedores_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            
            if (btnEliminar.Text == "Habilitar")
            {
                TablaProveedores();


                habilidar();
                LimpiarCajas();
                
                ID_Proveedor();
                deshabilitarCajas();

                btnNuevo.Enabled = true;
                btnEliminar.Enabled = false;
                btnMoficar.Enabled = false;
                btnGuardar.Enabled = false;
            }
            else if (btnEliminar.Text == "Bloquear")
            {
                blockear();
                LimpiarCajas();
                TablaProveedores();
                ID_Proveedor();
                deshabilitarCajas();
                btnNuevo.Enabled = true;
                btnEliminar.Enabled = false;
                btnMoficar.Enabled = false;
                btnGuardar.Enabled = false;
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ID_Proveedor();
            LimpiarCajas();
            deshabilitarCajas();
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnMoficar.Enabled = false;
        }
        void habilidar()
        {
            //string men = "";

            pro.IdProveedor = int.Parse(txtIdProveedor.Text);
            pro.NombreCompañia = txtCompania.Text;

            pro.NombreContacto = txtcontacto.Text;
            pro.CargoContacto = txtCargo.Text;
            pro.Direccion = txtDireccion.Text;
            pro.Ciudad = grupo2.Text;
            pro.Region = txtregion.Text;
            pro.Telefono = txttelefono.Text;
            pro.Pagina = txtpagina.Text;
            pro.Idestado = 1;

             objproveedor.ActualizarProveedor(pro);
            MessageBox.Show("Se Habilito el Proveedor");

            LimpiarCajas();
            TablaProveedores();
            ID_Proveedor();
            deshabilitarCajas();
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = false;
            btnMoficar.Enabled = false;
            btnGuardar.Enabled = false;



        }
        void blockear()
        {
            //string men = "";

            pro.IdProveedor = int.Parse(txtIdProveedor.Text);
            pro.NombreCompañia = txtCompania.Text;

            pro.NombreContacto = txtcontacto.Text;
            pro.CargoContacto = txtCargo.Text;
            pro.Direccion = txtDireccion.Text;
            pro.Ciudad = grupo2.Text;
            pro.Region = txtregion.Text;
            pro.Telefono = txttelefono.Text;
            pro.Pagina = txtpagina.Text;
            pro.Idestado = 2;

            objproveedor.ActualizarProveedor(pro);
            MessageBox.Show("Se desabilito al proveedor");


            LimpiarCajas();
            TablaProveedores();
            ID_Proveedor();
            deshabilitarCajas();
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = false;
            btnMoficar.Enabled = false;
            btnGuardar.Enabled = false;

        }
        public void Comboestado()
        {
            comboCargo.DataSource = estado.Tablaestado();
            comboCargo.DisplayMember = "Nombre";
            comboCargo.ValueMember = "Id";

        }

        private void Disponibles_CheckedChanged(object sender, EventArgs e)
        {
            idestado = 1;
            if (Disponibles.Checked == true)
            {
                radioButton1.Checked = false;
                TablaProveedores();
                btnEliminar.Text = "Seleccionar";
                 lblregistros.Text = tablaproveedores1.Rows.Count.ToString();
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            idestado = 2;

            if (radioButton1.Checked == true)
            {
                Disponibles.Checked = false;
                TablaProveedores();
                btnEliminar.Text = "Seleccionar";
                lblregistros.Text = tablaproveedores1.Rows.Count.ToString();
            }
        }

        private void tablaproveedores1_DoubleClick(object sender, EventArgs e)
        {
            HabilitarCajas();
            txtIdProveedor.Text = tablaproveedores1.CurrentRow.Cells[0].Value.ToString();
            txtCompania.Text = tablaproveedores1.CurrentRow.Cells[1].Value.ToString();
            txtcontacto.Text = tablaproveedores1.CurrentRow.Cells[2].Value.ToString();
            txtCargo.Text = tablaproveedores1.CurrentRow.Cells[3].Value.ToString();
            txttelefono.Text = tablaproveedores1.CurrentRow.Cells[7].Value.ToString();
            txtciudad.Text = tablaproveedores1.CurrentRow.Cells[5].Value.ToString();
            txtpagina.Text = tablaproveedores1.CurrentRow.Cells[8].Value.ToString();
            txtregion.Text = tablaproveedores1.CurrentRow.Cells[6].Value.ToString();
            txtDireccion.Text = tablaproveedores1.CurrentRow.Cells[4].Value.ToString();
            comboCargo.Text = tablaproveedores1.CurrentRow.Cells[9].Value.ToString();
            //LimpiarCajas();

            if (comboCargo.Text == "disponible")
            {
                btnEliminar.Text = "Bloquear";
            }
            else if (comboCargo.Text == "no disponible")
            {
                btnEliminar.Text = "Habilitar";
            }
            btnMoficar.Enabled = true;
            btnEliminar.Enabled = true;
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
