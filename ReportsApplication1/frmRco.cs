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
    public partial class frmRco : Form
    {
        dbClass capaDb = new dbClass();
        public frmRco()
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
        string _procs = "";
        public string procs
        {
            set
            {
                _procs = value;
            }
        }
        string _procsName = "";
        public string procsName
        {
            set
            {
                _procsName = value;
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
        string _ct = "";
        public string CenTrab
        {
            set
            {
                _ct = value;
            }
        }
        string _ctName = "";
        public string CenTrabName
        {
            set
            {
                _ctName = value;
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
        string _ora = "";
        public string ora
        {
            set
            {
                _ora = value;
            }
        }
        string _nop = "";
        public string nop
        {
            set
            {
                _nop = value;
            }
        }
        private void frmRco_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EficienDataSet.CodigosDeOperacion' table. You can move, or remove it, as needed.
            //this.CodigosDeOperacionTableAdapter.Fill(this.EficienDataSet.CodigosDeOperacion);
            //this.reportViewer1.RefreshReport();
            string appPath = ConfigurationSettings.AppSettings["PathBd"];
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
            DataSet ds = new DataSet();
            ds.Tables.Add("CodigosDeOperacion");
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                string titFiltros = "";
                string sqlDeptos = "", sqlCt = "",sqlFbu="",sqlOra="",sqlNop="",sqlProcs="";

                if (_deptos != "")
                {
                    sqlDeptos = " and Departamentos.Departamento in ( " + _deptos + ") ";
                    titFiltros += " Departamento: " + _deptosName +","; 
                }
                if (_ct != "")
                {
                    sqlCt = " and CentrosTrabajos.CentroTrabajo in ( " + _ct + ") ";
                    titFiltros += " Centros de Trabajo: " + _ctName+"," ; 
                }
                if (_fbu != "")
                {
                    sqlFbu = " and FBU_s.FBU = '" + _fbu + "' ";

                }
                if (_ora != "")
                {
                    sqlOra = " and CodigosDeOperacion.oracle = '" + _ora + "' ";
                    titFiltros += " Oracle: " + _ora +",";
                }
                if (_procs != "")
                {
                    _procs = _procs.Replace("'", "");
                    sqlProcs = " and CodigosDeOperacion.proceso in (" + _procs + ") ";
                    titFiltros += " Proceso: " + _procsName + ",";
                }
                string joinNop = "",selNop="";
                if (_nop != "")
                {
                    selNop = ",Numeros_De_Parte.No_Parte as aplicapara";
                    joinNop = " INNER JOIN Numeros_De_Parte ON CodigosDeOperacion.CodigoOperacion = Numeros_De_Parte.Cod_Operacion ";
                    //sqlNop = " and CodigosDeOperacion.aplicapara like '%" + _nop + "%' ";
                    sqlNop = " and numeros_de_parte.no_parte like '%" + _nop + "%' ";
                    titFiltros += " No.Parte: " + _nop +",";
                    ReportParameter pNp = new ReportParameter("pNoParte", "1");
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pNp });
                }
                /*
                 * SELECT        FBU_s.FBU, FBU_s.Descripcion AS fbu_desc, CentrosTrabajos.CentroTrabajo, CentrosTrabajos.Descripcion AS desc_ct, 
                         Departamentos.Descripcion AS deptoDesc, CodigosDeOperacion.CodigoOperacion, CodigosDeOperacion.CodigoReferencia, 
                         CodigosDeOperacion.NumeroOperacion, CodigosDeOperacion.DescEsp, CodigosDeOperacion.System_Standard, CodigosDeOperacion.Standard, 
                         CodigosDeOperacion.Operadores, CodigosDeOperacion.Standard_Group, CodigosDeOperacion.MTM, CodigosDeOperacion.Oracle
FROM            (((CodigosDeOperacion INNER JOIN
                         Departamentos ON CodigosDeOperacion.Departamento = Departamentos.Departamento) INNER JOIN
                         FBU_s ON CodigosDeOperacion.FBU = FBU_s.FBU) INNER JOIN
                         CentrosTrabajos ON CodigosDeOperacion.CentroTrabajo = CentrosTrabajos.CentroTrabajo)
                 */
                titFiltros = titFiltros.TrimEnd(',');
                ReportParameter pTf = new ReportParameter("pFiltros", titFiltros);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pTf });
                conAcc.Open();
                string sql = "SELECT FBU_s.FBU, FBU_s.Descripcion AS fbu_desc,CentrosTrabajos.CentroTrabajo, CentrosTrabajos.Descripcion AS desc_ct," +
                    " Departamentos.departamento AS deptoDesc, CodigosDeOperacion.CodigoOperacion," +
                    " CodigosDeOperacion.CodigoReferencia,"+
                    " CodigosDeOperacion.NumeroOperacion, CodigosDeOperacion.DescEsp,"+
                    " CodigosDeOperacion.NumeroOperacion, CodigosDeOperacion.DescIng," +
                    " CodigosDeOperacion.System_Standard, CodigosDeOperacion.Standard,"+
                    " CodigosDeOperacion.Operadores, CodigosDeOperacion.Standard_Group, CodigosDeOperacion.MTM, "+
                    "CodigosDeOperacion.Oracle,hrs_ing,procesos.proceso" +//,'' as aplicapara " +
                    selNop+
                    " FROM ((((CodigosDeOperacion INNER JOIN"+
                    " Departamentos ON CodigosDeOperacion.Departamento = Departamentos.Departamento) "+
                    " INNER JOIN FBU_s ON CodigosDeOperacion.FBU = FBU_s.FBU) " +
                    " INNER JOIN CentrosTrabajos ON CodigosDeOperacion.CentroTrabajo = CentrosTrabajos.CentroTrabajo) "+
                    "  LEFT JOIN procesos ON CodigosDeOperacion.proceso = procesos.proc_id) "+
                    joinNop+
                    " where CodigoOperacion is not null and activo=1 "+sqlDeptos+sqlCt+sqlFbu+sqlOra+sqlNop+sqlProcs;

                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);

                
                da.Fill(ds.Tables[0]);
                

                da.Dispose();
                CodigosDeOperacionBindingSource.DataSource = ds;

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
