﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportsApplication1
{
    public partial class rep2 : Form
    {
        public rep2()
        {
            InitializeComponent();
        }

        private void rep2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'EficienDataSet.CentrosTrabajos' table. You can move, or remove it, as needed.
            this.CentrosTrabajosTableAdapter.Fill(this.EficienDataSet.CentrosTrabajos);
            // TODO: This line of code loads data into the 'EficienDataSet.Empleados' table. You can move, or remove it, as needed.
            this.EmpleadosTableAdapter.Fill(this.EficienDataSet.Empleados);
            // TODO: This line of code loads data into the 'EficienDataSet.Departamentos' table. You can move, or remove it, as needed.
            this.DepartamentosTableAdapter.Fill(this.EficienDataSet.Departamentos);
            // TODO: This line of code loads data into the 'EficienDataSet.Supervisores' table. You can move, or remove it, as needed.
            this.SupervisoresTableAdapter.Fill(this.EficienDataSet.Supervisores);

            this.reportViewer1.RefreshReport();
        }
    }
}