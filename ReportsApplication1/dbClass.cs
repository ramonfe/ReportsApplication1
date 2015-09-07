using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;

namespace ReportsApplication1
{
    class dbClass
    {
        public dbClass()
        {
        }
        public OleDbDataAdapter selectDa(string sql)
        {
           
            // lb.Items.Clear();

            OleDbConnection conAcc = new OleDbConnection(dbPath());
            OleDbDataAdapter da = null;
            try
            {
                conAcc.Open();
                //string sql = "select * from permisos where userid = '" + txtLogin.Text + "'";
                //OleDbCommand comm = new OleDbCommand(sql, conAcc);
                da = new OleDbDataAdapter(sql, conAcc);
                
            }
            catch
            {
            }
            finally
            {
                conAcc.Close();
                conAcc.Dispose();
            }
            return da;
        }
        public string dbPath ()
        {
             string appPath = ConfigurationSettings.AppSettings["PathBd"];
            string path="Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=l3v1t0np@$$s1mg@p;Data Source=" +
                    appPath;
            return path;
        }
    }
}
