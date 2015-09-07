using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ReportsApplication1
{
    public partial class frmMenu2 : Form
    {
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        dbClass capaDb = new dbClass();
        public frmMenu2()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cmbReps.SelectedIndex >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                string texto = "";
                //frm.reportViewer1.Reset();
                switch (cmbReps.SelectedIndex)
                {
                    #region rep eficiencia
                    case 0://depto
                    case 1://centro trab
                    case 2://linea
                    case 3://cod op
                    case 5://empl
                    case 7://supervisor
                        //}
                        //else if (cmbEfBy.SelectedIndex == 1)//Centro de Trabajo
                        //{
                        frmEfCt frEfCt = new frmEfCt();

                        if (cmbReps.SelectedIndex == 3 && chkHIng.Checked)
                            frEfCt.hearnIng = 1;
                        else
                            frEfCt.hearnIng = 0;

                        frEfCt.procs = sacaFiltro(lbCoProc, ref texto);
                        frEfCt.procsName = texto; texto = "";

                        if (cbFbuM.SelectedIndex > 0)
                        {
                            frEfCt.fbu = cbFbuM.SelectedValue.ToString();
                            frEfCt.fbu_name = cbFbuM.Text;
                        }
                        if (chkOverH.Checked)
                            frEfCt.showOver = 1;
                        else
                            frEfCt.showOver = 0;

                        frEfCt.reporte = cmbReps.SelectedIndex;
                        frEfCt.ct = sacaFiltro(lbCtM, ref texto);
                        frEfCt.ctN = texto; texto = "";
                        frEfCt.co = sacaFiltro(lbCoM, ref texto);
                        frEfCt.coN = texto; texto = "";
                        frEfCt.linea = sacaFiltro(lbLinM, ref texto);
                        frEfCt.depto = sacaFiltro(lbDepM, ref texto);
                        frEfCt.turno = sacaFiltro(cbShiftM, ref texto);
                        frEfCt.deptoName = texto; texto = "";
                        //if (texto != "")
                        //{
                        //    string[] lin = texto.Split('|');
                        //    frEfCt.deptoName = lin[1]; texto = "";
                        //}
                        frEfCt.date1 = date1M.Value.ToShortDateString();
                        frEfCt.date2 = date2M.Value.ToShortDateString();


                        // if (cbShiftM.SelectedIndex > 0) frEfCt.turno = cbShiftM.Text;
                        if (cbEmM.SelectedIndex > 0 && cbEmM.Text != "")
                        {
                            frEfCt.emp = cbEmM.SelectedValue.ToString();
                            frEfCt.empN = cbEmM.Text;
                        }
                        if (cbSupM.SelectedIndex > 0 && cbSupM.Text != "")
                        {
                            frEfCt.supN = cbSupM.Text;
                            frEfCt.sup = cbSupM.SelectedValue.ToString();
                        }
                        if (cmbCoordM.SelectedIndex > 0 && cmbCoordM.Text != "")
                        {
                            frEfCt.coordN = cmbCoordM.Text;
                            frEfCt.coord = cmbCoordM.SelectedValue.ToString();
                        }
                        if (txtEfM.Text.Length > 0 && cbEfM.SelectedIndex >= 0) { frEfCt.efic = txtEfM.Text; frEfCt.efsign = cbEfM.Text; }
                        frEfCt.ShowDialog();
                        frEfCt.Dispose();
                        break;
                    case 8://REPORTE DE HORAS INDIRECTAS

                        frmRepHi frRepHi = new frmRepHi();
                        if (cbFbuM.SelectedIndex > 0)
                        {
                            frRepHi.fbu = cbFbuM.SelectedValue.ToString();
                            frRepHi.fbu_name = cbFbuM.Text;
                        }
                        //if (chkOverH.Checked)
                        //    frRepHi.showOver = 1;
                        //else
                        //    frRepHi.showOver = 0;
                        frRepHi.reporte = cmbReps.SelectedIndex;
                        frRepHi.ct = sacaFiltro(lbCtM, ref texto);
                        frRepHi.ctN = texto; texto = "";
                        frRepHi.di = sacaFiltro(lbCoM, ref texto);//<--
                        frRepHi.diN = texto; texto = "";

                        frRepHi.depto = sacaFiltro(lbDepM, ref texto);
                        frRepHi.deptoName = texto; texto = "";
                        frRepHi.date1 = date1M.Value.ToShortDateString();
                        frRepHi.date2 = date2M.Value.ToShortDateString();
                        //if (cbShiftM.SelectedIndex > 0) frRepHi.turno = cbShiftM.Text;
                        frRepHi.turno = sacaFiltro(cbShiftM, ref texto);
                        if (cbSupM.SelectedIndex > 0 && cbSupM.Text != "")
                        {
                            frRepHi.supN = cbSupM.Text;
                            frRepHi.sup = cbSupM.SelectedValue.ToString();
                        }
                        if (cmbCoordM.SelectedIndex > 0 && cmbCoordM.Text != "")
                        {
                            frRepHi.coordN = cmbCoordM.Text;
                            frRepHi.coord = cmbCoordM.SelectedValue.ToString();
                        }

                        frRepHi.ShowDialog();
                        frRepHi.Dispose();
                        break;
                    case 9://REPORTE DE HORAS INDIRECTAS2

                        frmRepHi2 frRepHi2 = new frmRepHi2();
                        if (cbFbuM.SelectedIndex > 0)
                        {
                            frRepHi2.fbu = cbFbuM.SelectedValue.ToString();
                            frRepHi2.fbu_name = cbFbuM.Text;
                        }
                        //if (chkOverH.Checked)
                        //    frRepHi.showOver = 1;
                        //else
                        //    frRepHi.showOver = 0;
                        frRepHi2.reporte = cmbReps.SelectedIndex;
                        frRepHi2.ct = sacaFiltro(lbCtM, ref texto);
                        frRepHi2.ctN = texto; texto = "";
                        frRepHi2.di = sacaFiltro(lbCoM, ref texto);//<--
                        frRepHi2.diN = texto; texto = "";

                        frRepHi2.depto = sacaFiltro(lbDepM, ref texto);
                        frRepHi2.deptoName = texto; texto = "";
                        frRepHi2.date1 = date1M.Value.ToShortDateString();
                        frRepHi2.date2 = date2M.Value.ToShortDateString();
                        //if (cbShiftM.SelectedIndex > 0) frRepHi.turno = cbShiftM.Text;
                        frRepHi2.turno = sacaFiltro(cbShiftM, ref texto);
                        if (cbSupM.SelectedIndex > 0 && cbSupM.Text != "")
                        {
                            frRepHi2.supN = cbSupM.Text;
                            frRepHi2.sup = cbSupM.SelectedValue.ToString();
                        }
                        if (cmbCoordM.SelectedIndex > 0 && cmbCoordM.Text != "")
                        {
                            frRepHi2.coordN = cmbCoordM.Text;
                            frRepHi2.coord = cmbCoordM.SelectedValue.ToString();
                        }

                        frRepHi2.ShowDialog();
                        frRepHi2.Dispose();
                        break;
                    case 4://Codigo de Operación (Empl)
                    case 6://Empleado (Codigo de Operación)
                        frmEfEmpCo frEEco = new frmEfEmpCo();
                        if (cbFbuM.SelectedIndex > 0)
                        {
                            frEEco.fbu = cbFbuM.SelectedValue.ToString();
                            frEEco.fbu_name = cbFbuM.Text;
                        }
                        if (chkHIng.Checked)
                            frEEco.hearnIng = 1;
                        else
                            frEEco.hearnIng = 0;
                        frEEco.procs = sacaFiltro(lbCoProc, ref texto);
                        frEEco.procsName = texto; texto = "";
                        frEEco.reporte = cmbReps.SelectedIndex;
                        frEEco.ct = sacaFiltro(lbCtM, ref texto);
                        frEEco.ctN = texto; texto = "";
                        frEEco.co = sacaFiltro(lbCoM, ref texto);
                        frEEco.coN = texto; texto = "";
                        frEEco.linea = sacaFiltro(lbLinM, ref texto);
                        frEEco.depto = sacaFiltro(lbDepM, ref texto);
                        frEEco.deptoName = texto; texto = "";
                        //if (texto != "")
                        //{
                        //    string[] lin = texto.Split('|');
                        //    frEEco.deptoName = lin[1]; texto = "";
                        //}
                        frEEco.date1 = date1M.Value.ToShortDateString();
                        frEEco.date2 = date2M.Value.ToShortDateString();
                        frEEco.turno = sacaFiltro(cbShiftM, ref texto);

                        //if (cbShiftM.SelectedIndex > 0) frEEco.turno = cbShiftM.Text;
                        if (cbEmM.SelectedIndex > 0 && cbEmM.Text != "")
                        {
                            frEEco.emp = cbEmM.SelectedValue.ToString();
                            frEEco.empN = cbEmM.Text;
                        }
                        if (cbSupM.SelectedIndex > 0 && cbSupM.Text != "")
                        {
                            frEEco.supN = cbSupM.Text;
                            frEEco.sup = cbSupM.SelectedValue.ToString();
                        }
                        if (cmbCoordM.SelectedIndex > 0 && cmbCoordM.Text != "")
                        {
                            frEEco.coordN = cmbCoordM.Text;
                            frEEco.coord = cmbCoordM.SelectedValue.ToString();
                        }
                        if (txtEfM.Text.Length > 0 && cbEfM.SelectedIndex >= 0) { frEEco.efic = txtEfM.Text; frEEco.efsign = cbEfM.Text; }
                        frEEco.ShowDialog();
                        frEEco.Dispose();
                        break;
                    #endregion
                    #region listados
                    case 10://departamentos
                        frmRdep frDep = new frmRdep();
                        if (lstDeptosFbu.SelectedIndex > 0)
                        {
                            frDep.fbu = lstDeptosFbu.SelectedValue.ToString();
                        }
                        if (chkOverHead.Checked)
                            frDep.overHead = "1";
                        else
                            frDep.overHead = "0";

                        frDep.ShowDialog();
                        frDep.Dispose();
                        break;
                    case 11:///centros de trabajo
                        frmRct frCt = new frmRct();
                        if (cmbFbu1.SelectedIndex > 0)
                        {
                            frCt.fbu = cmbFbu1.SelectedValue.ToString();
                        }
                        frCt.deptos = sacaFiltro(linLbDeptos, ref texto);
                        frCt.deptosName = texto;
                        frCt.ShowDialog();
                        frCt.Dispose();
                        break;
                    case 12:///Linea
                        frmRlin frLin = new frmRlin();
                        if (cmbFbu1.SelectedIndex > 0)
                        {
                            frLin.fbu = cmbFbu1.SelectedValue.ToString();
                        }
                        frLin.deptos = sacaFiltro(linLbDeptos, ref texto);
                        frLin.CenTrab = sacaFiltro(linLbCt, ref texto);
                        frLin.ShowDialog();
                        frLin.Dispose();
                        break;
                    case 13://codigos de operacion
                        frmRco frco = new frmRco();
                        if (cmbFbu1.SelectedIndex > 0)
                        {
                            frco.fbu = cmbFbu1.SelectedValue.ToString();
                        }
                        frco.deptos = sacaFiltro(linLbDeptos, ref texto);
                        frco.deptosName = texto; texto = "";
                        frco.CenTrab = sacaFiltro(linLbCt, ref texto);
                        frco.CenTrabName = texto; texto = "";
                        frco.procs = sacaFiltro(lstProc, ref texto);
                        frco.procsName = texto; texto = "";
                        frco.ora = txtOra.Text;
                        frco.nop = txtNparte.Text;
                        frco.ShowDialog();
                        frco.Dispose();
                        break;
                    case 14://supervisores
                        frmRsup frSup = new frmRsup();
                        frSup.ShowDialog();
                        frSup.Dispose();
                        break;
                    case 15://vouchers
                        frmRvouch frVch = new frmRvouch();
                        frVch.date1 = dtPick1.Value.ToShortDateString();
                        frVch.date2 = dtPick2.Value.ToShortDateString();
                        frVch.turno = sacaFiltro(cmbTrn, ref texto);
                        //if (cmbTrn.SelectedIndex > 0) frVch.turno = cmbTrn.Text;
                        if (cmbLine.SelectedIndex > 0 && cmbLine.Text != "")
                        {
                            frVch.lineaName = cmbLine.Text;
                            frVch.linea = cmbLine.SelectedValue.ToString();
                        }
                        if (txtCo.Text.Length > 0) frVch.codOp = txtCo.Text;
                        if (cmbSup.SelectedIndex > 0 && cmbSup.Text != "")
                        {
                            frVch.sup = cmbSup.SelectedValue.ToString();
                            frVch.supName = cmbSup.Text;
                        }
                        if (cmbEmp.SelectedIndex > 0 && cmbEmp.Text != "")
                        {
                            frVch.empl = cmbEmp.SelectedValue.ToString();
                            frVch.emplName = cmbEmp.Text;
                        }
                        if (txtEf.Text.Length > 0 && cmbEf.SelectedIndex >= 0) { frVch.efic = txtEf.Text; frVch.efsign = cmbEf.Text; }
                        if (cmbFbu2.SelectedIndex > 0 && cmbFbu2.Text != "")
                        {
                            frVch.fbu = cmbFbu2.SelectedValue.ToString();
                            //frVch.fbu = cmbFbu2
                        }
                        if (cmbDepto.SelectedIndex > 0 && cmbDepto.Text != "")
                        {
                            frVch.depto = cmbDepto.SelectedValue.ToString();
                            frVch.deptoName = cmbDepto.Text;
                        }
                        if (cmbCt.SelectedIndex > 0 && cmbCt.Text != "")
                        {
                            frVch.ct = cmbCt.SelectedValue.ToString();
                            frVch.ctName = cmbCt.Text;
                        }
                        if (cmbCoord.SelectedIndex > 0 && cmbCoord.Text != "")
                        {
                            frVch.coord = cmbCoord.SelectedValue.ToString();
                            frVch.coordName = cmbCoord.Text;
                        }
                        frVch.ShowDialog();
                        frVch.Dispose();
                        break;
                    case 16://fbus
                        frmRfbus frFbus = new frmRfbus();
                        frFbus.ShowDialog();
                        frFbus.Dispose();
                        break;
                    #endregion
                }
                this.Cursor = Cursors.Default;
            }
        }
        //private string sacaDeptos(ListBox lb)
        //{
        //    string deptos = "";
        //    if (lb.SelectedIndex >= 0)
        //    {
        //        ////ListBox Item;
        //        //foreach (ListBox Item in lb.SelectedItems)
        //        //{


        //        //    deptos += "'" + Item.SelectedValue + "',";
        //        //        //ItemValue.Text += Item.Value + " ";
                    
        //        //}
        //        for (int z = 0; z < lb.SelectedItems.Count; z++)
        //        {
        //            deptos += "'" + lb.SelectedItems[z].ToString() + "',";
        //        }
        //        deptos = deptos.TrimEnd(',');
        //    }
        //    return deptos;
        //}
        //private string sacaCenTrab(ListBox lb)
        //{
        //    string cenTrab = "";
        //    if (lb.SelectedIndex >= 0)
        //    {
        //        for (int z = 0; z < lb.SelectedItems.Count; z++)
        //        {
        //            cenTrab += "'" + lb.SelectedItems[z].ToString() + "',";
        //        }
        //        cenTrab = cenTrab.TrimEnd(',');
        //    }
        //    return cenTrab;
        //}
        private string sacaFiltro(ListBox lb,ref string text)
        {
            string filtro = "";
            if (lb.SelectedIndex >= 0)
            {
                for (int z = 0; z < lb.SelectedItems.Count; z++)
                {
                    string filtroTemp = "";
                    if (lb.Name == "lbLinM")
                    {
                        filtro += "'" + lb.SelectedItems[z].ToString() + "',";
                        filtroTemp =
                             lb.SelectedItems[z].ToString().Remove(0, lb.SelectedItems[z].ToString().IndexOf("|")+1);
                    }
                    else if ((lb.Name == "cbShiftM")||(lb.Name=="cmbTrn"))
                    {
                        filtro +=  ((DataRowView)lb.SelectedItems[z])[0].ToString() + ",";
                        filtroTemp =
                             ((DataRowView)lb.SelectedItems[z])[0].ToString().Remove(0, ((DataRowView)lb.SelectedItems[z])[0].ToString().IndexOf("|") + 1);
                        text += filtroTemp + ",";
                    }
                    else
                    {
                        //filtro+=((ListControl)lb.SelectedItems[z]).SelectedValue.ToString();
                        filtro += "'" + ((DataRowView)lb.SelectedItems[z])[1].ToString() + "',";
                        filtroTemp =
                             ((DataRowView)lb.SelectedItems[z])[0].ToString().Remove(0, ((DataRowView)lb.SelectedItems[z])[0].ToString().IndexOf("|")+1);
                        text += filtroTemp + ",";
                        //text += ((DataRowView)lb.SelectedItems[z])[0].ToString() + ",";
                       
                        //object[] algo = (object[])lb.SelectedItems[z].
                    }
                }
                
                filtro = filtro.TrimEnd(',');
                text = text.TrimEnd(',');
            }
            return filtro;
        }
        private void frmMenu2_Load(object sender, EventArgs e)
        {
            //if (appPath == "Local")
            //    appPath = AppDomain.CurrentDomain.BaseDirectory;
            //// TODO: This line of code loads data into the 'eficienDataSet.Departamentos' table. You can move, or remove it, as needed.
            //this.departamentosTableAdapter.Fill(this.eficienDataSet.Departamentos);
            // TODO: This line of code loads data into the 'eficienDataSet.Empleados' table. You can move, or remove it, as needed.
            //this.empleadosTableAdapter.Fill(this.eficienDataSet.Empleados);
            // TODO: This line of code loads data into the 'eficienDataSet.Supervisores' table. You can move, or remove it, as needed.
            //this.supervisoresTableAdapter.Fill(this.eficienDataSet.Supervisores);
            // TODO: This line of code loads data into the 'eficienDataSet.lstSup' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'eficienDataSet.lstLineas' table. You can move, or remove it, as needed.
            //this.lstLineasTableAdapter.Fill(this.eficienDataSet.lstLineas);
            //tabsCtrl.TabPages.Remove(tabPage1);
            //tabsCtrl.TabPages.Remove(tabPage2);
            cargaFbu(cbFbuM);
            cargaCt(lbCtM);
            
            lbLinM.SelectedIndex = -1;
            cargaDeptos(lbDepM);
            cargaSup(cbSupM);
            cargaEmp(cbEmM);            
            cargaTurnos(cbShiftM);
            cargaTurnos(cmbTrn);
            cargaCoord(cmbCoord);
            cargaCoord(cmbCoordM);
            cargaProc(lbCoProc);
            //->objetos listado vouchers
            cargaLinea(cmbLine);
            cargaSup(cmbSup);
            cargaDeptos(cmbDepto);
            cargaCt(cmbCt);
            cargaEmp(cmbEmp);//<-
            cmbLine.SelectedIndex = -1;
            cmbSup.SelectedIndex = -1;
            cmbEmp.SelectedIndex = -1;
            date1M.Text = DateTime.Today.ToShortDateString();
            date2M.Text = DateTime.Today.ToShortDateString();

        }
        private void cargaDeptos(ListBox lb)
        {
            //lb.Items.Clear();

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
                //dt.Rows.Add(new object[] { "[Todos]", 0 });
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
        private void cargaDeptos(ComboBox lb)
        {
            //lb.Items.Clear();

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
                dt.Rows.Add(new object[] { "[Todos]", 0 });
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
        private void cargaDeptosInd(ListBox lb)
        {
            lb.DataSource = null;
            lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select codigo_indirecto,codigo_indirecto & ' | ' & departamento as departamento from IndirectosAsignadosDepartementosPlanta  order by codigo_indirecto";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("departamento", typeof(string));
                dt.Columns.Add("codigo_indirecto", typeof(string));
                //dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "departamento";
                lb.ValueMember = "codigo_indirecto";
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
        private void cargaProc(ListBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select * from procesos order by proceso";
                // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("proceso", typeof(string));
                dt.Columns.Add("proc_id", typeof(string));
                //if (lb.Name != "cmbSup")
                //dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "proceso";
                lb.ValueMember = "proc_id";
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
        private void  cargaCodOp(ListBox lb)
        {
            lb.DataSource = null;
            lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select codigooperacion,codigooperacion as codigooperacion2 from codigosdeoperacion where activo = 1 order by codigooperacion";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("codigooperacion", typeof(string));
                dt.Columns.Add("codigooperacion2", typeof(string));
                //dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "codigooperacion";
                lb.ValueMember = "codigooperacion2";
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
        //
        private void cargaSup(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select * from supervisores order by nombre";
                // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("nombre", typeof(string));
                dt.Columns.Add("supervisor", typeof(string));
                //if (lb.Name != "cmbSup")
                    dt.Rows.Add(new object[] { "[Todos]", 0 });
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
        private void cargaCoord(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select * from coordinadores order by nombre_coord";
                // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("nombre_coord", typeof(string));
                dt.Columns.Add("id_coordinador", typeof(string));
                //if (lb.Name != "cmbCoord")
                    dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "nombre_coord";
                lb.ValueMember = "id_coordinador";
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
        private void cargaEmp(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select * from empleados order by nombre";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("nombre", typeof(string));
                dt.Columns.Add("empleado", typeof(string));
                dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "nombre";
                lb.ValueMember = "empleado";
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
        private void cargaTurnos(ListBox lb)
        {
            // lb.Items.Clear();
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select turno from turnos order by turno";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("turno", typeof(string));
                dt.Columns.Add("turno2", typeof(string));
                //dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "turno";
                lb.ValueMember = "turno2";
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
                dt.Columns.Add("descripcion",typeof(string));
                dt.Columns.Add("fbu", typeof(string));
                dt.Rows.Add(new object[]{"[Todos]",0});
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
        private void cargaKindRep(string _sql,string text)
        {
            //edLst.Items.Clear();

            //OleDbConnection conAcc = new OleDbConnection(
            //        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath);
            //try
            //{
            //    conAcc.Open();
            //    string sql = _sql;
            //    OleDbCommand comm = new OleDbCommand(sql, conAcc);
            //    OleDbDataReader dr = comm.ExecuteReader();
            //    while (dr.Read())
            //    {

            //        edLst.Items.Add(dr[text]);
            //    }
            //    comm.Dispose();
            //    dr.Close();
            //    dr.Dispose();
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
            //finally
            //{
            //    conAcc.Close();
            //    conAcc.Dispose();
            //}
        }
        private void cargaCt(ListBox lb)
        {
           // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select centrotrabajo,centrotrabajo & ' | '& descripcion as descripcion from centrostrabajos order by descripcion";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("centrotrabajo", typeof(string));
                //dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "descripcion";
                lb.ValueMember = "centrotrabajo";
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
            lbLinM.Items.Clear();
        }
        private void cargaCt(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select centrotrabajo,centrotrabajo & ' | '& descripcion as descripcion from centrostrabajos order by descripcion";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("centrotrabajo", typeof(string));
                dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "descripcion";
                lb.ValueMember = "centrotrabajo";
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
            lbLinM.Items.Clear();
        }
        private void cargaLinea(ComboBox lb)
        {
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select linea,descripcion as descripcion from lineas order by descripcion";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("linea", typeof(string));
                dt.Rows.Add(new object[] { "[Todos]", 0 });
                da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                lb.DisplayMember = "descripcion";
                lb.ValueMember = "linea";
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
            lbLinM.Items.Clear();
        }
        private void cargaLinea(ListBox lb,string ctId)
        {

            lb.Items.Clear();
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                //conAcc.Open();
                //string sql =
                //    "select linea from lineas where centrotrabajo='" + ctId + "' order by linea";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                //OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                //DataTable dt = new DataTable();
                //dt.Columns.Add("linea", typeof(string));
                //dt.Columns.Add("linea2", typeof(string));
                ////dt.Rows.Add(new object[] { "[Todas]", 0 });
                //da.Fill(dt);
                //da.Dispose();
                //dt.Dispose();
                //lb.DisplayMember = "linea";
                //lb.ValueMember = "linea2";
                //lb.DataSource = dt;
                conAcc.Open();
                string sql =
                    "select linea from lineas where centrotrabajo='" + ctId + "' order by linea";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                //dt.Columns.Add("linea", typeof(string));
                //dt.Columns.Add("linea2", typeof(string));
                da.Fill(dt);
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    lb.Items.Add(dt.Rows[x]["linea"].ToString());
                }
                    
                //dt.Rows.Add(new object[] { "[Todas]", 0 });
                //da.Fill(dt);
                da.Dispose();
                dt.Dispose();
                //lb.DisplayMember = "linea";
                //lb.ValueMember = "linea";
                //lb.DataSource = dt;
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

        private void remueveTabs()
        {
            
            foreach (TabPage tp in this.tabsCtrl.TabPages)
            {
                tabsCtrl.TabPages.Remove(tp);
            }
        }
        private void cmbReps_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            chkOverH.Visible = false;
            chkOverH.Checked = false;
            chkHIng.Visible = false;
            chkHIng.Checked = false;
            remueveTabs();
            tabsCtrl.Visible = false;
            panCt.Visible = false;
            panProc.Visible = false;
            panPlt.Visible = false;
            chkOverHead.Visible = false;
            panCo.Visible = false;
            txtOra.Text = "";
            txtNparte.Text = "";
            lbCoProc.Visible = false;
            lblProc.Visible = false;
            if (cmbReps.SelectedIndex >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                lbLinM.Items.Clear();
                //frm.reportViewer1.Reset();
                #region reportes
                if (cmbReps.SelectedIndex >= 0 && cmbReps.SelectedIndex <= 9)// || cmbReps.SelectedIndex == 16)
                {
                    switch (cmbReps.SelectedIndex)
                    {
                        case 3:
                        case 4:
                        case 6:
                            chkHIng.Visible = true;
                            lbCoProc.Visible = true;
                            lblProc.Visible = true;
                            break;
                    }
                    if (cmbReps.SelectedIndex == 0)
                        chkOverH.Visible = true;
                    if (cmbReps.SelectedIndex == 8 || cmbReps.SelectedIndex == 9)//reporte de cod. indirectos
                    {
                        lbCoM.Location = new Point(251, 82);
                        lbCoM.Height = 100;
                        lbCoM.Width = 260;
                        lblLin.Text = "Departamentos de Planta:";
                        lblCodOp.Visible = false;
                        lblEf.Visible = false;
                        cbEfM.Visible = false;
                        txtEfM.Visible = false;
                        lbLinM.Visible = false;
                        cbEmM.Visible = false;
                        lblEmp.Visible = false;
                        cargaDeptosInd(lbCoM);
                    }
                    else
                    {
                        lblLin.Text = "Lineas:";
                        lbCoM.Location = new Point(373, 82);
                        lbCoM.Height = 100;
                        lbCoM.Width = 138;
                        lblCodOp.Visible = true;
                        lblEf.Visible = true;
                        cbEfM.Visible = true;
                        txtEfM.Visible = true;
                        lbLinM.Visible = true;
                        cbEmM.Visible = true;
                        lblEmp.Visible = true;
                        cargaCodOp(lbCoM);
                    }
                    tabsCtrl.Visible = true;
                    tabsCtrl.TabPages.Add(tabMain);
                    cbFbuM.SelectedIndex = 0;
                    lbCtM.SelectedIndex = -1;
                    lbCoM.SelectedIndex = -1;
                    lbDepM.SelectedIndex = -1;
                    cbEmM.SelectedIndex = -1;
                    cbSupM.SelectedIndex = -1;
                    cmbCoordM.SelectedIndex = -1;
                    cbShiftM.SelectedIndex = -1;
                    lbCoProc.SelectedIndex = -1;
                }
                #endregion
                #region Listados
                switch (cmbReps.SelectedIndex)
                {
                    case 10://departamentos
                        chkOverHead.Visible = true;
                        cargaFbu(lstDeptosFbu);
                        panPlt.Visible = true;
                        break;
                    case 11:///centros de trabajo
                        tabsCtrl.Visible = true;
                        linLbDeptos.Visible = true;
                        tabsCtrl.TabPages.Add(tabPage1);
                        cargaDeptos(linLbDeptos);
                        cargaFbu(cmbFbu1);
                        break;
                    
                    case 13://cod de op
                        panCo.Visible = true;
                        tabsCtrl.Visible = true;
                        panCt.Visible = true;
                        panProc.Visible = true;
                        tabsCtrl.TabPages.Add(tabPage1);
                        cargaDeptos(linLbDeptos);
                        cargaCt(linLbCt);
                        cargaFbu(cmbFbu1);
                        cargaProc(lstProc);
                        break;
                    case 12:
                    case 16:
                    case 14://supervisores
                        //cargaFbu(lstDeptosFbu);
                        //panPlt.Visible = true;
                        break;
                    case 15://vouchers
                        tabsCtrl.Visible = true;
                        cargaFbu(cmbFbu2);
                        tabsCtrl.TabPages.Add(tabPage2);
                        cmbLine.Text = "";
                        cmbSup.Text = "";
                        cmbEmp.Text = "";
                        cmbDepto.Text = "";
                        cmbCt.Text = "";
                        cmbCoord.Text = "";
                        break;

                }
                #endregion
                this.Cursor = Cursors.Default;
            }
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach)
            //lstDeptos3.se
        }

        private void edLstDeptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void cmbEfBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbEfBy.SelectedIndex >= 0)
            //{
            //    rb1.Visible = false;
            //    rb2.Visible = false;
            //    lblKindRepEf.Visible = true;
            //    edLst.Visible = true;
            //    lblKindRepEf.Text = cmbEfBy.Text;
            //    switch (cmbEfBy.SelectedIndex)
            //    {
            //        case 0://Departamento
            //            cargaKindRep("select departamento,descripcion from departamentos order by departamento",
            //                "descripcion");
            //            break;
            //        case 1://Centro de Trabajo
            //            cargaKindRep("select descripcion from centrostrabajos order by descripcion","descripcion");
            //            break;
            //        case 2://Linea
            //            cargaKindRep("select descripcion from lineas order by descripcion", "descripcion");
            //            break;
            //        case 3://Codigo de Operación
            //        case 4://Codigo de Operación (Empleado)
            //            cargaKindRep("select codigooperacion from codigosdeoperacion where activo = 1 order by codigooperacion",
            //                "codigooperacion");
            //            rb1.Visible = true;
            //            rb2.Visible = true;
            //            break;
            //        case 5://Empleado
            //        case 6://Empleado (Codigo de Operación)
            //            cargaKindRep("select nombre from empleados order by nombre",
            //                "nombre");
            //            break;
            //        case 7://Supervisor
            //            cargaKindRep("select nombre from supervisores order by nombre",
            //                "nombre");
            //            break;
            //    }
            //}
            //else
            //{
            //    lblKindRepEf.Visible = false;
            //    edLst.Visible = false;
            //}
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            cargaKindRep("select codigooperacion from codigosdeoperacion where activo = 1 order by codigooperacion",
                            "codigooperacion");
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            cargaKindRep("select descesp from codigosdeoperacion where activo = 1 order by descesp",
                            "descesp");
        }

        private void edCmbEf_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (edCmbEf.SelectedIndex >= 0)
            //{
            //    edTxtEf.Enabled = true;
            //}
            //else
            //{
            //    edTxtEf.Text = "";
            //    edTxtEf.Enabled = false;
            //}
        }

        private void lbCtM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCtM.SelectedIndex >= 0)
            {
                cargaLinea(lbLinM, lbCtM.SelectedValue.ToString());
            }
            //else
            //{
            //    lbLinM.Items.Clear();
            //}
        }

        private void limpiarSeleccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = contextMenuStrip1.SourceControl;
            ListBox c1 = (ListBox)c;
            c1.SelectedIndex = -1;
            if (c1.Name == "lbCtM")
            {
                lbLinM.Items.Clear();
            }
        }

        private void cmbFbu1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        
    }
}
