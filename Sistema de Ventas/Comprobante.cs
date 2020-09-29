using System;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Util' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
using Util;
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Util' no se encontró (¿falta una directiva using o una referencia de ensamblado?)

namespace Sistema_de_Ventas
{
    public partial class Comprobante : Form
    {
        VentasNE objventas = new VentasNE();
        DetalleVentasNE objdetalle = new DetalleVentasNE();
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'NumeroaLetras' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
        NumeroaLetras letras = new NumeroaLetras();
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'NumeroaLetras' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
        VentasE v = new VentasE();
        DetalleVenta d = new DetalleVenta();  
        public Comprobante()
        {
            InitializeComponent();
        }
        public void Id_Detalle()
        {
            int cod_detalle=0;
            cod_detalle = objdetalle.Id_Detalle();     
        }
        public void Correlativo()
        {
            int correlativo = objventas.Correlaito();
            txtnumeroCorrelativo.Text = "0000"+correlativo.ToString();

            if (correlativo >= 100 )
            {
                txtnumeroCorrelativo.Text = "000" + correlativo.ToString();
            }
        }
        public void ID_Venta()
        {
            int id_venta = objventas.ID_Venta();
            txtidventa.Text = id_venta.ToString();
        }
        private void Comprobante_Load(object sender, EventArgs e)
        {  
            lblSerie.Text = "T0001".ToString();
            lblTipo.Text = "TICKED";
            txtDatos.Text = "Público en general";


            ID_Venta();
            Correlativo();

           
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salir del formato de ventas","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }                 
        }
        private void rbnBoleta_CheckedChanged(object sender, EventArgs e)
        {
            lblSerie.Text = "B0001".ToString();
            lblTipo.Text = "BOLETA DE VENTA";
            txtDatos.Text = "";
        }
        private void rbnFactura_CheckedChanged(object sender, EventArgs e)
        {
            lblSerie.Text = "F0001".ToString();
            lblTipo.Text = "FACTURA";
            txtDatos.Text = "";
        }
        private void rbnTicked_CheckedChanged(object sender, EventArgs e)
        {
            lblSerie.Text = "T0001";
            lblTipo.Text = "TICKED";
            txtDatos.Text = "Público en general";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmProductos pro = new FrmProductos();
            pro.ShowDialog();
        }
        private void btnBusquedaCliente_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
        }
        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (MessageBox.Show("Desea eliminar el producto de la lista", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    double total;
                    double igv, st;
                    double dato =Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value);
                    total = double.Parse(lbltotal.Text);
                    int fila = dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.RemoveAt(fila);

                  // MessageBox.Show("El valor es: " + dato, "Aviso");
                    total -= dato;
                    igv = total * 0.18;
                    st = total - igv;

                    lblsubtotal.Text = st.ToString("00.00");
                    lbligv.Text = igv.ToString("00.00");
                    lbltotal.Text = total.ToString("00.00");

                    lblletras.Text = letras.enletras(total.ToString()) + " NUEVOS SOLES";
                }
            }
            else
            {
                MessageBox.Show("No esta selecionado o lista vacia");
            }
        }
        public void RegistrarVentas()
        {
            int idcomprobante = 0;
            string mensaje = "";
            if (rbnTicked.Checked == true)
            {
                idcomprobante = 3;
            }
            else if (rbnBoleta.Checked == true)
            {
                idcomprobante = 1;
            }
            else if (rbnFactura.Checked == true)
            {
                idcomprobante = 2;
            }
            v.Idventa = int.Parse(txtidventa.Text);
            v.Idcliente = int.Parse(txtIdcliente.Text);
            v.Idempleado = int.Parse(txtidEmpleado.Text);
            v.Fechaventa = txtfecha.Text;
            v.Total = double.Parse(lbltotal.Text);
            v.Serie = lblSerie.Text;
            v.Numero = int.Parse(txtnumeroCorrelativo.Text);
            v.Idcomprobante = idcomprobante;

            mensaje = objventas.Registrarventas(v);

            //MessageBox.Show("Estado: " + mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void LimpiaCcajasdeTexto()
        {
            txtNombrePro.Clear();
            txtStock.Clear();
            txtprecio.Clear();
            txtidProducto.Clear();
        }
        public void RegistrarDetalles()
        {
            string mensaje = "";
            d.Idventa = int.Parse(txtidventa.Text);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                d.Idproducto =Convert.ToInt32( row.Cells[0].Value);
                d.Preciopro = Convert.ToDouble(row.Cells[2].Value);
                d.Cantidad = Convert.ToInt32(row.Cells[3].Value);
                d.Importe = Convert.ToDouble(row.Cells[4].Value);
                d.Iddetalle = objdetalle.Id_Detalle();

                mensaje = objdetalle.RegistrarDetalle(d);
            }

            MessageBox.Show("" + mensaje);
        }
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea realizar la venta ?","Aviso",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    RegistrarVentas();
                    RegistrarDetalles();

                    
                    dataGridView1.Rows.Clear();

                    
                    double total = 0, igv = 0, st = 0;
                    lbltotal.Text = total.ToString("00.00");
                    lbligv.Text = igv.ToString("00.00");
                    lblsubtotal.Text = st.ToString("00.00");
                    lblletras.Text = "ñ__ñ";

                    ID_Venta();
                    Correlativo();
                    int id = int.Parse(txtidventa.Text) - 1;
                    //FrmReportes r = new FrmReportes(id);
                    //r.Show();
                    Reportes_Comprobantes.FRM_comprobantes frm = new Reportes_Comprobantes.FRM_comprobantes();
                    frm.Idventa = Convert.ToInt32(id);
                   frm.ShowDialog();

                }
                else
                {
                    MessageBox.Show("La lista esta vacia!", "Aviso");
                }
            }        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNombrePro.Text != "")
            {
                if (txtCantidad.Text != "")
                {
                    int cantidad = int.Parse(txtCantidad.Text) , 
                        stock = int.Parse(txtStock.Text);
                    if (cantidad > stock || cantidad < 0)
                    {
                        MessageBox.Show("No hay suficiente producto en stock ó ingreso número negativo","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        double importe, igv, st, total = 0;
                        importe = double.Parse(txtprecio.Text) * double.Parse(txtCantidad.Text);
                        string imp = String.Format("{0:0.00}", importe);
                        string pro="";
                        foreach (DataGridViewRow dato in dataGridView1.Rows)
                        {
                             pro = Convert.ToString(dato.Cells[1].Value);
                        }
                        if (txtNombrePro.Text != pro)
                        {
                            //MessageBox.Show("" + pro);
                            dataGridView1.Rows.Add(txtidProducto.Text, txtNombrePro.Text, txtprecio.Text, txtCantidad.Text, imp);

                            LimpiaCcajasdeTexto();
                            foreach (DataGridViewRow item in dataGridView1.Rows)
                            {
                                total += Convert.ToDouble(item.Cells[4].Value);
                            }
                            igv = total * 0.18;
                            st = total - igv;
                            lblsubtotal.Text = st.ToString("00.00");
                            lbligv.Text = igv.ToString("00.00");
                            lbltotal.Text = total.ToString("00.00");
                            lblletras.Text = letras.enletras(total.ToString()) + " NUEVOS SOLES";
                        }
                        else
                        {
                            MessageBox.Show("El producto ya eta en la lista");
                        }
                       
                    }                  
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad", "Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                }
            }
            else
            {
              MessageBox.Show("Debe llenar los campos para continuar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
