using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Ventas.Reportes_Comprobantes
{
    public partial class FRM_ventas_diarios : Form
    {
        DateTime emplFechaDate;
        DateTime emplFechaDateuno;
        public FRM_ventas_diarios()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FRM_ventas_diarios_Load(object sender, EventArgs e)
        {
            DS_Dia_actual.EnforceConstraints = false;
            // emplFechaDate = dateTimePicker1.Value;
            /// // TODO: esta línea de código carga datos en la tabla 'DS_Dia_actual.ventas_diarios' Puede moverla o quitarla según sea necesario.
            // this.ventas_diariosTableAdapter.Fill(this.DS_Dia_actual.ventas_diarios,emplFechaDate);
            // this.reportViewer1.RefreshReport();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            emplFechaDate = dateTimePicker1.Value;
            emplFechaDateuno = dateTimePicker2.Value;
            // TODO: esta línea de código carga datos en la tabla 'DS_Dia_actual.ventas_diarios' Puede moverla o quitarla según sea necesario.
            this.ventas_diariosTableAdapter.Fill(this.DS_Dia_actual.ventas_diarios, emplFechaDate,emplFechaDateuno);
            this.reportViewer1.RefreshReport();
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
