using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Configuration;

namespace ReportsApplication1
{
    public partial class frmRlin : Form
    {
        dbClass capaDb = new dbClass();
        public frmRlin()
        {
            InitializeComponent();
        }
        string _deptos = "";
        public string deptos
        {
            set
            {
                _deptos = value;
            }
        }
        string _ct = "";
        public string CenTrab
        {
            set
            {
                _ct = value;
            }
        }
        string _fbu = "";
        public string fbu
        {
            set
            {
                _fbu = value;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string appPath = ConfigurationSettings.AppSettings["PathBd"];
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
           DataSet ds = new DataSet();
            ds.Tables.Add("Lineas");
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                string sqlDeptos="", sqlCt = "",sqlFbu="";
                
                if (_deptos != "")
                {
                    sqlDeptos = " and Departamentos.Departamento in ( " + _deptos + ") ";
                    
                }
                if (_ct != "")
                {
                    sqlCt = " and CentrosTrabajos.CentroTrabajo in ( " + _ct + ") ";

                }
                if (_fbu != "")
                {
                    sqlFbu = " and FBU_s.FBU = '" + _fbu + "' ";

                }
                conAcc.Open();
                /*
                 * SELECT        FBU_s.FBU, FBU_s.Descripcion AS fbu_desc, Departamentos.Departamento, Departamentos.Descripcion, CentrosTrabajos.CentroTrabajo, 
                         CentrosTrabajos.Descripcion AS ctDesc, Lineas.Linea, Lineas.Descripcion AS linDesc
FROM            (((Lineas INNER JOIN
                         Departamentos ON Lineas.Departamento = Departamentos.Departamento) INNER JOIN
                         CentrosTrabajos ON Lineas.CentroTrabajo = CentrosTrabajos.CentroTrabajo) INNER JOIN
                         FBU_s ON Lineas.FBU = FBU_s.FBU)
ORDER BY Lineas.Linea
                 */
                string sql = "SELECT FBU_s.FBU, FBU_s.Descripcion AS fbu_desc,Departamentos.Departamento, Departamentos.Descripcion, CentrosTrabajos.CentroTrabajo, CentrosTrabajos.Descripcion AS ctDesc, Lineas.Linea," +
                      "Lineas.Descripcion AS linDesc " +
                        "FROM (((Lineas INNER JOIN " +
                      "Departamentos ON Lineas.Departamento = Departamentos.Departamento) INNER JOIN " +
                      "CentrosTrabajos ON Lineas.CentroTrabajo = CentrosTrabajos.CentroTrabajo) " +
                      " INNER JOIN FBU_s ON Lineas.FBU = FBU_s.FBU) "+
                      " where Lineas.Linea is not null "+
                      sqlDeptos + sqlCt +   sqlFbu+                   
                        "ORDER BY Lineas.Linea";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                da.Fill(ds.Tables[0]);
                da.Dispose();
                LineasBindingSource.DataSource = ds;

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
