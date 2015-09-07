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
using Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn;
using dgv;

namespace ReportsApplication1
{
    public partial class frmVoucher : Form
    {
        dbClass capaDb = new dbClass();
        int _fromDiscr = 0;
        public int fromDiscr
        {
            set
            {
                _fromDiscr = value;
            }
        }
        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        bool indirecto = false,removidos = false;
        int indVoucher = 0;
        bool editando = false;
        frmVouchersSearch frmS = new frmVouchersSearch();
        public frmVoucher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow item = dgEmpleados.CurrentRow;
            //item.CreateCells(dgEmpleados);
            //item.Cells[0].Value = "algo";
            //dgEmpleados.Rows.Add(item);
            dgEmpleados.CurrentRow.Cells[0].Value = "";
        }

        

        

        
        private void dgEmpleados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                //string numEmpl = .ToString();
                //if (dgEmpleados.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value != null)
                ////MessageBox.Show();
                //{
                //    string empl_num =
                //        dgEmpleados.Rows[e.RowIndex - 1].Cells[0].Value.ToString().Replace(" ", "");
                //    OleDbConnection conAcc = new OleDbConnection(
                //    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath);
                //    try
                //    {
                //        if (empl_num == "")
                //        {
                //            //MessageBox.Show("Especifique un numero de empleado");
                //            throw new Exception("Especifique un numero de empleado");
                //            //return;
                //        }
                //        #region valida si ya esta el empleado en la lista
                //        if ((e.RowIndex - 1) > 0)
                //        {
                //            for (int c = 0; c < (e.RowIndex - 1); c++)
                //            {
                //                if (dgEmpleados.Rows[c].Cells[0].Value.ToString() == empl_num)
                //                {
                //                    throw new Exception("El empleado ya esta en la lista");
                //                    //MessageBox.Show("El empleado ya esta en la lista");
                //                    //dgEmpleados.CurrentRow.Cells[0].Value = null;
                //                    //dgEmpleados.CurrentRow.Cells[1].Value = null;
                //                    //return;
                //                }

                //            }
                //        }
                //        #endregion

                //        conAcc.Open();
                //        string sql = "select Nombre from empleados where empleado =" + empl_num;
                //        // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                //        OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                //        DataTable dt = new DataTable();
                //        da.Fill(dt);
                //        if (dt.Rows.Count > 0)
                //        {
                //            dgEmpleados.Rows[e.RowIndex - 1].Cells[1].Value = dt.Rows[0][0].ToString();

                //        }
                //        else
                //        {
                //            // dgEmpleados.Rows.Remove(dr);
                //            //MessageBox.Show("Empleado no Existe");
                //            throw new Exception("Empleado no Existe");
                //            //dgEmpleados.CurrentRow.Cells[0].Value = null;
                //            //dgEmpleados.CurrentRow.Cells[1].Value = null;
                //        }
                //        da.Dispose();
                //        dt.Dispose();

                //    }
                //    catch (Exception err)
                //    {
                //        MessageBox.Show("Error al validar el empleado: "+err.Message);
                //        dgEmpleados.CurrentRow.Cells[0].Value = null;
                //        dgEmpleados.CurrentRow.Cells[1].Value = null;
                //    }
                //    finally
                //    {
                //        if (conAcc.State == ConnectionState.Open)
                //            conAcc.Close();
                //        conAcc.Dispose();
                //    }
                //    dgEmpleados.Focus();
                //    try
                //    {
                //        dgEmpleados.CurrentCell = dgEmpleados[0, 1];
                //    }
                //    catch { }
                //}
                //#region cuenta empleados
                //int conteo = 0;
                //foreach (DataGridViewRow cRow in dgEmpleados.Rows)
                //{
                //    if (cRow.Cells[0].Value != null)
                //        conteo++;
                //}
                //txtBox_conteo.Text = conteo.ToString();
                //#endregion
            }
            
        }
        private void buscaEmpleado(string empl_num)
        {

        }

        private void altaV_Load(object sender, EventArgs e)
        {
            if (appPath == "Local")
                appPath = AppDomain.CurrentDomain.BaseDirectory;

          //  dgEmpleados.Rows.Add();
            MaskedTextBoxColumn maskColumn;
            DataGridViewTextBoxColumn dgvtbc;

            maskColumn = new MaskedTextBoxColumn();
            maskColumn.Name = "empezo";
            maskColumn.HeaderText = "Empezo";
            maskColumn.Mask = "00:00";
            maskColumn.Width = 50;
            this.dgVoucher.Columns.Add(maskColumn);

            maskColumn = new MaskedTextBoxColumn();
            maskColumn.Name = "termino";
            maskColumn.HeaderText = "Termino";
            maskColumn.Mask = "00:00";
            maskColumn.Width = 50;
            this.dgVoucher.Columns.Add(maskColumn);

            dgvtbc = new DataGridViewTextBoxColumn();
            dgvtbc.HeaderText = "Codigo de Operación";
            dgvtbc.Name = "codOp";
            dgvtbc.MaxInputLength = 8;
            dgvtbc.Width = 130;
            this.dgVoucher.Columns.Add(dgvtbc);

            maskColumn = new MaskedTextBoxColumn();
            maskColumn.Name = "prodTot";
            maskColumn.HeaderText = "Prod Total";
            maskColumn.Mask = "0000000000";
            maskColumn.Width = 70;
            this.dgVoucher.Columns.Add(maskColumn);

            dgvtbc = new DataGridViewTextBoxColumn();
            dgvtbc.HeaderText = "Horas";
            dgvtbc.Width = 50;
            dgvtbc.ReadOnly = true;
            this.dgVoucher.Columns.Add(dgvtbc);

            dgvtbc = new DataGridViewTextBoxColumn();
            dgvtbc.HeaderText = "Pzas/Hra";
            dgvtbc.Width = 60;
            dgvtbc.ReadOnly = true;
            this.dgVoucher.Columns.Add(dgvtbc);

            dgvtbc = new DataGridViewTextBoxColumn();
            dgvtbc.HeaderText = "Eficiencia";
            dgvtbc.Width = 60;
            dgvtbc.ReadOnly = true;
            this.dgVoucher.Columns.Add(dgvtbc);

            if (_fromDiscr != 0)
                cargaVoucher(_fromDiscr);
        }

       
       
        private void restaHoras(int row)
        {
            try
            {
                string empezo = "", termino = "";
                if (dgVoucher.Rows[row].Cells[0].Value != null)//celda empezo
                {
                    empezo = dgVoucher.Rows[row].Cells[0].Value.ToString().Replace(" ", "");
                    if (empezo.Length < 5)
                    {
                        MessageBox.Show("La hora debe tener al menos 4 caracteres", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgVoucher.Rows[row].Cells[0].Value = null;
                        return;
                    }
                }
                if (dgVoucher.Rows[row].Cells[1].Value != null)//celda termino
                {
                    termino = dgVoucher.Rows[row].Cells[1].Value.ToString().Replace(" ", "");
                    if (termino.Length < 5)
                    {
                        MessageBox.Show("La hora debe tener al menos 4 caracteres", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgVoucher.Rows[row].Cells[1].Value = null;
                        return;
                    }
                }
                if (empezo == "" || termino == "")
                {
                    dgVoucher.Rows[row].Cells[4].Value = "0.00";
                    gridCellNextFocus();
                }
                else
                {
                    //TimeSpanConverter tsc = new TimeSpanConverter();
                    //TimeSpan ts1 = (TimeSpan)tsc.ConvertFromString(dgVoucher.Rows[e.RowIndex - 1].Cells[0].Value.ToString());
                    //TimeSpan ts2 = (TimeSpan)tsc.ConvertFromString(dgVoucher.Rows[e.RowIndex - 1].Cells[1].Value.ToString());
                    string[] hr_inicio = dgVoucher.Rows[row].Cells[0].Value.ToString().Split(':');
                    string[] hr_termino = dgVoucher.Rows[row].Cells[1].Value.ToString().Split(':');
                    int hora1 = Convert.ToInt16(hr_inicio[0]), minuto1 = Convert.ToInt16(hr_inicio[1]);
                    int hora2 = Convert.ToInt16(hr_termino[0]), minuto2 = Convert.ToInt16(hr_termino[1]);
                    hora1 = hora1 * 60; hora2 = hora2 * 60;
                    if (minuto1 > 60 || minuto2 > 60)
                    {
                        MessageBox.Show("Los minutos son invalidos", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    hora1 += minuto1;
                    hora2 += minuto2;

                    int res = hora2 - hora1;
                    //TimeSpan res = ts2.Subtract(ts1);

                    if (res < 0)
                    {
                        MessageBox.Show("La hora de termino debe ser mayor a la de inicio", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int minutos_a_restar = 0;
                    if (tbTurno.Text != "")//resta descansos del turno
                    {
                        minutos_a_restar = restaDescansos(hora1, hora2);
                    }
                    res = res - minutos_a_restar;

                    //string hora = res.Hours.ToString();
                    //double doub_minutos = Math.Abs((double)res.Minutes / (double)60) * 100;
                    //minutos = (int)Math.Round(doub_minutos);
                    //dgVoucher.CurrentRow.Cells[4].Value = hora + "." + minutos.ToString();

                    double doub_minutos = Math.Abs((double)res / (double)60);
                    
                    //dgVoucher.Rows[row].Cells[4].Value = Math.Round(doub_minutos, 1).ToString("0.0");
                    dgVoucher.Rows[row].Cells[4].Value = doub_minutos;
                    //dgVoucher.Rows[0].Cells[2].Selected = true;
                    gridCellNextFocus();
                    //dgVoucher.CurrentRow.Cells[4].Value = minutos.ToString();
                }
            }
            catch (Exception err) { 
                MessageBox.Show("Error al estar restando las horas: "+err.Message);
            }
            

        }
        private void gridCellNextFocus()
        {
            try
            {                             
                
               //// dgVoucher.CurrentCell = dgVoucher[dgVoucher.CurrentCell.ColumnIndex , dgVoucher.CurrentRow.Index];
               // //SendKeys.Send("{Up}");
               // SendKeys.Send("{Tab}");
               // //dgVoucher.CurrentCell.Selected = true;
            }
            catch { }
        }
        private int restaDescansos(int _ts1,int _ts2)
        {
            int minutos_a_restar = 0;
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                
                conAcc.Open();
                string sql = "select entrada,salida from turnos_hija where turno_id =" + tbTurno.Text;
                // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TimeSpanConverter tsc = new TimeSpanConverter();
                TimeSpan ts1, ts2;
                for (int c = 0; c < dt.Rows.Count;c++ )
                {
                    //ts1 = (TimeSpan)tsc.ConvertFromString(dt.Rows[c][0].ToString());
                    //ts2 = (TimeSpan)tsc.ConvertFromString(dt.Rows[c][1].ToString());
                    string[] hr_inicio = dt.Rows[c][0].ToString().Split(':');
                    string[] hr_termino = dt.Rows[c][1].ToString().Split(':');
                    int hora1 = Convert.ToInt16(hr_inicio[0]), minuto1 = Convert.ToInt16(hr_inicio[1]);
                    int hora2 = Convert.ToInt16(hr_termino[0]), minuto2 = Convert.ToInt16(hr_termino[1]);
                    hora1 = hora1 * 60; hora2 = hora2 * 60;                   
                    hora1 += minuto1;
                    hora2 += minuto2;
                    if (_ts1 <= hora1 && _ts2 >= hora2)//si el descanso esta entre las horas capturadas
                        minutos_a_restar += hora2-hora1;
                    else if (_ts1 <= hora1 && (_ts2 >= hora1 && _ts2<=hora2))//si el descanso esta entre las horas capturadas
                        minutos_a_restar += _ts2-hora1;
                    else if ((_ts1 >= hora1 && _ts1 <= hora2)&&_ts2>=hora2)//si el descanso esta entre las horas capturadas
                        minutos_a_restar += hora2-_ts1;
                    //else if (_ts1 > hora1 && _ts2 < hora2)//si el descanso esta entre las horas capturadas
                    //    minutos_a_restar = 0;
                }
                da.Dispose();
                dt.Dispose();
                
            }
            catch (Exception err)
            {
                MessageBox.Show("Error en el turno: "+err.Message);
                tbTurno.Text = "";
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            return minutos_a_restar;
        }
        private Boolean  validaTurno()
        {
            Boolean ret = true;
            if (tbTurno.Text == "")
            {
                MessageBox.Show("Turno vacio");
                tbTurno.Text = "";
                return false; ;
            }
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                string sql = "select turno from turnos where turno =" + tbTurno.Text;
                // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    // dgEmpleados.Rows.Remove(dr);
                    MessageBox.Show("El turno no existe");
                    tbTurno.Text = "";
                    ret = false;
                }
                da.Dispose();
                dt.Dispose();

            }
            catch  (Exception err){ 
                MessageBox.Show("Error en el turno: "+err.Message);
                tbTurno.Text = "";
                ret = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            return ret;
        }

        private void tbTurno_Leave(object sender, EventArgs e)
        {
            if (validaTurno())
            {
                foreach (DataGridViewRow cRow in dgVoucher.Rows)
                {
                    if (cRow.Cells[0].Value != null &&  cRow.Cells[1].Value != null)
                        restaHoras(cRow.Index);
                }
                calculaEficiencia();
            }
        }

        private void dgEmpleados_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {            
            updateConteo();
        }
        private void updateConteo()
        {
            int conteo = 0;
            for (int c = 0; c < dgEmpleados.Rows.Count; c++)
            {
                if (dgEmpleados.Rows[c].Cells[0].Value != null &&
                        dgEmpleados.Rows[c].Cells[1].Value != null)
                    conteo++;
            }
            txtBox_conteo.Text = conteo.ToString();
        }
        private void dgVoucher_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > 0)
            //{
            #region valida la celda codigo de operacion
            if (dgVoucher.Columns[e.ColumnIndex].Name == "codOp" &&
                dgVoucher.CurrentRow.Cells[e.ColumnIndex].Value != null)
            {
                string cod_op =
                        dgVoucher.CurrentRow.Cells[e.ColumnIndex].Value.ToString();
                if (cod_op.Length < 7)
                {
                    MessageBox.Show("Codigo invalido");
                    dgVoucher.CurrentRow.Cells[2].Value = null;
                    return;
                }
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    conAcc.Open();
                    string centro_trabajo = "", linea = "", consecutivo = "0";
                    //int int_consecutivo = 0;
                    centro_trabajo = cod_op.Substring(0, 2);
                    cod_op = cod_op.Remove(0, 2);
                    consecutivo = cod_op.Substring(cod_op.Length - 4, 4);

                    validaIndirecto(consecutivo);//valida si es una hora indirectaq

                    cod_op = cod_op.Remove(cod_op.Length - 4, 4);
                    linea = cod_op;
                    //
                    cod_op = centro_trabajo + consecutivo;
                    string sql = "select standard,activo from codigosdeoperacion where activo = 1 and codigooperacion ='" +
                        cod_op + "'";
                    // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No existe codigo de operación");
                        dgVoucher.CurrentRow.Cells[2].Value = null;
                    }
                    else
                    {
                        if (dt.Rows[0][1].ToString() == "0")
                        {
                            MessageBox.Show("Codigo de operación restringido");
                            dgVoucher.CurrentRow.Cells[2].Value = null;
                        }
                        else
                        {
                            //valido que la linea sea valida para el centro de trab
                            sql = "select linea from lineas where centrotrabajo ='" +
                                centro_trabajo + "' and int(linea)=" + linea;
                            OleDbDataAdapter daLinea = new OleDbDataAdapter(sql, conAcc);
                            DataTable dtLinea = new DataTable();
                            daLinea.Fill(dtLinea);
                            if (dtLinea.Rows.Count == 0)
                            {
                                MessageBox.Show("La linea no existe para el centro de trabajo");
                                dgVoucher.CurrentRow.Cells[2].Value = null;
                            }
                            else
                            {
                                double stand = Convert.ToDouble(dt.Rows[0][0]);
                                dgVoucher.CurrentRow.Cells[5].Value = stand;//dt.Rows[0][0].ToString();
                            }
                            daLinea.Dispose();
                            dtLinea.Dispose();
                        }
                    }
                    
                    da.Dispose();
                    dt.Dispose();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error validando en codigo de operacion: "+err.Message);
                }
                finally
                {
                    conAcc.Close();
                    conAcc.Dispose();
                }
            }
            #endregion
            #region valida las celda empezo y termino
            if (dgVoucher.Columns[e.ColumnIndex].Name == "empezo" ||
                dgVoucher.Columns[e.ColumnIndex].Name == "termino")
            {
                restaHoras(dgVoucher.CurrentRow.Index);
            }
            #endregion
            //prodTot
            if (dgVoucher.Columns[e.ColumnIndex].Name == "prodTot")
            {

                //dgVoucher.Rows.Add();
                
            }
            //if (!indirecto)
                calculaEficiencia();
            //}
           
           
                
        }
        private void calculaEficiencia()
        {
            try
            {
                int qtyEmpleados = Convert.ToInt16(txtBox_conteo.Text);
                double pzas_por_hora = 0;
                if (dgVoucher.RowCount<2)//solo tendra 1 cuando el renglon no tenga datos
                    return;
                if (dgVoucher[5, dgVoucher.CurrentRow.Index]!=null)
                    pzas_por_hora = Convert.ToDouble(dgVoucher[5, dgVoucher.CurrentRow.Index].Value);
                double horasTrabajadas = 0;
                if (dgVoucher[4, dgVoucher.CurrentRow.Index] != null)
                    horasTrabajadas = Convert.ToDouble(dgVoucher[4, dgVoucher.CurrentRow.Index].Value);
                
                double horas_directas = qtyEmpleados * pzas_por_hora * horasTrabajadas;
                int prod_total = 0;
                if (dgVoucher[3, dgVoucher.CurrentRow.Index] != null)
                    prod_total = Convert.ToInt32(dgVoucher[3, dgVoucher.CurrentRow.Index].Value);
                string eficiencia = "0.00";
                if (horas_directas > 0&&(!indirecto))
                    eficiencia = Math.Abs((prod_total / horas_directas) * 100).ToString();//"0.00");
                dgVoucher[6, dgVoucher.CurrentRow.Index].Value = eficiencia;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error calculando la eficiencia: "+err.Message);
            }
        }

        private void txtBox_conteo_TextChanged(object sender, EventArgs e)
        {
            calculaEficiencia();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                if (abcVouchers(2))//borra
                    if (abcVouchers(1))//editando
                        editando = false;
            }
            else
                abcVouchers(0);//alta
        }
        private bool abcVouchers(int accionVoucher)
        {
            bool allOk = true;
            if (!valida())
            {
                MessageBox.Show("Datos Insuficientes");
                return false;
            }
            string sqlSearch, sqlAccion = "";

            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
               
                if (accionVoucher == 0)//es un nuevo voucher
                    indVoucher = 0;
                //{
                //    #region saca el id del voucher q acaba de insertar
                //    sqlSearch = "select max(novoucher) from indicevoucher";
                //    OleDbDataAdapter da = new OleDbDataAdapter(sqlSearch, conAcc);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    indVoucher = 0;
                //    if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")                    
                //        indVoucher = Convert.ToInt32(dt.Rows[0][0].ToString());
                //    indVoucher++;
                //    dt.Dispose();
                //    da.Dispose();
                //    #endregion
                //}
                string fecha = dateTimePicker1.Value.ToShortDateString();

                int colectivo = 0;
                int operadores = Convert.ToInt32(txtBox_conteo.Text);
                if (operadores > 1)
                    colectivo = 1;
                if (accionVoucher == 0 || (accionVoucher == 1))
                {
                    if (!validaTraslapeGrid())
                    {
                        MessageBox.Show("Hay un traslape de horas, revise");
                        return false;
                    }
                    string empl = "";
                    if (!validaTraslapeEmp(ref empl))
                    {
                        MessageBox.Show("Al empleado:[ "+empl+" ] ya se le capturo este horario en otro voucher");
                        return false;
                    }
                }

                #region afecta tabla indicevoucher
                if (accionVoucher == 0)//es un nuevo voucher
                {
                    sqlAccion = "insert into indicevoucher (fecha,turno,colectivo,operadores)values (#" +
                        fecha + "#," + tbTurno.Text + "," + colectivo + "," + operadores + ")";
                }
                else if (accionVoucher == 1)//editar voucher
                {
                    sqlAccion = "insert into indicevoucher (novoucher,fecha,turno,colectivo,operadores)"+
                        "values ("+indVoucher+",#" +
                       fecha + "#," + tbTurno.Text + "," + colectivo + "," + operadores + ")";
                }
                else if (accionVoucher == 2)//borrar voucher
                {
                    sqlAccion = "delete from indicevoucher where novoucher=" + indVoucher;
                }
                conAcc.Open();
                OleDbCommand comm = new OleDbCommand(sqlAccion, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
                #endregion
                if (accionVoucher == 0)//es un nuevo voucher
                {
                    #region saca el id del voucher q acaba de insertar
                    sqlSearch = "select max(novoucher) from indicevoucher";
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlSearch, conAcc);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    indVoucher = 0;
                    if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                        indVoucher = Convert.ToInt32(dt.Rows[0][0].ToString());
                    //indVoucher++;
                    dt.Dispose();
                    da.Dispose();
                    #endregion
                }
                #region afecta en tabla empvoucher
                string empleado = "", supervisor = "";
                OleDbCommand commEmp = new OleDbCommand();
                commEmp.Connection = conAcc;
                if (accionVoucher == 2)//borrar voucher
                {
                    sqlAccion = "delete from empvoucher where novoucher=" + indVoucher;
                    commEmp.CommandText = sqlAccion;
                    commEmp.ExecuteNonQuery();
                }
                else
                {
                    foreach (DataGridViewRow row in dgEmpleados.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            empleado = row.Cells[0].Value.ToString();

                            #region saca el supervisor del empleado
                            sqlSearch = "select supervisor from empleados where empleado =" + empleado;
                            OleDbDataAdapter da2 = new OleDbDataAdapter(sqlSearch, conAcc);
                            DataTable dt2 = new DataTable();
                            da2.Fill(dt2);
                            if (dt2.Rows.Count > 0 && dt2.Rows[0][0].ToString() != "")
                                supervisor = dt2.Rows[0][0].ToString();
                            dt2.Dispose();
                            da2.Dispose();
                            #endregion

                            sqlAccion = "insert into empvoucher values(" + indVoucher + "," + empleado + ",'" +
                                supervisor + "')";
                            commEmp.CommandText = sqlAccion;
                            commEmp.ExecuteNonQuery();

                        }
                    }
                }
                commEmp.Dispose();
                #endregion

                #region afecta en la tabla detVoucher
                string cod_op = "", centro_trabajo = "", consecutivo = "", departamento = "", empezo = "",
                    termino = "", horas = "0.00", eficiencia = "", linea = "", numeroDeOp = "", mtm = "";
                double produccion = 0, hearned = 0.00, standard = 0;
                int prodTotal = 0;
                OleDbCommand commVoucher = new OleDbCommand();
                commVoucher.Connection = conAcc;
                if (accionVoucher == 2)//borrar voucher
                {
                    sqlAccion = "delete from detvoucher where novoucher=" + indVoucher;
                    commVoucher.CommandText = sqlAccion;
                    commVoucher.ExecuteNonQuery();
                }
                else
                {
                    foreach (DataGridViewRow row in dgVoucher.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            departamento = ""; mtm = ""; numeroDeOp = "";
                            //empleado = row.Cells[0].Value.ToString();
                            #region saca el depto del cod de operacion
                            cod_op = row.Cells[2].Value.ToString();
                            centro_trabajo = cod_op.Substring(0, 2);
                            cod_op = cod_op.Remove(0, 2);
                            consecutivo = cod_op.Substring(cod_op.Length - 4, 4);
                            validaIndirecto(consecutivo);
                            cod_op = cod_op.Remove(cod_op.Length - 4, 4);
                            linea = cod_op.PadLeft(2, '0');
                            cod_op = centro_trabajo + consecutivo;
                            
                            sqlSearch = "select departamento,mtm,numerooperacion,hrs_ing from codigosdeoperacion where activo = 1 and codigooperacion ='" + cod_op + "'";
                            OleDbDataAdapter da2 = new OleDbDataAdapter(sqlSearch, conAcc);
                            DataTable dt2 = new DataTable();
                            da2.Fill(dt2);
                            double hrsIng = 0.0;
                            if (dt2.Rows.Count > 0)
                            {
                                departamento = dt2.Rows[0][0].ToString();
                                mtm = dt2.Rows[0][1].ToString();
                                numeroDeOp = dt2.Rows[0][2].ToString();
                                hrsIng = Convert.ToDouble(dt2.Rows[0][3].ToString());
                            }
                            dt2.Dispose();
                            da2.Dispose();
                            #endregion
                            #region sacando valores
                            empezo = row.Cells[0].Value.ToString();
                            termino = row.Cells[1].Value.ToString();
                            prodTotal = Convert.ToInt32(row.Cells[3].Value.ToString());
                            produccion = prodTotal / Convert.ToInt32(txtBox_conteo.Text);
                            
                            standard = Convert.ToDouble(row.Cells[5].Value.ToString());
                            eficiencia = row.Cells[6].Value.ToString();
                            //horas = "0.00";
                            hearned = 0.00;
                            double hearnIng = 0.0;
                            //hearned = produccion / standard;
                            horas = row.Cells[4].Value.ToString();
                            if (!indirecto)
                            {
                                hearned = produccion / standard;
                                if (hrsIng>0)
                                hearnIng = produccion / hrsIng;
                                //horas = row.Cells[4].Value.ToString();
                            }
                            #endregion                            
                            sqlAccion = "insert into detvoucher values(" + indVoucher + ",'" +
                                empezo + "','" +
                                termino + "'," +
                                horas + ",'" +
                                cod_op + "'," +
                                prodTotal + "," +
                                produccion + "," +
                                hearned + "," +
                                standard + "," +
                                eficiencia + ",'" +
                                departamento + "','" +
                                centro_trabajo + "','" +
                                linea + "','" +
                                numeroDeOp + "','" +
                                mtm + "',"+hearnIng+")";
                            commVoucher.CommandText = sqlAccion;
                            commVoucher.ExecuteNonQuery();
                        }
                    }
                }
                commVoucher.Dispose();
                #endregion

            }
            catch (Exception err)
            {
                MessageBox.Show("Error al intentar grabar el voucher: "+err.Message);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk && (accionVoucher == 0||accionVoucher == 1))
            {
                btnNew.Enabled = true;
                btnDel.Enabled = true;
                btnEdit.Enabled = true;
                btnSearch.Enabled = true;
                btnAdd.Enabled = false;
                dgVoucher.Enabled = false;
                dgEmpleados.Enabled = false;
            }
            #endregion
            return allOk;
        }
        private void validaIndirecto(string consecutivo)
        {
            int int_consecutivo = Convert.ToInt32(consecutivo);
            if (int_consecutivo >= 80 && int_consecutivo <= 96)
                indirecto = true;
            else
                indirecto = false;
        }
        private Boolean validaTraslapeGrid()
        {
            try
            {
                for (int x = 0; x < dgVoucher.Rows.Count - 1; x++)
                {
                    string[] hr_inicio = dgVoucher[0, x].Value.ToString().Split(':');
                    string[] hr_termino = dgVoucher[1, x].Value.ToString().Split(':');
                    int hora1_I = Convert.ToInt16(hr_inicio[0]), minuto1 = Convert.ToInt16(hr_inicio[1]);
                    int hora1_F = Convert.ToInt16(hr_termino[0]), minuto2 = Convert.ToInt16(hr_termino[1]);
                    hora1_I = hora1_I * 60; hora1_F = hora1_F * 60;
                    hora1_I += minuto1;
                    hora1_F += minuto2;
                    //bool ret = true;
                    //TimeSpan hora1_I = TimeSpan.Parse(dgVoucher[0, x].Value.ToString());
                    //TimeSpan hora1_F = TimeSpan.Parse(dgVoucher[1, x].Value.ToString());
                    for (int y = 0; y < dgVoucher.Rows.Count - 1; y++)
                    {
                        if (x != y)
                        {
                            string[] hr_inicio2 = dgVoucher[0, y].Value.ToString().Split(':');
                            string[] hr_termino2 = dgVoucher[1, y].Value.ToString().Split(':');
                            int hora2_I = Convert.ToInt16(hr_inicio2[0]), minuto2_1 = Convert.ToInt16(hr_inicio2[1]);
                            int hora2_F = Convert.ToInt16(hr_termino2[0]), minuto2_2 = Convert.ToInt16(hr_termino2[1]);
                            hora2_I = hora2_I * 60; hora2_F = hora2_F * 60;
                            hora2_I += minuto2_1;
                            hora2_F += minuto2_2;
                            if (hora1_I == hora2_I || hora1_F == hora2_F)
                                return false;
                            if ((hora1_I > hora2_I && hora1_I < hora2_F) || (hora1_F > hora2_I && hora1_F < hora2_F))
                                return false;
                        }
                    }

                }
            }
            catch  (Exception err)
            {
                MessageBox.Show("Error validando el traslape de horas: " + err.Message);
                return false;
            }

            return true;
        }
        private bool validaTraslapeEmp(ref string empl)
        {
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                conAcc.Open();
                foreach (DataGridViewRow row in dgEmpleados.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string empleado = row.Cells[0].Value.ToString();
                        string sqlidV = "";
                        if (indVoucher!=0)
                            sqlidV = " and c.novoucher <> " + indVoucher;
                        empl = empleado;
                        //quiery de las talbas empleado y detvoucerh sacando las horas..
                        string sqlSearch = "select a.empezo,a.termino from detvoucher a,empvoucher b,indicevoucher c where a.novoucher =b.novoucher " +
                            " and a.novoucher = c.novoucher and  b.empleado =" + empleado + " and c.fecha =#" +
                            dateTimePicker1.Value.ToShortDateString() + "# " + sqlidV;//and c.novoucher <> "+indVoucher;
                        OleDbDataAdapter da2 = new OleDbDataAdapter(sqlSearch, conAcc);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        //if (dt2.Rows.Count > 0)
                        //    supervisor = dt2.Rows[0][0].ToString();
                        for (int x = 0; x < dt2.Rows.Count; x++)
                        {
                            //bool ret = true;
                            //TimeSpan hora1_I = TimeSpan.Parse(dt2.Rows[0][0].ToString());
                            //TimeSpan hora1_F = TimeSpan.Parse(dt2.Rows[0][1].ToString());
                            string[] hr_inicio = dt2.Rows[x][0].ToString().Split(':');
                            string[] hr_termino = dt2.Rows[x][1].ToString().Split(':');
                            int hora1_I = Convert.ToInt16(hr_inicio[0]), minuto1 = Convert.ToInt16(hr_inicio[1]);
                            int hora1_F = Convert.ToInt16(hr_termino[0]), minuto2 = Convert.ToInt16(hr_termino[1]);
                            hora1_I = hora1_I * 60; hora1_F = hora1_F * 60;
                            hora1_I += minuto1;
                            hora1_F += minuto2;
                            for (int y = 0; y < dgVoucher.Rows.Count - 1; y++)
                            {
                                //if (x != y)
                                //{
                                //TimeSpan hora2_I = TimeSpan.Parse(dgVoucher[0, x].Value.ToString());
                                //TimeSpan hora2_F = TimeSpan.Parse(dgVoucher[1, x].Value.ToString());
                                string[] hr_inicio2 = dgVoucher[0, y].Value.ToString().Split(':');
                                string[] hr_termino2 = dgVoucher[1, y].Value.ToString().Split(':');
                                int hora2_I = Convert.ToInt16(hr_inicio2[0]), minuto2_1 = Convert.ToInt16(hr_inicio2[1]);
                                int hora2_F = Convert.ToInt16(hr_termino2[0]), minuto2_2 = Convert.ToInt16(hr_termino2[1]);
                                hora2_I = hora2_I * 60; hora2_F = hora2_F * 60;
                                hora2_I += minuto2_1;
                                hora2_F += minuto2_2;
                                if (hora1_I == hora2_I || hora1_F == hora2_F)
                                    return false;
                                if ((hora1_I > hora2_I && hora1_I < hora2_F) || (hora1_F > hora2_I && hora1_F < hora2_F))
                                    return false;
                                //}
                            }
                        }
                        dt2.Dispose();
                        da2.Dispose();
                    }
                }
            }
            catch (Exception err) { 
                MessageBox.Show("Error validando el traslape de horas: "+err.Message);
                return false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            return true;
        }
        private bool valida()
        {
            bool ret = true;
            bool vouchers = false;
            for (int x = 0; x < dgVoucher.RowCount - 1; x++)
            {
                if (dgVoucher[0, x].Value == null || dgVoucher[1, x].Value == null || dgVoucher[2, x].Value == null ||
                    dgVoucher[3, x].Value == null)
                    return false;
            }
            if (tbTurno.Text == "" || txtBox_conteo.Text == "0")
                return false;
            return true;
        }
        private void bntNew_Click(object sender, EventArgs e)
        {
            dgEmpleados.Enabled = true;
            dgVoucher.Enabled = true;
            btnAdd.Enabled = true;
            removidos = true;
            dgEmpleados.Rows.Clear();
            dgVoucher.Rows.Clear();
            txtBox_conteo.Text = "0";
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnSearch.Enabled = false;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //abcVouchers(1);
            dgEmpleados.Enabled = true;
            dgVoucher.Enabled = true;
            editando = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnSearch.Enabled = false;
            btnAdd.Enabled = true;
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Estas seguro de borrarlo","Precaución", MessageBoxButtons.OKCancel);
            if (ret == DialogResult.OK)
            {                
                abcVouchers(2);
                tbTurno.Text = "";
                dgEmpleados.Enabled = false;
                dgVoucher.Enabled = false;
                btnAdd.Enabled = false;
                removidos = true;
                dgEmpleados.Rows.Clear();
                dgVoucher.Rows.Clear();
                txtBox_conteo.Text = "0";
                btnNew.Enabled = true;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
                btnSearch.Enabled = true;
            }
        }

        private void nextRow()
        {
            
            //dgVoucher[0, 0].Selected = true;
            //dgVoucher.Focus();
            //dgVoucher.Rows.Add();
            //button1.PerformClick();
            //dgVoucher.CurrentCell = dgVoucher[0, 1];
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            dgVoucher.Focus();

            dgVoucher.CurrentCell = dgVoucher[0, 1];
        }

        private void dgVoucher_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void dgEmpleados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //MessageBox.Show();
            {
                string empl_num =
                    dgEmpleados.Rows[e.RowIndex].Cells[0].Value.ToString().Replace(" ", "");
                OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
                try
                {
                    if (empl_num == "")
                    {
                        //MessageBox.Show("Especifique un numero de empleado");
                        throw new Exception("Especifique un numero de empleado");
                        //return;
                    }
                    #region valida si ya esta el empleado en la lista
                    
                        for (int c = 0; c < e.RowIndex; c++)
                        {
                            if (dgEmpleados.Rows[c].Cells[0].Value.ToString() == empl_num)
                            {
                                throw new Exception("El empleado ya esta en la lista");
                                //MessageBox.Show("El empleado ya esta en la lista");
                                //dgEmpleados.CurrentRow.Cells[0].Value = null;
                                //dgEmpleados.CurrentRow.Cells[1].Value = null;
                                //return;
                            }

                        }
                    
                    #endregion

                    conAcc.Open();
                    string sql = "select Nombre from empleados where Status = 1 and empleado =" + empl_num;
                    // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgEmpleados.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0].ToString();

                    }
                    else
                    {
                        // dgEmpleados.Rows.Remove(dr);
                        //MessageBox.Show("Empleado no Existe");
                        throw new Exception("Empleado no Existe");
                        //dgEmpleados.CurrentRow.Cells[0].Value = null;
                        //dgEmpleados.CurrentRow.Cells[1].Value = null;
                    }
                    da.Dispose();
                    dt.Dispose();

                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al validar el empleado: " + err.Message);
                    dgEmpleados.CurrentRow.Cells[0].Value = null;
                    dgEmpleados.CurrentRow.Cells[1].Value = null;
                }
                finally
                {
                    if (conAcc.State == ConnectionState.Open)
                        conAcc.Close();
                    conAcc.Dispose();
                }
                dgEmpleados.Focus();
                try
                {
                    dgEmpleados.CurrentCell = dgEmpleados[0, 1];
                }
                catch { }
            }
            #region cuenta empleados
            int conteo = 0;
            foreach (DataGridViewRow cRow in dgEmpleados.Rows)
            {
                if (cRow.Cells[0].Value != null)
                    conteo++;
            }
            txtBox_conteo.Text = conteo.ToString();
            #endregion
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //frmS.dgResult.Rows.Clear();
            frmS.tbVoucher.Text = "";
            frmS.tbEmp.Text = "";
            frmS.tbCo.Text = "";
            
           // frmS.dgResult.AllowUserToDeleteRows = true;
           //// frmS.dgResult.Rows.Clear();
           // frmS.dgResult.AllowUserToDeleteRows = false;
            frmS.ShowDialog();
            if (frmS.noVoucher != 0)
            {

                cargaVoucher(frmS.noVoucher);
            }
        }
        private void cargaVoucher(int vId)
        {
            dgEmpleados.Rows.Clear();
            dgVoucher.Rows.Clear();
            tbTurno.Text = "";
            OleDbConnection conAcc = new OleDbConnection(capaDb.dbPath());
            try
            {
                indVoucher = vId;
                #region carga los empl
                string sqlEmpl = "select a.empleado,a.nombre from empleados a,empvoucher b where " +
                    "a.empleado = b.empleado and b.novoucher=" + indVoucher;
                conAcc.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(sqlEmpl, conAcc);
                DataTable dtEmpl = new DataTable();
                da.Fill(dtEmpl);
                int totEmpl = dtEmpl.Rows.Count;
                for (int c = 0; c < dtEmpl.Rows.Count; c++)
                {
                    //if (c > 0)
                    dgEmpleados.Rows.Add();
                    dgEmpleados[0, c].Value = dtEmpl.Rows[c][0].ToString();
                    dgEmpleados[1, c].Value = dtEmpl.Rows[c][1].ToString();
                }
                dtEmpl.Dispose();
                txtBox_conteo.Text = totEmpl.ToString();
                #endregion
                #region carga las horas
                string sqlHrs = "select a.empezo,a.termino,a.codigooperacion,a.prodtotal,a.horas," +
                    "a.standard,a.eficiencia,a.linea " +
                    " from detvoucher a where a.novoucher=" + indVoucher;
                da.SelectCommand.CommandText = sqlHrs;
                string co = "", linea = "";
                DataTable dtHrs = new DataTable();
                da.Fill(dtHrs);
                for (int c = 0; c < dtHrs.Rows.Count; c++)
                {
                    co = dtHrs.Rows[c][2].ToString();
                    linea = dtHrs.Rows[c][7].ToString();
                    co = co.Insert(2, linea);
                    //if (c > 0)
                    dgVoucher.Rows.Add();
                    dgVoucher[0, c].Value = dtHrs.Rows[c][0].ToString();
                    dgVoucher[1, c].Value = dtHrs.Rows[c][1].ToString();
                    //dgVoucher[2, c].Value = dtHrs.Rows[c][2].ToString();
                    dgVoucher[2, c].Value = co;
                    dgVoucher[3, c].Value = dtHrs.Rows[c][3].ToString();
                    dgVoucher[4, c].Value = dtHrs.Rows[c][4].ToString();
                    dgVoucher[5, c].Value = dtHrs.Rows[c][5].ToString();
                    dgVoucher[6, c].Value = dtHrs.Rows[c][6].ToString();

                }
                dtHrs.Dispose();
                #endregion
                #region carga fecha y turno
                string sqlIndV = "select fecha,turno from indicevoucher where novoucher=" + indVoucher;
                da.SelectCommand.CommandText = sqlIndV;

                DataTable dtIv = new DataTable();
                da.Fill(dtIv);
                for (int c = 0; c < dtIv.Rows.Count; c++)
                {
                    dateTimePicker1.Text = dtIv.Rows[c][0].ToString();
                    tbTurno.Text = dtIv.Rows[c][1].ToString();

                }
                dtIv.Dispose();
                #endregion
                da.Dispose();
                btnNew.Enabled = true;
                btnDel.Enabled = true;
                btnEdit.Enabled = true;
                btnSearch.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al cargar voucher: " + err.Message);
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
        
    }
}
