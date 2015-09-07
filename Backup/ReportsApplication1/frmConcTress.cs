using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.OleDb;

namespace ReportsApplication1
{
    public partial class frmConcTress : Form
    {
        dbClass capaDb = new dbClass();
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        int repType = 0;
        public int RepType
        {
            set
            {
                repType = value;
                if (value == 1)
                    this.Text = "Cargar archivo de checadas";
                else if (value == 2)
                    this.Text = "Cargar listado de empleados";
            }
        }
        public frmConcTress()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            oFileDlg.ShowDialog();
            if (oFileDlg.FileName != null)
            {
                txtFileSel.Text = oFileDlg.FileName;
            }
        }
        private void cargaChecadas()
        {
            if (File.Exists(txtFileSel.Text))
            {
                #region tabla donde se cargaran las discrepancias
                DataTable dtVMal = new DataTable();
                dtVMal.Columns.Add("EMPLEADO");
                dtVMal.Columns.Add("NOMBRE");
                dtVMal.Columns.Add("TOTAL_HORAS");
                dtVMal.Columns.Add("HRS_VOUCHER");
                dtVMal.Columns.Add("COORDINADOR");

                //dtVMal.Columns.Add("EMPLEADO");
                //dtVMal.Columns.Add("NOMBRE");
                //dtVMal.Columns.Add("ENTRO");
                //dtVMal.Columns.Add("SALIO");
                //dtVMal.Columns.Add("NUM_VOUCHER");
                //dtVMal.Columns.Add("EMPEZO");
                //dtVMal.Columns.Add("TERMINO");
                #endregion
                string[] arrStr = File.ReadAllLines(txtFileSel.Text);
                string[,] arrChecadas = new string[arrStr.Length, 2];
                progBar.Minimum = 0;
                progBar.Maximum = arrStr.Length;
                string[] line = null;
                string num = "";
                string name = "";
                string entro = "";
                string salio = "";
                string fecha = "";
                string coord = "";
                //horas checada
                string[] arrH1Check = null;
                string[] arrH2Check = null;
                double h1Chr = 0;
                double h1Cmin = 0;
                double h2Chr = 0;
                double h2Cmin = 0;
                double horaV = 0, horaChk = 0;
                int valorX = 0;
                //DataSet ds = new DataSet("conciliacion2");
                try
                {

                    for (int x = 0; x < arrStr.Length; x++)
                    {
                        num = "";
                        name = "";
                        entro = "";
                        salio = "";
                        fecha = "";
                        h1Chr = 0;
                        h1Cmin = 0;
                        h2Chr = 0;
                        h2Cmin = 0;
                        horaV = 0;
                        horaChk = 0;
                        valorX = x;
                        arrStr[x] = arrStr[x].Replace('\"', ' ');
                        line = arrStr[x].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        num = line[0];
                        arrChecadas[x, 0] = num;
                        name = line[1] + "," + line[2];
                        if (line[3] != ":")
                            entro = line[3];
                        if (line[4] != ":")
                            salio = line[4];
                        if (line[6] != ":")
                            salio = line[6];
                        else if (line[5] != ":")
                            salio = line[5];


                        fecha = line[7];
                        if (!string.IsNullOrEmpty(entro) && !string.IsNullOrEmpty(salio))
                        //horas checad7
                        {
                            arrH1Check = entro.Split(':');
                            arrH2Check = salio.Split(':');
                            h1Chr = Convert.ToDouble(arrH1Check[0]);
                            h1Cmin = Convert.ToDouble(arrH1Check[1]);
                            h2Chr = Convert.ToDouble(arrH2Check[0]);
                            h2Cmin = Convert.ToDouble(arrH2Check[1]);
                        }
                        h1Cmin = h1Cmin / 60;
                        h2Cmin = h2Cmin / 60;
                        h1Chr += h1Cmin;
                        h2Chr += h2Cmin;
                        horaChk = h2Chr - h1Chr;
                        arrChecadas[x, 1] = horaChk.ToString();
                        progBar.Value = x;
                    }
                }
                catch (Exception err)
                {

                    lblErr.Text = "Error: el archivo no tiene la estructura esperada";
                    return;
                }
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    conAcc.Open();
                    #region query
                    string sql = "SELECT empleado,nombre,Coordinadores.Nombre_coord FROM Empleados INNER JOIN Coordinadores ON Empleados.Coordinador " +
                    " = Coordinadores.ID_Coordinador order by empleado";
                    #endregion
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    da.Dispose();
                    //if (dt.Rows.Count > 0)
                    //{
                    //progBar.Minimum = 0;
                    progBar.Maximum = dtEmpl.Rows.Count;
                    for (int a = 0; a < dtEmpl.Rows.Count; a++)
                    {
                        progBar.Value = a;
                        horaChk = 0;
                        num = dtEmpl.Rows[a][0].ToString();
                        name = dtEmpl.Rows[a][1].ToString();
                        horaV = 0;
                        coord = dtEmpl.Rows[a][2].ToString();
                        string sqlHrs = "SELECT Sum(DetVoucher.Horas) AS SumOfHoras " +
                        " FROM (IndiceVoucher INNER JOIN EmpVoucher ON IndiceVoucher.NoVoucher = EmpVoucher.NoVoucher) INNER JOIN " +
                        " DetVoucher ON EmpVoucher.NoVoucher = DetVoucher.NoVoucher " +
                        " WHERE (((IndiceVoucher.Fecha)=#" + fecha + "#) AND ((EmpVoucher.Empleado)=" + num + ")) ";

                        OleDbDataAdapter da2 = new OleDbDataAdapter(sqlHrs, conAcc);
                        DataTable dtVouch = new DataTable();
                        da2.Fill(dtVouch);
                        da2.Dispose();
                        if (dtVouch.Rows.Count > 0 && string.IsNullOrEmpty(dtVouch.Rows[0][0].ToString()) == false)
                            horaV = Convert.ToDouble(dtVouch.Rows[0][0].ToString());
                        dtVouch.Dispose();
                        for (int arrId = 0; arrId < arrChecadas.GetUpperBound(0); arrId++)
                        {
                            if (arrChecadas[arrId, 0] == num)
                            {
                                horaChk = Convert.ToDouble(arrChecadas[arrId, 1]);
                                break;
                            }
                        }
                        dtVMal.Rows.Add(new object[] { num, name, horaChk, horaV, coord });
                        progBar.Value = a;
                    }
                    #region compara horas

                    //horas vouchers
                    //string NoVoucher = dt.Rows[0][0].ToString();
                    //string[] arrH1Voucher = dt.Rows[0][1].ToString().Split(':');
                    //string[] arrH2Voucher = dt.Rows[1][1].ToString().Split(':');
                    //double h1Vhr = Convert.ToDouble(arrH1Voucher[0]);
                    //double h1Vmin = Convert.ToDouble(arrH1Voucher[1]);
                    //double h2Vhr = Convert.ToDouble(arrH2Voucher[0]);
                    //double h2Vmin = Convert.ToDouble(arrH2Voucher[1]);
                    //h1Vmin = h1Vmin / 60;
                    //h2Vmin = h2Vmin / 60;
                    //h1Vhr += h1Vmin;
                    //h2Vhr += h2Vmin;
                    //horas checada
                    //string[] arrH1Check = entro.Split(':');
                    //string[] arrH2Check = salio.Split(':');
                    //double h1Chr = Convert.ToDouble(arrH1Check[0]);
                    //double h1Cmin = Convert.ToDouble(arrH1Check[1]);
                    //double h2Chr = Convert.ToDouble(arrH2Check[0]);
                    //double h2Cmin = Convert.ToDouble(arrH2Check[1]);
                    //h1Cmin = h1Cmin / 60;
                    //h2Cmin = h2Cmin / 60;
                    //h1Chr += h1Cmin;
                    //h2Chr += h2Cmin;


                    //if ((h1Vhr < h1Chr || h1Vhr > h2Chr) || (h2Vhr < h1Chr || h2Vhr > h2Chr))
                    //{
                    //    dtVMal.Rows.Add(new object[] { num, name, entro, salio, NoVoucher, dt.Rows[0][1].ToString(),
                    //        dt.Rows[1][1].ToString()});
                    //}

                    #endregion
                    //}
                    dtEmpl.Dispose();
                }
                catch (Exception err)
                {
                    if (err.Message != "No current record.")
                        lblErr.Text = "Error cargando checadas: " + err.Message;
                }
                finally
                {
                    conAcc.Close();
                    conAcc.Dispose();
                }

                //}
                if (dtVMal.Rows.Count > 0)
                {
                    //ds.Tables.Add(dtVMal);
                    frmRConc frmRepConc = new frmRConc();
                    frmRepConc.dtConc = dtVMal;
                    frmRepConc.fecha = "Fecha de Reporte: " + fecha;
                    //frmDiscrEmplChecadas frmDisc = new frmDiscrEmplChecadas();
                    //frmDisc.dtP = dtVMal;
                    dtVMal.Dispose();
                    this.Hide();
                    frmRepConc.ShowDialog();
                    frmRepConc.Dispose();
                    this.Show();
                }
                else
                    lblErr.Text = "No se encontraron discrepancias!!";
            }
        }
        private void btnCarga_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (txtFileSel.Text != "")
            {
                if (repType == 1)
                    cargaChecadas();
                else if (repType == 2)
                    cargaEmpleados();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cargaEmpleados()
        {
            if (File.Exists(txtFileSel.Text))
            {                
                string[] arrStr = File.ReadAllLines(txtFileSel.Text);
                //string[,] arrChecadas = new string[arrStr.Length, 2];
                progBar.Minimum = 0;
                progBar.Maximum = arrStr.Length-1;
                string[] line = null;
                string num = "";
                string name = "";
                string sup = "";
                string fecha = DateTime.Today.ToShortDateString();
                string sqlInsert = "";

                try
                {
                    for (int x = 0; x < arrStr.Length; x++)
                    {
                        num = "";
                        name = "";
                        sup = "";

                        //fecha = "";

                        arrStr[x] = arrStr[x].Replace('\"',' ');
                        line = arrStr[x].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        num = line[0];
                        // arrChecadas[x, 0] = num;
                        name = line[1].Trim() + "," + line[2].Trim();
                        if (!string.IsNullOrEmpty(line[3]))
                            sup = line[3];
                        //if (!string.IsNullOrEmpty(line[4]))
                          //  fecha = line[4];

                        // arrChecadas[x, 1] = horaChk.ToString();


                        OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                        try
                        {
                            conAcc.Open();
                            #region queryes
                            string sql = "SELECT count(empleado) FROM Empleados where empleado=" + num;

                            OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                            DataTable dtEmpl = new DataTable();
                            da.Fill(dtEmpl);
                            da.Dispose();
                            string empExist = "0";
                            empExist = dtEmpl.Rows[0][0].ToString();
                            dtEmpl.Dispose();
                            if (empExist == "0")
                            {
                                //progBar.Minimum = 0;
                                // progBar.Maximum = dtEmpl.Rows.Count;

                                string supId = "00";                            
                                string sqlHrs = "SELECT supervisor from supervisores where nombre ='" + sup + "'";
                                OleDbDataAdapter da2 = new OleDbDataAdapter(sqlHrs, conAcc);
                                DataTable dtVouch = new DataTable();
                                da2.Fill(dtVouch);
                                da2.Dispose();
                                if (dtVouch.Rows.Count > 0)
                                    supId = dtVouch.Rows[0][0].ToString();
                                dtVouch.Dispose();
                                //insert del empleado
                                sqlInsert = "insert into empleados values(" + num + ",'" + name + "'," + fecha + "," + fecha + ",'" + supId + "',1,'00')";
                               
                                OleDbCommand comm = new OleDbCommand(sqlInsert, conAcc);
                                comm.ExecuteNonQuery();

                            }
                            
                            #endregion
                        }
                        catch (Exception err)
                        {
                            if (err.Message != "No current record.")
                                lblErr.Text = "Error cargando empleados: " + err.Message;
                        }
                        finally
                        {
                            conAcc.Close();
                            conAcc.Dispose();
                        }
                        progBar.Value = x;
                        
                    }
                    MessageBox.Show("El listado de Empleados fue cargado a la base de datos");
                }
                catch (Exception err)
                {

                    lblErr.Text = "Error: el archivo no tiene la estructura esperada";
                    return;
                }
                //}
                //if (dtVMal.Rows.Count > 0)
                //{
                //    //ds.Tables.Add(dtVMal);
                //    frmRConc frmRepConc = new frmRConc();
                //    frmRepConc.dtConc = dtVMal;
                //    frmRepConc.fecha = "Fecha de Reporte: " + fecha;
                //    //frmDiscrEmplChecadas frmDisc = new frmDiscrEmplChecadas();
                //    //frmDisc.dtP = dtVMal;
                //    dtVMal.Dispose();
                //    this.Hide();
                //    frmRepConc.ShowDialog();
                //    frmRepConc.Dispose();
                //    this.Show();
                //}
                //else
                //    lblErr.Text = "No se encontraron discrepancias!!";
            }
        }
    }
}
    
