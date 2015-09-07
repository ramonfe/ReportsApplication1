using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using Microsoft.Reporting.WinForms;

namespace ReportsApplication1
{
    public partial class frmRConc : Form
    {
        dbClass capaDb = new dbClass();
        DataTable dt = new DataTable();
        public DataTable dtConc
        {
            set
            {
                dt = value;
            }
        }
        string _fecha="";
        public string fecha
        {
            set
            {
                _fecha = value;
            }
        }
        public frmRConc()
        {
            InitializeComponent();
        }

        private void frmRConc_Load(object sender, EventArgs e)
        {
             string appPath = ConfigurationSettings.AppSettings["PathBd"];
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
            //DataSet ds = new DataSet();
            //ds.Tables.Add("conciliacion");
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from conciliacion", conAcc);
            
            ds.Tables.Add("conciliacion");
            da.Fill(ds.Tables[0]);
            da.Dispose();
            int c = dt.Rows.Count;
            string num = "", name = "", horaChk = "", horaV = "", coord = "";
            //ds.Tables[0].Columns.Count
            foreach (DataRow dr in dt.Rows)
            {
                num = dr[0].ToString();
                name = dr[1].ToString();
                horaChk = dr[2].ToString();
                horaV = dr[3].ToString();
                coord = dr[4].ToString();
                ds.Tables[0].Rows.Add(new object[] { num, name, horaChk, horaV, coord });
            }
            ReportParameter pOH = new ReportParameter("fechas",_fecha);//"0.00"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pOH });

            conciliacionBindingSource.DataSource = ds;
            ds.Dispose();
            this.reportViewer1.RefreshReport();
            dt.Dispose();
        }
    }
}
