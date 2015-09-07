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
    public partial class frmCodOp : Form
    {
        dbClass capaDb = new dbClass();
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        bool editando = false;
        string prevCo = "";
        public frmCodOp()
        {
            InitializeComponent();
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.KeyChar = (char)0;
            else if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void checkBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }
        private void cargaDeptos()
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
                //dt.Columns.Add("descripcion", typeof(string));
                //dt.Columns.Add("departamento", typeof(string));
                //dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                cmbDeptos.DisplayMember = "descripcion";
                cmbDeptos.ValueMember = "departamento";
                cmbDeptos.DataSource = dt;

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
            cmbDeptos.SelectedIndex = -1;
        }

        private void frmCodOp_Load(object sender, EventArgs e)
        {
            limpiaObj(true, false);
            cargaFbu();
            cargaDeptos();
            cargaProc();
        }

        private void cmbDeptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeptos.SelectedValue != null)// && !lReload)
                cargaCt(cmbDeptos.SelectedValue.ToString());
            else
            {
                cmbCt.DataSource = null;
                cmbCt.Items.Clear();
            }

        }
        private void cargaCt(string value)
        {
            cmbCt.Text = "";

            if (txtCop.Text.Length > 0)
            {
                txtCop.Text = txtCop.Text.Remove(0, 2);
                txtCop.Text = "XX" + txtCons.Text;
            }

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

        private void btn_dNew_Click(object sender, EventArgs e)
        {
            btnEsc.Enabled = true;
            btn_dNew.Enabled = false;
            btn_dAdd.Enabled = true;
            btn_dSearch.Enabled = false;
            btn_dDel.Enabled = false;
            btn_dEdit.Enabled = false;
            limpiaObj(true, true);
            cmbFbu.Focus();
        }
        private void limpiaObj(bool limpia, bool enabled)
        {
            if (limpia)
            {
                chkAct.Checked = true;
                cmbFbu.SelectedIndex = -1;
                cmbDeptos.SelectedIndex = -1;
                cmbCt.SelectedIndex = -1;
                cmbMtm.SelectedIndex = -1;
                cmbProc.SelectedIndex = -1;
                cmbMtm.Text = "";
                txtOp.Text = "0";
                foreach (Control control in Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textbox = control as TextBox;
                        textbox.Clear();
                    }
                }
                txtSs.Text = "0";
                txtSt.Text = "0";
                txtGp.Text = "0";
                txtHing.Text = "0";
            }
            cmbProc.Enabled = enabled;
            cmbFbu.Enabled = enabled;
            cmbDeptos.Enabled = enabled;
            cmbCt.Enabled = enabled;
            cmbMtm.Enabled = enabled;
            txtOp.Enabled = enabled;
            chkAct.Enabled = enabled;
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    TextBox textbox = control as TextBox;
                    textbox.Enabled = enabled;
                }
            }
        }
        private void btn_dDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo", "Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {
                abc(2);
                limpiaObj(true, false);

                btn_dAdd.Enabled = false;
                btn_dNew.Enabled = true;
                btn_dEdit.Enabled = false;
                btn_dDel.Enabled = false;
                btn_dSearch.Enabled = true;
            }
        }

        private void btn_dEdit_Click(object sender, EventArgs e)
        {
            limpiaObj(false, true);
            prevCo = txtCop.Text;
            editando = true;
            btn_dNew.Enabled = false;
            btn_dEdit.Enabled = false;
            btn_dDel.Enabled = false;
            btn_dSearch.Enabled = false;
            btn_dAdd.Enabled = true;
            btnEsc.Enabled = true;
        }

        private void btn_dAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                if (abc(1))//editando
                editando = false;
            }
             else
             abc(0);//alta
        }

        private void btn_dSearch_Click(object sender, EventArgs e)
        {
            frmSearchCodOp frmS = new frmSearchCodOp(3);

            frmS.ShowDialog();
            if (frmS.co !=null)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    #region carga busqueda
                    string sqlEmpl = "select * from codigosdeoperacion where codigooperacion ='" + frmS.co+"'";

                    conAcc.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    int totEmpl = dtEmpl.Rows.Count;
                    cmbProc.SelectedIndex = -1;
                    txtHing.Text = "0";
                    if (dtEmpl.Rows.Count > 0)
                    {
                        txtCop.Text = frmS.co;
                        cmbFbu.SelectedValue = dtEmpl.Rows[0][3].ToString();
                        cmbDeptos.SelectedValue = dtEmpl.Rows[0][12].ToString();
                        cmbCt.SelectedValue = dtEmpl.Rows[0][1].ToString();
                        txtCons.Text = dtEmpl.Rows[0][2].ToString();
                        txtNo.Text = dtEmpl.Rows[0][4].ToString();
                        txtCodR.Text = dtEmpl.Rows[0][5].ToString();
                        txtDe.Text = dtEmpl.Rows[0][6].ToString();
                        txtDi.Text = dtEmpl.Rows[0][7].ToString();
                        txtSs.Text = dtEmpl.Rows[0][8].ToString();
                        txtOp.Text = dtEmpl.Rows[0][11].ToString();
                        txtSt.Text = dtEmpl.Rows[0][9].ToString();
                        txtGp.Text = dtEmpl.Rows[0][10].ToString();
                        if (!string.IsNullOrEmpty(dtEmpl.Rows[0][13].ToString()))
                            chkAct.Checked = Convert.ToBoolean(dtEmpl.Rows[0][13]);
                        cmbMtm.Text = dtEmpl.Rows[0][14].ToString();
                        txtOra.Text = dtEmpl.Rows[0][15].ToString();
                        txtHing.Text = dtEmpl.Rows[0][17].ToString();
                        if (!string.IsNullOrEmpty(dtEmpl.Rows[0][18].ToString()))
                            cmbProc.SelectedValue = dtEmpl.Rows[0][18].ToString();
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
                    MessageBox.Show("Error al cargar el codigo de operacion: " + err.Message);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            btn_dNew.Enabled = true;
            btn_dEdit.Enabled = false;
            btn_dDel.Enabled = false;
            btn_dSearch.Enabled = true;
            btn_dAdd.Enabled = false;
            limpiaObj(true,false);
        }
        private bool validaDatos()
        {
            if (cmbFbu.SelectedIndex > -1 && cmbCt.SelectedIndex > -1 && cmbDeptos.SelectedIndex > -1 && cmbMtm.Text!="" && txtCodR.Text != "" &&
                txtCons.Text != "" && txtCop.Text != "" && txtDe.Text != "" && txtDi.Text != "" && txtGp.Text != "" && txtNo.Text != "" &&
                txtOp.Text != "" && txtOra.Text != "" && txtSs.Text != "" && txtSt.Text != "")
            {
                return true;  
            }
            else
                return false;
        }
        private bool abc(int accionVoucher)
        {
            bool allOk = true,ret=true;
            if (!validaDatos())
            {
                MessageBox.Show("Datos Insuficientes");
                return false;
            }

            try
            {
                Convert.ToDouble(txtSt.Text);
                Convert.ToDouble(txtSs.Text);
                Convert.ToDouble(txtGp.Text);
                
            }
            catch {
                MessageBox.Show("Las horas no son numericas");
                return false;
            }              
            txtOp.Text = txtOp.Text.Replace(" ", "");
            //dOverHead.Text = dOverHead.Text.Replace(" ", "");
            string sqlAccion = "";//, overHead = dOverHead.Text.Trim();
            //if (ohDec.Text != "" && ohDec.Text.Length > 0)
            //{
            //    ohDec.Text = ohDec.Text.Replace(" ", "");
            //    overHead += "." + ohDec.Text.Trim();
            //}

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string descIng = txtDi.Text.TrimEnd(new char[] {'\r','\n'});
                string descEsp = txtDe.Text.TrimEnd(new char[] { '\r', '\n' });
                if (accionVoucher == 0)//es un nuevo 
                {
                    string sqlProc = "",sqlProcCol="";

                    if (cmbProc.SelectedIndex >= 0)
                    {
                        sqlProc = "," + cmbProc.SelectedValue.ToString();
                        sqlProcCol = ",proceso";
                    }

                    sqlAccion = "INSERT INTO CodigosDeOperacion ( codigooperacion, CentroTrabajo, Consecutivo, FBU," +
                    "NumeroOperacion, CodigoReferencia, DescEsp, DescIng, System_Standard, Standard, Standard_Group, " +
                    "Operadores, Departamento, Activo, MTM, Oracle,hrs_ing"+sqlProcCol+" )" +
                    "values('" +
                    txtCop.Text + "','" + cmbCt.SelectedValue.ToString() + "','" + txtCons.Text + "','" +
                    cmbFbu.SelectedValue.ToString() + "','" + txtNo.Text + "','" + txtCodR.Text + "','" +
                     descEsp.ToUpper() + "','" + descIng.ToUpper() + "'," + txtSs.Text + "," + txtSt.Text + "," + txtGp.Text +
                     ","+txtOp.Text + ",'"+cmbDeptos.SelectedValue.ToString() +"',"+ Convert.ToInt16(chkAct.Checked) +
                    ",'" + cmbMtm.Text + "','" + txtOra.Text + "'," + txtHing.Text + sqlProc + ")";
                }
                else if (accionVoucher == 1)//editar 
                {
                    string sqlProc = "";
                    if (cmbProc.SelectedIndex >= 0)
                        sqlProc = ",proceso=" + cmbProc.SelectedValue.ToString();
                    sqlAccion = "update CodigosDeOperacion set " +
                        "codigooperacion='" + txtCop.Text + "',CentroTrabajo='" +
                         cmbCt.SelectedValue.ToString() + "',Consecutivo='" + txtCons.Text + "',FBU='" +
                         cmbFbu.SelectedValue.ToString() + "',NumeroOperacion='" + txtNo.Text + "',CodigoReferencia='" +
                         txtCodR.Text + "',DescEsp='" + descEsp.ToUpper() + "',DescIng='" + descIng.ToUpper() +
                          "',System_Standard=" + txtSs.Text + ",Standard=" + txtSt.Text +
                         ",Standard_Group=" + txtGp.Text + ",Operadores=" + txtOp.Text +
                        ",Departamento='" + cmbDeptos.SelectedValue.ToString() + "',Activo=" + Convert.ToInt16(chkAct.Checked)
                          + ",MTM='" + cmbMtm.Text + "',Oracle='" + txtOra.Text + "',hrs_ing=" + txtHing.Text +sqlProc+
                        " where codigooperacion='" + prevCo + "'";
                }
                else if (accionVoucher == 2)//borrar 
                {
                    sqlAccion = "delete from CodigosDeOperacion where codigooperacion='" + txtCop.Text + "'";
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
                ret = false;
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
                btnEsc.Enabled = false;
                //dFbu.Enabled = false;
                //dNumDepto.Enabled = false;
                //dDepto.Enabled = false;
                //dOverHead.Enabled = false;
                //ohDec.Enabled = false;
                limpiaObj(false, false);
            }
            #endregion
            return ret;
        }

        private void txtCons_TextChanged(object sender, EventArgs e)
        {
            string idCt = "XX";
            if (cmbCt.SelectedValue != null)
                idCt = cmbCt.SelectedValue.ToString();
            txtCop.Text = idCt+txtCons.Text;
        }

        private void txtCons_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
            //else
            //{
            //    string idCt = "XX";
            //    if (cmbCt.SelectedIndex > 0 && cmbCt.SelectedValue.ToString() != null)
            //        idCt = cmbCt.SelectedValue.ToString();
            //    txtCop.Text = idCt;
            //}
        }

        private void cmbCt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtCop.Text.Length > 0 && cmbCt.Text!=null)
            //{
            //    txtCop.Text = txtCop.Text.Remove(0, 2);
            //    txtCop.Text = cmbCt.SelectedValue.ToString() + txtCons.Text;
            //}
        }

        private void cmbFbu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }
        private void cargaFbu()
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
//                dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                cmbFbu.DisplayMember = "descripcion";
                cmbFbu.ValueMember = "fbu";
                cmbFbu.DataSource = dt;

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
            cmbFbu.SelectedIndex = -1;
        }
        private void cargaProc()
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select * from procesos order by proceso";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("proceso", typeof(string));
                dt.Columns.Add("proc_id", typeof(string));
                //                dt.Rows.Add(new object[] { "Seleccione..", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                cmbProc.DisplayMember = "proceso";
                cmbProc.ValueMember = "proc_id";
                cmbProc.DataSource = dt;
                
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
            cmbProc.SelectedIndex = -1;
        }
        private void txtSs_Leave(object sender, EventArgs e)
        {
            try
            {
                double ss = Convert.ToDouble(txtSs.Text);
                if (Convert.ToDouble(txtSs.Text) > 0)
                {
                    txtSt.Text = Math.Round((1000 / ss), 2).ToString();
                    if (Convert.ToDouble(txtOp.Text.Length) > 0)
                        calHrsGp();
                }
                else
                {
                    txtSt.Text = "0"; txtGp.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show("El valor debe ser numerico");
                txtSs.Focus();
            }
        }

        private void txtNo_Leave(object sender, EventArgs e)
        {
            if (txtNo.Text.Length != 4)
            {
                MessageBox.Show("El numero de operacion debe ser de 4 caracteres");
                txtNo.Focus();
            }
        }

        private void txtCodR_Leave(object sender, EventArgs e)
        {
            if (txtCodR.Text.Length != 13)
            {
                MessageBox.Show("El codigo de referencia debe ser de 13 caracteres");
                txtCodR.Focus();
            }
        }

        private void txtOp_Leave(object sender, EventArgs e)
        {
            try
            {
                double ss = Convert.ToDouble(txtOp.Text);
                calHrsGp();
            }
            catch
            {
                MessageBox.Show("El valos debe ser numerico");
                txtOp.Focus();
            }
        }
        private void calHrsGp()
        {
            double op = Convert.ToDouble(txtOp.Text);
            double st = Convert.ToDouble(txtSt.Text);
            txtGp.Text = Math.Round((op * st), 2).ToString();
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void txtHing_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtHing.Text))
                {
                    txtHing.Text = "0"; 
                }
                double ss = Convert.ToDouble(txtHing.Text);
                if (Convert.ToDouble(txtHing.Text) > 0)
                {
                    //txtSt.Text = Math.Round((1000 / ss), 2).ToString();
                    //if (Convert.ToDouble(txtOp.Text.Length) > 0)
                        //calHrsGp();
                }
                else
                {
                    txtHing.Text = "0"; //txtGp.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show("El valor debe ser numerico");
                txtHing.Focus();
            }
        }

        private void cmbProc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }
    }
}
