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
    public partial class altaV : Form
    {

        string appPath = ConfigurationSettings.AppSettings["PathBd"];
        bool indirecto = false,removidos = false;
        public altaV()
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

        private void dgEmpleados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > 0)
            //{
            //    //string numEmpl = .ToString();
            //    if (dgEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!= null)
            //        MessageBox.Show(dgEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //}
        }

        private void dgEmpleados_Enter(object sender, EventArgs e)
        {
            //if (e.RowIndex > 0)
            //{
            //    if (dgEmpleados.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value != null)
            //        MessageBox.Show(dgEmpleados.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString());
            //}
        }

        private void dgEmpleados_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgEmpleados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                //string numEmpl = .ToString();
                if (dgEmpleados.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value != null)
                //MessageBox.Show();
                {
                    string empl_num =
                        dgEmpleados.Rows[e.RowIndex - 1].Cells[0].Value.ToString().Replace(" ", "");
                    OleDbConnection conAcc = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + "Eficien.mdb");
                    try
                    {
                        if (empl_num == "")
                        {
                            //MessageBox.Show("Especifique un numero de empleado");
                            throw new Exception("Especifique un numero de empleado");
                            //return;
                        }
                        #region valida si ya esta el empleado en la lista
                        if ((e.RowIndex - 1) > 0)
                        {
                            for (int c = 0; c < (e.RowIndex - 1); c++)
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
                        }
                        #endregion

                        conAcc.Open();
                        string sql = "select Nombre from empleados where empleado =" + empl_num;
                        // OleDbCommand comm = new OleDbCommand(sql, conAcc);
                        OleDbDataAdapter da = new OleDbDataAdapter(sql, conAcc);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dgEmpleados.Rows[e.RowIndex - 1].Cells[1].Value = dt.Rows[0][0].ToString();

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
                        MessageBox.Show(err.Message);
                        dgEmpleados.CurrentRow.Cells[0].Value = null;
                        dgEmpleados.CurrentRow.Cells[1].Value = null;
                    }
                    finally
                    {
                        if (conAcc.State == ConnectionState.Open)
                            conAcc.Close();
                        conAcc.Dispose();
                    }

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
            maskColumn.HeaderText = "Prod Total";
            maskColumn.Mask = "00000";
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

            //dgVoucher.Rows.Add();
        }

       
        private void dgVoucher_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
           
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
                    dgVoucher.Rows[row].Cells[4].Value = Math.Round(doub_minutos, 2).ToString("0.00");
                    //dgVoucher.Rows[0].Cells[2].Selected = true;
                    gridCellNextFocus();
                    //dgVoucher.CurrentRow.Cells[4].Value = minutos.ToString();
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
            

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
            OleDbConnection conAcc = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + "Eficien.mdb");
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
                    else if (_ts1 < hora1 && (_ts2 >= hora1 && _ts2<hora2))//si el descanso esta entre las horas capturadas
                        minutos_a_restar += _ts2-hora1;
                    else if ((_ts1 >= hora1 && _ts1 < hora2)&&_ts2>hora2)//si el descanso esta entre las horas capturadas
                        minutos_a_restar += hora2-_ts1;
                    //else if (_ts1 > hora1 && _ts2 < hora2)//si el descanso esta entre las horas capturadas
                    //    minutos_a_restar = 0;
                }
                da.Dispose();
                dt.Dispose();
                
            }
            catch
            {
                MessageBox.Show("Error en el turno");
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
                MessageBox.Show("Error en el turno");
                tbTurno.Text = "";
                return false; ;
            }
            OleDbConnection conAcc = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + "Eficien.mdb");
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
            catch  { 
                MessageBox.Show("Error en el turno");
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
            if (!removidos)
            if (dgEmpleados.Rows[e.RowIndex].Cells[0] != null &&
                dgEmpleados.Rows[e.RowIndex].Cells[1] != null)
            {
                int conteo = Convert.ToInt16(txtBox_conteo.Text);
                conteo -= 1;
                txtBox_conteo.Text = conteo.ToString();
            }
            removidos = false;
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
                OleDbConnection conAcc = new OleDbConnection(
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + "Eficien.mdb");
                try
                {
                    conAcc.Open();
                    string centro_trabajo = "", linea = "", consecutivo = "";
                    int int_consecutivo = 0;
                    centro_trabajo = cod_op.Substring(0, 2);
                    cod_op = cod_op.Remove(0, 2);
                    consecutivo = cod_op.Substring(cod_op.Length - 4, 4);
                    int_consecutivo = Convert.ToInt32(consecutivo);
                    if (int_consecutivo >= 80 && int_consecutivo <= 97)
                        indirecto = true;
                    else
                        indirecto = false;

                    cod_op = cod_op.Remove(cod_op.Length - 4, 4);
                    linea = cod_op;
                    //valido que la linea sea valida para el centro de trab
                    string sql = "select linea from lineas where centrotrabajo ='" +
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
                        cod_op = centro_trabajo + consecutivo;
                        sql = "select standard from codigosdeoperacion where codigooperacion ='" +
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
                            dgVoucher.CurrentRow.Cells[5].Value = dt.Rows[0][0].ToString();
                        da.Dispose();
                        dt.Dispose();
                    }
                    daLinea.Dispose();
                    dtLinea.Dispose();
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
            #endregion
            #region valida las celda empezo y termino
            if (dgVoucher.Columns[e.ColumnIndex].Name == "empezo" ||
                dgVoucher.Columns[e.ColumnIndex].Name == "termino")
            {
                restaHoras(dgVoucher.CurrentRow.Index);
            }
            #endregion
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
                if (horas_directas > 0&&!indirecto)
                    eficiencia = Math.Abs((prod_total / horas_directas) * 100).ToString("0.00");
                dgVoucher[6, dgVoucher.CurrentRow.Index].Value = eficiencia;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtBox_conteo_TextChanged(object sender, EventArgs e)
        {
            calculaEficiencia();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool allOk = true;
            if (!valida())
            {
                MessageBox.Show("Datos Insuficientes");
                return;
            }
            string sqlSearch,sqlInsert = "";

            OleDbConnection conAcc = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + appPath + "Eficien.mdb");
            try
            {
                conAcc.Open();
                string fecha = dateTimePicker1.Value.ToShortDateString();

                int colectivo = 0;
                int operadores = Convert.ToInt32(txtBox_conteo.Text);
                if (operadores > 1)
                    colectivo = 1;

                #region inserta en tabla indicevoucher
                sqlInsert = "insert into indicevoucher (fecha,turno,colectivo,operadores)values (#" +
                    fecha + "#," + tbTurno.Text + "," + colectivo + "," + operadores + ")";
                OleDbCommand comm = new OleDbCommand(sqlInsert, conAcc);
                comm.ExecuteNonQuery();
                comm.Dispose();
                #endregion
                #region saca el id del voucher q acaba de insertar
                sqlSearch = "select max(novoucher) from indicevoucher";
                OleDbDataAdapter da = new OleDbDataAdapter(sqlSearch, conAcc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int indVoucher = 0;
                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                    indVoucher = Convert.ToInt32(dt.Rows[0][0].ToString());
                //indVoucher++;
                dt.Dispose();
                da.Dispose();
                #endregion

                #region inserta en tabla empvoucher
                string empleado = "",supervisor="";                
                OleDbCommand commEmp = new OleDbCommand();
                commEmp.Connection = conAcc;
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
                        sqlInsert = "insert into empvoucher values(" + indVoucher + "," + empleado + ",'" +
                            supervisor + "')";
                        commEmp.CommandText = sqlInsert;
                        commEmp.ExecuteNonQuery();
                    }
                }                
                commEmp.Dispose();
                #endregion

                #region inserta en la tabla detVoucher
                string cod_op = "", centro_trabajo = "", consecutivo = "", departamento = "",empezo="",
                    termino="",horas="",eficiencia="",linea="",numeroDeOp="",mtm="";
                double produccion = 0, hearned = 0.00, standard=0; 
                    int prodTotal=0;
                OleDbCommand commVoucher = new OleDbCommand();
                commVoucher.Connection = conAcc;
                foreach (DataGridViewRow row in dgVoucher.Rows)
                {
                    if (row.Cells[6].Value != null)
                    {
                        //empleado = row.Cells[0].Value.ToString();
                        #region saca el depto del cod de operacion
                        cod_op = row.Cells[2].Value.ToString();
                        centro_trabajo = cod_op.Substring(0, 2);
                        cod_op = cod_op.Remove(0, 2);
                        consecutivo = cod_op.Substring(cod_op.Length - 4, 4);
                        cod_op = cod_op.Remove(cod_op.Length - 4, 4);
                        linea = cod_op.PadLeft(2,'0');
                        cod_op = centro_trabajo + consecutivo;
                        sqlSearch = "select departamento,mtm,numerooperacion from codigosdeoperacion where codigooperacion ='" + cod_op+"'";
                        OleDbDataAdapter da2 = new OleDbDataAdapter(sqlSearch, conAcc);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            departamento = dt2.Rows[0][0].ToString();
                            mtm = dt2.Rows[0][1].ToString();
                            numeroDeOp = dt2.Rows[0][2].ToString();
                        }
                        dt2.Dispose();
                        da2.Dispose();
                        #endregion
                        #region sacando valores
                        empezo = row.Cells[0].Value.ToString();
                        termino = row.Cells[1].Value.ToString();
                        prodTotal = Convert.ToInt32(row.Cells[3].Value.ToString());
                        produccion = prodTotal / Convert.ToInt32(txtBox_conteo.Text);
                        horas = row.Cells[4].Value.ToString();
                        standard = Convert.ToDouble(row.Cells[5].Value.ToString());
                        eficiencia = row.Cells[6].Value.ToString();
                        if (!indirecto)
                        hearned=  produccion / standard;
                        #endregion
                        sqlInsert = "insert into detvoucher values(" + indVoucher + ",'" +
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
                            mtm + "')";
                        commVoucher.CommandText = sqlInsert;
                        commVoucher.ExecuteNonQuery();
                    }
                }
                commVoucher.Dispose();
                #endregion
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                allOk = false;
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            #region activa botones
            if (allOk)
            btnNew.Enabled = true;
            btnDel.Enabled = true;
            btnEdit.Enabled = true;
            btnSearch.Enabled = true;
            btnAdd.Enabled = false;
            dgVoucher.Enabled = false;
            dgEmpleados.Enabled = false;
            #endregion
        }
        private bool valida()
        {
            bool ret = false;
            bool vouchers = false;
            for (int x = 0; x < dgVoucher.RowCount - 1; x++)
            {
                if (dgVoucher[0,x].Value != null && dgVoucher[1,x].Value != null && dgVoucher[2,x].Value != null &&
                    dgVoucher[3,x].Value != null)
                    vouchers = true;
            }
            if (tbTurno.Text != "" && txtBox_conteo.Text != "0" && vouchers)
                ret = true;
            return ret;
        }
        private void bntNew_Click(object sender, EventArgs e)
        {
            dgEmpleados.Enabled = true;
            dgVoucher.Enabled = true;
            btnAdd.Enabled = true;
            btnNew.Enabled = false;
            removidos = true;
            dgEmpleados.Rows.Clear();
            txtBox_conteo.Text = "0";
        }       
    }
}
