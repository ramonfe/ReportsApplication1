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
    public partial class frmSearchCodOp : Form
    {
        dbClass capaDb = new dbClass();
        int _tipoReporte = 0;
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        public frmSearchCodOp(int tipoReporte)
        {
            InitializeComponent();
            _tipoReporte = tipoReporte;
        }
       
        string _co;
        public string co
        {
            get
            {
                return _co;
            }
        }
        
        private void frmSearchcomun_Load(object sender, EventArgs e)
        {

            busqueda(" select CodigosDeOperacion.*, procesos.proceso as proceso FROM CodigosDeOperacion LEFT JOIN procesos ON "+
                " CodigosDeOperacion.proceso = procesos.proc_id order by codigooperacion ");
            cargaCt();
        }
        private void cargaCt()
        {
            //lCt.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select centrotrabajo,centrotrabajo & ' | ' & descripcion as descripcion from centrostrabajos " +
                    " order by descripcion";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("centrotrabajo", typeof(string));
                //dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                cmbCt.DisplayMember = "descripcion";
                cmbCt.ValueMember = "centrotrabajo";
                cmbCt.DataSource = dt;

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
            cmbCt.SelectedIndex = -1;
        }
        private void busqueda(string sql)
        {
            #region executa query
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();

                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();

                da.Fill(dt);
                da.Dispose();
                dg.DataSource = dt;
                dt.Dispose();


                dg.Columns[16].Visible = false;
                dg.Columns[18].Visible = false;
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
            #endregion
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            cargaSeleccion();
        }
        private void cargaSeleccion()
        {
            if (dg.Rows.Count > 0)
            {

                _co = dg[0, dg.CurrentRow.Index].Value.ToString();

                this.Close();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string co="",ct="",ora="",filtros="",sql;
            if (txtCo.Text != "")
                co = " CodigosDeOperacion.codigooperacion like'%" + txtCo.Text + "%'|";
            if (cmbCt.Text != "")
                ct = " CodigosDeOperacion.centrotrabajo='" + cmbCt.SelectedValue.ToString() + "'|";
            if (txtOra.Text != "")
                ora = " CodigosDeOperacion.oracle like '%" + txtOra.Text + "%'|";
            filtros = co + ct + ora;
            filtros = filtros.TrimEnd('|');
            filtros = filtros.Replace("|", " and ");
            if (filtros.Length>0)
                filtros = " where " + filtros; ;
            /*select CodigosDeOperacion.*, procesos.proceso as proceso FROM CodigosDeOperacion LEFT JOIN procesos ON "+
                " CodigosDeOperacion.proceso = procesos.proc_id order by codigooperacion ");
             * */
            busqueda("select CodigosDeOperacion.*,procesos.proceso as proceso FROM CodigosDeOperacion LEFT JOIN procesos ON " +
                " CodigosDeOperacion.proceso = procesos.proc_id " + filtros + " order by CodigosDeOperacion.codigooperacion");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            cargaSeleccion();
        }
    }
}
