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
    public partial class frmRvouch : Form
    {
        dbClass capaDb = new dbClass();
        public frmRvouch()
        {
            InitializeComponent();
        }
        string _linea = "",_codOp ="",_sup="",_empl="",_turno="",_efic="",_date1="",_date2="",_efSign="";
        #region properties
        public string linea
        {
            set
            {
                _linea = value;
            }
        }
        string _lineaName = "";
        public string lineaName
        {
            set
            {
                _lineaName = value;
            }
        }
        public string codOp
        {
            set
            {
                _codOp = value;
            }
        }
        public string sup
        {
            set
            {
                _sup = value;
            }
        }
        string _supName = "";
        public string supName
        {
            set
            {
                _supName = value;
            }
        }
        public string empl
        {
            set
            {
                _empl = value;
            }
        }
        string _emplName = "";
        public string emplName
        {
            set
            {
                _emplName = value;
            }
        }
        public string turno
        {
            set
            {
                _turno = value;
            }
        }
        public string efic
        {
            set
            {
                _efic = value;
            }
        }
        public string efsign
        {
            set
            {
                _efSign = value;
            }
        }
        public string date1
        {
            set
            {
                _date1 = value;
            }
        }
        public string date2
        {
            set
            {
                _date2 = value;
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
        string _depto = "";
        public string depto
        {
            set
            {
                _depto = value;
            }
        }
        string _deptoName = "";
        public string deptoName
        {
            set
            {
                _deptoName = value;
            }
        }
        string _ct = "";
        public string ct
        {
            set
            {
                _ct = value;
            }
        }
        string _ctName = "";
        public string ctName
        {
            set
            {
                _ctName = value;
            }
        }
        string _coord = "",_coordName;
        public string coord
        {
            set
            {
                _coord = value;
            }
        }
        public string coordName
        {
            set
            {
                _coordName = value;
            }
        }
        #endregion
        private void rep2_Load(object sender, EventArgs e)
        {

            string appPath = ConfigurationSettings.AppSettings["PathBd"];
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
            DataSet ds = new DataSet();
            ds.Tables.Add("vouchers");
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                string sqlLin = "", sqlCop = "", sqlSup = "", sqlEmp = "", sqlTur = "", sqlEf = "", sqlFbu="";
                string titFiltros = "Del: " + _date1 + " Al: " + _date2;

                if (_linea != "")
                {
                    sqlLin = " and DetVoucher.Linea in ( '" + _linea + "') ";
                    titFiltros += ", Linea: " + _lineaName;
                }
                if (_codOp != "")
                {
                    sqlCop = " and DetVoucher.CodigoOperacion like '%" + _codOp + "%' ";                    
                }
                if (_sup != "")
                {
                    sqlSup = " and empleados.Supervisor in ( '" + _sup + "') ";
                    titFiltros += ", supervisor: " + _supName;
                }
                if (_empl != "")
                {
                    sqlEmp = " and empVoucher.Empleado in ( " + _empl + ") ";
                    titFiltros += ", empleado: " + _emplName;
                }
                if (_turno != "")
                {
                    sqlTur = " and IndiceVoucher.Turno in ( " + _turno + ") ";
                    titFiltros += ", Turno: " + _turno;
                }
                if (_efic != "")
                {
                    sqlEf = " and DetVoucher.Eficiencia "+_efSign+ _efic + " ";                    
                }
                if (_fbu != "")
                {
                    sqlFbu = " and FBU_s.FBU = '" + _fbu + "' ";
                    titFiltros += ", Fbu: " + _fbu;
                }
                string sqlCt = "";
                if (_ct != "")
                {
                    sqlCt = " and DetVoucher.centrotrabajo = '" + _ct + "' ";
                    titFiltros += ", Centro de Trabajo: " + _ctName;
                }
                string sqlDepto = "";
                if (_depto != "")
                {
                    sqlDepto = " and DetVoucher.departamento = '" + _depto + "' ";
                    titFiltros += ", Departamento: " + _deptoName;
                }
                string sqlCoord = "";
                if (_coord != "")
                {
                    sqlCoord = " and empleados.coordinador = '" + _coord + "' ";
                    titFiltros += ", Coordinador: " + _coordName;
                }
                titFiltros = titFiltros.TrimEnd(',');
                ReportParameter pTf = new ReportParameter("pFiltros", titFiltros);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pTf });
                conAcc.Open();
                /*
                 * SELECT        IndiceVoucher.Fecha, IndiceVoucher.Turno, DetVoucher.Linea, FBU_s.FBU, FBU_s.Descripcion AS fbu_desc, EmpVoucher.Empleado AS numempl, 
                         Empleados.Nombre AS nombEmpl, EmpVoucher.Supervisor, DetVoucher.Empezo, DetVoucher.Termino, DetVoucher.CodigoOperacion, 
                         CodigosDeOperacion.DescEsp AS DescCodOp, DetVoucher.Horas, DetVoucher.ProdTotal, DetVoucher.Produccion, DetVoucher.Eficiencia
FROM            (((CodigosDeOperacion INNER JOIN
                         (IndiceVoucher INNER JOIN
                         DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) ON CodigosDeOperacion.CodigoOperacion = DetVoucher.CodigoOperacion) INNER JOIN
                         FBU_s ON CodigosDeOperacion.FBU = FBU_s.FBU) LEFT OUTER JOIN
                         (Empleados RIGHT OUTER JOIN
                         EmpVoucher ON Empleados.Empleado = EmpVoucher.Empleado) ON IndiceVoucher.NoVoucher = EmpVoucher.NoVoucher)
                 */
                string sql = "SELECT IndiceVoucher.Fecha, IndiceVoucher.Turno, DetVoucher.Linea, FBU_s.FBU, FBU_s.Descripcion AS fbu_desc,EmpVoucher.Empleado AS numempl," +
                    " Empleados.Nombre AS nombEmpl, supervisores.Nombre as supervisor, " +
                         " DetVoucher.Empezo, DetVoucher.Termino, DetVoucher.CodigoOperacion, CodigosDeOperacion.DescEsp AS DescCodOp, DetVoucher.Horas," +
                         " DetVoucher.ProdTotal, DetVoucher.Produccion, DetVoucher.Eficiencia,Coordinadores.Nombre_coord as coordinador,DetVoucher.departamento,DetVoucher.centrotrabajo " +
                         " FROM ((((CodigosDeOperacion INNER JOIN "+
                         " (IndiceVoucher INNER JOIN "+
                         " DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) ON CodigosDeOperacion.CodigoOperacion = DetVoucher.CodigoOperacion) INNER JOIN "+
                         " FBU_s ON CodigosDeOperacion.FBU = FBU_s.FBU) LEFT OUTER JOIN "+
                         " (Empleados RIGHT OUTER JOIN "+
                         " EmpVoucher ON Empleados.Empleado = EmpVoucher.Empleado) ON IndiceVoucher.NoVoucher = EmpVoucher.NoVoucher) " +
                         " LEFT JOIN Coordinadores ON Empleados.Coordinador = Coordinadores.ID_Coordinador) LEFT JOIN supervisores ON Empleados.Supervisor = supervisores.Supervisor "+
                         " WHERE IndiceVoucher.Fecha>=#" + _date1 + "# and IndiceVoucher.Fecha<=#" + _date2 + "# " +
                         sqlLin + sqlCop + sqlSup + sqlEmp + sqlTur + sqlEf + sqlFbu + sqlCt+sqlDepto+sqlCoord;
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                da.Fill(ds.Tables[0]);
                da.Dispose();
                vouchersBindingSource.DataSource = ds;

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
