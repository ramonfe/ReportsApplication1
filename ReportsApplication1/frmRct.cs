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
    public partial class frmRct : Form
    {
        dbClass capaDb = new dbClass();
        public frmRct()
        {
            InitializeComponent();
        }
        string _deptos = "",_fbu="";
        public string deptos
        {
            set
            {
                _deptos = value;
            }
        }
        string _deptosName = "";
        public string deptosName
        {
            set
            {
                _deptosName = value;
            }
        }
        public string fbu
        {
            set
            {
                _fbu = value;
            }
        }
        private void rep2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EficienDataSet.CentrosTrabajos' table. You can move, or remove it, as needed.
            //this.CentrosTrabajosTableAdapter.Fill(this.EficienDataSet.CentrosTrabajos);                       
            //this.reportViewer1.RefreshReport();
            string appPath = ConfigurationSettings.AppSettings["PathBd"];
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
            DataSet ds = new DataSet();
            ds.Tables.Add("CentrosTrabajos");
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                string sqlDeptos = "",sqlFbu="",titFiltros = "";

                if (_deptos != "")
                {
                    sqlDeptos = " and Departamentos.Departamento in ( " + _deptos + ") ";
                    titFiltros = " Departamento: " + _deptosName + ","; 
                }
                if (_fbu != "")
                {
                    sqlFbu = " and FBU_s.FBU ='" + _fbu + "' ";

                }
                /*
                 * SELECT FBU_s.FBU, FBU_s.Descripcion AS fbu_desc, Departamentos.Departamento, Departamentos.Descripcion AS depDesc, CentrosTrabajos.CentroTrabajo, 
                          CentrosTrabajos.Descripcion
                    FROM            ((CentrosTrabajos INNER JOIN
                          Departamentos ON CentrosTrabajos.Departamento = Departamentos.Departamento) INNER JOIN
                          FBU_s ON CentrosTrabajos.FBU = FBU_s.FBU)
                 */
                titFiltros = titFiltros.TrimEnd(',');
                ReportParameter pTf = new ReportParameter("pFiltros", titFiltros);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pTf });
                conAcc.Open();
                string sql = "SELECT FBU_s.FBU, FBU_s.Descripcion AS fbu_desc,Departamentos.Departamento, Departamentos.Descripcion AS depDesc," +
                    " CentrosTrabajos.CentroTrabajo, CentrosTrabajos.Descripcion"+
                    " FROM ((CentrosTrabajos INNER JOIN "+
                    " Departamentos ON CentrosTrabajos.Departamento = Departamentos.Departamento) "+
                    " INNER JOIN FBU_s ON CentrosTrabajos.FBU = FBU_s.FBU) "+
                    " where CentrosTrabajos.Departamento is not null " + sqlDeptos +sqlFbu;
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                da.Fill(ds.Tables[0]);
                da.Dispose();
                CentrosTrabajosBindingSource.DataSource = ds;

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
