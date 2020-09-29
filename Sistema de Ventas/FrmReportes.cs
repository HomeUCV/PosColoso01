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
    public partial class FrmReportes : Form
    {

        int id;
        public FrmReportes(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {


            CrystalReport2 t = new CrystalReport2();
            t.SetParameterValue  ("@id",id);
            crystalReportViewer1.ReportSource = t;
          
        }

        private void CrystalReport21_InitReport(object sender, EventArgs e)
        {

        }
    }
}
