using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;

namespace ReportsApplication1
{
    public partial class frmRdep : Form
    {
        dbClass capaDb = new dbClass();
        public frmRdep()
        {
            InitializeComponent();
        }
        string _fbu = "", _overhead = "";
        public string fbu
        {
            set
            {
                _fbu = value;
            }
        }
        public string overHead
        {
            set
            {
                _overhead = value;
            }
        }
        private void rep2_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'EficienDataSet.Departamentos' table. You can move, or remove it, as needed.
            //this.DepartamentosTableAdapter.Fill(this.EficienDataSet.Departamentos);
            //// TODO: This line of code loads data into the 'EficienDataSet.Supervisores' table. You can move, or remove it, as needed.
            
            //this.reportViewer1.RefreshReport();
            string appPath = ConfigurationSettings.AppSettings["PathBd"];
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
            DataSet ds = new DataSet();
            ds.Tables.Add("Departamentos");
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                //parametro del reporte
                ReportParameter t = new ReportParameter("over", _overhead);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {t});

                string sqlDeptos = "";

                if (_fbu != "")
                {
                    sqlDeptos = " where FBU_s.fbu ='" + _fbu + "'";

                }
                /*
                 * SELECT        FBU_s.FBU, FBU_s.Descripcion AS fbu_desc, Departamentos.Departamento, Departamentos.Descripcion
FROM            (Departamentos INNER JOIN
                         FBU_s ON Departamentos.FBU = FBU_s.FBU)
                 */
                conAcc.Open();
                string sql = "SELECT FBU_s.fbu,FBU_s.Descripcion as fbu_desc,Departamento, Departamentos.Descripcion,overhead FROM Departamentos  INNER JOIN " +
                         " FBU_s ON Departamentos.FBU = FBU_s.FBU "+sqlDeptos;
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                da.Fill(ds.Tables[0]);
                da.Dispose();
                DepartamentosBindingSource.DataSource = ds;

                this.reportViewer1.RefreshReport();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
        }
    }
}
