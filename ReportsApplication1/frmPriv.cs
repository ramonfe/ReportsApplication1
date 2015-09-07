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
    public partial class frmPriv : Form
    {
        dbClass capaDb = new dbClass();
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        bool editando = false;
        string prevCo = "";
        public frmPriv()
        {
            InitializeComponent();
        }
        private void limpiaObj(bool limpia, bool enabled)
        {
            if (limpia)
            {
                txtUid.Clear();
                txtP1.Clear();
                txtP2.Clear();
                txtP3.Clear();
                chkMi.Checked = false;
                chkPriv.Checked=false;
                chkRep.Checked=false;
                chkV.Checked=false;
                chkEmp.Checked = false; 
            }
            txtUid.Enabled = enabled;
            txtP1.Enabled = enabled;
            txtP2.Enabled = enabled;
            txtP3.Enabled = enabled;
            chkMi.Enabled = enabled;
            chkPriv.Enabled = enabled;
            chkRep.Enabled = enabled;
            chkV.Enabled = enabled;   
            chkEmp.Enabled = enabled;
        }

        private void btn_dNew_Click(object sender, EventArgs e)
        {
            chkMod.Visible = false;
            lblP1.Text = "Clave:";
            lblP2.Text = "Confirmar Clave:";
            lblP3.Visible = false;
            txtP3.Visible = false;
            btnEsc.Enabled = true;
            btn_dNew.Enabled = false;
            btn_dAdd.Enabled = true;
            btn_dSearch.Enabled = false;
            btn_dDel.Enabled = false;
            btn_dEdit.Enabled = false;
            limpiaObj(true, true);
            txtUid.Focus();
        }

        private void btn_dEdit_Click(object sender, EventArgs e)
        {
            chkMod.Visible = true;
            lblP1.Text = "Clave Actual:";
            lblP2.Text = "Nueva Clave:";
            lblP3.Text = "Confirmar Clave:";
            lblP3.Visible = true;
            txtP3.Visible = true;
            limpiaObj(false, true);
            prevCo = txtUid.Text;
            editando = true;
            btn_dNew.Enabled = false;
            btn_dEdit.Enabled = false;
            btn_dDel.Enabled = false;
            btn_dSearch.Enabled = false;
            btn_dAdd.Enabled = true;
            txtP1.Enabled = false;
            txtP2.Enabled = false;
            txtP3.Enabled = false;
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

        private void btnEsc_Click(object sender, EventArgs e)
        {
            btn_dNew.Enabled = true;
            btn_dEdit.Enabled = false;
            btn_dDel.Enabled = false;
            btn_dSearch.Enabled = true;
            btn_dAdd.Enabled = false;
            limpiaObj(true, false);
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

        private void btn_dSearch_Click(object sender, EventArgs e)
        {
            frmSearchcomun frmS = new frmSearchcomun(9);

            frmS.ShowDialog();
            if (frmS.uId != null)
            {
                //dgEmpleados.Rows.Clear();
                //dgVoucher.Rows.Clear();
                //tbTurno.Text = "";
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    #region carga busqueda
                    string sqlEmpl = "select userid,moduloingenieria,captura,reportes,seguridad,clave,consulta from permisos where "+
                        " userid ='" + frmS.uId + "'";

                    conAcc.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                    DataTable dtEmpl = new DataTable();
                    da.Fill(dtEmpl);
                    int totEmpl = dtEmpl.Rows.Count;
                    if (dtEmpl.Rows.Count > 0)
                    {
                        txtUid.Text = dtEmpl.Rows[0][0].ToString();
                        chkMi.Checked = Convert.ToBoolean(dtEmpl.Rows[0][1]);
                        chkV.Checked = Convert.ToBoolean(dtEmpl.Rows[0][2]);
                        chkRep.Checked = Convert.ToBoolean(dtEmpl.Rows[0][3]);
                        chkPriv.Checked = Convert.ToBoolean(dtEmpl.Rows[0][4]);
                        chkEmp.Checked = Convert.ToBoolean(dtEmpl.Rows[0][6]);
                        txtUid.Tag = dtEmpl.Rows[0][5].ToString();
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
                    MessageBox.Show("Error al cargar el user Id: " + err.Message);
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
        private bool abc(int accionVoucher)
        {
            bool allOk = true, ret = true;

            if (txtUid.Text == "")
            {
                MessageBox.Show("Datos Insuficientes");
                return false;
            }
           
            //txtOp.Text = txtOp.Text.Replace(" ", "");
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
                if (accionVoucher == 0)//es un nuevo 
                {
                    if (txtP1.Text==""||txtP2.Text=="")
                    {
                        MessageBox.Show("Especifique claves");
                        return false;
                    }
                    if (txtP1.Text!=txtP2.Text)
                    {
                        MessageBox.Show("La confirmación de la clave no coincide, verifiquela!");
                        txtP3.Focus();
                        return false;
                    }
                    sqlAccion = "INSERT INTO permisos (userid, clave, moduloingenieria, captura," +
                    "reportes, seguridad,consulta) values('" +
                    txtUid.Text + "','" + txtP1.Text + "'," 
                    + Convert.ToInt16(chkMi.Checked) +","+
                    +Convert.ToInt16(chkV.Checked) +","+
                    +Convert.ToInt16(chkRep.Checked) +","+
                    +Convert.ToInt16(chkPriv.Checked) + "," +
                    +Convert.ToInt16(chkEmp.Checked) + ")";
                }
                else if (accionVoucher == 1)//editar 
                {
                    string sqlClave = "";
                    if (chkMod.Checked)
                    {
                        if (txtUid.Tag.ToString() != txtP1.Text)
                        {
                            MessageBox.Show("La clave actual no coincide");
                            txtP1.Focus();
                            return false;
                        }
                        if (txtP2.Text != txtP3.Text)
                        {
                            MessageBox.Show("La confirmación de la clave no coincide, verifiquela!");
                            txtP3.Focus();
                            return false;
                        }
                        sqlClave = ", clave='" + txtP2.Text + "'";
                    }
                    sqlAccion = "update permisos set userid='" + txtUid.Text + "'"+sqlClave+
                   ", moduloingenieria=" + Convert.ToInt16(chkMi.Checked) + ", captura=" + Convert.ToInt16(chkV.Checked) +
                   ",reportes=" + Convert.ToInt16(chkRep.Checked) + ", seguridad=" + Convert.ToInt16(chkPriv.Checked) +
                   ", consulta=" + Convert.ToInt16(chkEmp.Checked) +
                   " where userid='" + prevCo + "'";
                }
                else if (accionVoucher == 2)//borrar 
                {
                    sqlAccion = "delete from permisos where userid='" + txtUid.Text + "'";
                }
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();

            }
            catch (Exception err)
            {
                string error = "Error al intentar grabar el Privilegio: " + err.Message; ;
                if (err.Message.IndexOf("duplicate") > 0)
                    error = "El user ID esta duplicado, verifique";
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
                
                    txtUid.Tag = txtP2.Text;
                
                btn_dNew.Enabled = true;
                btn_dDel.Enabled = true;
                btn_dEdit.Enabled = true;
                btn_dSearch.Enabled = true;
                btn_dAdd.Enabled = false;
                btnEsc.Enabled = false;
                chkMod.Checked = false;
                chkMod.Visible = false;
                txtP1.Text = "";
                txtP2.Text = "";
                txtP3.Text = "";
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

        private void chkMod_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMod.Checked)
            {
                txtP1.Enabled = true;
                txtP2.Enabled = true;
                txtP3.Enabled = true;
            }
            else
            {
                txtP1.Enabled = false;
                txtP2.Enabled = false;
                txtP3.Enabled = false;
            }
        }

        private void txtP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void txtP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void txtP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void chkMi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void chkV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void chkRep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void chkPriv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void txtUid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

        private void chkEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendKeys.Send("{Tab}");
        }

    }

}
