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
    public partial class MProductos : Form

    {
        ProveedoresNE objprovee = new ProveedoresNE();
        CategoriasNE objCat = new CategoriasNE();
        ProductosNE objProductos = new ProductosNE();
        ProductoE objpro = new ProductoE();
        estadoNE estado = new estadoNE();

        int idestado = 0;
        public MProductos()
        {
            InitializeComponent();
        }

        public void ID_Producto()
        {
            txtIdProduxto.Text = objProductos.ID_Producto().ToString();
        }
        private void MProductos_Load(object sender, EventArgs e)
        {

          
            Comboestado();
            llenarComboCategorias();
            LLenarcomboProveedores();
            ID_Producto();


            
            Disponibles.Checked = true;
            idestado = 1;
            if (Disponibles.Checked == true)
            {

                radioButton1.Checked = false;
                TablaProductos();
            }
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LLenarcomboProveedores()
        {
            comboProveedor.DataSource = objprovee.ListarProveedores();
            comboProveedor.DisplayMember = "Compañia";
            comboProveedor.ValueMember = "ID";
        }
        public void llenarComboCategorias()
        {
            comboCategoria.DataSource = objCat.listaCategorias();
            comboCategoria.DisplayMember = "Categorias";
            comboCategoria.ValueMember = "ID";
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCajasdeTexto();
            HabilitarCajasdeTexo();

            ID_Producto();

            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
            btnMoficar.Enabled = false;
        }

        private void txtbuscador_TextChanged(object sender, EventArgs e)
        {
                string nombre = txtbuscador.Text;
            tablaproductos1.DataSource = objProductos.BuscarPorNombre(nombre);
            
        }
    
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text != "")
            {
                if (txtPrecio.Text != "")
                {
                    if (txtStock.Text != "")
                    {
                        
                        string mensaje = "";

                        objpro.Idproducto = int.Parse(txtIdProduxto.Text);
                        objpro.NombreProducto = txtNombreProducto.Text;
                        objpro.Idproveedor = int.Parse(comboProveedor.SelectedValue.ToString());
                        objpro.Idcategoria = int.Parse(comboCategoria.SelectedValue.ToString());
                        objpro.Presentacion = txtpresenta.Text;
                        objpro.PrecioUnidad1 = double.Parse(txtPrecio.Text.ToString());
                        objpro.UnidadenExistencia = int.Parse(txtStock.Text.ToString());
                        objpro.Idestado = int.Parse(comboCategoria.SelectedValue.ToString());

                        mensaje = objProductos.AgregarProducto(objpro);

                        MessageBox.Show(mensaje, "Aviso");
                       TablaProductos();
                        LimpiarCajasdeTexto();
                        DeshabilitarCajas();
                        ID_Producto();
                        txtIdProduxto.Focus();

                        btnGuardar.Enabled = false;
                        btnNuevo.Enabled = true;

                        btnMoficar.Enabled = false;
                        btnEliminar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Escriba el stock del producto");
                    }
                }else
                {
                    MessageBox.Show("Escriba el precio del producto");
                }
            }
            else
            {
                MessageBox.Show("Escriba el nombre del producto");
                txtNombreProducto.Text = "escriba aqui";
                txtNombreProducto.ForeColor = Color.Red;
                
            }
        }

        public void LimpiarCajasdeTexto()
        {
            txtNombreProducto.Clear();
            txtPrecio.Clear();
            txtpresenta.Clear();
            txtStock.Clear();
            ID_Producto();

        }
        public void HabilitarCajasdeTexo()
        {
          
            txtNombreProducto.Enabled = true;
            txtPrecio.Enabled = true;
            txtpresenta.Enabled = true;
            txtStock.Enabled = true;
            comboCategoria.Enabled = true;
            comboProveedor.Enabled = true;
            comboCargo.Enabled = true;

        }
        public void DeshabilitarCajas()
        {
           
            txtNombreProducto.Enabled = false;
            txtPrecio.Enabled = false;
            txtpresenta.Enabled = false;
            txtStock.Enabled = false;
            comboCategoria.Enabled = false;
            comboProveedor.Enabled = false;
            comboCargo.Enabled = false;
        }
        private void tablaproductos_DoubleClick(object sender, EventArgs e)
        {
            

        }

    
        private void btnMoficar_Click(object sender, EventArgs e)
        {
            string mensaje = "";

            objpro.Idproducto = int.Parse(txtIdProduxto.Text);
            objpro.NombreProducto = txtNombreProducto.Text;
            objpro.Idproveedor = int.Parse(comboProveedor.SelectedValue.ToString());
            objpro.Idcategoria = int.Parse(comboCategoria.SelectedValue.ToString());
            objpro.Presentacion = txtpresenta.Text;
            objpro.PrecioUnidad1 = double.Parse(txtPrecio.Text.ToString());
            objpro.UnidadenExistencia = int.Parse(txtStock.Text.ToString());
            objpro.Idestado = int.Parse(comboCargo.SelectedValue.ToString());

            mensaje = objProductos.ActualizarProducto(objpro);

            MessageBox.Show(mensaje, "Aviso");
            TablaProductos();
            LimpiarCajasdeTexto();
            DeshabilitarCajas();
            txtIdProduxto.ReadOnly = true;
            txtIdProduxto.Focus();

            btnMoficar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (btnEliminar.Text == "Habilitar")
            {
                habilidar();
                DeshabilitarCajas();
                LimpiarCajasdeTexto();
                 TablaProductos();

                btnNuevo.Enabled = true;
                btnEliminar.Enabled = false;
                btnMoficar.Enabled = false;
            }
            else if (btnEliminar.Text == "Bloquear")
            {
                blockear();
                DeshabilitarCajas();
                LimpiarCajasdeTexto();
                TablaProductos();

                btnNuevo.Enabled = true;
                btnEliminar.Enabled = false;
                btnMoficar.Enabled = false;
            }

           
           // }

           
        }

        private void txtNombreProducto_Enter(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text !="")
            {
                txtNombreProducto.Text="";
            }
        }

        private void txtbuscador_KeyPress(object sender, KeyPressEventArgs e)
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
            ID_Producto();
            LimpiarCajasdeTexto();
            DeshabilitarCajas();
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnMoficar.Enabled = false;
        }
        void habilidar()
        {
            //string men = "";

            objpro.Idproducto = int.Parse(txtIdProduxto.Text);
            objpro.NombreProducto = txtNombreProducto.Text;
            objpro.Idproveedor = int.Parse(comboProveedor.SelectedValue.ToString());
            objpro.Idcategoria = int.Parse(comboCategoria.SelectedValue.ToString());
            objpro.Presentacion = txtpresenta.Text;
            objpro.PrecioUnidad1 = double.Parse(txtPrecio.Text.ToString());
            objpro.UnidadenExistencia = int.Parse(txtStock.Text.ToString());
            objpro.Idestado = 1;

            objProductos.ActualizarProducto(objpro);

            MessageBox.Show("Se Habilito en producto ahora puede venderse");

            TablaProductos();
            LimpiarCajasdeTexto();
            DeshabilitarCajas();
            txtIdProduxto.ReadOnly = true;
            txtIdProduxto.Focus();

            btnMoficar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
            
        }
        void blockear()
        {
            //string men = "";

            objpro.Idproducto = int.Parse(txtIdProduxto.Text);
            objpro.NombreProducto = txtNombreProducto.Text;
            objpro.Idproveedor = int.Parse(comboProveedor.SelectedValue.ToString());
            objpro.Idcategoria = int.Parse(comboCategoria.SelectedValue.ToString());
            objpro.Presentacion = txtpresenta.Text;
            objpro.PrecioUnidad1 = double.Parse(txtPrecio.Text.ToString());
            objpro.UnidadenExistencia = int.Parse(txtStock.Text.ToString());
            objpro.Idestado = 2;

            objProductos.ActualizarProducto(objpro);

            MessageBox.Show("Se bloqueo el prodcuto no podra venderse");

            TablaProductos();
            LimpiarCajasdeTexto();
            DeshabilitarCajas();
            txtIdProduxto.ReadOnly = true;
            txtIdProduxto.Focus();

            btnMoficar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
            
        }
        public void Comboestado()
        {
            comboCargo.DataSource = estado.Tablaestado();
            comboCargo.DisplayMember = "Nombre";
            comboCargo.ValueMember = "Id";

        }

        void TablaProductos()
        {
            tablaproductos1.DataSource = objProductos.ListarProductosPorEstado(idestado);
        }

        private void Disponibles_CheckedChanged(object sender, EventArgs e)
        {
            idestado = 1;
            if (Disponibles.Checked == true)
            {
                radioButton1.Checked = false;
                TablaProductos();
                btnEliminar.Text = "Seleccionar";
               
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            idestado = 2;

            if (radioButton1.Checked == true)
            {
                Disponibles.Checked = false;
                TablaProductos();
                btnEliminar.Text = "Seleccionar";
               
            }
        }

        private void tablaproductos1_DoubleClick(object sender, EventArgs e)
        {
            HabilitarCajasdeTexo();
            txtIdProduxto.Text = tablaproductos1.CurrentRow.Cells[0].Value.ToString();
            txtNombreProducto.Text = tablaproductos1.CurrentRow.Cells[1].Value.ToString();
            txtpresenta.Text = tablaproductos1.CurrentRow.Cells[2].Value.ToString();
            txtPrecio.Text = tablaproductos1.CurrentRow.Cells[3].Value.ToString();
            comboProveedor.Text = tablaproductos1.CurrentRow.Cells[4].Value.ToString();
            comboCategoria.Text = tablaproductos1.CurrentRow.Cells[5].Value.ToString();
            txtStock.Text = tablaproductos1.CurrentRow.Cells[6].Value.ToString();
            comboCargo.Text = tablaproductos1.CurrentRow.Cells[7].Value.ToString();


            if (comboCargo.Text == "disponible")
            {
                btnEliminar.Text = "Bloquear";
            }
            else if (comboCargo.Text == "no disponible")
            {
                btnEliminar.Text = "Habilitar";
            }

            btnMoficar.Enabled = true;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = false;
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

        private void tablaproductos1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
