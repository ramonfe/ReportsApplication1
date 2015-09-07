using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportsApplication1
{
    public partial class frmRsup : Form
    {
        public frmRsup()
        {
            InitializeComponent();
        }

        private void rep2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EficienDataSet.Supervisores' table. You can move, or remove it, as needed.
            this.SupervisoresTableAdapter.Fill(this.EficienDataSet.Supervisores);
            this.reportViewer1.RefreshReport();
        }
    }
}
