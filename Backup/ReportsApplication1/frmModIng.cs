using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;


namespace ReportsApplication1
{
    public partial class frmModIng : Form
    {
        dbClass capaDb = new dbClass();
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        bool editando = false, lReload = false;
        string ctOriginal = "", deptoOriginal = "", fbuOriginal = "", scOriginal = "", tOriginal="";
        bool horaEnt = false,horaSal = false,d1_1=false,d1_2=false,d2_1=false,d2_2=false,d3_1=false,d3_2=false;
        string npId = "",ciId="",idProc="";
        public frmModIng()
        {
            InitializeComponent();
            treeView1.ExpandAll();
        }


        private void remueveTabs()
        {
            foreach (TabPage tp in this.tabControl.TabPages)
            {
                tabControl.TabPages.Remove(tp);
            }
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            remueveTabs();
            tabControl.Visible = true;
            tabsControlsStatus(e.Node.Name, false);
            switch (e.Node.Name)
            {
                case "nCiD":
                    tabControl.TabPages.Add(tabNciD);
                    break;
                case "nDep":
                    tabControl.TabPages.Add(tabDeptos);
                    break;
                case "nCt":
                    tabControl.TabPages.Add(tabCt);
                    break;
                case "nL":
                    tabControl.TabPages.Add(tabLine);
                    break;
                case "nFbu":
                    tabControl.TabPages.Add(tabFbu);
                    break;
                case "nSup":
                case "nCoord":
                    tabControl.TabPages.Add(tabSc);
                    tabControl.TabPages["tabSc"].Text = e.Node.Text;
                    break;
                case "nSc":
                    tabControl.TabPages.Add(tabRelsc);
                    break;
                case "nTur":
                    tabControl.TabPages.Add(tabTurnos);
                    break;
                case "nNp":
                    tabControl.TabPages.Add(tabNoParte);
                    break;
                case "nProc":
                    tabControl.TabPages.Add(tabProc);
                    break;
                case "nEc":
                    lblerr4.Text = "";
                    txtEmp.Text = "";
                    txtEmpName.Text = "";
                    cmbEmpSup.DataSource = null;
                    cmbEmpSup.Items.Clear();
                    lstBoxEmpl.DataSource = null;
                    lstBoxEmpl.Items.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    tabControl.TabPages.Add(tabEmpCoord);
                    break;
                case "nRegresar":
                    this.Close();
                    break;
                case "nCo":
                    frmCodOp co = new frmCodOp();
                    this.Hide();
                    co.ShowDialog();
                    co.Dispose();
                    this.Show();
                    treeView1.Nodes[0].ExpandAll();
                    break;
                case "otro":
                    break;
                default:
                    tabControl.Visible = false;
                    break;

            }
            this.Cursor = Cursors.Default;
        }
        private void tabsControlsStatus(string tabName, bool status)
        {
            switch (tabName)
            {
                case "nDep":
                    if (!status)
                    {
                        btn_dNew.Enabled = true;
                        btn_dSearch.Enabled = true;
                        btn_dAdd.Enabled = false;
                        btn_dDel.Enabled = false;
                        btn_dEdit.Enabled = false;
                        cargaFbu(dFbu);
                        dFbu.SelectedIndex = -1;
                    }

                    dNumDepto.Text = "";
                    dDepto.Text = "";
                    dOverHead.Text = "";
                    ohDec.Text = "";

                    dFbu.Enabled = status;
                    dNumDepto.Enabled = status;
                    dDepto.Enabled = status;
                    dOverHead.Enabled = status;
                    ohDec.Enabled = status;
                    break;
                case "nCt":
                    if (!status)
                    {
                        btn_ctNew.Enabled = true;
                        btn_ctSearch.Enabled = true;
                        btn_ctAdd.Enabled = false;
                        btn_ctDel.Enabled = false;
                        btn_ctEdit.Enabled = false;
                        cargaFbu(ctFbu);
                        cargaDeptos(ctDepto);
                        ctFbu.SelectedIndex = -1;
                        ctDepto.SelectedIndex = -1;
                    }

                    ct.Text = "";
                    //dDepto.Text = "";
                    ctDesc.Text = "";

                    ctFbu.Enabled = status;
                    ctDepto.Enabled = status;
                    ct.Enabled = status;
                    ctDesc.Enabled = status;
                    break;
                case "nL":
                    if (!status)
                    {
                        btn_lNew.Enabled = true;
                        btn_lSearch.Enabled = true;
                        btn_lAdd.Enabled = false;
                        btn_lDel.Enabled = false;
                        btn_lEdit.Enabled = false;
                        cargaFbu(lFbu);
                        cargaDeptos(lDepto);
                        lFbu.SelectedIndex = -1;
                        lDepto.SelectedIndex = -1;
                        lCt.SelectedIndex = -1;
                        
                    }
                    linea.Text = "";
                    lDesc.Text = "";

                    lFbu.Enabled = status;
                    lDepto.Enabled = status;
                    lCt.Enabled = status;
                    linea.Enabled = status;
                    lDesc.Enabled = status;
                    break;
                case "nFbu":
                    if (!status)
                    {
                        btn_fNew.Enabled = true;
                        btn_fSearch.Enabled = true;
                        btn_fAdd.Enabled = false;
                        btn_fDel.Enabled = false;
                        btn_fEdit.Enabled = false;
                    }
                    fDesc.Text = "";
                    fId.Text = "";
                    fId.Enabled = status;
                    fDesc.Enabled = status;
                    break;
                case "nSup":
                case "nCoord":
                    if (!status)
                    {
                        btn_scNew.Enabled = true;
                        btn_scSearch.Enabled = true;
                        btn_scAdd.Enabled = false;
                        btn_scDel.Enabled = false;
                        btn_scEdit.Enabled = false;
                    }
                    scId.Text = "";
                    scNom.Text = "";
                    scId.Enabled = status;
                    scNom.Enabled = status;
                    break;
                case "nProc":
                    if (!status)
                    {
                        btn_pNew.Enabled = true;
                        btn_pSearch.Enabled = true;
                        btn_pAdd.Enabled = false;
                        btn_pDel.Enabled = false;
                        btn_pEdit.Enabled = false;
                    }
                    txtProc.Text = "";

                    txtProc.Enabled = status;
                   
                    break;
                case "nSc":
                    if (!status)
                    {                        
                        cargaSup(cmbSup);
                        cargaCoord(chkListCoord);
                    }
                    chkListCoord.Enabled = status;
                    break;
                case "nTur":
                    if (!status)
                    {
                        btn_tNew.Enabled = true;
                        btn_tSearch.Enabled = true;
                        btn_tAdd.Enabled = false;
                        btn_tDel.Enabled = false;
                        btn_tEdit.Enabled = false;
                    }
                    turnosObjEnabled(status, true);                    
                    break;
                case "nCiD":
                    if (!status)
                    {
                        btn_ciNew.Enabled = true;
                        btn_ciSearch.Enabled = true;
                        btn_ciAdd.Enabled = false;
                        btn_ciDel.Enabled = false;
                        btn_ciEdit.Enabled = false;
                    }
                    txtCi.Text = "";
                    txtDepto.Text = "";
                    txtDesc.Text = "";
                    txtCi.Enabled = status;
                    txtDepto.Enabled = status;
                    txtDesc.Enabled = status;
                    break;
                case "nNp":
                    if (!status)
                    {                        
                        btn_npNew.Enabled = true;
                        btn_npSearch.Enabled = true;
                        btn_npAdd.Enabled = false;
                        btn_npDel.Enabled = false;
                        btn_npEdit.Enabled = false;
                        cargaCodOp(cmbCodOp);
                        cmbCodOp.SelectedIndex = -1;           
                    }
                    np.Text = "";
                    sec.Text = "";
                    codOra.Text = "";
                    np.Enabled = status;
                    sec.Enabled = status;
                    codOra.Enabled = status;
                    cmbCodOp.Enabled = status;                    
                    break;
                default:
                    break;
            }
        }
        private void cargaCodOp(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select codigooperacion from codigosdeoperacion where activo = 1 order by codigooperacion";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("codigooperacion", typeof(string));
                //dt.Columns.Add("codigooperacion", typeof(string));
                dt.Rows.Add(new object[] { "Seleccione.."});
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "codigooperacion";
                lb.ValueMember = "codigooperacion";
                lb.DataSource = dt;
               
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
            lb.SelectedIndex = -1;
        }
        private void btn_dNew_Click(object sender, EventArgs e)
        {
            tabsControlsStatus("nDep", true);
            btn_dNew.Enabled = false;
            btn_dAdd.Enabled = true;
            btn_dSearch.Enabled = false;
            btn_dDel.Enabled = false;
            btn_dEdit.Enabled = false;
            dFbu.SelectedIndex = 0;
            dFbu.Focus();
        }
        private void cargaFbu(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select * from fbu_s order by FBU";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("fbu", typeof(string));
                dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "descripcion";
                lb.ValueMember = "fbu";
                lb.DataSource = dt;
                
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
            lb.SelectedIndex = -1;
        }
        private void cargaCoord(CheckedListBox chk)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select id_coordinador,nombre_coord from coordinadores order by nombre_coord";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("id_coordinador", typeof(string));
                dt.Columns.Add("nombre_coord", typeof(string));

                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                chk.DisplayMember = "nombre_coord";
                chk.ValueMember = "id_coordinador";
                chk.DataSource = dt;
                //chkListCoord
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
            // lb.SelectedIndex = -1;
        }
        private void cargaDeptos(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select departamento,departamento & ' | ' & descripcion as descripcion from departamentos order by departamento";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("departamento", typeof(string));
                dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "descripcion";
                lb.ValueMember = "departamento";
                lb.DataSource = dt;

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
            lb.SelectedIndex = -1;
        }
        private void cargaSup(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select supervisor,nombre from supervisores order by nombre";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("nombre", typeof(string));
                dt.Columns.Add("supervisor", typeof(string));
                if (lb.Name != "cmbEmpSup")
                    dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "nombre";
                lb.ValueMember = "supervisor";
                lb.DataSource = dt;

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
            lb.SelectedIndex = -1;
        }

        private void btn_dAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                abc(1);//editando
                editando = false;
            }
            else
                abc(0);//alta


        }
        private void abc(int accionVoucher)
        {
            bool allOk = true;
            if (dFbu.SelectedIndex == 0 || dNumDepto.Text == "" || dDepto.Text == "" || dOverHead.Text == "")
            {
                MessageBox.Show("Datos Insuficientes");
                return;
            }
            dNumDepto.Text = dNumDepto.Text.Replace(" ", "");
            dOverHead.Text = dOverHead.Text.Replace(" ", "");
            string sqlAccion = "", overHead = dOverHead.Text.Trim();
            if (ohDec.Text != "" && ohDec.Text.Length > 0)
            {
                ohDec.Text = ohDec.Text.Replace(" ", "");
                overHead += "." + ohDec.Text.Trim();
            }

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();


                if (accionVoucher == 0)//es un nuevo 
                {
                    sqlAccion = "insert into departamentos (fbu,departamento,descripcion,overhead)values('" +
                        dFbu.SelectedValue.ToString() + "','" + dNumDepto.Text.Trim() + "','" + dDepto.Text.ToUpper() + "'," +
                        overHead + ")";
                }
                else if (accionVoucher == 1)//editar 
                {
                    sqlAccion = "update departamentos set fbu='" + dFbu.SelectedValue.ToString() + "',departamento='" +
                        dNumDepto.Text.Trim() + "',descripcion='" + dDepto.Text.ToUpper() + "',overhead=" + overHead +
                        " where departamento='" + deptoOriginal + "'";
                }
                else if (accionVoucher == 2)//borrar 
                {
                    sqlAccion = "delete from departamentos where departamento='" + dNumDepto.Text + "'";
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();

            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar el Departamento: " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "El numero de departamento esta duplicado, verifique";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accionVoucher == 0 || accionVoucher == 1))
            {
                btn_dNew.Enabled = true;
                btn_dDel.Enabled = true;
                btn_dEdit.Enabled = true;
                btn_dSearch.Enabled = true;
                btn_dAdd.Enabled = false;
                dFbu.Enabled = false;
                dNumDepto.Enabled = false;
                dDepto.Enabled = false;
                dOverHead.Enabled = false;
                ohDec.Enabled = false;
            }
            #endregion
        }
        private void abcCt(int accionVoucher)
        {
            bool allOk = true;
            if (ctFbu.SelectedIndex == 0 || ctDepto.SelectedIndex == 0 || ct.Text == "" || ctDesc.Text == "")
            {
                MessageBox.Show("Datos Insuficientes");
                return;
            }
            ct.Text = ct.Text.Replace(" ", "");

            string sqlAccion = "";


            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();


                if (accionVoucher == 0)//es un nuevo 
                {
                    sqlAccion = "insert into centrostrabajos (centrotrabajo,departamento,fbu,descripcion)values('" +
                        ct.Text.Trim() + "','" + ctDepto.SelectedValue.ToString() + "','" + ctFbu.SelectedValue.ToString() +
                        "','" + ctDesc.Text.ToUpper() + "')";
                }
                else if (accionVoucher == 1)//editar 
                {
                    sqlAccion = "update centrostrabajos set fbu='" + ctFbu.SelectedValue.ToString() + "',departamento='" +
                        ctDepto.SelectedValue.ToString() + "',descripcion='" + ctDesc.Text.ToUpper() + "',centrotrabajo='" +
                         ct.Text + "' where centrotrabajo='" + ctOriginal + "'";
                }
                else if (accionVoucher == 2)//borrar 
                {
                    sqlAccion = "delete from centrostrabajos where centrotrabajo='" + ct.Text + "'";
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();

            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar el Centro de Trabajo: " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "El Centro de Trabajo esta duplicado, verifique";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accionVoucher == 0 || accionVoucher == 1))
            {
                btn_ctNew.Enabled = true;
                btn_ctDel.Enabled = true;
                btn_ctEdit.Enabled = true;
                btn_ctSearch.Enabled = true;
                btn_ctAdd.Enabled = false;

                ctFbu.Enabled = false;
                ctDepto.Enabled = false;
                ctDesc.Enabled = false;
                ct.Enabled = false;

            }
            #endregion
        }
        private void btn_dEdit_Click(object sender, EventArgs e)
        {
            deptoOriginal = dNumDepto.Text;
            dFbu.Enabled = true;
            dNumDepto.Enabled = true;
            dDepto.Enabled = true;
            dOverHead.Enabled = true;
            ohDec.Enabled = true;
            editando = true;
            btn_dNew.Enabled = false;
            btn_dEdit.Enabled = false;
            btn_dDel.Enabled = false;
            btn_dSearch.Enabled = false;
            btn_dAdd.Enabled = true;
        }

        private void btn_dDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abc(2);
                dFbu.SelectedIndex = 0;
                dNumDepto.Text = "";
                dDepto.Text = "";
                dOverHead.Text = "";
                ohDec.Text = "";

                dFbu.Enabled = false;
                dNumDepto.Enabled = false;
                dDepto.Enabled = false;
                dOverHead.Enabled = false;
                ohDec.Enabled = false;

                btn_dAdd.Enabled = false;
                btn_dNew.Enabled = true;
                btn_dEdit.Enabled = false;
                btn_dDel.Enabled = false;
                btn_dSearch.Enabled = true;
            }
        }

        private void btn_dSearch_Click(object sender, EventArgs e)
        {
            //frmS.tbVoucher.Text = "";
            //frmS.tbEmp.Text = "";
            //frmS.tbCo.Text = "";
            frmSearchcomun frmS = new frmSearchcomun(1);

            frmS.ShowDialog();
            if (frmS.nDepto != null)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    //indVoucher = frmS.noVoucher;
                    #region carga los empl
                    string sqlEmpl = "select * from departamentos where departamento ='" + frmS.nDepto + "'";

                    conAcc.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    int totEmpl = dtEmpl.Rows.Count;
                    if (dtEmpl.Rows.Count > 0)
                    {
                        dFbu.SelectedValue = dtEmpl.Rows[0][0].ToString();
                        dNumDepto.Text = dtEmpl.Rows[0][1].ToString();
                        dDepto.Text = dtEmpl.Rows[0][2].ToString();
                        string[] ohArray = dtEmpl.Rows[0][3].ToString().Split('.');
                        dOverHead.Text = ohArray[0];
                        if (ohArray.Length > 1)
                            ohDec.Text = ohArray[1];
                    }
                    dtEmpl.Dispose();
                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion


                    da.Dispose();
                    btn_dNew.Enabled = true;
                    btn_dDel.Enabled = true;
                    btn_dEdit.Enabled = true;
                    btn_dSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar el departamento: " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }

        private void dNumDepto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");

        }

        private void dFbu_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void btn_ctNew_Click(object sender, EventArgs e)
        {
            tabsControlsStatus("nCt", true);
            btn_ctNew.Enabled = false;
            btn_ctAdd.Enabled = true;
            btn_ctSearch.Enabled = false;
            btn_ctDel.Enabled = false;
            btn_ctEdit.Enabled = false;
            ctFbu.SelectedIndex = 0;
            ctDepto.SelectedIndex = 0;
            ctFbu.Focus();
        }

        private void btn_ctDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abcCt(2);
                ctFbu.SelectedIndex = 0;
                ctDepto.SelectedIndex = 0;
                ct.Text = "";
                ctDesc.Text = "";

                ctFbu.Enabled = false;
                ctDepto.Enabled = false;
                ct.Enabled = false;
                ctDesc.Enabled = false;


                btn_ctAdd.Enabled = false;
                btn_ctNew.Enabled = true;
                btn_ctEdit.Enabled = false;
                btn_ctDel.Enabled = false;
                btn_ctSearch.Enabled = true;
            }
        }

        private void btn_ctEdit_Click(object sender, EventArgs e)
        {
            ctOriginal = ct.Text;
            ctFbu.Enabled = true;
            ctDepto.Enabled = true;
            ct.Enabled = true;
            ctDesc.Enabled = true;

            editando = true;
            btn_ctNew.Enabled = false;
            btn_ctEdit.Enabled = false;
            btn_ctDel.Enabled = false;
            btn_ctSearch.Enabled = false;
            btn_ctAdd.Enabled = true;
        }

        private void btn_ctAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                abcCt(1);//editando
                editando = false;
            }
            else
                abcCt(0);//alta
        }

        private void btn_ctSearch_Click(object sender, EventArgs e)
        {

            frmSearchcomun frmS = new frmSearchcomun(2);

            frmS.ShowDialog();
            if (frmS.ct != 0)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {

                    #region carga los empl
                    string sqlEmpl = "select * from centrostrabajos where centrotrabajo ='" + frmS.ct + "'";

                    conAcc.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    int totEmpl = dtEmpl.Rows.Count;
                    if (dtEmpl.Rows.Count > 0)
                    {
                        ctFbu.SelectedValue = dtEmpl.Rows[0][2].ToString();
                        ctDepto.SelectedValue = dtEmpl.Rows[0][1].ToString();
                        ct.Text = dtEmpl.Rows[0][0].ToString();
                        ctDesc.Text = dtEmpl.Rows[0][3].ToString();

                    }
                    dtEmpl.Dispose();
                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion


                    da.Dispose();
                    btn_ctNew.Enabled = true;
                    btn_ctDel.Enabled = true;
                    btn_ctEdit.Enabled = true;
                    btn_ctSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar el departamento: " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }

        private void ctFbu_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void ctDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void ctDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void dDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void dOverHead_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void ohDec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btn_lNew_Click(object sender, EventArgs e)
        {
            tabsControlsStatus("nL", true);
            btn_lNew.Enabled = false;
            btn_lAdd.Enabled = true;
            btn_lSearch.Enabled = false;
            btn_lDel.Enabled = false;
            btn_lEdit.Enabled = false;
            lFbu.SelectedIndex = 0;
            lDepto.SelectedIndex = 0;
            //lCt.SelectedIndex = 0;
            lFbu.Focus();
        }

        private void lFbu_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void lCt_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void lDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendKeys.Send("{Tab}");
        }

        private void lDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btn_lDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abcLine(2);
                lFbu.SelectedIndex = 0;
                lDepto.SelectedIndex = 0;
                lCt.SelectedIndex = -1;
                linea.Text = "";
                lDesc.Text = "";

                lFbu.Enabled = false;
                lDepto.Enabled = false;
                lCt.Enabled = false;
                lDesc.Enabled = false;
                linea.Enabled = false;

                btn_lAdd.Enabled = false;
                btn_lNew.Enabled = true;
                btn_lEdit.Enabled = false;
                btn_lDel.Enabled = false;
                btn_lSearch.Enabled = true;
            }
        }
        private void abcLine(int accion)
        {
            bool allOk = true;
            if (lFbu.SelectedIndex == 0 || lDepto.SelectedIndex == 0 || lCt.SelectedValue == null || linea.Text == "" || lDesc.Text == "")
            {
                MessageBox.Show("Datos Insuficientes");
                return;
            }
            linea.Text = linea.Text.Replace(" ", "");

            string sqlAccion = "";


            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();


                if (accion == 0)//es un nuevo 
                {
                    sqlAccion = "insert into lineas (departamento,centrotrabajo,fbu,linea,descripcion)values('" +
                        lDepto.SelectedValue.ToString() + "','" + lCt.SelectedValue.ToString() + "','" +
                        lFbu.SelectedValue.ToString() + "','" + linea.Text + "','" + lDesc.Text.ToUpper() + "')";
                }
                else if (accion == 1)//editar 
                {
                    sqlAccion = "update lineas set fbu='" + lFbu.SelectedValue.ToString() + "',departamento='" +
                        lDepto.SelectedValue.ToString() + "',descripcion='" + lDesc.Text.ToUpper() + "',linea='" +
                         linea.Text.ToUpper() + "',centrotrabajo='" + lCt.SelectedValue.ToString() +
                         "' where l_id=" + lblLineId.Text;
                }
                else if (accion == 2)//borrar 
                {
                    sqlAccion = "delete from lineas where l_id=" + lblLineId.Text;
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
                if (accion == 0)
                {
                    OleDbCommand comm2 = new OleDbCommand("select max(l_id) from lineas", conAcc);
                    OleDbDataReader dr = comm2.ExecuteReader();
                    dr.Read();
                    lblLineId.Text = dr.GetValue(0).ToString();
                    dr.Dispose();
                    comm2.Dispose();
                }
            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar la Linea: " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "La linea esta duplicada, verifique";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accion == 0 || accion == 1))
            {
                btn_lNew.Enabled = true;
                btn_lDel.Enabled = true;
                btn_lEdit.Enabled = true;
                btn_lSearch.Enabled = true;
                btn_lAdd.Enabled = false;

                lFbu.Enabled = false;
                lDepto.Enabled = false;
                lCt.Enabled = false;
                lDesc.Enabled = false;
                linea.Enabled = false;

            }
            #endregion
        }

        private void lDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lDepto.SelectedValue != null)// && !lReload)
                cargaCt(lDepto.SelectedValue.ToString());
            else
            {
                lCt.DataSource = null;
                lCt.Items.Clear();
            }
        }
        private void cargaCt(string value)
        {
            //lCt.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select centrotrabajo,centrotrabajo & ' | ' & descripcion as descripcion from centrostrabajos " +
                    " where departamento='" + value + "'order by descripcion";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("centrotrabajo", typeof(string));
                //dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lCt.DisplayMember = "descripcion";
                lCt.ValueMember = "centrotrabajo";
                lCt.DataSource = dt;

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
            lCt.SelectedIndex = -1;
        }

        private void btn_lEdit_Click(object sender, EventArgs e)
        {

            lFbu.Enabled = true;
            lDepto.Enabled = true;
            lCt.Enabled = true;
            lDesc.Enabled = true;
            linea.Enabled = true;

            editando = true;
            btn_lNew.Enabled = false;
            btn_lEdit.Enabled = false;
            btn_lDel.Enabled = false;
            btn_lSearch.Enabled = false;
            btn_lAdd.Enabled = true;
        }

        private void btn_lAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                abcLine(1);//editando
                editando = false;
            }
            else
                abcLine(0);//alta
        }

        private void btn_lSearch_Click(object sender, EventArgs e)
        {
            frmSearchcomun frmS = new frmSearchcomun(3);

            frmS.ShowDialog();
            if (frmS.lineId != 0)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {

                    #region carga busqueda
                    string sqlEmpl = "select * from lineas where l_id =" + frmS.lineId;

                    conAcc.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    int totEmpl = dtEmpl.Rows.Count;
                    if (dtEmpl.Rows.Count > 0)
                    {

                        lDepto.SelectedValue = dtEmpl.Rows[0][0].ToString();
                        lCt.SelectedValue = dtEmpl.Rows[0][1].ToString();
                        lFbu.SelectedValue = dtEmpl.Rows[0][2].ToString();
                        linea.Text = dtEmpl.Rows[0][3].ToString();
                        lDesc.Text = dtEmpl.Rows[0][4].ToString();
                        lblLineId.Text = frmS.lineId.ToString();
                    }
                    dtEmpl.Dispose();
                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion


                    da.Dispose();
                    btn_lNew.Enabled = true;
                    btn_lDel.Enabled = true;
                    btn_lEdit.Enabled = true;
                    btn_lSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar la Linea: " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }

        private void fId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void fDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btn_fNew_Click(object sender, EventArgs e)
        {
            tabsControlsStatus("nFbu", true);
            btn_fNew.Enabled = false;
            btn_fAdd.Enabled = true;
            btn_fSearch.Enabled = false;
            btn_fDel.Enabled = false;
            btn_fEdit.Enabled = false;
            fId.Focus();
        }

        private void btn_fDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abcFbu(2);
                fId.Text = "";
                fDesc.Text = "";

                fId.Enabled = false;
                fDesc.Enabled = false;

                btn_fAdd.Enabled = false;
                btn_fNew.Enabled = true;
                btn_fEdit.Enabled = false;
                btn_fDel.Enabled = false;
                btn_fSearch.Enabled = true;
            }
        }
        private void abcFbu(int accion)
        {
            bool allOk = true;
            if (fId.Text == null || fDesc.Text == "")
            {
                MessageBox.Show("Datos Insuficientes");
                return;
            }
            fId.Text = fId.Text.Replace(" ", "");
            fDesc.Text = fDesc.Text.Replace(" ", "");

            string sqlAccion = "";


            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();

                if (accion == 0)//es un nuevo 
                {
                    sqlAccion = "insert into fbu_s (fbu,descripcion)values('" +
                        fId.Text.ToUpper() + "','" + fDesc.Text.ToUpper() + "')";
                }
                else if (accion == 1)//editar 
                {
                    sqlAccion = "update fbu_s set fbu='" + fId.Text + "',descripcion='" + fDesc.Text.ToUpper() +
                        "' where fbu='" + fbuOriginal + "'";
                }
                else if (accion == 2)//borrar 
                {
                    sqlAccion = "delete from fbu_s where fbu='" + fId.Text + "'";
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar el fbu: " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "El Fbu esta duplicado, verifique";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accion == 0 || accion == 1))
            {
                btn_fNew.Enabled = true;
                btn_fDel.Enabled = true;
                btn_fEdit.Enabled = true;
                btn_fSearch.Enabled = true;
                btn_fAdd.Enabled = false;

                fId.Enabled = false;
                fDesc.Enabled = false;
            }
            #endregion
        }
        private void btn_fEdit_Click(object sender, EventArgs e)
        {
            fbuOriginal = fId.Text;

            fDesc.Enabled = true;
            fId.Enabled = true;

            editando = true;
            btn_fNew.Enabled = false;
            btn_fEdit.Enabled = false;
            btn_fDel.Enabled = false;
            btn_fSearch.Enabled = false;
            btn_fAdd.Enabled = true;
        }

        private void btn_fAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                abcFbu(1);//editando
                editando = false;
            }
            else
                abcFbu(0);//alta
        }

        private void btn_fSearch_Click(object sender, EventArgs e)
        {
            frmSearchcomun frmS = new frmSearchcomun(4);

            frmS.ShowDialog();
            if (frmS.fbuId != "")
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {

                    #region carga busqueda
                    string sqlEmpl = "select * from fbu_s where fbu ='" + frmS.fbuId + "'";

                    conAcc.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    int totEmpl = dtEmpl.Rows.Count;
                    if (dtEmpl.Rows.Count > 0)
                    {
                        fId.Text = dtEmpl.Rows[0][0].ToString();
                        fDesc.Text = dtEmpl.Rows[0][1].ToString();
                    }
                    dtEmpl.Dispose();
                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion


                    da.Dispose();
                    btn_fNew.Enabled = true;
                    btn_fDel.Enabled = true;
                    btn_fEdit.Enabled = true;
                    btn_fSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar el Fbu: " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }

        private void linea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void scId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void scNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btn_scNew_Click(object sender, EventArgs e)
        {
            tabsControlsStatus("nSup", true);
            btn_scNew.Enabled = false;
            btn_scAdd.Enabled = true;
            btn_scSearch.Enabled = false;
            btn_scDel.Enabled = false;
            btn_scEdit.Enabled = false;
            scId.Focus();
        }

        private void btn_scDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abcSc(2);
                scId.Text = "";
                scNom.Text = "";

                scId.Enabled = false;
                scNom.Enabled = false;

                btn_scAdd.Enabled = false;
                btn_scNew.Enabled = true;
                btn_scEdit.Enabled = false;
                btn_scDel.Enabled = false;
                btn_scSearch.Enabled = true;
            }
        }

        private void btn_scEdit_Click(object sender, EventArgs e)
        {
            scOriginal = scId.Text;

            scId.Enabled = true;
            scNom.Enabled = true;

            editando = true;
            btn_scNew.Enabled = false;
            btn_scEdit.Enabled = false;
            btn_scDel.Enabled = false;
            btn_scSearch.Enabled = false;
            btn_scAdd.Enabled = true;
        }

        private void btn_scAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                abcSc(1);//editando
                editando = false;
            }
            else
                abcSc(0);//alta
        }

        private void btn_scSearch_Click(object sender, EventArgs e)
        {
            string tipo = tabControl.TabPages["tabSc"].Text;
            int rep = 6;
            if (tipo == "Supervisores")
                rep = 5;

            frmSearchcomun frmS = new frmSearchcomun(rep);

            frmS.ShowDialog();

            if (frmS.scId != "")
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {

                    #region carga busqueda
                    string sqlEmpl = "";
                    if (tipo == "Supervisores")
                        sqlEmpl = "select * from supervisores where supervisor ='" + frmS.scId + "'";
                    else
                        sqlEmpl = "select * from coordinadores where id_coordinador ='" + frmS.scId + "'";

                    conAcc.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    int totEmpl = dtEmpl.Rows.Count;
                    if (dtEmpl.Rows.Count > 0)
                    {
                        scId.Text = dtEmpl.Rows[0][0].ToString();
                        scNom.Text = dtEmpl.Rows[0][1].ToString();
                    }
                    dtEmpl.Dispose();
                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion


                    da.Dispose();
                    btn_scNew.Enabled = true;
                    btn_scDel.Enabled = true;
                    btn_scEdit.Enabled = true;
                    btn_scSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar el " + tipo + ": " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }
        private void abcSc(int accion)
        {
            bool allOk = true;
            if (scId.Text == null || scNom.Text == "")
            {
                MessageBox.Show("Datos Insuficientes");
                return;
            }
            scId.Text = scId.Text.Replace(" ", "");
            //scNom.Text = scNom.Text.Replace(" ", "");

            string sqlAccion = "";


            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();

                if (accion == 0)//es un nuevo 
                {
                    if (tabControl.TabPages["tabSc"].Text == "Supervisores")
                        sqlAccion = "insert into supervisores (supervisor,nombre)values('" +
                            scId.Text.ToUpper() + "','" + scNom.Text.ToUpper() + "')";
                    else
                        sqlAccion = "insert into coordinadores (id_coordinador,nombre_coord)values('" +
                       scId.Text.ToUpper() + "','" + scNom.Text.ToUpper() + "')";
                }
                else if (accion == 1)//editar 
                {
                    if (tabControl.TabPages["tabSc"].Text == "Supervisores")
                        sqlAccion = "update supervisores set supervisor='" + scId.Text + "',nombre='" + scNom.Text.ToUpper() +
                            "' where supervisor='" + scOriginal + "'";
                    else
                        sqlAccion = "update coordinadores set id_coordinador='" + scId.Text + "',nombre_coord='" + scNom.Text.ToUpper() +
                        "' where id_coordinador='" + scOriginal + "'";
                }
                else if (accion == 2)//borrar 
                {
                    if (tabControl.TabPages["tabSc"].Text == "Supervisores")
                        sqlAccion = "delete from supervisores where supervisor='" + scId.Text + "'";
                    else
                        sqlAccion = "delete from coordinadores where id_coordinador='" + scId.Text + "'";
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar el " + tabControl.TabPages["tabSc"].Text + ": " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "Esta duplicado, verifique";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accion == 0 || accion == 1))
            {
                btn_scNew.Enabled = true;
                btn_scDel.Enabled = true;
                btn_scEdit.Enabled = true;
                btn_scSearch.Enabled = true;
                btn_scAdd.Enabled = false;

                scId.Enabled = false;
                scNom.Enabled = false;
            }
            #endregion
        }
        private void unselectItems()
        {
            for (int x = 0; x < chkListCoord.Items.Count; x++)
            {
                chkListCoord.SetItemChecked(x, false);
            }
        }
        private void cmbSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErr.Text = "";
            if (cmbSup.SelectedIndex > 0)
            {
                unselectItems();
                chkListCoord.Enabled = true;
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    string idsup = cmbSup.SelectedValue.ToString();
                    conAcc.Open();
                    string sqlAllCoord = "select id_cord from sup_cord where id_sup='" + idsup + "'";


                    OleDbDataAdapter da = new OleDbDataAdapter(sqlAllCoord, conAcc);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    for (int c = 0; c < dt.Rows.Count; c++)
                    {
                        int idx = 0;
                        foreach (DataRowView drv in chkListCoord.Items)
                        {
                            if (drv.Row.ItemArray[0].ToString() == dt.Rows[c][0].ToString())
                            {
                                chkListCoord.SetItemChecked(idx, true);
                                break;
                            }
                            idx++;
                        }
                    }
                    dt.Dispose();

                }
                catch
                {
                }
                finally
                {
                    conAcc.Close();
                    conAcc.Dispose();
                }
            }
            else
                chkListCoord.Enabled = false;
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lblErr.ForeColor = Color.Green;
            if (cmbSup.SelectedIndex > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    string idSup = cmbSup.SelectedValue.ToString();
                    string sql = "delete from sup_cord where id_sup ='" + idSup + "'";
                    conAcc.Open();
                    OleDbCommand comm = new OleDbCommand(sql, conAcc);
                    OleDbCommand commIn = null;
                    comm.ExecuteNonQuery();
                    string idCord = "";
                    foreach (DataRowView drv in chkListCoord.CheckedItems)
                    {
                        idCord = drv.Row.ItemArray[0].ToString();
                        commIn = new OleDbCommand("insert into sup_cord values('" + idSup + "','" + idCord + "')", conAcc);
                        commIn.ExecuteNonQuery();
                    }
                    commIn.Dispose();
                    comm.Dispose();
                    lblErr.Text = "Se guardo relación!";
                }
                catch (Exception err)
                {
                    string error = "";
                    if (err.Message.IndexOf("duplicate") > 0)
                        error = "Esta duplicado, verifique";
                    else
                        error = err.Message;
                    lblErr.Text = error;
                    lblErr.ForeColor = Color.Red;
                }
                finally
                {
                    conAcc.Close();
                    conAcc.Dispose();
                }
                this.Cursor = Cursors.Default;
            }

        }

        private void btn_tNew_Click(object sender, EventArgs e)
        {
            horaEnt = false; horaSal = false; d1_1 = false; d1_2 = false; d2_1 = false; d2_2 = false; d3_1 = false;
            d3_2 = false;
            tabsControlsStatus("nTur", true);
            btn_tNew.Enabled = false;
            btn_tAdd.Enabled = true;
            btn_tSearch.Enabled = false;
            btn_tDel.Enabled = false;
            btn_tEdit.Enabled = false;
            tId.Focus();
        }

        private void btn_tDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abcTurno(2);
               
                turnosObjEnabled(false, true);
                

                btn_tAdd.Enabled = false;
                btn_tNew.Enabled = true;
                btn_tEdit.Enabled = false;
                btn_tDel.Enabled = false;
                btn_tSearch.Enabled = true;
            }
        }
        private void turnosObjEnabled(bool st, bool limpia)
        {
            tId.Enabled = st;
            tHrs.Enabled = st;
            tEnt.Enabled = st;
            tSal.Enabled = st;
            td1_1.Enabled = st;
            td1_2.Enabled = st;
            td2_1.Enabled = st;
            td2_2.Enabled = st;
            td3_1.Enabled = st;
            td3_2.Enabled = st;
            if (limpia)
            {
                tId.Text = "";
                tHrs.Text = "";
                tEnt.Text = "";
                tSal.Text = "";
                td1_1.Text = "";
                td1_2.Text = "";
                td2_1.Text = "";
                td2_2.Text = "";
                td3_1.Text = "";
                td3_2.Text = "";
            }
        }
        private void btn_tEdit_Click(object sender, EventArgs e)
        {
            horaEnt = true; horaSal = true; d1_1 = true; d1_2 = true; d2_1 = true; d2_2 = true; d3_1 = true;
            tOriginal = tId.Text;

            turnosObjEnabled(true, false);

            editando = true;
            btn_tNew.Enabled = false;
            btn_tEdit.Enabled = false;
            btn_tDel.Enabled = false;
            btn_tSearch.Enabled = false;
            btn_tAdd.Enabled = true;
        }

        private void btn_tAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                abcTurno(1);//editando
                editando = false;
            }
            else
                abcTurno(0);//alta
        }

        private void btn_tSearch_Click(object sender, EventArgs e)
        {
            frmSearchcomun frmS = new frmSearchcomun(7);

            frmS.ShowDialog();

            if (frmS.tId != null)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {

                    #region carga busqueda
                    string sqlEmpl = "";             

                    conAcc.Open();
                    sqlEmpl = "select * from turnos where turno =" + frmS.tId;   
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    
                    if (dtEmpl.Rows.Count > 0)
                    {
                        tId.Text = dtEmpl.Rows[0][0].ToString();
                        tEnt.Text = dtEmpl.Rows[0][1].ToString();
                        tSal.Text = dtEmpl.Rows[0][2].ToString();
                        tHrs.Text = dtEmpl.Rows[0][3].ToString();
                    }
                    dtEmpl.Dispose();
                    da.Dispose();
                    //horas hija
                    sqlEmpl = "select entrada,salida from turnos_hija where turno_id =" + frmS.tId;
                    OleDbDataAdapter da2 = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl2 = new DataTable();
                    da2.Fill(dtEmpl2);
                    
                    for (int x = 0; x < dtEmpl2.Rows.Count;x++ )
                    {
                        if (x == 0)
                        {
                            td1_1.Text = dtEmpl2.Rows[x][0].ToString();                            
                            td1_2.Text = dtEmpl2.Rows[x][1].ToString();
                        }
                        else if (x==1)
                        {
                            td2_1.Text = dtEmpl2.Rows[x][0].ToString();
                            td2_2.Text = dtEmpl2.Rows[x][1].ToString();
                        }
                        else if (x==2)
                        {
                            td3_1.Text = dtEmpl2.Rows[x][0].ToString();
                            td3_2.Text = dtEmpl2.Rows[x][1].ToString();
                        }
                    }
                    dtEmpl2.Dispose();
                    da2.Dispose();
                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion                   
                    btn_tNew.Enabled = true;
                    btn_tDel.Enabled = true;
                    btn_tEdit.Enabled = true;
                    btn_tSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar el Turno: " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }
        private void abcTurno(int accion)
        {
            bool allOk = true;
            if (tId.Text == null || tHrs.Text == "")
            {
                MessageBox.Show("Datos Insuficientes");
                return;
            }
            //tEnt.Text = tEnt.Text.Replace(" ", "");
            //tSal.Text = tSal.Text.Replace(" ", "");
            //td1_1.Text = td1_1.Text.Replace(" ", "");
            //td1_2.Text = td1_2.Text.Replace(" ", "");
            //td2_1.Text = td2_1.Text.Replace(" ", "");
            //td2_2.Text = td2_2.Text.Replace(" ", "");
            //td3_1.Text = td3_1.Text.Replace(" ", "");
            //td3_2.Text = td3_2.Text.Replace(" ", "");
            if (!validaHoras(tEnt.Text)||
                !validaHoras(tSal.Text)||
                !validaHoras(td1_1.Text)||
                !validaHoras(td1_2.Text)||
                !validaHoras(td2_1.Text)||
                !validaHoras(td2_2.Text)||
                !validaHoras(td3_1.Text)||
                !validaHoras(td3_2.Text))
            {
                MessageBox.Show("Horas invalidas");
                return;
            }
            if (sumaHora())//horaEnt && horaSal && d1_1 && d1_2 && d2_1 && d2_2 && d3_1 && d3_2 && sumaHora())
            {
                string sqlAccion1 = "", sqlAccion2 = "", sqlAccion3 = "", sqlAccion4 = "", sql = "";


                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    conAcc.Open();

                    if (accion == 0)//es un nuevo 
                    {

                        sqlAccion1 = "insert into turnos values(" + tId.Text + ",'" + tEnt.Text + "','" + tSal.Text + "'," + tHrs.Text + ")";
                        sqlAccion2 = "insert into turnos_hija values (" + tId.Text + ",'" + td1_1.Text + "','" + td1_2.Text + "',1)";
                        sqlAccion3 = "insert into turnos_hija values (" + tId.Text + ",'" + td2_1.Text + "','" + td2_2.Text + "',2)";
                        sqlAccion4 = "insert into turnos_hija values (" + tId.Text + ",'" + td3_1.Text + "','" + td3_2.Text + "',3)";
                    }
                    else if (accion == 1)//editar 
                    {

                        sqlAccion1 = "update turnos set turno=" + tId.Text + ",entrada='" + tEnt.Text +
                            "',salida='" + tSal.Text + "',hrsdiarias=" + tHrs.Text + " where turno=" + tOriginal;

                        sqlAccion2 = "update turnos_hija set entrada='" + td1_1.Text + "',salida='" + td1_2.Text +
                        "' where turno_id=" + tId.Text +" and desc_id =1";
                        sqlAccion3 = "update turnos_hija set entrada='" + td2_1.Text + "',salida='" + td2_2.Text +
                        "' where turno_id=" + tId.Text + " and desc_id =2";
                        sqlAccion4 = "update turnos_hija set entrada='" + td3_1.Text + "',salida='" + td3_2.Text +
                        "' where turno_id=" + tId.Text + " and desc_id =3";
                    }
                    else if (accion == 2)//borrar 
                    {
                        sqlAccion1 = "delete from turnos where turno=" + tId.Text;
                    }
                    OleDbCommand comm1 = new OleDbCommand(sqlAccion1, conAcc);
                    comm1.ExecuteNonQuery();
                    comm1.Dispose();
                    if (accion != 2)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            if (x == 0) sql = sqlAccion2; else if (x == 1) sql = sqlAccion3; else if (x == 2) sql = sqlAccion4;
                            OleDbCommand comm2 = new OleDbCommand(sql, conAcc);
                            comm2.ExecuteNonQuery();
                            comm2.Dispose();
                        }
                    }
                }
                catch (Exception err)
                {
                    string error = "Error al intentar grabar el Turno: " + err.Message; ;
                    if (err.Message.IndexOf("duplicate") > 0)
                        error = "Turno Esta duplicado, verifique";
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    allOk = false;
                }
                finally
                {
                    conAcc.Close();
                    conAcc.Dispose();
                }
                #region activa botones
                if (allOk && (accion == 0 || accion == 1))
                {
                    btn_tNew.Enabled = true;
                    btn_tDel.Enabled = true;
                    btn_tEdit.Enabled = true;
                    btn_tSearch.Enabled = true;
                    btn_tAdd.Enabled = false;

                    turnosObjEnabled(false, false);
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Horas invalidas");
                return;
            }
           
        }

        private void tId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void tHrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void tEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void tSal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td1_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td1_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td2_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td2_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td3_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td3_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void cmbSup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void chkListCoord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void tEnt_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void tSal_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td1_1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td1_2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td2_1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td2_2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td3_1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void td3_2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void tEnt_MouseLeave(object sender, EventArgs e)
        {
            

                

        }

        private void tEnt_Leave(object sender, EventArgs e)
        {

            if (!validaHoras(tEnt.Text))
            {
                horaEnt = false;
                MessageBox.Show("Hora de entrada invalida");
            }
            else
            {
                horaEnt = true;
                sumaHora();
            }
        }
        private bool validaHoras(string hr)
        {
            string[] hora = hr.Split(':');
            if (hora[0].Length < 2 || hora[1].Length < 2 || Convert.ToInt16(hora[1]) > 60)
            {               
                return false;
            }
            return true;
        }
        private bool sumaHora()
        {
            bool ret = true;
            double hora1 = 0, hora2 = 0;
            if (horaEnt && horaSal)
            {
                string[] aH1 = tEnt.Text.Split(':');
                string[] aH2 = tSal.Text.Split(':');
                hora1 = Convert.ToDouble(aH1[0]);
                hora2 = Convert.ToDouble(aH2[0]);
                //horas en minutos
                hora1 *= 60;
                hora2 *= 60;
                //le sumo los min a las horas
                hora1 += Convert.ToDouble(aH1[1]);
                hora2 += Convert.ToDouble(aH2[1]);
                double res = hora2 - hora1;

                if (res < 0)
                {
                    MessageBox.Show("Hora de turno entrada > salida");
                    tHrs.Text = "";
                    //tSal.Focus();
                    ret = false;
                }
                else
                {
                    res = res / 60;
                    double minDesc = 0;
                    if (minDescansos(hora1, hora2, ref minDesc))
                    {
                        res = res - minDesc;
                        tHrs.Text = res.ToString();
                    }
                    else
                        ret = false;
                }
            }
            else
                ret = false;
            return ret;
            
 }
        private bool minDescansos(double hora1,double hora2,ref double minDesc)
        {
            bool ret = true;
            try
            {
                if (d1_1 && d1_2)
                {
                    #region descanso 1
                    string[] ad1_1 = td1_1.Text.Split(':');
                    string[] ad1_2 = td1_2.Text.Split(':');
                    double hd1_1 = 0, hd1_2 = 0;
                    hd1_1 = Convert.ToDouble(ad1_1[0]);
                    hd1_2 = Convert.ToDouble(ad1_2[0]);
                    //horas en minutos
                    hd1_1 *= 60;
                    hd1_2 *= 60;
                    //le sumo los min a las horas
                    hd1_1 += Convert.ToDouble(ad1_1[1]);
                    hd1_2 += Convert.ToDouble(ad1_2[1]);
                    double minTotDesc1 = hd1_2 - hd1_1;
                    if (minTotDesc1 < 0)
                    {
                        MessageBox.Show("Descanso 1: Hora1 > Hora2");
                        //td1_1.Focus();
                        ret = false;
                    }
                    #endregion
                    if (ret)
                    {
                        if (hora1 <= hd1_1 && hora2 >= hd1_1)//valido 1er desc hora 1
                            if (hora1 <= hd1_2 && hora2 >= hd1_2)//valido 1er desc hora 2
                            {
                                minTotDesc1/=60;// +minTotDesc2 + minTotDesc3;
                                minDesc += minTotDesc1;
                            }
                            else
                            {
                                ret = false;
                                td1_2.Focus();
                            }
                        else
                        {
                            ret = false;
                            td1_1.Focus();
                        }
                        if (!ret)
                            MessageBox.Show("Descanso1 no esta dentro del turno");
                    }
                }
                if (d2_1 && d2_2&&ret)
                {
                    #region descanso 2
                    string[] ad2_1 = td2_1.Text.Split(':');
                    string[] ad2_2 = td2_2.Text.Split(':');
                    double hd2_1 = 0, hd2_2 = 0;
                    hd2_1 = Convert.ToDouble(ad2_1[0]);
                    hd2_2 = Convert.ToDouble(ad2_2[0]);
                    //horas en minutos
                    hd2_1 *= 60;
                    hd2_2 *= 60;
                    //le sumo los min a las horas
                    hd2_1 += Convert.ToDouble(ad2_1[1]);
                    hd2_2 += Convert.ToDouble(ad2_2[1]);
                    double minTotDesc2 = hd2_2 - hd2_1;
                    if (minTotDesc2 < 0)
                    {
                        MessageBox.Show("Descanso 2: Hora1 > Hora2");
                       // td2_1.Focus();
                        ret = false;
                    }
                    #endregion
                    if (ret)
                    {
                        if (hora1 <= hd2_1 && hora2 >= hd2_1)//valido 2do desc hora 1
                            if (hora1 <= hd2_2 && hora2 >= hd2_2)//valido 2do desc hora 2
                            {
                                minTotDesc2/=60;// +minTotDesc3;
                                minDesc += minTotDesc2;
                            }
                            else
                            {
                                ret = false;
                                td2_2.Focus();
                            }
                        else
                        {
                            ret = false;
                            td2_1.Focus();
                        }
                        if (!ret)
                            MessageBox.Show("Descanso2 no esta dentro del turno");
                    }
                }
                if (d3_1 && d3_2&&ret)
                {
                    #region descanso 3
                    string[] ad3_1 = td3_1.Text.Split(':');
                    string[] ad3_2 = td3_2.Text.Split(':');
                    double hd3_1 = 0, hd3_2 = 0;
                    hd3_1 = Convert.ToDouble(ad3_1[0]);
                    hd3_2 = Convert.ToDouble(ad3_2[0]);
                    //horas en minutos
                    hd3_1 *= 60;
                    hd3_2 *= 60;
                    //le sumo los min a las horas
                    hd3_1 += Convert.ToDouble(ad3_1[1]);
                    hd3_2 += Convert.ToDouble(ad3_2[1]);
                    double minTotDesc3 = hd3_2 - hd3_1;
                    if (minTotDesc3 < 0)
                    {
                        MessageBox.Show("Descanso 3: Hora1 > Hora2");
                        //td1_1.Focus();
                        ret = false;
                    }
                    #endregion
                    if (ret)
                    {
                        if (hora1 <= hd3_1 && hora2 >= hd3_1)//valido 3er desc hora 1
                            if (hora1 <= hd3_2 && hora2 >= hd3_2)//valido 3er desc hora 2
                            {
                                minTotDesc3/=60;
                                minDesc += minTotDesc3;
                            }
                            else
                            {
                                ret = false;
                                td3_2.Focus();
                            }
                        else
                        {
                            ret = false;
                            td3_1.Focus();
                        }
                        if (!ret)
                            MessageBox.Show("Descanso3 no esta dentro del turno");
                    }
                }
            }
            catch (Exception err)
            {
                ret = false;
            }
            return ret;
        }
        private void tSal_Leave(object sender, EventArgs e)
        {
            if (!validaHoras(tSal.Text))
            {
                horaSal = false;
                MessageBox.Show("Hora de Salida invalida");
            }
            else
            {
                horaSal = true;
                sumaHora();
            }
        }

        private void td1_1_Leave(object sender, EventArgs e)
        {
            if (!validaHoras(td1_1.Text))
            {
                MessageBox.Show("Desc 1, hora1 invalida");
                d1_1 = false;
            }
            else
            {
                d1_1 = true;
                if (d1_1 && d1_2)
                    sumaHora();
            }
        }

        private void td1_2_Leave(object sender, EventArgs e)
        {
            if (!validaHoras(td1_2.Text))
            {
                MessageBox.Show("Desc 1, hora2 invalida");
                d1_2 = false;
            }
            else
            {
                d1_2 = true;
                if (d1_1 && d1_2)
                    sumaHora();
            }
        }

        private void td2_1_Leave(object sender, EventArgs e)
        {
            if(!validaHoras(td2_1.Text))
            {
                MessageBox.Show("Hora invalida");
                 d2_1 = false;
            }
            else
            {
                d2_1 = true;
                if (d2_1 && d2_2)
                sumaHora();
            }
        }

        private void td2_2_Leave(object sender, EventArgs e)
        {
            if(!validaHoras(td2_2.Text))
            {
                MessageBox.Show("Hora invalida");
                d2_2 = false;
            }
            else
            {
                d2_2 = true;
                if (d2_1 && d2_2)
                sumaHora();
            }
        }

        private void td3_1_Leave(object sender, EventArgs e)
        {
            if(!validaHoras(td3_1.Text))
            {
                MessageBox.Show("Hora invalida");
                d3_1 = false;
            }
            else
            {
                d3_1 = true;
                if (d3_1 && d3_2)
                sumaHora();
            }
        }

        private void td3_2_Leave(object sender, EventArgs e)
        {
            if (!validaHoras(td3_2.Text))
            {
                MessageBox.Show("Hora invalida");
                d3_2 = false;
            }
            else
            {
                d3_2 = true;
                if (d3_1 && d3_2)
                    sumaHora();
            }
        }

        private void tHrs_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btn_npNew_Click(object sender, EventArgs e)
        {
            
            tabsControlsStatus("nNp", true);
            btn_npNew.Enabled = false;
            btn_npAdd.Enabled = true;
            btn_npSearch.Enabled = false;
            btn_npDel.Enabled = false;
            btn_npEdit.Enabled = false;
            cmbCodOp.SelectedIndex = 0;
            cmbCodOp.Focus();
        }

        private void btn_npDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abcNoParte(2);

                cmbCodOp.SelectedIndex = 0;                
                np.Text = "";
                sec.Text = "";
                codOra.Text = "";

                cmbCodOp.Enabled = false;
                np.Enabled = false;
                sec.Enabled = false;
                codOra.Enabled = false;
                
                btn_npAdd.Enabled = false;
                btn_npNew.Enabled = true;
                btn_npEdit.Enabled = false;
                btn_npDel.Enabled = false;
                btn_npSearch.Enabled = true;
            }
        }

        private void btn_npEdit_Click(object sender, EventArgs e)
        {
            cmbCodOp.Enabled = true;
            np.Enabled = true;
            editando = true;
            sec.Enabled = true;
            codOra.Enabled = true;
            btn_npNew.Enabled = false;
            btn_npEdit.Enabled = false;
            btn_npDel.Enabled = false;
            btn_npSearch.Enabled = false;
            btn_npAdd.Enabled = true;
        }

        private void btn_npAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                abcNoParte(1);//editando
                editando = false;
            }
            else
                abcNoParte(0);//alta
        }
        private void abcNoParte(int accion)
        {
            bool allOk = true;
            if (cmbCodOp.SelectedIndex == 0 || np.Text==""|| sec.Text == "" || codOra.Text == "")
            {
                MessageBox.Show("Datos Insuficientes");
                return;
            }
            np.Text = np.Text.Replace(" ", "");
            codOra.Text = codOra.Text.Replace(" ", "");

            string sqlAccion = "";


            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();


                if (accion == 0)//es un nuevo 
                {
                    sqlAccion = "insert into numeros_de_parte (cod_operacion,no_parte,seq,cod_oracle)values('" +
                        cmbCodOp.SelectedValue.ToString() + "','" + np.Text.ToUpper() + "','" +
                        sec.Text + "','" + codOra.Text.ToUpper() + "')";
                }
                else if (accion == 1)//editar 
                {
                    sqlAccion = "update numeros_de_parte set cod_operacion='" + cmbCodOp.SelectedValue.ToString() + 
                        "',no_parte='" +np.Text.ToUpper() + "',seq='" + sec.Text +
                        "',cod_oracle='" + codOra.Text.ToUpper() + "' where np_id=" + npId;
                }
                else if (accion == 2)//borrar 
                {
                    sqlAccion = "delete from numeros_de_parte where np_id=" + npId;
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
                if (accion == 0)
                {
                    OleDbCommand comm2 = new OleDbCommand("select max(np_id) from numeros_de_parte", conAcc);
                    OleDbDataReader dr = comm2.ExecuteReader();
                    dr.Read();
                    npId = dr.GetValue(0).ToString();
                    dr.Dispose();
                    comm2.Dispose();
                }
                
            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar el numero de parte: " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "el numero de parte esta duplicado, verifique";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accion == 0 || accion == 1))
            {
                btn_npNew.Enabled = true;
                btn_npDel.Enabled = true;
                btn_npEdit.Enabled = true;
                btn_npSearch.Enabled = true;
                btn_npAdd.Enabled = false;

                cmbCodOp.Enabled = false;
                np.Enabled = false;
                sec.Enabled = false;
                codOra.Enabled = false;              

            }
            #endregion
        }
        private void btn_npSearch_Click(object sender, EventArgs e)
        {
            frmSearchcomun frmS = new frmSearchcomun(8);

            frmS.ShowDialog();
            npId = "";
            if (frmS.npId != null)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    
                    #region carga busqueda
                    string sqlEmpl = "";

                    conAcc.Open();
                    sqlEmpl = "select * from numeros_de_parte where np_id =" + frmS.npId;
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);

                    if (dtEmpl.Rows.Count > 0)
                    {

                        cmbCodOp.SelectedValue = dtEmpl.Rows[0][0].ToString();
                        np.Text = dtEmpl.Rows[0][1].ToString();
                        sec.Text = dtEmpl.Rows[0][2].ToString();
                        codOra.Text = dtEmpl.Rows[0][3].ToString();
                    }
                    npId = frmS.npId;
                    dtEmpl.Dispose();
                    da.Dispose();
                   
                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion
                    btn_npNew.Enabled = true;
                    btn_npDel.Enabled = true;
                    btn_npEdit.Enabled = true;
                    btn_npSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar el numero de parte: " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }

        private void scId_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void sec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void cmbCodOp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void np_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void codOra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btn_ciNew_Click(object sender, EventArgs e)
        {

            tabsControlsStatus("nCiD", true);
            btn_ciNew.Enabled = false;
            btn_ciAdd.Enabled = true;
            btn_ciSearch.Enabled = false;
            btn_ciDel.Enabled = false;
            btn_ciEdit.Enabled = false;
            
            txtCi.Focus();
        }

        private void btn_ciDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abcCodInd(2);

                
                txtCi.Text = "";
                txtDepto.Text = "";
                txtDesc.Text = "";


                txtCi.Enabled = false;
                txtDepto.Enabled = false;
                txtDesc.Enabled = false;

                btn_ciAdd.Enabled = false;
                btn_ciNew.Enabled = true;
                btn_ciEdit.Enabled = false;
                btn_ciDel.Enabled = false;
                btn_ciSearch.Enabled = true;
            }
        }

        private void btn_ciEdit_Click(object sender, EventArgs e)
        {
            ciId = txtCi.Text;
           txtCi.Enabled = true;
           txtDepto.Enabled = true;
           txtDesc.Enabled = true;
            editando = true;
            btn_ciNew.Enabled = false;
            btn_ciEdit.Enabled = false;
            btn_ciDel.Enabled = false;
            btn_ciSearch.Enabled = false;
            btn_ciAdd.Enabled = true;
        }

        private void btn_ciAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                if (abcCodInd(1))//editando
                    editando = false;
            }
            else
                abcCodInd(0);//alta
        }

        private void btn_ciSearch_Click(object sender, EventArgs e)
        {
            frmSearchcomun frmS = new frmSearchcomun(10);

            frmS.ShowDialog();
            npId = "";
            if (frmS.ciId != null)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {

                    #region carga busqueda
                    string sqlEmpl = "";

                    conAcc.Open();
                    sqlEmpl = "select * from IndirectosAsignadosDepartementosPlanta where codigo_indirecto ='" + frmS.ciId+"'";
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);

                    if (dtEmpl.Rows.Count > 0)
                    {                        
                        txtDepto.Text = dtEmpl.Rows[0][0].ToString();
                        txtCi.Text = dtEmpl.Rows[0][1].ToString();
                        txtDesc.Text = dtEmpl.Rows[0][2].ToString();
                    }
                    ciId = frmS.ciId;
                    dtEmpl.Dispose();
                    da.Dispose();

                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion
                    btn_ciNew.Enabled = true;
                    btn_ciDel.Enabled = true;
                    btn_ciEdit.Enabled = true;
                    btn_ciSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar el codigo indirecto: " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }
        private bool abcCodInd(int accion)
        {
            bool allOk = true;
            if (txtCi.Text=="" || txtDepto.Text == "" )
            {
                MessageBox.Show("Datos Insuficientes");
                txtCi.Focus();
                return false;
            }
            //np.Text = np.Text.Replace(" ", "");
            //codOra.Text = codOra.Text.Replace(" ", "");

            string sqlAccion = "";
            string desc = txtDesc.Text.Trim(new char[]{'\r','\n'});

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();


                if (accion == 0)//es un nuevo 
                {
                    sqlAccion = "insert into IndirectosAsignadosDepartementosPlanta values('" +
                        txtDepto.Text.ToUpper() + "','" + txtCi.Text.ToUpper() + "','" +
                        desc.ToUpper() + "')";
                }
                else if (accion == 1)//editar 
                {
                    sqlAccion = "update IndirectosAsignadosDepartementosPlanta set departamento='" + txtDepto.Text.ToUpper() +
                        "',codigo_indirecto='" + txtCi.Text.ToUpper() + "',descripcion='" + desc.ToUpper() +
                        "' where codigo_indirecto='" + ciId+"'";
                }
                else if (accion == 2)//borrar 
                {
                    sqlAccion = "delete from IndirectosAsignadosDepartementosPlanta where codigo_indirecto='" + ciId+"'";
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
                
            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar el codigo indirecto: " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "el codigo indirecto esta duplicado, verifique";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accion == 0 || accion == 1))
            {
                btn_ciNew.Enabled = true;
                btn_ciDel.Enabled = true;
                btn_ciEdit.Enabled = true;
                btn_ciSearch.Enabled = true;
                btn_ciAdd.Enabled = false;

                
                txtCi.Enabled = false;
                txtDepto.Enabled = false;
                txtDesc.Enabled = false;

            }
            #endregion
            return allOk;
        }

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void txtDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btnEmS_Click(object sender, EventArgs e)
        {
            busqueEmpleado();
           
        }
        private void busqueEmpleado()
        {
            lblerr4.Text = "";
            txtEmpName.Text = "";
            cmbEmpSup.SelectedIndex = -1;
            lstBoxEmpl.DataSource = null;
            lstBoxEmpl.Items.Clear();


            if (!String.IsNullOrEmpty(txtEmp.Text))
            {
                try
                {
                    Int64 numEmpl = Convert.ToInt64(txtEmp.Text);
                }
                catch
                {
                    MessageBox.Show("Introduzca solo numeros en el # de empleado");
                    txtEmp.Focus();
                    return;
                }
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    conAcc.Open();
                    string sql = "select * from empleados where empleado=" + txtEmp.Text;
                    //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    da.Dispose();
                    if (dt.Rows.Count > 0)
                    {
                        txtEmpName.Text = dt.Rows[0][1].ToString();
                        cargaSup(cmbEmpSup);
                        cmbEmpSup.SelectedValue = dt.Rows[0][4].ToString();
                        cordsbySup(dt.Rows[0][4].ToString());
                        int st = Convert.ToInt16(dt.Rows[0][5].ToString());
                        if (st == 1)
                            radioButton1.Checked = true;
                        else
                            radioButton2.Checked = true;

                        if (lstBoxEmpl.Items.Count > 0)
                        {

                            lstBoxEmpl.SelectedValue = dt.Rows[0][6].ToString();

                        }

                    }
                    else
                        lblerr4.Text = "No existe";
                    dt.Dispose();


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
        private void cordsbySup(string sup)
        {
            //if (!String.IsNullOrEmpty(txtEmp.Text))
            //{
            lstBoxEmpl.DataSource = null;
            lstBoxEmpl.Items.Clear();
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    

                    conAcc.Open();
                    string sql = "SELECT ID_Coordinador, Nombre_coord "+
                    " FROM Sup_Cord INNER JOIN Coordinadores ON Sup_Cord.ID_Cord = Coordinadores.ID_Coordinador "+
                    " WHERE Sup_Cord.ID_sup='"+sup+"'";
;
                    //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID_Coordinador", typeof(string));
                    dt.Columns.Add("Nombre_coord", typeof(string));

                    da.Fill(dt);
                    da.Dispose();
                    //dt.Dispose();
                    
                    
                    //for (int c = 0; c < dt.Rows.Count; c++)
                    //{
                    //   // chkEmpCoord.Items.AddRange(new object[] { dt.Rows[c][1], dt.Rows[c][0] });
                    //    chkEmpCoord.Items.Insert(c, dt.Rows[c][1].ToString());
                    //}
                    //chkEmpCoord.Items.Add
                    lstBoxEmpl.DisplayMember = "Nombre_coord";
                    lstBoxEmpl.ValueMember = "ID_Coordinador";
                    
                    lstBoxEmpl.DataSource = dt;
                    ////Application.DoEvents();
                    //chkEmpCoord.DataSource = dt;
                    //int algo = chkEmpCoord.Items.Count;
                    
                    //int algo2 = chkEmpCoord.Items.Count;

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
           // }
        }

        private void cmbEmpSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpSup.SelectedIndex >= 0)
            {
                //chkEmpCoord.DataSource = null;
                //chkEmpCoord.Items.Clear();
                cordsbySup(cmbEmpSup.SelectedValue.ToString());
                lstBoxEmpl.SelectedIndex = -1;
               // cordsbySup(cmbEmpSup.SelectedValue.ToString());
            }
        }

        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            if (string.IsNullOrEmpty(txtEmp.Text)||string.IsNullOrEmpty(txtEmpName.Text)||
                string.IsNullOrEmpty(cmbEmpSup.Text) || lstBoxEmpl.SelectedItems.Count==0)
            {
                MessageBox.Show("Datos insuficientes");
                return;
            }
            try
            {
               
                string sup = cmbEmpSup.SelectedValue.ToString();
                string coord = lstBoxEmpl.SelectedValue.ToString();
                string activo ="0";
                if (radioButton1.Checked)
                    activo = "1";
                conAcc.Open();
                string sqlIns = "update empleados set supervisor='" +sup+"',coordinador='"+coord+"',status="+activo +
                " WHERE empleado=" + txtEmp.Text;
                OleDbCommand comm = new OleDbCommand(sqlIns, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
                lblerr4.Text = "Se guardo la relacion";
                
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

        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void cmbEmpSup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void lstBoxEmpl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btnEmS_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSearchcomun frmS = new frmSearchcomun(11);

            frmS.ShowDialog();
            npId = "";
            if (frmS.Emp != null)
            {
                txtEmp.Text = frmS.Emp;
                busqueEmpleado();
            }
            frmS.Dispose();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void btn_pNew_Click(object sender, EventArgs e)
        {
            txtProc.Enabled = true;
            btn_pNew.Enabled = false;
            btn_pAdd.Enabled = true;
            btn_pSearch.Enabled = false;
            btn_pDel.Enabled = false;
            btn_pEdit.Enabled = false;

            txtProc.Text = "";
            txtProc.Focus();
        }

        private void btn_pDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abcProc(2);
                txtProc.Text = "";
               
                btn_pAdd.Enabled = false;
                btn_pNew.Enabled = true;
                btn_pEdit.Enabled = false;
                btn_pDel.Enabled = false;
                btn_pSearch.Enabled = true;
            }
        }

        private void btn_pEdit_Click(object sender, EventArgs e)
        {
            //ciId = txtProc.Text;
            txtProc.Enabled = true;
            
            editando = true;

            btn_pNew.Enabled = false;
            btn_pEdit.Enabled = false;
            btn_pDel.Enabled = false;
            btn_pSearch.Enabled = false;
            btn_pAdd.Enabled = true;
            txtProc.Focus();
        }

        private void btn_pAdd_Click(object sender, EventArgs e)
        {

            if (editando)
            {
                if (abcProc(1))//editando
                    editando = false;
            }
            else
                abcProc(0);//alta
        }
        private bool abcProc(int accion)
        {
            bool allOk = true;
            if (String.IsNullOrEmpty(txtProc.Text))
            {
                MessageBox.Show("Datos Insuficientes");
                txtProc.Focus();
                return false;
            }
            //np.Text = np.Text.Replace(" ", "");
            //codOra.Text = codOra.Text.Replace(" ", "");

            string sqlAccion = "";
           // string desc = txtDesc.Text.Trim(new char[] { '\r', '\n' });
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();

                if (accion == 0)//es un nuevo 
                {
                    sqlAccion = "insert into procesos (proceso)values('" +txtProc.Text.ToUpper() + "')";
                }
                else if (accion == 1)//editar 
                {
                    sqlAccion = "update procesos set proceso='" + txtProc.Text.ToUpper() + "'where proc_id=" + idProc;
                }
                else if (accion == 2)//borrar 
                {
                    sqlAccion = "delete from procesos where proc_id=" + idProc;
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
                if (accion == 0)
                {
                    OleDbCommand comm2 = new OleDbCommand("select max(proc_id) from procesos", conAcc);
                    OleDbDataReader dr = comm2.ExecuteReader();
                    dr.Read();
                    idProc = dr.GetValue(0).ToString();
                    dr.Dispose();
                    comm2.Dispose();
                }

            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar el Proceso: " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "El proceso esta duplicado, verifique";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accion == 0 || accion == 1))
            {
                btn_pNew.Enabled = true;
                btn_pDel.Enabled = true;
                btn_pEdit.Enabled = true;
                btn_pSearch.Enabled = true;
                btn_pAdd.Enabled = false;


                txtProc.Enabled = false;
                
            }
            #endregion
            return allOk;
        }
        private void btn_pSearch_Click(object sender, EventArgs e)
        {
            frmSearchcomun frmS = new frmSearchcomun(12);

            frmS.ShowDialog();
            npId = "";
            if (frmS.idProc != null)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {

                    #region carga busqueda
                    string sqlEmpl = "";

                    conAcc.Open();
                    sqlEmpl = "select * from procesos where proc_id =" + frmS.idProc;
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);

                    if (dtEmpl.Rows.Count > 0)
                    {
                        txtProc.Text = dtEmpl.Rows[0][1].ToString();
                       
                    }
                    idProc = frmS.idProc;
                    dtEmpl.Dispose();
                    da.Dispose();

                    // txtBox_conteo.Text = totEmpl.ToString();
                    #endregion
                    btn_pNew.Enabled = true;
                    btn_pDel.Enabled = true;
                    btn_pEdit.Enabled = true;
                    btn_pSearch.Enabled = true;
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al cargar el proceso: " + err.Message);
                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }

            }
            frmS.Dispose();
        }
    }
}
