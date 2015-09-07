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
using System.Diagnostics;

namespace ReportsApplication1
{
    public partial class frmEfEmpCo : Form
    {
        dbClass capaDb = new dbClass();
        public frmEfEmpCo()
        {
            InitializeComponent();
        }
        string _linea = "", _depto = "", _turno = "", _efic = "", _date1 = "", _date2 = "", _efSign = "", _ct = "";
        int _reporte = 0;
        #region properties
        int _hearnIng = 0;
        public int hearnIng
        {
            set
            {
                _hearnIng = value;
            }
        }
        public int reporte
        {
            set
            {
                _reporte = value;
            }
        }
        public string linea
        {
            set
            {
                _linea = value;
            }
        }
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

        string _fbu = "";
        public string fbu
        {
            set
            {
                _fbu = value;
            }
        }
        string _fbu_name = "";
        public string fbu_name
        {
            set
            {
                _fbu_name = value;
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
        public string ct
        {
            set
            {
                _ct = value;
            }
        }
        string _ctN = "";
        public string ctN
        {
            set
            {
                _ctN = value;
            }
        }
        string _co = "";
        public string co
        {
            set
            {
                _co = value;
            }
        }
        string _coN = "";
        public string coN
        {
            set
            {
                _coN = value;
            }
        }
        string _emp = "";
        public string emp
        {
            set
            {
                _emp = value;
            }
        }
        string _empN = "";
        public string empN
        {
            set
            {
                _empN = value;
            }
        }
        string _sup = "";
        public string sup
        {
            set
            {
                _sup = value;
            }
        }
        string _coord = "";
        public string coord
        {
            set
            {
                _coord = value;
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
        string _supN = "";
        public string supN
        {
            set
            {
                _supN = value;
            }
        }
        string _coordN = "";
        public string coordN
        {
            set
            {
                _coordN = value;
            }
        }
        #endregion
        private void rep2_Load(object sender, EventArgs e)
        {

            string appPath = ConfigurationSettings.AppSettings["PathBd"];
            if (appPath=="Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
            
            DataSet ds = new DataSet();
            ds.Tables.Add("efByDepto");

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                ReportParameter d1 = new ReportParameter("date1", _date1);
                ReportParameter d2 = new ReportParameter("date2", _date2);
                ReportParameter t = new ReportParameter("turno", _turno);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { d1, d2, t });

                string sqlDepto = "", sqlLine = "", sqlTur = "", sqlEf = "", sqlCt = "", sqlFbu = "",
                    grbyLine = "", grbyDepto = "", selLinea = "", selDepto = "", grbyCt = "", selCt = "",
                    grbyCo = "", selCo = "", grbyEmp = "", selEmp = "", grbySup = "", selSup = "", grbyTurno = "";

                string selIDep = "", grpIDep = "", selICt = "", grpICt = "", selILin = "", selICo = "",
                    selIEmp = "", grpIEmp = "", selISup = "", grpISup = "", colJoin = "", colJoin2="",
                    repName = "",selMain = "", grpMain = "", selFbu="", grbyFbu="",colFiltro="";
                string titFiltros = "Del: " + _date1 + " Al: " + _date2;
                int colToBegin = 0;
                #region que tipo de reporte es
                if (_reporte == 4)//codigo de op (empl)
                {
                    selICo = " DetVoucher.codigooperacion,";
                    colJoin = "codigooperacion";
                    colJoin2 = "numEmp";
                    grbyCo = ",DetVoucher.codigooperacion,codigosdeoperacion.descesp ";
                    selCo = ",DetVoucher.codigooperacion,codigosdeoperacion.descesp as coDesc";
                    repName = "Reporte de Eficiencia por Codigo de Operación (Empleado)";
                    colToBegin = 4;
                    selMain = selCo;
                    grpMain = grbyCo;
                    //
                    selIEmp = " empleados.empleado as numEmp,";
                    grpIEmp = " empleados.empleado,";
                    grbyEmp = ",empleados.empleado,empleados.nombre ";
                    selEmp = ",empleados.empleado as numEmp,empleados.nombre as emp ";
                }
                else if (_reporte == 6)//Empleado (Codigo de Operación)
                {
                    selIEmp = " empleados.empleado as numEmp,";
                    grpIEmp = " empleados.empleado,";
                    colJoin = "numEmp";
                    colJoin2 = "codigooperacion";
                    grbyEmp = ",empleados.empleado,empleados.nombre ";
                    selEmp = ",empleados.empleado as numEmp,empleados.nombre as emp ";
                    repName = "Reporte de Eficiencia por Empleado (Codigo de Operación)";
                    selMain = selEmp;
                    grpMain = grbyEmp;
                    //
                    selICo = " DetVoucher.codigooperacion,";
                    grbyCo = ",DetVoucher.codigooperacion,codigosdeoperacion.descesp ";
                    selCo = ",DetVoucher.codigooperacion,codigosdeoperacion.descesp as coDesc";
                    colToBegin = 3;
                }
                
                ReportParameter pRep = new ReportParameter("pRep", _reporte.ToString());
                ReportParameter pRepN = new ReportParameter("repName", repName);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pRep, pRepN });
                #endregion
                #region filtros
                if (_turno != "")
                {
                    //colFiltro += "Turno|";
                    sqlTur = " and (IndiceVoucher.Turno in (" + _turno + ")) ";
                    titFiltros += ", Turno: " + _turno;
                    //grbyTurno = ",IndiceVoucher.Turno ";
                    ReportParameter pTurno = new ReportParameter("turno", "1");
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pTurno });
                }
                if (_efic != "")
                {
              //      colFiltro += "ef|";
                    titFiltros += ", Eficiencia " + _efSign + " " + _efic;
                    //sqlEf = " having (ROUND(SUM(DetVoucher.Eficiencia),2) " + _efSign + _efic + ") ";
                    sqlEf = " having SUM(DetVoucher.Horas) >0 and ((SUM(DetVoucher.HEarned)/SUM(DetVoucher.Horas))*100) " + _efSign + _efic + " ";
                    //ReportParameter pSigno = new ReportParameter("pSigno", _efSign);
                    //ReportParameter pEficiencia = new ReportParameter("pEficiencia", _efic);
                    //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pSigno, pEficiencia });
                }
                if (_ct != "")
                {
                    colFiltro += "ct|descr|";
                    titFiltros += ", Centr. de Trab: " + _ctN;
                    sqlCt = " and CentrosTrabajos.centrotrabajo in (" + _ct + ") ";
                    if (_reporte != 1)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    {
                        ReportParameter pct = new ReportParameter("ct", "1");
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pct });
                        grbyCt = ",CentrosTrabajos.CentroTrabajo, CentrosTrabajos.Descripcion ";
                        selCt = ",CentrosTrabajos.CentroTrabajo as ct, CentrosTrabajos.Descripcion as descr ";
                    }
                }
                if (_fbu != "")
                {
                    colFiltro += "FBU|fbuDesc|";
                    titFiltros += ", FBU: " + _fbu_name;
                    ReportParameter pfbu = new ReportParameter("fbu", "1");
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pfbu });
                    sqlFbu = " and FBU_s.FBU = '" + _fbu + "' ";
                    selFbu = ",FBU_s.FBU, FBU_s.Descripcion as fbuDesc ";
                    grbyFbu = ",FBU_s.FBU, FBU_s.Descripcion ";
                }
                if (_linea != "")
                {
                    colFiltro += "Linea|lineaDesc|";
                    titFiltros += ", Linea: " + _linea;
                    sqlLine = " and lineas.linea  in (" + _linea + ") ";
                    if (_reporte != 2)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    {
                        ReportParameter pline = new ReportParameter("linea", "1");
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pline });
                        //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                        grbyLine = ",Lineas.Linea,lineas.descripcion ";
                        selLinea = ",Lineas.Linea,lineas.descripcion as lineaDesc ";
                    }
                }
                string sqlCo = "";
                if (_co != "")
                {
                    //colFiltro += "coDesc|codigooperacion|";
                    titFiltros += ", Cent. Trab: " + _coN;
                    sqlCo = " and DetVoucher.codigooperacion  in (" + _co + ") ";
                    if ((_reporte != 4)||(_reporte != 6))//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    {
                        ReportParameter pco = new ReportParameter("codOp", "1");
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pco });
                        //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                        //grbyCo = ",DetVoucher.codigooperacion,codigosdeoperacion.descesp ";
                        //selCo = ",DetVoucher.codigooperacion,codigosdeoperacion.descesp as coDesc";
                    }
                }
                string sqlEmp = "";
                if (_emp != "")
                {
                    //colFiltro += "numemp|emp|";
                    titFiltros += ", Empleado " + _empN;
                    sqlEmp = " and empvoucher.empleado  = " + _emp + " ";
                    if ((_reporte != 4) || (_reporte != 6))//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    {
                        ReportParameter pemp = new ReportParameter("emp", "1");
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pemp });
                        //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                        //grbyEmp = ",empleados.empleado,empleados.nombre ";
                        //selEmp = ",empleados.empleado as numemp,empleados.nombre as emp ";
                    }
                }
                string sqlSup = "";
                if (_sup != "")
                {
                    colFiltro += "sup|";
                    titFiltros += ", Supv: " + _supN;
                    sqlSup = " and empvoucher.supervisor  = '" + _sup + "' ";
                    if (_reporte != 7)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    {
                        ReportParameter psup = new ReportParameter("sup", "1");
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { psup });
                        //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                        grbySup = ",supervisores.nombre ";
                        selSup = ",supervisores.nombre as sup ";
                    }
                }
                if (_depto != "")
                {
                    colFiltro += "depto|deptoDesc|";
                    titFiltros += ", Depto: " + _deptoName;
                    sqlDepto = " and departamentos.departamento in (" + _depto + ") ";
                    if (_reporte != 0)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    {
                        ReportParameter pdepto = new ReportParameter("departamento", "1");
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pdepto });
                        //inJoinDepto = "  DetVoucher INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento ";
                        grbyDepto = ",Departamentos.Departamento,Departamentos.descripcion ";
                        selDepto = ",Departamentos.Departamento as depto,Departamentos.descripcion as deptoDesc ";
                    }
                }
                string sqlCoord = "", joinCoord = "", grbyCoord = "", selCoord = "";
                bool byCoord = false;
                if (_coord != "")
                {
                    byCoord = true;
                    //tablascoord = ",sup_cord,coordinadores ";
                    //joinCoord = ") LEFT JOIN Sup_Cord ON Supervisores.Supervisor = Sup_Cord.ID_sup) LEFT JOIN Coordinadores ON Sup_Cord.ID_Cord = Coordinadores.ID_Coordinador ";
                    joinCoord = ") LEFT JOIN Coordinadores ON Empleados.Coordinador = Coordinadores.ID_Coordinador ";
                    titFiltros += ", Coordinador: " + _coordN;
                    sqlCoord = " and coordinadores.id_coordinador  = '" + _coord + "' ";
                    //if (_reporte != 7)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    //{
                   // ReportParameter pcord = new ReportParameter("coord", "1");
                    //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pcord });
                    //    //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                    grbyCoord = ",coordinadores.nombre_coord ";
                    selCoord = ",coordinadores.nombre_coord as coord ";
                    //}
                }
                bool byProcs = false;
                string joinProcs = "", sqlProcs = "";
                if (_procs != "")
                {
                    byProcs = true;
                    _procs = _procs.Replace("'", "");
                    //tablascoord = ",sup_cord,coordinadores ";
                    //joinCoord = ") LEFT JOIN Sup_Cord ON Supervisores.Supervisor = Sup_Cord.ID_sup) LEFT JOIN Coordinadores ON Sup_Cord.ID_Cord = Coordinadores.ID_Coordinador ";
                    joinProcs = ") LEFT JOIN procesos ON CodigosDeOperacion.proceso = procesos.proc_id ";
                    titFiltros += ", Proceso: " + _procsName;
                    sqlProcs = " and CodigosDeOperacion.proceso in (" + _procs + ") ";
                    //if (_reporte != 7)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    //{
                    // ReportParameter pcord = new ReportParameter("coord", "1");
                    //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pcord });
                    //    //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                    //grbyCoord = ",coordinadores.nombre_coord ";
                    //selCoord = ",coordinadores.nombre_coord as coord ";
                    //}
                }
                #endregion
                colFiltro = colFiltro.TrimEnd('|');
                ReportParameter pTf = new ReportParameter("pFiltros", titFiltros);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pTf });
                conAcc.Open();

                string sqlHearn = "";
                if (_hearnIng == 0)
                    sqlHearn = ",SUM(DetVoucher.HEarned) AS hEarn,";
                else
                    sqlHearn = ",SUM(DetVoucher.hearn_ing) AS hEarn,";

                string sqlMain = " SELECT " +
                    "SUM(DetVoucher.Horas) AS dHrs" + sqlHearn +
                    "SUM(DetVoucher.Eficiencia)AS ef,SUM(DetVoucher.Produccion) AS Produc, " +
                    "'0.00' as ID0080,'0.00' as ID0081,'0.00' as ID0082,'0.00' as ID0083,'0.00' as ID0084,'0.00' as ID0085," +
                    "'0.00' as ID0086,'0.00' as ID0087,'0.00' as ID0088,'0.00' as ID0089,'0.00' as ID0090,'0.00' as ID0091," +
                    "'0.00' as ID0092,'0.00' as ID0093,'0.00' as ID0094,'0.00' as ID0095,'0.00' as ID0096,'0.00' as ID0097, '0.00' as HI,'0.00' as HT,'0.0' as Util " +
                    selMain +
                    " FROM ((EmpVoucher RIGHT JOIN (FBU_s INNER JOIN (Lineas INNER JOIN ((((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) INNER JOIN CentrosTrabajos ON DetVoucher.CentroTrabajo = CentrosTrabajos.CentroTrabajo) ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento)) ON FBU_s.FBU = CentrosTrabajos.FBU) ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher) LEFT JOIN Empleados ON EmpVoucher.Empleado = Empleados.Empleado) LEFT JOIN Supervisores ON EmpVoucher.Supervisor = Supervisores.Supervisor " +
                    joinCoord+joinProcs+
                    " WHERE (IndiceVoucher.Fecha >= #" + _date1 + "#) AND (IndiceVoucher.Fecha <= #" + _date2 + "#) "+//AND " +
                    //"  (CodigosDeOperacion.Consecutivo Not Between '0080' And '0096') " +
                    sqlTur + sqlCt + sqlFbu + sqlLine + sqlDepto + sqlCo + sqlEmp + sqlSup +sqlCoord+sqlProcs+
                    " GROUP BY |" +
                    grpMain + sqlEf;
                sqlMain = sqlMain.Replace("GROUP BY |,", "GROUP BY ");

                string sql = " SELECT " +
                    "SUM(DetVoucher.Horas) AS dHrs" + sqlHearn +
                    "SUM(DetVoucher.Eficiencia)AS ef,SUM(DetVoucher.Produccion) AS Produc, " +
                    //"SUM(HEarn) as ef,ROUND(SUM(DetVoucher.Produccion),2) AS produc, " +
                    "'0.00' as ID0080,'0.00' as ID0081,'0.00' as ID0082,'0.00' as ID0083,'0.00' as ID0084,'0.00' as ID0085," +
                    "'0.00' as ID0086,'0.00' as ID0087,'0.00' as ID0088,'0.00' as ID0089,'0.00' as ID0090,'0.00' as ID0091," +
                    "'0.00' as ID0092,'0.00' as ID0093,'0.00' as ID0094,'0.00' as ID0095,'0.00' as ID0096,'0.00' as ID0097, '0.00' as HI,'0.00' as HT,'0.0' as Util " +
                    selDepto +
                    selEmp +
                    selSup +
                    selCo +
                    selLinea +
                    grbyTurno +
                    selCt +
                    selFbu +
                    " FROM ((EmpVoucher RIGHT JOIN (FBU_s INNER JOIN (Lineas INNER JOIN ((((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) INNER JOIN CentrosTrabajos ON DetVoucher.CentroTrabajo = CentrosTrabajos.CentroTrabajo) ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento)) ON FBU_s.FBU = CentrosTrabajos.FBU) ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher) LEFT JOIN Empleados ON EmpVoucher.Empleado = Empleados.Empleado) LEFT JOIN Supervisores ON EmpVoucher.Supervisor = Supervisores.Supervisor " +
                    joinCoord+joinProcs+
                    " WHERE (IndiceVoucher.Fecha >= #" + _date1 + "#) AND (IndiceVoucher.Fecha <= #" + _date2 + "#) "+
                    sqlTur + sqlCt + sqlFbu + sqlLine + sqlDepto + sqlCo + sqlEmp + sqlSup +sqlCoord+sqlProcs+
                   " GROUP BY |" +
                    grbyDepto +
                    grbyEmp +
                    grbySup +
                    grbyCo +
                    grbyLine +
                    grbyCt +
                    grbyTurno +
                    grbyFbu +
                    sqlEf;
                sql = sql.Replace("GROUP BY |,", "GROUP BY ");

                string sqlDummy = " SELECT " +
                    "SUM(DetVoucher.Horas) AS dHrs" + sqlHearn +
                    "SUM(DetVoucher.Eficiencia)AS ef,SUM(DetVoucher.Produccion) AS Produc, " +
                    "'0.00' as ID0080,'0.00' as ID0081,'0.00' as ID0082,'0.00' as ID0083,'0.00' as ID0084,'0.00' as ID0085," +
                    "'0.00' as ID0086,'0.00' as ID0087,'0.00' as ID0088,'0.00' as ID0089,'0.00' as ID0090,'0.00' as ID0091," +
                    "'0.00' as ID0092,'0.00' as ID0093,'0.00' as ID0094,'0.00' as ID0095,'0.00' as ID0096,'0.00' as ID0097, '0.00' as HI,'0.00' as HT,'0.0' as Util " +
                    selDepto +
                    selEmp +
                    selSup +
                    selCo +
                    selLinea +
                    grbyTurno +
                     selFbu +
                    selCt +
                    " FROM ((EmpVoucher RIGHT JOIN (FBU_s INNER JOIN (Lineas INNER JOIN ((((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) INNER JOIN CentrosTrabajos ON DetVoucher.CentroTrabajo = CentrosTrabajos.CentroTrabajo) ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento)) ON FBU_s.FBU = CentrosTrabajos.FBU) ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher) LEFT JOIN Empleados ON EmpVoucher.Empleado = Empleados.Empleado) LEFT JOIN Supervisores ON EmpVoucher.Supervisor = Supervisores.Supervisor " +
                    joinCoord+joinProcs+
                    " WHERE (IndiceVoucher.Fecha >= #01/01/1800#) AND (IndiceVoucher.Fecha <= #01/01/1800#) "+
                    sqlTur + sqlCt + sqlFbu + sqlLine + sqlDepto + sqlCo + sqlEmp + sqlSup +sqlCoord+sqlProcs+
                   " GROUP BY |" +
                    grbyDepto +
                    grbyEmp +
                    grbySup +
                    grbyCo +
                    grbyLine +
                    grbyCt +
                     grbyTurno +
                    grbyFbu +
                    sqlEf;
                sqlDummy = sqlDummy.Replace("GROUP BY |,", "GROUP BY ");

                string sqlInd = "SELECT " + selICo + selICt + selIDep + selIEmp + selILin + selISup + "'ID'&CodigosDeOperacion.Consecutivo as Consecutivo,SUM(DetVoucher.Horas) AS indH " +
                     " FROM ((EmpVoucher RIGHT JOIN (FBU_s INNER JOIN (Lineas INNER JOIN ((((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) INNER JOIN CentrosTrabajos ON DetVoucher.CentroTrabajo = CentrosTrabajos.CentroTrabajo) ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento)) ON FBU_s.FBU = CentrosTrabajos.FBU) ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher) LEFT JOIN Empleados ON EmpVoucher.Empleado = Empleados.Empleado) LEFT JOIN Supervisores ON EmpVoucher.Supervisor = Supervisores.Supervisor " +
                     joinCoord+joinProcs+
                     " WHERE (IndiceVoucher.Fecha >= #" + _date1 + "#) AND (IndiceVoucher.Fecha <= #" + _date2 + "#) " +
                     " and (CodigosDeOperacion.Consecutivo Between '0080' And '0097') " +
                     sqlTur + sqlCt + sqlFbu + sqlLine + sqlDepto + sqlCo + sqlEmp + sqlSup +sqlCoord+sqlProcs+
                     " GROUP BY " + selICo + grpICt + grpIDep + grpIEmp + selILin + grpISup + "CodigosDeOperacion.Consecutivo";

                if (byCoord||byProcs)
                {
                    sqlMain = sqlMain.Replace("FROM ((", "FROM (((");
                    sql = sql.Replace("FROM ((", "FROM (((");
                    sqlDummy = sqlDummy.Replace("FROM ((", "FROM (((");
                    sqlInd = sqlInd.Replace("FROM ((", "FROM (((");
                }
                OleDbDataAdapter da = new OleDbDataAdapter(sqlDummy, conAcc);//tabla en blanco para popularla
                da.Fill(ds.Tables[0]);
                da.Dispose();

                efByDeptoBindingSource.DataSource = ds;

                DataTable dtMain = new DataTable();//tabla main (empelado o cod trab.)
                OleDbDataAdapter da1 = new OleDbDataAdapter(sqlMain, conAcc);
                da1.Fill(dtMain);
                da1.Dispose();

                DataTable dtD = new DataTable();//tabla con el detalle del reporte
                OleDbDataAdapter da2 = new OleDbDataAdapter(sql, conAcc);
                da2.Fill(dtD);
                da2.Dispose();

                //DataTable dtD = dtD2;
                
                //if (_efic != "")
                //{
                //    int aasd = dtD.Rows.Count;
                //    for (int w = 0; w < dtD.Rows.Count; w++)
                //    {
                //        double __eficiencia = 0, __hEarn=0, __hrsD=0;
                //        if (dtD.Rows[w]["HEarn"].ToString() != "")
                //        {
                //            __hEarn = Convert.ToDouble(dtD.Rows[w]["HEarn"]);
                //        }
                //        if (dtD.Rows[w]["DHrs"].ToString() != "")
                //        {
                //            __hrsD = Convert.ToDouble(dtD.Rows[w]["DHrs"]);
                //        }
                //        __eficiencia = (__hEarn / __hrsD) * 100;
                //        if (_efSign == "=")
                //        {
                //            if (__eficiencia != Convert.ToDouble(_efic))
                //                dtD.Rows.RemoveAt(w);
                //        }
                //        else if (_efSign == ">")
                //        {
                //            if (__eficiencia < Convert.ToDouble(_efic))
                //                dtD.Rows.RemoveAt(w);
                //        }
                //        else if (_efSign == "<")
                //        {
                //            if (__eficiencia > Convert.ToDouble(_efic))
                //                dtD.Rows.RemoveAt(w);
                //        }
                //    }
                //}

               

                DataTable dtInd = new DataTable();//tabla con valores indirectos (80..96)
                OleDbDataAdapter da3 = new OleDbDataAdapter(sqlInd, conAcc);
                da3.Fill(dtInd);
                da3.Dispose();
                string colCons = "";
                int rowsMain = 0;
                int count = ds.Tables[0].Rows.Count;
                if (dtMain.Rows.Count > 0 && dtD.Rows.Count > 0)
                {
                    for (int x = 0; x < dtMain.Rows.Count; x++)//renglones de la tbla main
                    {

                        ds.Tables[0].Rows.Add();//-->
                        if (_reporte == 6)
                        {
                            try
                            {
                                ds.Tables[0].Rows[rowsMain]["numemp"] = dtMain.Rows[x]["numemp"].ToString();
                                ds.Tables[0].Rows[rowsMain]["emp"] = dtMain.Rows[x]["emp"].ToString();
                            }
                            catch { }
                        }
                        else if (_reporte == 4)
                        {
                            ds.Tables[0].Rows[rowsMain]["codigooperacion"] = dtMain.Rows[x]["codigooperacion"].ToString();
                            ds.Tables[0].Rows[rowsMain]["coDesc"] = dtMain.Rows[x]["coDesc"].ToString();
                        }
                        double sumHrsIndSum = 0;
                        double hEarnSum = 0;
                        double hrsTotSum = 0;
                        double hrsDSum = 0;
                        double utilizacionSum = 0;
                        double _80 = 0, _81 = 0, _82 = 0, _83 = 0, _84 = 0, _85 = 0, _86 = 0, _87 = 0, _88 = 0, _89 = 0,
                            _90 = 0, _91 = 0, _92 = 0, _93 = 0, _94 = 0, _95 = 0, _96 = 0, _97 = 0;
                        for (int y = 0; y < dtD.Rows.Count; y++)//renglones de la tbla 2 (Directos)
                        {
                            if (dtMain.Rows[x][colJoin].ToString() == dtD.Rows[y][colJoin].ToString())
                            {

                                //-->aqui iban
                                double sumHrsInd = 0;
                                double hEarn = 0;
                                double hrsTot = 0;
                                double hrsD = 0;
                                double utilizacion = 0;
                                double eficiencia = 0;
                                //if (dtD.Rows[y]["HEarn"].ToString() != "")
                                //{
                                //    hEarn = Convert.ToDouble(dtD.Rows[y]["HEarn"]);
                                //    hEarnSum += hEarn;
                                //}
                                //if (dtD.Rows[y]["DHrs"].ToString() != "")
                                //{
                                //    hrsD = Convert.ToDouble(dtD.Rows[y]["DHrs"]);
                                //    hrsDSum += hrsD;
                                //}
                                //eficiencia = ((hEarn / hrsD) * 100);

                                ds.Tables[0].Rows.Add();//-->AGREGANDO RENGLON
                                rowsMain++;
                                //agregando valores a los filstros q selecciono el usuarios
                                string[] arrColFiltro = colFiltro.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                for (int d = 0; d < arrColFiltro.Length; d++)
                                {
                                    ds.Tables[0].Rows[rowsMain][arrColFiltro[d]] = dtD.Rows[y][arrColFiltro[d]].ToString();
                                }
                                //rellenando las columnasde indirectos con ceros
                                for (int colInd = 80; colInd <= 97; colInd++)
                                {
                                    ds.Tables[0].Rows[rowsMain]["ID00" + colInd.ToString()] = "0.00";
                                }

                                if (_reporte == 4)
                                {
                                    try
                                    {
                                        ds.Tables[0].Rows[rowsMain]["numemp"] = dtD.Rows[y]["numemp"].ToString();
                                        ds.Tables[0].Rows[rowsMain]["emp"] = dtD.Rows[y]["emp"].ToString();
                                    }
                                    catch { }
                                }
                                else if (_reporte == 6)
                                {
                                    ds.Tables[0].Rows[rowsMain]["codigooperacion"] = dtD.Rows[y]["codigooperacion"].ToString();
                                    ds.Tables[0].Rows[rowsMain]["coDesc"] = dtD.Rows[y]["coDesc"].ToString();
                                }

                                ////renglones de la tbla 2 (InDirectos)
                                if (dtInd.Rows.Count > 0)
                                {
                                    for (int b = 0; b < dtInd.Rows.Count; b++)//renglones de la tbla 2 (InDirectos)
                                    {
                                        //if (ds.Tables[0].Rows[a]["ct"].ToString() == dtInd.Rows[b]["ct"].ToString())
                                        if (dtD.Rows[y][colJoin].ToString() == dtInd.Rows[b][colJoin].ToString() &&
                                            dtD.Rows[y][colJoin2].ToString() == dtInd.Rows[b][colJoin2].ToString())
                                        {
                                            colCons = dtInd.Rows[b]["Consecutivo"].ToString();
                                            #region sumaIndirectos
                                            if (colCons == "ID0080")
                                                _80 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0081")
                                                _81 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0082")
                                                _82 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0083")
                                                _83 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0084")
                                                _84 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0085")
                                                _85 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0086")
                                                _86 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0087")
                                                _87 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0088")
                                                _88 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0089")
                                                _89 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0090")
                                                _90 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0091")
                                                _91 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0092")
                                                _92 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0093")
                                                _93 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0094")
                                                _94 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0095")
                                                _95 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0096")
                                                _96 += Convert.ToDouble(dtInd.Rows[b]["indH"]);
                                            if (colCons == "ID0097")
                                                _97 += Convert.ToDouble(dtInd.Rows[b]["indH"]);

                                            #endregion
                                            ds.Tables[0].Rows[rowsMain][colCons] = Convert.ToDouble(dtInd.Rows[b]["indH"]);//.ToString("0.00");
                                            sumHrsInd += Convert.ToDouble(dtInd.Rows[b]["indH"].ToString());
                                            sumHrsIndSum += sumHrsInd;
                                            //les borro los campos q no deberia tener
                                            dtD.Rows[y]["dhrs"] = "0";
                                            dtD.Rows[y]["hearn"] = "0";
                                            dtD.Rows[y]["ef"] = "0";
                                            dtD.Rows[y]["produc"] = "0";
                                        }
                                    }
                                }
                                //todos los sig los movi de arriba a esta posicion
                                ds.Tables[0].Rows[rowsMain]["dhrs"] = dtD.Rows[y]["dhrs"].ToString();
                                ds.Tables[0].Rows[rowsMain]["hearn"] = dtD.Rows[y]["hearn"].ToString();

                                //ds.Tables[0].Rows[rowsMain]["ef"] = dtD.Rows[y]["ef"].ToString();
                                //ds.Tables[0].Rows[rowsMain]["produc"] = dtD.Rows[y]["produc"].ToString();
                                if (dtD.Rows[y]["HEarn"].ToString() != "")
                                {
                                    hEarn = Convert.ToDouble(dtD.Rows[y]["HEarn"]);
                                    hEarnSum += hEarn;
                                }
                                if (dtD.Rows[y]["DHrs"].ToString() != "")
                                {
                                    hrsD = Convert.ToDouble(dtD.Rows[y]["DHrs"]);
                                    hrsDSum += hrsD;
                                }
                                if (hrsD == 0)
                                    eficiencia = 0;
                                else
                                eficiencia = ((hEarn / hrsD) * 100);


                                //
                                ds.Tables[0].Rows[rowsMain]["HI"] = sumHrsInd;//.ToString("0.00");//tot horas ind
                                //-->antes estaba mal la formula: hrsTot = hEarn + sumHrsInd;
                                hrsTot = hrsD + sumHrsInd;
                                //string hrstTotStr = hrsTot.ToString();//"0.00");
                                //if (hrstTotStr.IndexOf(".9") > 0)
                                //    hrsTot = Math.Round(hrsTot);
                                //else if (hrstTotStr.IndexOf(".1") > 0)
                                //    hrsTot = Math.Floor(hrsTot);
                                ds.Tables[0].Rows[rowsMain]["HT"] = hrsTot;//.ToString("0.00");//horas tot

                                if (hrsTot == 0)
                                {
                                    utilizacion = 0;
                                    ds.Tables[0].Rows[rowsMain]["produc"] = "0.00";
                                }
                                else
                                {
                                    utilizacion = (hrsD / hrsTot) * 100;
                                    ds.Tables[0].Rows[rowsMain]["produc"] = ((hEarn / hrsTot) * 100);//.ToString("0.00");
                                }

                                ds.Tables[0].Rows[rowsMain]["util"] = utilizacion;//.ToString("0.00");//utilizacion
                                //ds.Tables[0].Rows[rowsMain]["ef"] = ((hEarn / hrsD) * 100).ToString("0.00");
                                ds.Tables[0].Rows[rowsMain]["ef"] = eficiencia;//.ToString("0.00");
                            }
                        }
                        double eficienciasum = 0;
                        ds.Tables[0].Rows.Add();//-->Renglon del Total x subgrupo
                        rowsMain++;
                        ds.Tables[0].Rows[rowsMain]["dhrs"] = hrsDSum;
                        ds.Tables[0].Rows[rowsMain]["hearn"] = hEarnSum;
                        if (_reporte == 6)
                            ds.Tables[0].Rows[rowsMain]["coDesc"] = "Suma";
                        else if (_reporte == 4)
                            ds.Tables[0].Rows[rowsMain]["emp"] = "Suma";

                        if ((hrsDSum == 0)||(hEarnSum ==0 && hrsDSum==0))
                            eficienciasum = 0;
                        else
                            eficienciasum = ((hEarnSum / hrsDSum) * 100);

                        ds.Tables[0].Rows[rowsMain]["HI"] = sumHrsIndSum;//.ToString("0.00");//tot horas ind

                        //-->antes estaba mal la formula: hrsTotSum = hEarnSum + sumHrsIndSum;
                        hrsTotSum = hrsDSum + sumHrsIndSum;
                        //string hrstTotSumStr = hrsTotSum.ToString();//"0.00");
                        //if (hrstTotSumStr.IndexOf(".9") > 0)
                        //    hrsTotSum = Math.Round(hrsTotSum);
                        //else if (hrstTotSumStr.IndexOf(".1") > 0)
                        //    hrsTotSum = Math.Floor(hrsTotSum);
                        ds.Tables[0].Rows[rowsMain]["HT"] = hrsTotSum;//.ToString("0.00");//horas tot

                        if (hrsTotSum == 0)
                        {
                            ds.Tables[0].Rows[rowsMain]["produc"] = "0.00";
                            utilizacionSum = 0;
                        }
                        else
                        {
                            utilizacionSum = (hrsDSum / hrsTotSum) * 100;
                            ds.Tables[0].Rows[rowsMain]["produc"] = ((hEarnSum / hrsTotSum) * 100);//.ToString("0.00");
                        }
                        ds.Tables[0].Rows[rowsMain]["util"] = utilizacionSum;//.ToString("0.00");//utilizacion
                        //ds.Tables[0].Rows[rowsMain]["ef"] = ((hEarnSum / hrsDSum) * 100).ToString("0.00");
                        ds.Tables[0].Rows[rowsMain]["ef"] = eficienciasum;//.ToString("0.00");
                        

                        #region Hindirectas
                        //ds.Tables[0].Rows[rowsMain]["dhrs"] = "0";
                        //ds.Tables[0].Rows[rowsMain]["hearn"] = "0";
                        //ds.Tables[0].Rows[rowsMain]["ef"] = "0";
                        //ds.Tables[0].Rows[rowsMain]["produc"] = "0";
                       ds.Tables[0].Rows[rowsMain]["ID0080"] = _80;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0081"] = _81;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0082"] = _82;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0083"] = _83;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0084"] = _84;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0085"] = _85;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0086"] = _86;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0087"] = _87;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0088"] = _88;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0089"] = _89;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0090"] = _90;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0091"] = _91;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0092"] = _92;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0093"] = _93;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0094"] = _94;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0095"] = _95;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0096"] = _96;//.ToString("0.00");
                       ds.Tables[0].Rows[rowsMain]["ID0097"] = _97;//.ToString("0.00");
                        #endregion
                        ds.Tables[0].Rows.Add();//renglon de separacion con sig grupo
                        rowsMain++;
                        //string alfo = ds.Tables[0].Rows[rowsMain]["coDesc"].ToString();
                    }
                }
                //por alguna razon se acumulan renglones al final, aqui los borro
                for (int z = ds.Tables[0].Rows.Count-1; z >= rowsMain; z--)
                {
                    ds.Tables[0].Rows[z].Delete();
                }
                
                dtD.Dispose();
                dtInd.Dispose();
                dtMain.Dispose();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception err)
            {
                var st = new StackTrace(err, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
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
