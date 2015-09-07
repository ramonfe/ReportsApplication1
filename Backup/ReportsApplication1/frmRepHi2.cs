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
    public partial class frmRepHi2 : Form
    {
        dbClass capaDb = new dbClass();
        public frmRepHi2()
        {
            InitializeComponent();
        }
        string _linea = "", _depto = "", _turno = "", _efic = "", _date1 = "", _date2 = "", _efSign = "", _ct = "";
        int _reporte = 0;
        #region properties
        public int reporte
        {
            set
            {
                _reporte = value;
            }
        }
        //public string linea
        //{
        //    set
        //    {
        //        _linea = value;
        //    }
        //}
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
        //public string efic
        //{
        //    set
        //    {
        //        _efic = value;
        //    }
        //}
        //public string efsign
        //{
        //    set
        //    {
        //        _efSign = value;
        //    }
        //}
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
        string _di = "";
        public string di
        {
            set
            {
                _di = value;
            }
        }
        string _diN = "";
        public string diN
        {
            set
            {
                _diN = value;
            }
        }
        //string _emp = "";
        //public string emp
        //{
        //    set
        //    {
        //        _emp = value;
        //    }
        //}
        //string _empN = "";
        //public string empN
        //{
        //    set
        //    {
        //        _empN = value;
        //    }
        //}
        string _sup = "";
        public string sup
        {
            set
            {
                _sup = value;
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
        string _coord = "";
        public string coord
        {
            set
            {
                _coord = value;
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
        //int _showOver = 0;
        //public int showOver
        //{
        //    set
        //    {
        //        _showOver = value;
        //    }
        //}
        #endregion
        private void rep2_Load(object sender, EventArgs e)
        {

            string appPath = ConfigurationSettings.AppSettings["PathBd"];
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
            DataSet ds = new DataSet();
            ds.Tables.Add("efByDepto");
            ds.Tables.Add("efByDeptoInd");
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                ReportParameter d1 = new ReportParameter("date1", _date1);
                ReportParameter d2 = new ReportParameter("date2", _date2);
                //ReportParameter t = new ReportParameter("turno", _turno);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { d1, d2});//, t });

                string sqlDepto = "", sqlLine = "", sqlTur = "", sqlEf = "", sqlCt = "", sqlFbu = "",
                    grbyLine = "", grbyDepto = "", selLinea = "", selDepto = "", grbyCt = "", selCt = "",
                    grbyCo = "", selCo = "", grbyEmp = "", selEmp = "", grbySup = "", selSup = "",grbyTurno="";

                string selIDep = "", grpIDep="",selICt = "",grpICt="", selILin = "", selICo = "",
                    selIEmp = "", grpIEmp = "", selISup = "", grpISup = "", colJoin = "", repName = "",
                    selFbu = "", grbyFbu = "", grpILinea="";

                string titFiltros = "Del: " + _date1+" Al: "+_date2;
                //string quitaInd = "  and (CodigosDeOperacion.Consecutivo Not Between '0080' And '0096') ";
                #region que tipo de reporte es
                //if (_reporte == 0)//depto
                //{
                //selIDep = " Departamentos.Departamento as depto,";
                //grpIDep = " Departamentos.Departamento,";
                    colJoin = "fecha";
                    //selDepto = ",Departamentos.Departamento as depto,Departamentos.descripcion as deptoDesc,Departamentos.overhead ";    
                    //grbyDepto = ",Departamentos.Departamento,Departamentos.descripcion,Departamentos.overhead ";

                    repName = "Reporte de Horas Indirectas por dia";
               
               // ReportParameter pRep = new ReportParameter("pRep", _reporte.ToString());
                ReportParameter pRepN = new ReportParameter("repName", repName);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pRepN });
                #endregion
                #region filtros
                if (_turno != "")
                {
                    sqlTur = " and (IndiceVoucher.Turno in (" + _turno + ")) ";
                    titFiltros += ", Turno: "+_turno;
                    //grbyTurno = ",IndiceVoucher.Turno ";
                    //ReportParameter pTurno = new ReportParameter("turno", "1");
                    //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pTurno });
                }
                //if (_efic != "")
                //{
                //    titFiltros += ", Eficiencia " + _efSign + " " + _efic;
                //    //sqlEf = " having (ROUND(SUM(DetVoucher.Eficiencia),2) " + _efSign + _efic + ") ";
                //    //ROUND(SUM(DetVoucher.Horas), 2) AS DHrs,ROUND(SUM(DetVoucher.HEarned), 2) AS HEarn
                //    sqlEf = " having SUM(DetVoucher.Horas) >0 and ((ROUND(SUM(DetVoucher.HEarned), 2)/ROUND(SUM(DetVoucher.Horas), 2))*100) " + _efSign + _efic + " ";
                //}
                if (_ct != "")
                {
                    titFiltros += ", Centr. de Trab: "+ _ctN;
                    sqlCt = " and CentrosTrabajos.centrotrabajo in (" + _ct + ") ";
                    if (_reporte != 1)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    {
                        //ReportParameter pct = new ReportParameter("ct", "1");
                        //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pct });
                        //grbyCt = ",CentrosTrabajos.CentroTrabajo, CentrosTrabajos.Descripcion ";
                        //selCt = ",CentrosTrabajos.CentroTrabajo as ct, CentrosTrabajos.Descripcion as descr ";
                    }
                }
                if (_fbu != "")
                {
                    titFiltros += ", FBU: " + _fbu_name;
                    //ReportParameter pfbu = new ReportParameter("fbu", "1");
                    //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pfbu });
                    sqlFbu = " and FBU_s.FBU = '" + _fbu + "' ";
                    //selFbu = ",FBU_s.FBU, FBU_s.Descripcion as fbuDesc ";
                    //grbyFbu = ",FBU_s.FBU, FBU_s.Descripcion ";
                }
                //if (_linea != "")
                //{
                //    titFiltros += ", Linea: " + _linea;
                //    sqlLine = " and lineas.linea  in (" + _linea + ") ";
                //    if (_reporte != 2)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                //    {
                //        ReportParameter pline = new ReportParameter("linea", "1");
                //        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pline });
                //        //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                //        grbyLine = ",Lineas.Linea,lineas.descripcion ";
                //        selLinea = ",Lineas.Linea,lineas.descripcion as lineaDesc ";
                //    }
                //}
                string sqlCo = "";
                if (_di != "")//departamentos indirectos
                {
                    titFiltros += ", Horas Ind: " + _diN;
                    sqlCo = " and CodigosDeOperacion.Consecutivo in (" + _di + ") ";
                    string[] hrs = _di.Split(new string[] {",","'"}, StringSplitOptions.RemoveEmptyEntries);
                    string[] hrsName = _diN.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int x = 0; x < hrs.Length; x++)
                    {
                        ReportParameter hIndName = new ReportParameter("p"+hrs[x], hrsName[x]);

                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { hIndName });
                    }
                    //if (_reporte != 3)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    //{
                    //    ReportParameter pco = new ReportParameter("codOp", "1");
                    //    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pco });
                    //    //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                    //    grbyCo = ",DetVoucher.codigooperacion,codigosdeoperacion.descesp ";
                    //    selCo = ",DetVoucher.codigooperacion,codigosdeoperacion.descesp as coDesc";
                    //}
                }
                else
                {
                    string sqlHrs = "select * from IndirectosAsignadosDepartementosPlanta";
                    DataTable dtHrs = new DataTable();
                    OleDbDataAdapter da3 = new OleDbDataAdapter(sqlHrs, conAcc);
                    da3.Fill(dtHrs);
                    da3.Dispose();
                    for (int x = 0; x < dtHrs.Rows.Count; x++)
                    {
                        ReportParameter hIndName = new ReportParameter("p"+dtHrs.Rows[x][1].ToString(), dtHrs.Rows[x][0].ToString());
                        
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { hIndName });
                    }
                    dtHrs.Dispose();
                }
                //string sqlEmp = "";
                //if (_emp != "")
                //{
                //    titFiltros += ", Empleado " + _empN;
                //    sqlEmp = " and empvoucher.empleado  = " + _emp + " ";
                //    if (_reporte != 5)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                //    {
                //        ReportParameter pemp = new ReportParameter("emp", "1");
                //        this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pemp });
                //        //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                //        //grbyEmp = ",empleados.nombre ";
                //        //selEmp = ",empleados.nombre as emp ";
                //        grbyEmp = ",empleados.empleado,empleados.nombre ";
                //        selEmp = ",empleados.empleado as numemp,empleados.nombre as emp ";
                //    }
                //}
                string sqlSup = "";
                if (_sup != "")
                {
                    titFiltros += ", Supv: " + _supN;
                    sqlSup = " and empvoucher.supervisor  = '" + _sup + "' ";
                    if (_reporte != 7)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    {                        
                        //ReportParameter psup = new ReportParameter("sup", "1");
                        //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { psup });
                        //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                        //grbySup = ",supervisores.nombre ";
                        //selSup = ",supervisores.nombre as sup ";
                    }
                }
                string sqlCoord = "", joinCoord = "", grbyCoord = "", selCoord="";
                bool byCoord = false;
                if (_coord != "")
                {
                    byCoord = true;
                    //tablascoord = ",sup_cord,coordinadores ";
                    joinCoord = ") LEFT JOIN Sup_Cord ON Supervisores.Supervisor = Sup_Cord.ID_sup) LEFT JOIN Coordinadores ON Sup_Cord.ID_Cord = Coordinadores.ID_Coordinador ";
                               //) LEFT JOIN Sup_Cord ON Supervisores.Supervisor = Sup_Cord.ID_sup) LEFT JOIN Coordinadores ON Sup_Cord.ID_Cord = Coordinadores.ID_Coordinador) 
                    titFiltros += ", Coordinador: " + _coordN;
                    sqlCoord = " and coordinadores.id_coordinador  = '" + _coord + "' ";
                    //if (_reporte != 7)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    //{
                    //ReportParameter pcord = new ReportParameter("coord", "1");
                    //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pcord });
                    //    //inJoinLine = " DetVoucher INNER JOIN Lineas ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento) ";
                    //grbyCoord = ",coordinadores.nombre_coord ";
                    //selCoord = ",coordinadores.nombre_coord as coord ";
                    //}
                }
                if (_depto != "")
                {
                    titFiltros += ", Depto: " + _deptoName;
                    sqlDepto = " and departamentos.departamento in (" + _depto + ") ";
                    //if (_reporte != 0)//si es reporte es el mismo el par. no es nec. y las demas lineas ya estan cargadas previamente
                    //{
                    //    ReportParameter pdepto = new ReportParameter("departamento", "1");
                    //    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pdepto });
                    //    //inJoinDepto = "  DetVoucher INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento ";
                    //    grbyDepto = ",Departamentos.Departamento,Departamentos.descripcion ";
                    //    selDepto = ",Departamentos.Departamento as depto,Departamentos.descripcion as deptoDesc ";
                    //}
                }
                #endregion
                ReportParameter pTf = new ReportParameter("pFiltros", titFiltros);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pTf });
                conAcc.Open();
                string sql = " SELECT " +
                    //"ROUND(SUM(DetVoucher.Horas), 2) AS DHrs,ROUND(SUM(DetVoucher.HEarned), 2) AS HEarn," +
                    //"ROUND(SUM(DetVoucher.Eficiencia),2)AS ef,ROUND(SUM(DetVoucher.Produccion),2) AS produc, " +
                    " IndiceVoucher.Fecha, Sum(DetVoucher.Horas) AS DHrs," +                    
                    "'0.00' as 0080,'0.00' as 0081,'0.00' as 0082,'0.00' as 0083,'0.00' as 0084,'0.00' as 0085," +
                    "'0.00' as 0086,'0.00' as 0087,'0.00' as 0088,'0.00' as 0089,'0.00' as 0090,'0.00' as 0091," +
                    "'0.00' as 0092,'0.00' as 0093,'0.00' as 0094,'0.00' as 0095,'0.00' as 0096,'0.00' as 0097 " +
                    selDepto +
                    selEmp +
                    selSup +
                    selCo +
                    selLinea +
                    selCt +
                    grbyTurno+
                    selFbu+
                    selCoord+
                    //FROM ((((EmpVoucher RIGHT JOIN (FBU_s INNER JOIN ((((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) INNER JOIN CentrosTrabajos ON DetVoucher.CentroTrabajo = CentrosTrabajos.CentroTrabajo) ON FBU_s.FBU = CentrosTrabajos.FBU) ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher) LEFT JOIN Supervisores ON EmpVoucher.Supervisor = Supervisores.Supervisor) LEFT JOIN Sup_Cord ON Supervisores.Supervisor = Sup_Cord.ID_sup) LEFT JOIN Coordinadores ON Sup_Cord.ID_Cord = Coordinadores.ID_Coordinador) INNER JOIN IndirectosAsignadosDepartementosPlanta ON CodigosDeOperacion.Consecutivo = IndirectosAsignadosDepartementosPlanta.Codigo_Indirecto
                    " FROM ((EmpVoucher RIGHT JOIN (FBU_s INNER JOIN   ((((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) INNER JOIN CentrosTrabajos ON DetVoucher.CentroTrabajo = CentrosTrabajos.CentroTrabajo) ON FBU_s.FBU = CentrosTrabajos.FBU) ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher) LEFT JOIN Supervisores ON EmpVoucher.Supervisor = Supervisores.Supervisor) INNER JOIN IndirectosAsignadosDepartementosPlanta ON CodigosDeOperacion.Consecutivo = IndirectosAsignadosDepartementosPlanta.Codigo_Indirecto " +
                    joinCoord +
                    " WHERE (IndiceVoucher.Fecha >= #" + _date1 + "#) AND (IndiceVoucher.Fecha <= #" + _date2 + "#) "+//AND " +                    
                    //quitaInd + todos deben de selecionar hasta los indirectos
                    sqlTur + sqlCt + sqlFbu + sqlLine + sqlDepto + sqlCo + sqlSup +sqlCoord+
                    " GROUP BY IndiceVoucher.Fecha ";
                //    grbyDepto +
                //    grbyEmp +
                //    grbySup +
                //    grbyCo +
                //    grbyLine +
                //    grbyCt +
                //    grbyTurno+
                //    grbyFbu+
                //    sqlEf+
                //    grbyCoord;
                //sql = sql.Replace("GROUP BY |,", "GROUP BY ");
                if (byCoord)
                    sql = sql.Replace("FROM ((", "FROM ((((");
                string sqlInd = "SELECT IndirectosAsignadosDepartementosPlanta.Codigo_Indirecto, Sum(DetVoucher.Horas) AS indH, IndiceVoucher.Fecha " +
                     //" FROM ((EmpVoucher RIGHT JOIN (FBU_s INNER JOIN (Lineas INNER JOIN ((((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) INNER JOIN CentrosTrabajos ON DetVoucher.CentroTrabajo = CentrosTrabajos.CentroTrabajo) ON (Lineas.CentroTrabajo = DetVoucher.CentroTrabajo) AND (Lineas.Linea = DetVoucher.Linea) AND (Lineas.Departamento = DetVoucher.Departamento)) ON FBU_s.FBU = CentrosTrabajos.FBU) ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher) LEFT JOIN Empleados ON EmpVoucher.Empleado = Empleados.Empleado) LEFT JOIN Supervisores ON EmpVoucher.Supervisor = Supervisores.Supervisor " +
                     " FROM ((EmpVoucher RIGHT JOIN (FBU_s INNER JOIN   ((((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN Departamentos ON DetVoucher.Departamento = Departamentos.Departamento) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) INNER JOIN CentrosTrabajos ON DetVoucher.CentroTrabajo = CentrosTrabajos.CentroTrabajo) ON FBU_s.FBU = CentrosTrabajos.FBU) ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher) LEFT JOIN Supervisores ON EmpVoucher.Supervisor = Supervisores.Supervisor) INNER JOIN IndirectosAsignadosDepartementosPlanta ON CodigosDeOperacion.Consecutivo = IndirectosAsignadosDepartementosPlanta.Codigo_Indirecto " +
                     joinCoord+
                     " WHERE (IndiceVoucher.Fecha >= #" + _date1 + "#) AND (IndiceVoucher.Fecha <= #" + _date2 + "#) " +
                     //" and (CodigosDeOperacion.Consecutivo Between '0080' And '0096') " +
                     sqlTur + sqlCt + sqlFbu + sqlLine + sqlDepto + sqlCo + sqlSup +sqlCoord+
                     " GROUP BY IndirectosAsignadosDepartementosPlanta.Codigo_Indirecto, IndiceVoucher.Fecha ORDER BY IndiceVoucher.Fecha ";
               
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                da.Fill(ds.Tables[0]);
                da.Dispose();

                efByDeptoBindingSource.DataSource = ds;//.Tables[0];
                if (byCoord)
                    sqlInd = sqlInd.Replace("FROM ((", "FROM ((((");

                DataTable dtInd = new DataTable();
                OleDbDataAdapter da2 = new OleDbDataAdapter(sqlInd, conAcc);
                da2.Fill(dtInd);
                da2.Dispose();
                string colCons = "";
                //if (ds.Tables[0].Rows.Count > 0 && dtInd.Rows.Count > 0) ANTES
                if (ds.Tables[0].Rows.Count > 0)
                {
                    double overHeadAcum = 0;
                    double HrsTotAcum = 0;
                    //ReportParameter ptr = new ReportParameter("totReg", "1");
                    //this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ptr });
                   
                    double sumHrsInd = 0;
                    for (int a = 0; a < ds.Tables[0].Rows.Count; a++)//renglones de la tbla 1 (directos)
                    {
                        
                        double hEarn = 0;
                        double hrsTot = 0;
                        double hrsD = 0;
                        double utilizacion = 0;
                        double eficiencia = 0;
                        double overhead = 0;
                        //cambio la sig linea
                        if (dtInd.Rows.Count > 0)
                        {
                            for (int b = 0; b < dtInd.Rows.Count; b++)//renglones de la tbla 2 (InDirectos)
                            {
                                //if (ds.Tables[0].Rows[a]["ct"].ToString() == dtInd.Rows[b]["ct"].ToString())
                                if (ds.Tables[0].Rows[a][colJoin].ToString() == dtInd.Rows[b][colJoin].ToString())
                                {
                                    colCons = dtInd.Rows[b]["codigo_indirecto"].ToString();
                                    ds.Tables[0].Rows[a][colCons] = dtInd.Rows[b]["indH"].ToString();
                                    sumHrsInd += Convert.ToDouble(dtInd.Rows[b]["indH"].ToString());
                                    //if (_reporte == 3)//si es x cod. de operacion le quito campos q no debe tener
                                    //{
                                    //    //les borro los campos q no deberia tener
                                    //    ds.Tables[0].Rows[a]["dhrs"] = "0";
                                    //    ds.Tables[0].Rows[a]["hearn"] = "0";
                                    //    ds.Tables[0].Rows[a]["ef"] = "0";
                                    //    ds.Tables[0].Rows[a]["produc"] = "0";
                                    //}
                                }
                            }
                        }
                       

                    }
                    string pPerc="";
                    if (dtInd.Rows.Count > 0)
                        pPerc = "100%";
                    ReportParameter _pPerc = new ReportParameter("pPerc", pPerc);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { _pPerc });

                    ReportParameter pOH = new ReportParameter("pTotHrs",sumHrsInd.ToString());
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pOH });
                    //}

                }
                
                dtInd.Dispose();

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
