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
    public partial class frmLogin : Form
    {
        dbClass capaDb = new dbClass();
        bool _result=false;
        public bool result
        {
            get
            {
                return _result;
            }
        }
        string _captura = "";
        public string captura
        {
            get
            {
                return _captura;
            }
        }
        string _privilegios = "";
        public string privilegios
        {
            get
            {
                return _privilegios;
            }
        }
        string _reportes = "";
        public string reportes
        {
            get
            {
                return _reportes;
            }
        }
        string _moding = "";
        public string moding
        {
            get
            {
                return _moding;
            }
        }
        string _emp = "";
        public string emp
        {
            get
            {
                return _emp;
            }
        }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //string appPath = ConfigurationSettings.AppSettings["PathBd"];
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                    //"Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=l3v1t0np@$$s1mg@p;Data Source=" + appPath);
            try
            {
                conAcc.Open();
                string sql = "select * from permisos where userid = '"+txtLogin.Text+"'";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                
                DataTable dt = new DataTable();
                //dt.Columns.Add("descripcion", typeof(string));
                //dt.Columns.Add("departamento", typeof(string));
                //dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["clave"].ToString() == txtPass.Text)
                    {
                        _moding = dt.Rows[0]["moduloingenieria"].ToString();
                        _captura = dt.Rows[0]["captura"].ToString();
                        _privilegios = dt.Rows[0]["seguridad"].ToString();
                        _reportes = dt.Rows[0]["reportes"].ToString();
                        _emp = dt.Rows[0]["consulta"].ToString();
                        _result = true;
                        this.Close();
                    }
                    else
                    {
                        _result = false;
                        MessageBox.Show("Clave Incorrecta");
                        txtPass.Focus();
                        return;
                    }
                }
                else
                {
                    _result = false;
                    MessageBox.Show("No existe el usuario");
                    txtLogin.Focus();
                    return;
                }

            }
            catch (Exception err)
            {
                _result = false;
                MessageBox.Show(err.Message);
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _result = false;
            this.Close();
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }
    }
}
