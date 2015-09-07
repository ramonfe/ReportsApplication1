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
    public partial class frmDiscrEmplChecadas : Form
    {
        DataTable dt = new DataTable();
        public DataTable dtP
        {
            set
            {
                dt = value;
            }
        }
        public frmDiscrEmplChecadas()
        {
            InitializeComponent();
        }

        private void frmDiscrEmplChecadas_Load(object sender, EventArgs e)
        {
            dg1.DataSource = dt;
            dg1.Columns[1].Width = 200;
        }

        private void dg1_DoubleClick(object sender, EventArgs e)
        {
            if (dg1.Rows.Count > 0)
            {
                muestraVoucher();
               
            }
        }
        private void muestraVoucher()
        {
            int noVoucher = Convert.ToInt32(dg1[4, dg1.CurrentRow.Index].Value.ToString());
            frmVoucher frmV = new frmVoucher();
            frmV.fromDiscr = noVoucher;
            frmV.ShowDialog();

            frmV.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dg1.SelectedCells.Count>0)
                muestraVoucher();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
