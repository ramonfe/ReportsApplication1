using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

namespace ReportsApplication1
{
    public partial class frmMenu : Form
    {
        
        public frmMenu()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
           //this.Text = String.Format("Menu Principal. Version ",Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            KeyValueConfigurationElement kvce;
            Configuration config,config2;
            ConnectionStringSettings conStr;
            fileMap.ExeConfigFilename = fileMap.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + Application.ProductName+".exe.config";
            config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None) as Configuration;
            
            //Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            kvce = config.AppSettings.Settings["PathBd"];
            
            
            
            
            if (ConfigurationManager.AppSettings["PathBd"] == "NEW")
            {
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    kvce.Value = openFileDialog1.FileName;
                    config.Save(ConfigurationSaveMode.Minimal, true);
                    ConfigurationManager.RefreshSection("appSettings");

                    config2 = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None) as Configuration;
                    conStr = config2.ConnectionStrings.ConnectionStrings["ReportsApplication1.Properties.Settings.EficienConnectionString"];
                    conStr.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:Database Password=l3v1t0np@$$s1mg@p;Data Source=" + openFileDialog1.FileName;
                    config2.Save();
                    
                    ConfigurationManager.RefreshSection("connectionStrings");
                }
                else
                {
                    MessageBox.Show("No puede iniciar sin seleccionar una Base de datos", "Error!!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();

                }
            }
            stTrip.Items[0].Text = DateTime.Now.ToShortDateString();
            stTrip.Items[1].Text = DateTime.Now.ToShortTimeString();
            frmLogin frmLog = new frmLogin();
            frmLog.ShowDialog();
            if (!frmLog.result)
            {
                frmLog.Dispose();
                this.Close();
                return;
            }
            
            btnMi.Enabled = Convert.ToBoolean(Convert.ToInt16(frmLog.moding));
            btnPriv.Enabled = Convert.ToBoolean(Convert.ToInt16(frmLog.privilegios));
            btnConTress.Enabled = Convert.ToBoolean(Convert.ToInt16(frmLog.reportes));
            btnV.Enabled = Convert.ToBoolean(Convert.ToInt16(frmLog.captura));
            btnEmp.Enabled = Convert.ToBoolean(Convert.ToInt16(frmLog.emp));
            frmLog.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stTrip.Items[1].Text = DateTime.Now.ToShortTimeString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmVoucher frmVoucher = new frmVoucher();
            frmVoucher.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu2 frmRep = new frmMenu2();
            frmRep.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            frmModIng fmi = new frmModIng();
            fmi.ShowDialog();
            fmi.Dispose();
            
        }

        private void btnPriv_Click(object sender, EventArgs e)
        {
            frmPriv fmi = new frmPriv();
            fmi.ShowDialog();
            fmi.Dispose();
        }

        private void btnConTress_Click(object sender, EventArgs e)
        {
            frmConcTress frmCt = new frmConcTress();
            this.Hide();
            frmCt.RepType = 1;
            frmCt.ShowDialog();
            frmCt.Dispose();
            this.Show();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            frmConcTress frmCt = new frmConcTress();
            this.Hide();
            frmCt.RepType = 2;
            frmCt.ShowDialog();
            frmCt.Dispose();
            this.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmA = new frmAbout();
            frmA.ShowDialog();
            frmA.Dispose();
        }
    }
}
