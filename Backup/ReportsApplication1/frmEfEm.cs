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

namespace ReportsApplication1
{
    public partial class frmEfEm : Form
    {
        dbClass capaDb = new dbClass();
        public frmEfEm()
        {
            InitializeComponent();
        }
        string _linea = "",_codOp ="",_depto="",_turno="",_efic="",_date1="",_date2="",_efSign="",_ct="";
        #region properties
        public string linea
        {
            set
            {
                _linea = value;
            }
        }
        public string codOp
        {
            set
            {
                _codOp = value;
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
                string sqlDepto = "", sqlTur = "", sqlEf = "", sqlCt = "", sqlFbu = "";

                         
                if (_turno != "")
                {
                    sqlTur = " and (IndiceVoucher.Turno = " + _turno + ") ";
                }
                if (_efic != "")
                {
                    sqlEf = " having (ROUND(SUM(DetVoucher.Eficiencia),2) " + _efSign + _efic + ") ";
                }
                if (_ct != "")
                {
                    sqlCt = " and CentrosTrabajos.Descripcion in (" + _ct + ") ";
                }
                if (_fbu != "")
                {
                    sqlFbu = " and FBU_s.FBU = '" + _fbu + "' ";
                }
                conAcc.Open();
                string sql = " SELECT FBU_s.FBU, FBU_s.Descripcion as fbuDesc, CentrosTrabajos.CentroTrabajo as ct, CentrosTrabajos.Descripcion as descr,IndiceVoucher.Turno," +
                    "ROUND(SUM(DetVoucher.Horas), 2) AS DHrs,ROUND(SUM(DetVoucher.HEarned), 2) AS HEarn," +
                    "ROUND(SUM(DetVoucher.Eficiencia),2)AS ef,ROUND(SUM(DetVoucher.Produccion),2) AS produc, " +
                    "'0.00' as 0080,'0.00' as 0081,'0.00' as 0082,'0.00' as 0083,'0.00' as 0084,'0.00' as 0085," +
                    "'0.00' as 0086,'0.00' as 0087,'0.00' as 0088,'0.00' as 0089,'0.00' as 0090,'0.00' as 0091,"+
                    "'0.00' as 0092,'0.00' as 0093,'0.00' as 0094,'0.00' as 0095,'0.00' as 0096, '0.00' as HI,'0.00' as HT,'0.0' as util " +
                    " FROM (CentrosTrabajos INNER JOIN ((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) ON CentrosTrabajos.CentroTrabajo = DetVoucher.CentroTrabajo) INNER JOIN FBU_s ON CentrosTrabajos.FBU = FBU_s.FBU " +
                    " WHERE (IndiceVoucher.Fecha >= #"+_date1+"#) AND (IndiceVoucher.Fecha <= #"+_date2+"#) AND " +
                    "  (CodigosDeOperacion.Consecutivo Not Between '0080' And '0096') " +
                    sqlTur+sqlCt+sqlFbu+
                    " GROUP BY FBU_s.FBU, FBU_s.Descripcion, CentrosTrabajos.CentroTrabajo, CentrosTrabajos.Descripcion,IndiceVoucher.Turno "+
                    sqlEf;

                string sqlInd = "SELECT  CentrosTrabajos.CentroTrabajo as ct,CodigosDeOperacion.Consecutivo,ROUND(SUM(DetVoucher.Horas), 2) AS indH " +
                     " FROM (CentrosTrabajos INNER JOIN ((IndiceVoucher INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher) INNER JOIN CodigosDeOperacion ON DetVoucher.CodigoOperacion = CodigosDeOperacion.CodigoOperacion) ON CentrosTrabajos.CentroTrabajo = DetVoucher.CentroTrabajo) INNER JOIN FBU_s ON CentrosTrabajos.FBU = FBU_s.FBU " +
                     " WHERE (IndiceVoucher.Fecha >= #" + _date1 + "#) AND (IndiceVoucher.Fecha <= #" + _date2 + "#) " +
                     " and (CodigosDeOperacion.Consecutivo Between '0080' And '0096') " +
                     sqlTur + sqlCt + sqlFbu +
                     " GROUP BY CentrosTrabajos.CentroTrabajo, CodigosDeOperacion.Consecutivo";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                da.Fill(ds.Tables[0]);
                da.Dispose();
                efByDeptoBindingSource.DataSource = ds;//.Tables[0];

                DataTable dtInd = new DataTable();
                OleDbDataAdapter da2 = new OleDbDataAdapter(sqlInd, conAcc);
                da2.Fill(dtInd);
                da2.Dispose();
                string colCons="";
                if (ds.Tables[0].Rows.Count > 0 && dtInd.Rows.Count > 0)
                {
                    for (int a = 0; a < ds.Tables[0].Rows.Count; a++)//renglones de la tbla 1 (directos)
                    {
                        double sumHrsInd = 0;
                        double hEarn = 0;
                        double hrsTot = 0;
                        double hrsD = 0;
                        double utilizacion = 0;
                        if (ds.Tables[0].Rows[a]["HEarn"].ToString() != "")
                        {
                            hEarn = Convert.ToDouble(ds.Tables[0].Rows[a]["HEarn"]);
                        }
                        if (ds.Tables[0].Rows[a]["DHrs"].ToString() != "")
                        {
                            hrsD = Convert.ToDouble(ds.Tables[0].Rows[a]["DHrs"]);
                        }
                        for (int b = 0; b < dtInd.Rows.Count; b++)//renglones de la tbla 2 (InDirectos)
                        {
                            if (ds.Tables[0].Rows[a]["ct"].ToString() == dtInd.Rows[b]["ct"].ToString())
                            {
                                colCons = dtInd.Rows[b]["Consecutivo"].ToString();
                                ds.Tables[0].Rows[a][colCons] = dtInd.Rows[b]["indH"].ToString();
                                sumHrsInd+= Convert.ToDouble(dtInd.Rows[b]["indH"].ToString());
                            }
                        }
                        ds.Tables[0].Rows[a]["HI"] = sumHrsInd;//.ToString("0.00");//tot horas ind
                        hrsTot = hEarn + sumHrsInd;
                        ds.Tables[0].Rows[a]["HT"] = hrsTot;//.ToString("0.00");//horas tot
                        utilizacion = (hrsD / hrsTot) * 100;
                        ds.Tables[0].Rows[a]["util"] = utilizacion;//.ToString("0.00");//utilizacion
                    }
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
