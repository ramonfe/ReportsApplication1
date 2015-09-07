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
    public partial class frmSearchcomun : Form
    {
        dbClass capaDb = new dbClass();
        int _tipoReporte = 0;
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        string sqlWhere = "";
        public frmSearchcomun(int tipoReporte)
        {
            InitializeComponent();
            _tipoReporte = tipoReporte;
        }
        #region propiedades
        string _nDepto;
        public string nDepto
        {
            get
            {
                return _nDepto;
            }
        }
        string _Emp;
        public string Emp
        {
            get
            {
                return _Emp;
            }
        }
        int _ct;
        public int ct
        {
            get
            {
                return _ct;
            }
        }
        int _lineId;
        public int lineId
        {
            get
            {
                return _lineId;
            }
        }
        string _fbu;
        public string fbuId
        {
            get
            {
                return _fbu;
            }
        }
        string _sc;
        public string scId
        {
            get
            {
                return _sc;
            }
        }
        string _turno;
        public string tId
        {
            get
            {
                return _turno;
            }
        }
        string _npId;
        public string npId
        {
            get
            {
                return _npId;
            }
        }
        string _uId;
        public string uId
        {
            get
            {
                return _uId;
            }
        }
        string _ciId;
        public string ciId
        {
            get
            {
                return _ciId;
            }
        }
        string _idProc;
        public string idProc
        {
            get
            {
                return _idProc;
            }
        }
        #endregion
        private void frmSearchcomun_Load(object sender, EventArgs e)
        {
            
            cargaGrid();
        }
        private void cargaGrid()
        {
            string sql = "";
            switch (_tipoReporte)
            {
                #region tipos
                case 1:
                    {
                        //aqui var el query..tambien esta pendiente validar q los numericos en la entrada de datos
                        sql = "select * from departamentos order by FBU,departamento";
                        break;
                    }
                case 2:
                    {
                        sql = "select FBU,DEPARTAMENTO,CENTROTRABAJO,DESCRIPCION from centrostrabajos order by FBU,departamento,centrotrabajo";
                        break;
                    }
                case 3:
                    {

                        sql = "select * from lineas order by departamento,centrotrabajo,linea";
                        break;
                    }
                case 4:
                    {

                        sql = "select * from fbu_s order by FBU";
                        break;
                    }
                case 5:
                    {

                        sql = "select * from supervisores order by supervisor";
                        break;
                    }
                case 6:
                    {

                        sql = "select * from coordinadores order by id_coordinador";
                        break;
                    }
                case 7:
                    {

                        sql = "select * from turnos order by turno";
                        break;
                    }
                case 8:
                    {

                        sql = "select * from numeros_de_parte order by no_parte";
                        break;
                    }
                case 9:
                    {

                        sql = "select userid,moduloingenieria,captura,reportes as conciliacion,seguridad,consulta as empleados from permisos order by userid";
                        break;
                    }
                case 10:
                    {

                        sql = "select codigo_indirecto,departamento,descripcion from IndirectosAsignadosDepartementosPlanta order by codigo_indirecto";
                        break;
                    }
                case 11:
                    {
                        panel1.Visible = true;
                        sql = "SELECT Empleados.Empleado AS EMPLEADO, Empleados.Nombre AS NOMBRE, Empleados.Status AS ESTATUS, supervisores.Nombre as SUPERVISOR," +
                            " Coordinadores.Nombre_coord AS COORDINADOR" +
                            " FROM (Empleados INNER JOIN supervisores ON Empleados.Supervisor = " +
                            " supervisores.Supervisor) INNER JOIN Coordinadores ON Empleados.Coordinador = " +
                            " Coordinadores.ID_Coordinador " + sqlWhere;
                        break;
                    }
                case 12:
                    {

                        sql = "select * from procesos order by proceso";
                        break;
                    }
                #endregion
            }
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
                #region columnas de reporte
                if (_tipoReporte == 3)
                {
                    dg.Columns[5].Visible = false;
                    dg.Columns[4].Width = 250;
                }
                if (_tipoReporte == 8)
                {
                    dg.Columns[4].Visible = false;
                }
                if (_tipoReporte >= 4 && _tipoReporte <= 6)
                {
                    dg.Columns[1].Width = 250;
                }
                if (_tipoReporte == 10)
                {
                    dg.Columns[2].Width = 350;
                }
                if (_tipoReporte == 12)
                {
                    dg.Columns[0].Visible = false;
                    dg.Columns[1].Width = 300;
                }
                #endregion
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
            #region seleccion
            if (dg.Rows.Count > 0)
            {
                switch (_tipoReporte)
                {
                    case 1:
                        {
                            _nDepto = dg[1, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                    case 2:
                        {
                            _ct = Convert.ToInt32(dg[2, dg.CurrentRow.Index].Value.ToString());
                            break;
                        }
                    case 3:
                        {
                            _lineId = Convert.ToInt32(dg[5, dg.CurrentRow.Index].Value.ToString());
                            break;
                        }
                    case 4:
                        {
                            _fbu = dg[0, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                    case 5:
                    case 6:
                        {
                            _sc = dg[0, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                    case 7:
                        {
                            _turno = dg[0, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                    case 8:
                        {
                            _npId = dg[4, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                    case 9:
                        {
                            _uId = dg[0, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                    case 10:
                        {
                            _ciId = dg[0, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                    case 11:
                        {
                            _Emp = dg[0, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                    case 12:
                        {
                            _idProc = dg[0, dg.CurrentRow.Index].Value.ToString();
                            break;
                        }
                }
                this.Close();
            }
            #endregion
        }
        private void btnfilter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFilter.Text))
            {
                sqlWhere = " where UCASE(Empleados.Nombre) like '%" + txtFilter.Text.ToUpper() + "%'";
                
            }
            else
            {
                sqlWhere = "";
            }
            cargaGrid();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            cargaSeleccion();
        }
    }
}
