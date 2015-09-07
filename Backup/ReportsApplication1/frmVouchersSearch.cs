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

namespace ReportsApplication1
{
    public partial class frmVouchersSearch : Form
    {
        dbClass capaDb = new dbClass();
        int _noVoucher = 0;
        public int noVoucher
        {
            get
            {
                return _noVoucher;
            }
        }
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        public frmVouchersSearch()
        {
            InitializeComponent();
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                string fechas = "", turno = "", empleado = "", depto = "", codOp = "",voucher="",linea="";
                if (!cbNoDate.Checked)
                    fechas = "and (IndiceVoucher.Fecha Between #" + date1.Value.ToShortDateString() +
                        "# And #" + date2.Value.ToShortDateString() + "#) ";
                if (tbVoucher.Text != "")
                    voucher = " AND IndiceVoucher.novoucher= " + tbVoucher.Text;
                //if (tbTurno.Text != "")
                //    turno = " AND IndiceVoucher.Turno= " +tbTurno.Text;
                if (tbEmp.Text != "")
                    empleado = " AND EmpVoucher.Empleado="+ tbEmp.Text;
                //if (tbLinea.Text != "")
                //    linea = " AND DetVoucher.linea='" + tbLinea.Text+"'";
                if (tbCo.Text != "")
                    codOp = " AND DetVoucher.CodigoOperacion='" + tbCo.Text+"'";

                string sql = "SELECT IndiceVoucher.novoucher,IndiceVoucher.Fecha, IndiceVoucher.Turno, EmpVoucher.Empleado, " +
                    "DetVoucher.Empezo,DetVoucher.Termino,DetVoucher.Horas,DetVoucher.CodigoOperacion,DetVoucher.Linea," +
                    "DetVoucher.Eficiencia " +
                    "FROM (IndiceVoucher INNER JOIN EmpVoucher ON IndiceVoucher.NoVoucher = EmpVoucher.NoVoucher) INNER JOIN DetVoucher ON IndiceVoucher.NoVoucher = DetVoucher.NoVoucher " +
                    "WHERE IndiceVoucher.operadores > 0 " + fechas + turno + empleado + linea + codOp+voucher;
                conAcc.Open();
                OleDbDataAdapter da2 = new OleDbDataAdapter(sql, conAcc);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dgResult.DataSource = dt2;
                dt2.Dispose();
                da2.Dispose();
            }
            catch(Exception err)
            {
                MessageBox.Show("Error en la busqueda:"+err.Message);
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
        }

        private void frmVouchersSearch_Load(object sender, EventArgs e)
        {
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgResult_DoubleClick(object sender, EventArgs e)
        {
            if (dgResult.Rows.Count > 0)
            {
                _noVoucher = Convert.ToInt32(dgResult[0, dgResult.CurrentRow.Index].Value.ToString());
                this.Close();
            }
        }
    }
}
