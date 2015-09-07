namespace ReportsApplication1
{
    partial class frmModIng
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModIng));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Departamentos");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Centros de Trabajo");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Lineas");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Codigos de Operacion");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Fbus");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Supervisores");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Coordinadores");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Relacion Sup-Coord");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Numeros de Parte");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Turnos");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Codigos Ind a Deptos");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Relacion Emp-Coord");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Procesos");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Salir");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Opciones", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDeptos = new System.Windows.Forms.TabPage();
            this.dOverHead = new System.Windows.Forms.MaskedTextBox();
            this.ohDec = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_dEdit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btn_dNew = new System.Windows.Forms.Button();
            this.dFbu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btn_dAdd = new System.Windows.Forms.Button();
            this.dNumDepto = new System.Windows.Forms.MaskedTextBox();
            this.btn_dSearch = new System.Windows.Forms.Button();
            this.dDepto = new System.Windows.Forms.TextBox();
            this.btn_dDel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCt = new System.Windows.Forms.TabPage();
            this.ctDepto = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_ctEdit = new System.Windows.Forms.Button();
            this.btn_ctNew = new System.Windows.Forms.Button();
            this.ctFbu = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_ctAdd = new System.Windows.Forms.Button();
            this.ct = new System.Windows.Forms.MaskedTextBox();
            this.btn_ctSearch = new System.Windows.Forms.Button();
            this.ctDesc = new System.Windows.Forms.TextBox();
            this.btn_ctDel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabLine = new System.Windows.Forms.TabPage();
            this.lblLineId = new System.Windows.Forms.Label();
            this.linea = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_lEdit = new System.Windows.Forms.Button();
            this.btn_lNew = new System.Windows.Forms.Button();
            this.btn_lAdd = new System.Windows.Forms.Button();
            this.btn_lSearch = new System.Windows.Forms.Button();
            this.btn_lDel = new System.Windows.Forms.Button();
            this.lCt = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lDesc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lDepto = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lFbu = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabFbu = new System.Windows.Forms.TabPage();
            this.btn_fEdit = new System.Windows.Forms.Button();
            this.btn_fNew = new System.Windows.Forms.Button();
            this.btn_fAdd = new System.Windows.Forms.Button();
            this.btn_fSearch = new System.Windows.Forms.Button();
            this.btn_fDel = new System.Windows.Forms.Button();
            this.fId = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.fDesc = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabSc = new System.Windows.Forms.TabPage();
            this.scId = new System.Windows.Forms.MaskedTextBox();
            this.btn_scEdit = new System.Windows.Forms.Button();
            this.btn_scNew = new System.Windows.Forms.Button();
            this.btn_scAdd = new System.Windows.Forms.Button();
            this.btn_scSearch = new System.Windows.Forms.Button();
            this.btn_scDel = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.scNom = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabRelsc = new System.Windows.Forms.TabPage();
            this.lblErr = new System.Windows.Forms.Label();
            this.chkListCoord = new System.Windows.Forms.CheckedListBox();
            this.cmbSup = new System.Windows.Forms.ComboBox();
            this.bnSave = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tabTurnos = new System.Windows.Forms.TabPage();
            this.tHrs = new System.Windows.Forms.TextBox();
            this.td3_2 = new System.Windows.Forms.MaskedTextBox();
            this.td3_1 = new System.Windows.Forms.MaskedTextBox();
            this.td2_1 = new System.Windows.Forms.MaskedTextBox();
            this.td2_2 = new System.Windows.Forms.MaskedTextBox();
            this.td1_2 = new System.Windows.Forms.MaskedTextBox();
            this.td1_1 = new System.Windows.Forms.MaskedTextBox();
            this.tSal = new System.Windows.Forms.MaskedTextBox();
            this.tEnt = new System.Windows.Forms.MaskedTextBox();
            this.tId = new System.Windows.Forms.MaskedTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btn_tEdit = new System.Windows.Forms.Button();
            this.btn_tNew = new System.Windows.Forms.Button();
            this.btn_tAdd = new System.Windows.Forms.Button();
            this.btn_tSearch = new System.Windows.Forms.Button();
            this.btn_tDel = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabNoParte = new System.Windows.Forms.TabPage();
            this.sec = new System.Windows.Forms.MaskedTextBox();
            this.np = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btn_npEdit = new System.Windows.Forms.Button();
            this.btn_npNew = new System.Windows.Forms.Button();
            this.btn_npAdd = new System.Windows.Forms.Button();
            this.btn_npSearch = new System.Windows.Forms.Button();
            this.btn_npDel = new System.Windows.Forms.Button();
            this.cmbCodOp = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.codOra = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tabNciD = new System.Windows.Forms.TabPage();
            this.btn_ciEdit = new System.Windows.Forms.Button();
            this.btn_ciNew = new System.Windows.Forms.Button();
            this.btn_ciAdd = new System.Windows.Forms.Button();
            this.btn_ciSearch = new System.Windows.Forms.Button();
            this.btn_ciDel = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtCi = new System.Windows.Forms.TextBox();
            this.tabEmpCoord = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label41 = new System.Windows.Forms.Label();
            this.lstBoxEmpl = new System.Windows.Forms.ListBox();
            this.lblerr4 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.btnEmS = new System.Windows.Forms.Button();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cmbEmpSup = new System.Windows.Forms.ComboBox();
            this.btnEmpSave = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabProc = new System.Windows.Forms.TabPage();
            this.btn_pEdit = new System.Windows.Forms.Button();
            this.btn_pNew = new System.Windows.Forms.Button();
            this.btn_pAdd = new System.Windows.Forms.Button();
            this.btn_pSearch = new System.Windows.Forms.Button();
            this.btn_pDel = new System.Windows.Forms.Button();
            this.txtProc = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabDeptos.SuspendLayout();
            this.tabCt.SuspendLayout();
            this.tabLine.SuspendLayout();
            this.tabFbu.SuspendLayout();
            this.tabSc.SuspendLayout();
            this.tabRelsc.SuspendLayout();
            this.tabTurnos.SuspendLayout();
            this.tabNoParte.SuspendLayout();
            this.tabNciD.SuspendLayout();
            this.tabEmpCoord.SuspendLayout();
            this.tabProc.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(684, 227);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDeptos);
            this.tabControl.Controls.Add(this.tabCt);
            this.tabControl.Controls.Add(this.tabLine);
            this.tabControl.Controls.Add(this.tabFbu);
            this.tabControl.Controls.Add(this.tabSc);
            this.tabControl.Controls.Add(this.tabRelsc);
            this.tabControl.Controls.Add(this.tabTurnos);
            this.tabControl.Controls.Add(this.tabNoParte);
            this.tabControl.Controls.Add(this.tabNciD);
            this.tabControl.Controls.Add(this.tabEmpCoord);
            this.tabControl.Controls.Add(this.tabProc);
            this.tabControl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(209, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(533, 295);
            this.tabControl.TabIndex = 11;
            this.tabControl.Visible = false;
            // 
            // tabDeptos
            // 
            this.tabDeptos.Controls.Add(this.dOverHead);
            this.tabDeptos.Controls.Add(this.ohDec);
            this.tabDeptos.Controls.Add(this.label5);
            this.tabDeptos.Controls.Add(this.btn_dEdit);
            this.tabDeptos.Controls.Add(this.label4);
            this.tabDeptos.Controls.Add(this.btn_dNew);
            this.tabDeptos.Controls.Add(this.dFbu);
            this.tabDeptos.Controls.Add(this.label3);
            this.tabDeptos.Controls.Add(this.btnExit);
            this.tabDeptos.Controls.Add(this.btn_dAdd);
            this.tabDeptos.Controls.Add(this.dNumDepto);
            this.tabDeptos.Controls.Add(this.btn_dSearch);
            this.tabDeptos.Controls.Add(this.dDepto);
            this.tabDeptos.Controls.Add(this.btn_dDel);
            this.tabDeptos.Controls.Add(this.label2);
            this.tabDeptos.Controls.Add(this.label1);
            this.tabDeptos.Font = new System.Drawing.Font("Verdana", 10F);
            this.tabDeptos.Location = new System.Drawing.Point(4, 23);
            this.tabDeptos.Name = "tabDeptos";
            this.tabDeptos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeptos.Size = new System.Drawing.Size(525, 268);
            this.tabDeptos.TabIndex = 0;
            this.tabDeptos.Text = "Departamentos";
            this.tabDeptos.UseVisualStyleBackColor = true;
            // 
            // dOverHead
            // 
            this.dOverHead.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dOverHead.Location = new System.Drawing.Point(148, 108);
            this.dOverHead.Mask = "00000000";
            this.dOverHead.Name = "dOverHead";
            this.dOverHead.Size = new System.Drawing.Size(72, 24);
            this.dOverHead.TabIndex = 3;
            this.dOverHead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dOverHead_KeyPress);
            // 
            // ohDec
            // 
            this.ohDec.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ohDec.Location = new System.Drawing.Point(227, 108);
            this.ohDec.Mask = "000";
            this.ohDec.Name = "ohDec";
            this.ohDec.Size = new System.Drawing.Size(33, 24);
            this.ohDec.TabIndex = 4;
            this.ohDec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ohDec_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(217, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 17);
            this.label5.TabIndex = 132;
            this.label5.Text = ".";
            // 
            // btn_dEdit
            // 
            this.btn_dEdit.Enabled = false;
            this.btn_dEdit.ImageIndex = 6;
            this.btn_dEdit.ImageList = this.imageList1;
            this.btn_dEdit.Location = new System.Drawing.Point(230, 158);
            this.btn_dEdit.Name = "btn_dEdit";
            this.btn_dEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_dEdit.TabIndex = 130;
            this.btn_dEdit.UseVisualStyleBackColor = true;
            this.btn_dEdit.Click += new System.EventHandler(this.btn_dEdit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GRABAR_.ICO");
            this.imageList1.Images.SetKeyName(1, "salir_.ico");
            this.imageList1.Images.SetKeyName(2, "delete.png");
            this.imageList1.Images.SetKeyName(3, "search.png");
            this.imageList1.Images.SetKeyName(4, "FloppyDisk.ico");
            this.imageList1.Images.SetKeyName(5, "NEW.BMP");
            this.imageList1.Images.SetKeyName(6, "NOTE16.ICO");
            this.imageList1.Images.SetKeyName(7, "NEW.BMP");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "OverHead:";
            // 
            // btn_dNew
            // 
            this.btn_dNew.AutoSize = true;
            this.btn_dNew.ImageIndex = 7;
            this.btn_dNew.ImageList = this.imageList1;
            this.btn_dNew.Location = new System.Drawing.Point(174, 158);
            this.btn_dNew.Name = "btn_dNew";
            this.btn_dNew.Size = new System.Drawing.Size(28, 32);
            this.btn_dNew.TabIndex = 125;
            this.btn_dNew.UseVisualStyleBackColor = true;
            this.btn_dNew.Click += new System.EventHandler(this.btn_dNew_Click);
            // 
            // dFbu
            // 
            this.dFbu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.dFbu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dFbu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dFbu.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFbu.FormattingEnabled = true;
            this.dFbu.Location = new System.Drawing.Point(148, 19);
            this.dFbu.Name = "dFbu";
            this.dFbu.Size = new System.Drawing.Size(280, 24);
            this.dFbu.TabIndex = 0;
            this.dFbu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dFbu_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fbu:";
            // 
            // btnExit
            // 
            this.btnExit.ImageIndex = 1;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(331, 126);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(28, 32);
            this.btnExit.TabIndex = 129;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            // 
            // btn_dAdd
            // 
            this.btn_dAdd.Enabled = false;
            this.btn_dAdd.ImageIndex = 0;
            this.btn_dAdd.ImageList = this.imageList1;
            this.btn_dAdd.Location = new System.Drawing.Point(258, 158);
            this.btn_dAdd.Name = "btn_dAdd";
            this.btn_dAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_dAdd.TabIndex = 5;
            this.btn_dAdd.UseVisualStyleBackColor = true;
            this.btn_dAdd.Click += new System.EventHandler(this.btn_dAdd_Click);
            // 
            // dNumDepto
            // 
            this.dNumDepto.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dNumDepto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dNumDepto.HidePromptOnLeave = true;
            this.dNumDepto.Location = new System.Drawing.Point(148, 49);
            this.dNumDepto.Mask = "0000";
            this.dNumDepto.Name = "dNumDepto";
            this.dNumDepto.Size = new System.Drawing.Size(48, 24);
            this.dNumDepto.TabIndex = 1;
            this.dNumDepto.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dNumDepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dNumDepto_KeyPress);
            // 
            // btn_dSearch
            // 
            this.btn_dSearch.ImageIndex = 3;
            this.btn_dSearch.ImageList = this.imageList1;
            this.btn_dSearch.Location = new System.Drawing.Point(286, 158);
            this.btn_dSearch.Name = "btn_dSearch";
            this.btn_dSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_dSearch.TabIndex = 128;
            this.btn_dSearch.UseVisualStyleBackColor = true;
            this.btn_dSearch.Click += new System.EventHandler(this.btn_dSearch_Click);
            // 
            // dDepto
            // 
            this.dDepto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dDepto.Location = new System.Drawing.Point(148, 78);
            this.dDepto.MaxLength = 50;
            this.dDepto.Name = "dDepto";
            this.dDepto.Size = new System.Drawing.Size(280, 24);
            this.dDepto.TabIndex = 2;
            this.dDepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dDepto_KeyPress);
            // 
            // btn_dDel
            // 
            this.btn_dDel.Enabled = false;
            this.btn_dDel.ImageIndex = 2;
            this.btn_dDel.ImageList = this.imageList1;
            this.btn_dDel.Location = new System.Drawing.Point(202, 158);
            this.btn_dDel.Name = "btn_dDel";
            this.btn_dDel.Size = new System.Drawing.Size(28, 32);
            this.btn_dDel.TabIndex = 127;
            this.btn_dDel.UseVisualStyleBackColor = true;
            this.btn_dDel.Click += new System.EventHandler(this.btn_dDel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Departamento:";
            // 
            // tabCt
            // 
            this.tabCt.Controls.Add(this.ctDepto);
            this.tabCt.Controls.Add(this.label9);
            this.tabCt.Controls.Add(this.btn_ctEdit);
            this.tabCt.Controls.Add(this.btn_ctNew);
            this.tabCt.Controls.Add(this.ctFbu);
            this.tabCt.Controls.Add(this.label6);
            this.tabCt.Controls.Add(this.btn_ctAdd);
            this.tabCt.Controls.Add(this.ct);
            this.tabCt.Controls.Add(this.btn_ctSearch);
            this.tabCt.Controls.Add(this.ctDesc);
            this.tabCt.Controls.Add(this.btn_ctDel);
            this.tabCt.Controls.Add(this.label7);
            this.tabCt.Controls.Add(this.label8);
            this.tabCt.Location = new System.Drawing.Point(4, 23);
            this.tabCt.Name = "tabCt";
            this.tabCt.Padding = new System.Windows.Forms.Padding(3);
            this.tabCt.Size = new System.Drawing.Size(525, 244);
            this.tabCt.TabIndex = 1;
            this.tabCt.Text = "Centros de Trabajo";
            this.tabCt.UseVisualStyleBackColor = true;
            // 
            // ctDepto
            // 
            this.ctDepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ctDepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ctDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctDepto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctDepto.FormattingEnabled = true;
            this.ctDepto.Location = new System.Drawing.Point(161, 44);
            this.ctDepto.Name = "ctDepto";
            this.ctDepto.Size = new System.Drawing.Size(358, 24);
            this.ctDepto.TabIndex = 1;
            this.ctDepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctDepto_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(48, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 17);
            this.label9.TabIndex = 143;
            this.label9.Text = "Departamento:";
            // 
            // btn_ctEdit
            // 
            this.btn_ctEdit.Enabled = false;
            this.btn_ctEdit.ImageIndex = 6;
            this.btn_ctEdit.ImageList = this.imageList1;
            this.btn_ctEdit.Location = new System.Drawing.Point(242, 152);
            this.btn_ctEdit.Name = "btn_ctEdit";
            this.btn_ctEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_ctEdit.TabIndex = 141;
            this.btn_ctEdit.UseVisualStyleBackColor = true;
            this.btn_ctEdit.Click += new System.EventHandler(this.btn_ctEdit_Click);
            // 
            // btn_ctNew
            // 
            this.btn_ctNew.AutoSize = true;
            this.btn_ctNew.ImageIndex = 7;
            this.btn_ctNew.ImageList = this.imageList1;
            this.btn_ctNew.Location = new System.Drawing.Point(186, 152);
            this.btn_ctNew.Name = "btn_ctNew";
            this.btn_ctNew.Size = new System.Drawing.Size(28, 32);
            this.btn_ctNew.TabIndex = 138;
            this.btn_ctNew.UseVisualStyleBackColor = true;
            this.btn_ctNew.Click += new System.EventHandler(this.btn_ctNew_Click);
            // 
            // ctFbu
            // 
            this.ctFbu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ctFbu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ctFbu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctFbu.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctFbu.FormattingEnabled = true;
            this.ctFbu.Location = new System.Drawing.Point(160, 13);
            this.ctFbu.Name = "ctFbu";
            this.ctFbu.Size = new System.Drawing.Size(280, 24);
            this.ctFbu.TabIndex = 0;
            this.ctFbu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctFbu_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(123, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 137;
            this.label6.Text = "Fbu:";
            // 
            // btn_ctAdd
            // 
            this.btn_ctAdd.Enabled = false;
            this.btn_ctAdd.ImageIndex = 0;
            this.btn_ctAdd.ImageList = this.imageList1;
            this.btn_ctAdd.Location = new System.Drawing.Point(270, 152);
            this.btn_ctAdd.Name = "btn_ctAdd";
            this.btn_ctAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_ctAdd.TabIndex = 4;
            this.btn_ctAdd.UseVisualStyleBackColor = true;
            this.btn_ctAdd.Click += new System.EventHandler(this.btn_ctAdd_Click);
            // 
            // ct
            // 
            this.ct.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ct.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ct.HidePromptOnLeave = true;
            this.ct.Location = new System.Drawing.Point(160, 73);
            this.ct.Mask = "0000";
            this.ct.Name = "ct";
            this.ct.Size = new System.Drawing.Size(48, 24);
            this.ct.TabIndex = 2;
            this.ct.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ct_KeyPress);
            // 
            // btn_ctSearch
            // 
            this.btn_ctSearch.ImageIndex = 3;
            this.btn_ctSearch.ImageList = this.imageList1;
            this.btn_ctSearch.Location = new System.Drawing.Point(298, 152);
            this.btn_ctSearch.Name = "btn_ctSearch";
            this.btn_ctSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_ctSearch.TabIndex = 140;
            this.btn_ctSearch.UseVisualStyleBackColor = true;
            this.btn_ctSearch.Click += new System.EventHandler(this.btn_ctSearch_Click);
            // 
            // ctDesc
            // 
            this.ctDesc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctDesc.Location = new System.Drawing.Point(160, 102);
            this.ctDesc.MaxLength = 50;
            this.ctDesc.Name = "ctDesc";
            this.ctDesc.Size = new System.Drawing.Size(280, 24);
            this.ctDesc.TabIndex = 3;
            this.ctDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ctDesc_KeyPress);
            // 
            // btn_ctDel
            // 
            this.btn_ctDel.Enabled = false;
            this.btn_ctDel.ImageIndex = 2;
            this.btn_ctDel.ImageList = this.imageList1;
            this.btn_ctDel.Location = new System.Drawing.Point(214, 152);
            this.btn_ctDel.Name = "btn_ctDel";
            this.btn_ctDel.Size = new System.Drawing.Size(28, 32);
            this.btn_ctDel.TabIndex = 139;
            this.btn_ctDel.UseVisualStyleBackColor = true;
            this.btn_ctDel.Click += new System.EventHandler(this.btn_ctDel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(69, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 134;
            this.label7.Text = "Descripcion:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 17);
            this.label8.TabIndex = 132;
            this.label8.Text = "Centro de Trabajo:";
            // 
            // tabLine
            // 
            this.tabLine.Controls.Add(this.lblLineId);
            this.tabLine.Controls.Add(this.linea);
            this.tabLine.Controls.Add(this.label14);
            this.tabLine.Controls.Add(this.btn_lEdit);
            this.tabLine.Controls.Add(this.btn_lNew);
            this.tabLine.Controls.Add(this.btn_lAdd);
            this.tabLine.Controls.Add(this.btn_lSearch);
            this.tabLine.Controls.Add(this.btn_lDel);
            this.tabLine.Controls.Add(this.lCt);
            this.tabLine.Controls.Add(this.label13);
            this.tabLine.Controls.Add(this.lDesc);
            this.tabLine.Controls.Add(this.label12);
            this.tabLine.Controls.Add(this.lDepto);
            this.tabLine.Controls.Add(this.label10);
            this.tabLine.Controls.Add(this.lFbu);
            this.tabLine.Controls.Add(this.label11);
            this.tabLine.Location = new System.Drawing.Point(4, 23);
            this.tabLine.Name = "tabLine";
            this.tabLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabLine.Size = new System.Drawing.Size(525, 244);
            this.tabLine.TabIndex = 2;
            this.tabLine.Text = "Lineas";
            this.tabLine.UseVisualStyleBackColor = true;
            // 
            // lblLineId
            // 
            this.lblLineId.AutoSize = true;
            this.lblLineId.Location = new System.Drawing.Point(415, 173);
            this.lblLineId.Name = "lblLineId";
            this.lblLineId.Size = new System.Drawing.Size(0, 14);
            this.lblLineId.TabIndex = 159;
            this.lblLineId.Visible = false;
            // 
            // linea
            // 
            this.linea.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linea.Location = new System.Drawing.Point(150, 106);
            this.linea.MaxLength = 2;
            this.linea.Name = "linea";
            this.linea.Size = new System.Drawing.Size(44, 24);
            this.linea.TabIndex = 3;
            this.linea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.linea_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(99, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 17);
            this.label14.TabIndex = 158;
            this.label14.Text = "Linea:";
            // 
            // btn_lEdit
            // 
            this.btn_lEdit.Enabled = false;
            this.btn_lEdit.ImageIndex = 6;
            this.btn_lEdit.ImageList = this.imageList1;
            this.btn_lEdit.Location = new System.Drawing.Point(263, 173);
            this.btn_lEdit.Name = "btn_lEdit";
            this.btn_lEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_lEdit.TabIndex = 156;
            this.btn_lEdit.UseVisualStyleBackColor = true;
            this.btn_lEdit.Click += new System.EventHandler(this.btn_lEdit_Click);
            // 
            // btn_lNew
            // 
            this.btn_lNew.AutoSize = true;
            this.btn_lNew.ImageIndex = 7;
            this.btn_lNew.ImageList = this.imageList1;
            this.btn_lNew.Location = new System.Drawing.Point(207, 173);
            this.btn_lNew.Name = "btn_lNew";
            this.btn_lNew.Size = new System.Drawing.Size(28, 32);
            this.btn_lNew.TabIndex = 5;
            this.btn_lNew.UseVisualStyleBackColor = true;
            this.btn_lNew.Click += new System.EventHandler(this.btn_lNew_Click);
            // 
            // btn_lAdd
            // 
            this.btn_lAdd.Enabled = false;
            this.btn_lAdd.ImageIndex = 0;
            this.btn_lAdd.ImageList = this.imageList1;
            this.btn_lAdd.Location = new System.Drawing.Point(291, 173);
            this.btn_lAdd.Name = "btn_lAdd";
            this.btn_lAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_lAdd.TabIndex = 152;
            this.btn_lAdd.UseVisualStyleBackColor = true;
            this.btn_lAdd.Click += new System.EventHandler(this.btn_lAdd_Click);
            // 
            // btn_lSearch
            // 
            this.btn_lSearch.ImageIndex = 3;
            this.btn_lSearch.ImageList = this.imageList1;
            this.btn_lSearch.Location = new System.Drawing.Point(319, 173);
            this.btn_lSearch.Name = "btn_lSearch";
            this.btn_lSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_lSearch.TabIndex = 155;
            this.btn_lSearch.UseVisualStyleBackColor = true;
            this.btn_lSearch.Click += new System.EventHandler(this.btn_lSearch_Click);
            // 
            // btn_lDel
            // 
            this.btn_lDel.Enabled = false;
            this.btn_lDel.ImageIndex = 2;
            this.btn_lDel.ImageList = this.imageList1;
            this.btn_lDel.Location = new System.Drawing.Point(235, 173);
            this.btn_lDel.Name = "btn_lDel";
            this.btn_lDel.Size = new System.Drawing.Size(28, 32);
            this.btn_lDel.TabIndex = 154;
            this.btn_lDel.UseVisualStyleBackColor = true;
            this.btn_lDel.Click += new System.EventHandler(this.btn_lDel_Click);
            // 
            // lCt
            // 
            this.lCt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.lCt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lCt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lCt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCt.FormattingEnabled = true;
            this.lCt.Location = new System.Drawing.Point(149, 76);
            this.lCt.Name = "lCt";
            this.lCt.Size = new System.Drawing.Size(281, 24);
            this.lCt.TabIndex = 2;
            this.lCt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lCt_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 17);
            this.label13.TabIndex = 151;
            this.label13.Text = "Centro de Trabajo:";
            // 
            // lDesc
            // 
            this.lDesc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDesc.Location = new System.Drawing.Point(150, 136);
            this.lDesc.MaxLength = 50;
            this.lDesc.Name = "lDesc";
            this.lDesc.Size = new System.Drawing.Size(280, 24);
            this.lDesc.TabIndex = 4;
            this.lDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lDesc_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(55, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 17);
            this.label12.TabIndex = 149;
            this.label12.Text = "Descripcion:";
            // 
            // lDepto
            // 
            this.lDepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.lDepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lDepto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDepto.FormattingEnabled = true;
            this.lDepto.Location = new System.Drawing.Point(149, 46);
            this.lDepto.Name = "lDepto";
            this.lDepto.Size = new System.Drawing.Size(358, 24);
            this.lDepto.TabIndex = 1;
            this.lDepto.SelectedIndexChanged += new System.EventHandler(this.lDepto_SelectedIndexChanged);
            this.lDepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lDepto_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 17);
            this.label10.TabIndex = 147;
            this.label10.Text = "Departamento:";
            // 
            // lFbu
            // 
            this.lFbu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.lFbu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lFbu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lFbu.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFbu.FormattingEnabled = true;
            this.lFbu.Location = new System.Drawing.Point(150, 16);
            this.lFbu.Name = "lFbu";
            this.lFbu.Size = new System.Drawing.Size(280, 24);
            this.lFbu.TabIndex = 0;
            this.lFbu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lFbu_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(109, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 146;
            this.label11.Text = "Fbu:";
            // 
            // tabFbu
            // 
            this.tabFbu.Controls.Add(this.btn_fEdit);
            this.tabFbu.Controls.Add(this.btn_fNew);
            this.tabFbu.Controls.Add(this.btn_fAdd);
            this.tabFbu.Controls.Add(this.btn_fSearch);
            this.tabFbu.Controls.Add(this.btn_fDel);
            this.tabFbu.Controls.Add(this.fId);
            this.tabFbu.Controls.Add(this.label15);
            this.tabFbu.Controls.Add(this.fDesc);
            this.tabFbu.Controls.Add(this.label16);
            this.tabFbu.Location = new System.Drawing.Point(4, 23);
            this.tabFbu.Name = "tabFbu";
            this.tabFbu.Padding = new System.Windows.Forms.Padding(3);
            this.tabFbu.Size = new System.Drawing.Size(525, 244);
            this.tabFbu.TabIndex = 3;
            this.tabFbu.Text = "Fbus";
            this.tabFbu.UseVisualStyleBackColor = true;
            // 
            // btn_fEdit
            // 
            this.btn_fEdit.Enabled = false;
            this.btn_fEdit.ImageIndex = 6;
            this.btn_fEdit.ImageList = this.imageList1;
            this.btn_fEdit.Location = new System.Drawing.Point(254, 161);
            this.btn_fEdit.Name = "btn_fEdit";
            this.btn_fEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_fEdit.TabIndex = 4;
            this.btn_fEdit.UseVisualStyleBackColor = true;
            this.btn_fEdit.Click += new System.EventHandler(this.btn_fEdit_Click);
            // 
            // btn_fNew
            // 
            this.btn_fNew.AutoSize = true;
            this.btn_fNew.ImageIndex = 7;
            this.btn_fNew.ImageList = this.imageList1;
            this.btn_fNew.Location = new System.Drawing.Point(198, 161);
            this.btn_fNew.Name = "btn_fNew";
            this.btn_fNew.Size = new System.Drawing.Size(28, 32);
            this.btn_fNew.TabIndex = 2;
            this.btn_fNew.UseVisualStyleBackColor = true;
            this.btn_fNew.Click += new System.EventHandler(this.btn_fNew_Click);
            // 
            // btn_fAdd
            // 
            this.btn_fAdd.Enabled = false;
            this.btn_fAdd.ImageIndex = 0;
            this.btn_fAdd.ImageList = this.imageList1;
            this.btn_fAdd.Location = new System.Drawing.Point(282, 161);
            this.btn_fAdd.Name = "btn_fAdd";
            this.btn_fAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_fAdd.TabIndex = 5;
            this.btn_fAdd.UseVisualStyleBackColor = true;
            this.btn_fAdd.Click += new System.EventHandler(this.btn_fAdd_Click);
            // 
            // btn_fSearch
            // 
            this.btn_fSearch.ImageIndex = 3;
            this.btn_fSearch.ImageList = this.imageList1;
            this.btn_fSearch.Location = new System.Drawing.Point(310, 161);
            this.btn_fSearch.Name = "btn_fSearch";
            this.btn_fSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_fSearch.TabIndex = 6;
            this.btn_fSearch.UseVisualStyleBackColor = true;
            this.btn_fSearch.Click += new System.EventHandler(this.btn_fSearch_Click);
            // 
            // btn_fDel
            // 
            this.btn_fDel.Enabled = false;
            this.btn_fDel.ImageIndex = 2;
            this.btn_fDel.ImageList = this.imageList1;
            this.btn_fDel.Location = new System.Drawing.Point(226, 161);
            this.btn_fDel.Name = "btn_fDel";
            this.btn_fDel.Size = new System.Drawing.Size(28, 32);
            this.btn_fDel.TabIndex = 3;
            this.btn_fDel.UseVisualStyleBackColor = true;
            this.btn_fDel.Click += new System.EventHandler(this.btn_fDel_Click);
            // 
            // fId
            // 
            this.fId.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fId.Location = new System.Drawing.Point(182, 45);
            this.fId.MaxLength = 4;
            this.fId.Name = "fId";
            this.fId.Size = new System.Drawing.Size(44, 24);
            this.fId.TabIndex = 0;
            this.fId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fId_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(141, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 17);
            this.label15.TabIndex = 162;
            this.label15.Text = "Fbu:";
            // 
            // fDesc
            // 
            this.fDesc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fDesc.Location = new System.Drawing.Point(182, 75);
            this.fDesc.MaxLength = 50;
            this.fDesc.Name = "fDesc";
            this.fDesc.Size = new System.Drawing.Size(280, 24);
            this.fDesc.TabIndex = 1;
            this.fDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fDesc_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(87, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 17);
            this.label16.TabIndex = 161;
            this.label16.Text = "Descripcion:";
            // 
            // tabSc
            // 
            this.tabSc.Controls.Add(this.scId);
            this.tabSc.Controls.Add(this.btn_scEdit);
            this.tabSc.Controls.Add(this.btn_scNew);
            this.tabSc.Controls.Add(this.btn_scAdd);
            this.tabSc.Controls.Add(this.btn_scSearch);
            this.tabSc.Controls.Add(this.btn_scDel);
            this.tabSc.Controls.Add(this.label17);
            this.tabSc.Controls.Add(this.scNom);
            this.tabSc.Controls.Add(this.label18);
            this.tabSc.Location = new System.Drawing.Point(4, 23);
            this.tabSc.Name = "tabSc";
            this.tabSc.Padding = new System.Windows.Forms.Padding(3);
            this.tabSc.Size = new System.Drawing.Size(525, 268);
            this.tabSc.TabIndex = 4;
            this.tabSc.Text = "tabPage5";
            this.tabSc.UseVisualStyleBackColor = true;
            // 
            // scId
            // 
            this.scId.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.scId.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scId.HidePromptOnLeave = true;
            this.scId.Location = new System.Drawing.Point(170, 27);
            this.scId.Mask = "00";
            this.scId.Name = "scId";
            this.scId.Size = new System.Drawing.Size(33, 24);
            this.scId.TabIndex = 0;
            this.scId.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.scId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scId_KeyPress_1);
            // 
            // btn_scEdit
            // 
            this.btn_scEdit.Enabled = false;
            this.btn_scEdit.ImageIndex = 6;
            this.btn_scEdit.ImageList = this.imageList1;
            this.btn_scEdit.Location = new System.Drawing.Point(242, 147);
            this.btn_scEdit.Name = "btn_scEdit";
            this.btn_scEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_scEdit.TabIndex = 4;
            this.btn_scEdit.UseVisualStyleBackColor = true;
            this.btn_scEdit.Click += new System.EventHandler(this.btn_scEdit_Click);
            // 
            // btn_scNew
            // 
            this.btn_scNew.AutoSize = true;
            this.btn_scNew.ImageIndex = 7;
            this.btn_scNew.ImageList = this.imageList1;
            this.btn_scNew.Location = new System.Drawing.Point(186, 147);
            this.btn_scNew.Name = "btn_scNew";
            this.btn_scNew.Size = new System.Drawing.Size(28, 32);
            this.btn_scNew.TabIndex = 2;
            this.btn_scNew.UseVisualStyleBackColor = true;
            this.btn_scNew.Click += new System.EventHandler(this.btn_scNew_Click);
            // 
            // btn_scAdd
            // 
            this.btn_scAdd.Enabled = false;
            this.btn_scAdd.ImageIndex = 0;
            this.btn_scAdd.ImageList = this.imageList1;
            this.btn_scAdd.Location = new System.Drawing.Point(270, 147);
            this.btn_scAdd.Name = "btn_scAdd";
            this.btn_scAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_scAdd.TabIndex = 5;
            this.btn_scAdd.UseVisualStyleBackColor = true;
            this.btn_scAdd.Click += new System.EventHandler(this.btn_scAdd_Click);
            // 
            // btn_scSearch
            // 
            this.btn_scSearch.ImageIndex = 3;
            this.btn_scSearch.ImageList = this.imageList1;
            this.btn_scSearch.Location = new System.Drawing.Point(298, 147);
            this.btn_scSearch.Name = "btn_scSearch";
            this.btn_scSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_scSearch.TabIndex = 6;
            this.btn_scSearch.UseVisualStyleBackColor = true;
            this.btn_scSearch.Click += new System.EventHandler(this.btn_scSearch_Click);
            // 
            // btn_scDel
            // 
            this.btn_scDel.Enabled = false;
            this.btn_scDel.ImageIndex = 2;
            this.btn_scDel.ImageList = this.imageList1;
            this.btn_scDel.Location = new System.Drawing.Point(214, 147);
            this.btn_scDel.Name = "btn_scDel";
            this.btn_scDel.Size = new System.Drawing.Size(28, 32);
            this.btn_scDel.TabIndex = 3;
            this.btn_scDel.UseVisualStyleBackColor = true;
            this.btn_scDel.Click += new System.EventHandler(this.btn_scDel_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(95, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 17);
            this.label17.TabIndex = 171;
            this.label17.Text = "Numero:";
            // 
            // scNom
            // 
            this.scNom.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scNom.Location = new System.Drawing.Point(170, 61);
            this.scNom.MaxLength = 50;
            this.scNom.Name = "scNom";
            this.scNom.Size = new System.Drawing.Size(280, 24);
            this.scNom.TabIndex = 1;
            this.scNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scNom_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(95, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 17);
            this.label18.TabIndex = 170;
            this.label18.Text = "Nombre:";
            // 
            // tabRelsc
            // 
            this.tabRelsc.Controls.Add(this.lblErr);
            this.tabRelsc.Controls.Add(this.chkListCoord);
            this.tabRelsc.Controls.Add(this.cmbSup);
            this.tabRelsc.Controls.Add(this.bnSave);
            this.tabRelsc.Controls.Add(this.label20);
            this.tabRelsc.Controls.Add(this.label19);
            this.tabRelsc.Location = new System.Drawing.Point(4, 23);
            this.tabRelsc.Name = "tabRelsc";
            this.tabRelsc.Padding = new System.Windows.Forms.Padding(3);
            this.tabRelsc.Size = new System.Drawing.Size(525, 268);
            this.tabRelsc.TabIndex = 5;
            this.tabRelsc.Text = "Relación Supervisores Coordinadores";
            this.tabRelsc.UseVisualStyleBackColor = true;
            // 
            // lblErr
            // 
            this.lblErr.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErr.Location = new System.Drawing.Point(6, 109);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(198, 96);
            this.lblErr.TabIndex = 176;
            this.lblErr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkListCoord
            // 
            this.chkListCoord.FormattingEnabled = true;
            this.chkListCoord.Location = new System.Drawing.Point(210, 36);
            this.chkListCoord.Name = "chkListCoord";
            this.chkListCoord.Size = new System.Drawing.Size(280, 140);
            this.chkListCoord.TabIndex = 1;
            this.chkListCoord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkListCoord_KeyPress);
            // 
            // cmbSup
            // 
            this.cmbSup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSup.FormattingEnabled = true;
            this.cmbSup.Location = new System.Drawing.Point(210, 6);
            this.cmbSup.Name = "cmbSup";
            this.cmbSup.Size = new System.Drawing.Size(280, 24);
            this.cmbSup.TabIndex = 0;
            this.cmbSup.SelectedIndexChanged += new System.EventHandler(this.cmbSup_SelectedIndexChanged);
            this.cmbSup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSup_KeyPress);
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(288, 182);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(129, 23);
            this.bnSave.TabIndex = 2;
            this.bnSave.Text = "Guarde Relación";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(225, 38);
            this.label20.TabIndex = 173;
            this.label20.Text = "2-Selecciones los coordinadores Relacionados:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(204, 17);
            this.label19.TabIndex = 172;
            this.label19.Text = "1-Seleccione un supervisor:";
            // 
            // tabTurnos
            // 
            this.tabTurnos.Controls.Add(this.tHrs);
            this.tabTurnos.Controls.Add(this.td3_2);
            this.tabTurnos.Controls.Add(this.td3_1);
            this.tabTurnos.Controls.Add(this.td2_1);
            this.tabTurnos.Controls.Add(this.td2_2);
            this.tabTurnos.Controls.Add(this.td1_2);
            this.tabTurnos.Controls.Add(this.td1_1);
            this.tabTurnos.Controls.Add(this.tSal);
            this.tabTurnos.Controls.Add(this.tEnt);
            this.tabTurnos.Controls.Add(this.tId);
            this.tabTurnos.Controls.Add(this.label29);
            this.tabTurnos.Controls.Add(this.label28);
            this.tabTurnos.Controls.Add(this.label27);
            this.tabTurnos.Controls.Add(this.label26);
            this.tabTurnos.Controls.Add(this.label25);
            this.tabTurnos.Controls.Add(this.label24);
            this.tabTurnos.Controls.Add(this.label23);
            this.tabTurnos.Controls.Add(this.btn_tEdit);
            this.tabTurnos.Controls.Add(this.btn_tNew);
            this.tabTurnos.Controls.Add(this.btn_tAdd);
            this.tabTurnos.Controls.Add(this.btn_tSearch);
            this.tabTurnos.Controls.Add(this.btn_tDel);
            this.tabTurnos.Controls.Add(this.label21);
            this.tabTurnos.Controls.Add(this.label22);
            this.tabTurnos.Location = new System.Drawing.Point(4, 23);
            this.tabTurnos.Name = "tabTurnos";
            this.tabTurnos.Padding = new System.Windows.Forms.Padding(3);
            this.tabTurnos.Size = new System.Drawing.Size(525, 268);
            this.tabTurnos.TabIndex = 6;
            this.tabTurnos.Text = "Turnos";
            this.tabTurnos.UseVisualStyleBackColor = true;
            // 
            // tHrs
            // 
            this.tHrs.Location = new System.Drawing.Point(141, 112);
            this.tHrs.MaxLength = 20;
            this.tHrs.Name = "tHrs";
            this.tHrs.ReadOnly = true;
            this.tHrs.Size = new System.Drawing.Size(81, 22);
            this.tHrs.TabIndex = 3;
            this.tHrs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tHrs_KeyPress_1);
            // 
            // td3_2
            // 
            this.td3_2.Location = new System.Drawing.Point(415, 104);
            this.td3_2.Mask = "##:##";
            this.td3_2.Name = "td3_2";
            this.td3_2.Size = new System.Drawing.Size(47, 22);
            this.td3_2.TabIndex = 9;
            this.td3_2.Leave += new System.EventHandler(this.td3_2_Leave);
            // 
            // td3_1
            // 
            this.td3_1.Location = new System.Drawing.Point(340, 105);
            this.td3_1.Mask = "##:##";
            this.td3_1.Name = "td3_1";
            this.td3_1.Size = new System.Drawing.Size(47, 22);
            this.td3_1.TabIndex = 8;
            this.td3_1.Leave += new System.EventHandler(this.td3_1_Leave);
            // 
            // td2_1
            // 
            this.td2_1.Location = new System.Drawing.Point(340, 77);
            this.td2_1.Mask = "##:##";
            this.td2_1.Name = "td2_1";
            this.td2_1.Size = new System.Drawing.Size(47, 22);
            this.td2_1.TabIndex = 6;
            this.td2_1.Leave += new System.EventHandler(this.td2_1_Leave);
            // 
            // td2_2
            // 
            this.td2_2.Location = new System.Drawing.Point(415, 77);
            this.td2_2.Mask = "##:##";
            this.td2_2.Name = "td2_2";
            this.td2_2.Size = new System.Drawing.Size(47, 22);
            this.td2_2.TabIndex = 7;
            this.td2_2.Leave += new System.EventHandler(this.td2_2_Leave);
            // 
            // td1_2
            // 
            this.td1_2.Location = new System.Drawing.Point(415, 50);
            this.td1_2.Mask = "##:##";
            this.td1_2.Name = "td1_2";
            this.td1_2.Size = new System.Drawing.Size(47, 22);
            this.td1_2.TabIndex = 5;
            this.td1_2.Leave += new System.EventHandler(this.td1_2_Leave);
            // 
            // td1_1
            // 
            this.td1_1.Location = new System.Drawing.Point(340, 50);
            this.td1_1.Mask = "##:##";
            this.td1_1.Name = "td1_1";
            this.td1_1.Size = new System.Drawing.Size(47, 22);
            this.td1_1.TabIndex = 4;
            this.td1_1.Leave += new System.EventHandler(this.td1_1_Leave);
            // 
            // tSal
            // 
            this.tSal.Location = new System.Drawing.Point(141, 78);
            this.tSal.Mask = "##:##";
            this.tSal.Name = "tSal";
            this.tSal.Size = new System.Drawing.Size(47, 22);
            this.tSal.TabIndex = 2;
            this.tSal.Leave += new System.EventHandler(this.tSal_Leave);
            // 
            // tEnt
            // 
            this.tEnt.Location = new System.Drawing.Point(141, 50);
            this.tEnt.Mask = "##:##";
            this.tEnt.Name = "tEnt";
            this.tEnt.Size = new System.Drawing.Size(47, 22);
            this.tEnt.TabIndex = 1;
            this.tEnt.Leave += new System.EventHandler(this.tEnt_Leave);
            // 
            // tId
            // 
            this.tId.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tId.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tId.HidePromptOnLeave = true;
            this.tId.Location = new System.Drawing.Point(141, 19);
            this.tId.Mask = "00";
            this.tId.Name = "tId";
            this.tId.Size = new System.Drawing.Size(33, 24);
            this.tId.TabIndex = 0;
            this.tId.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tId_KeyPress);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(238, 80);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 17);
            this.label29.TabIndex = 198;
            this.label29.Text = "Descanso 2:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(238, 109);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(96, 17);
            this.label28.TabIndex = 197;
            this.label28.Text = "Descanso 3:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(238, 52);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 17);
            this.label27.TabIndex = 196;
            this.label27.Text = "Descanso 1:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(412, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(55, 17);
            this.label26.TabIndex = 195;
            this.label26.Text = "Salida:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(337, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(69, 17);
            this.label25.TabIndex = 194;
            this.label25.Text = "Entrada:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(29, 112);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(107, 17);
            this.label24.TabIndex = 184;
            this.label24.Text = "Horas Diarias:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(81, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 17);
            this.label23.TabIndex = 182;
            this.label23.Text = "Salida:";
            // 
            // btn_tEdit
            // 
            this.btn_tEdit.Enabled = false;
            this.btn_tEdit.ImageIndex = 6;
            this.btn_tEdit.ImageList = this.imageList1;
            this.btn_tEdit.Location = new System.Drawing.Point(250, 152);
            this.btn_tEdit.Name = "btn_tEdit";
            this.btn_tEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_tEdit.TabIndex = 12;
            this.btn_tEdit.UseVisualStyleBackColor = true;
            this.btn_tEdit.Click += new System.EventHandler(this.btn_tEdit_Click);
            // 
            // btn_tNew
            // 
            this.btn_tNew.AutoSize = true;
            this.btn_tNew.ImageIndex = 7;
            this.btn_tNew.ImageList = this.imageList1;
            this.btn_tNew.Location = new System.Drawing.Point(194, 152);
            this.btn_tNew.Name = "btn_tNew";
            this.btn_tNew.Size = new System.Drawing.Size(28, 32);
            this.btn_tNew.TabIndex = 10;
            this.btn_tNew.UseVisualStyleBackColor = true;
            this.btn_tNew.Click += new System.EventHandler(this.btn_tNew_Click);
            // 
            // btn_tAdd
            // 
            this.btn_tAdd.Enabled = false;
            this.btn_tAdd.ImageIndex = 0;
            this.btn_tAdd.ImageList = this.imageList1;
            this.btn_tAdd.Location = new System.Drawing.Point(278, 152);
            this.btn_tAdd.Name = "btn_tAdd";
            this.btn_tAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_tAdd.TabIndex = 13;
            this.btn_tAdd.UseVisualStyleBackColor = true;
            this.btn_tAdd.Click += new System.EventHandler(this.btn_tAdd_Click);
            // 
            // btn_tSearch
            // 
            this.btn_tSearch.ImageIndex = 3;
            this.btn_tSearch.ImageList = this.imageList1;
            this.btn_tSearch.Location = new System.Drawing.Point(306, 152);
            this.btn_tSearch.Name = "btn_tSearch";
            this.btn_tSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_tSearch.TabIndex = 14;
            this.btn_tSearch.UseVisualStyleBackColor = true;
            this.btn_tSearch.Click += new System.EventHandler(this.btn_tSearch_Click);
            // 
            // btn_tDel
            // 
            this.btn_tDel.Enabled = false;
            this.btn_tDel.ImageIndex = 2;
            this.btn_tDel.ImageList = this.imageList1;
            this.btn_tDel.Location = new System.Drawing.Point(222, 152);
            this.btn_tDel.Name = "btn_tDel";
            this.btn_tDel.Size = new System.Drawing.Size(28, 32);
            this.btn_tDel.TabIndex = 11;
            this.btn_tDel.UseVisualStyleBackColor = true;
            this.btn_tDel.Click += new System.EventHandler(this.btn_tDel_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(81, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 17);
            this.label21.TabIndex = 180;
            this.label21.Text = "Turno:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(67, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 17);
            this.label22.TabIndex = 179;
            this.label22.Text = "Entrada:";
            // 
            // tabNoParte
            // 
            this.tabNoParte.Controls.Add(this.sec);
            this.tabNoParte.Controls.Add(this.np);
            this.tabNoParte.Controls.Add(this.label33);
            this.tabNoParte.Controls.Add(this.label30);
            this.tabNoParte.Controls.Add(this.btn_npEdit);
            this.tabNoParte.Controls.Add(this.btn_npNew);
            this.tabNoParte.Controls.Add(this.btn_npAdd);
            this.tabNoParte.Controls.Add(this.btn_npSearch);
            this.tabNoParte.Controls.Add(this.btn_npDel);
            this.tabNoParte.Controls.Add(this.cmbCodOp);
            this.tabNoParte.Controls.Add(this.label31);
            this.tabNoParte.Controls.Add(this.codOra);
            this.tabNoParte.Controls.Add(this.label32);
            this.tabNoParte.Location = new System.Drawing.Point(4, 23);
            this.tabNoParte.Name = "tabNoParte";
            this.tabNoParte.Padding = new System.Windows.Forms.Padding(3);
            this.tabNoParte.Size = new System.Drawing.Size(525, 244);
            this.tabNoParte.TabIndex = 7;
            this.tabNoParte.Text = "Numeros de Parte";
            this.tabNoParte.UseVisualStyleBackColor = true;
            // 
            // sec
            // 
            this.sec.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.sec.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sec.HidePromptOnLeave = true;
            this.sec.Location = new System.Drawing.Point(195, 78);
            this.sec.Mask = "0000000000";
            this.sec.Name = "sec";
            this.sec.Size = new System.Drawing.Size(90, 24);
            this.sec.TabIndex = 2;
            this.sec.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.sec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sec_KeyPress);
            // 
            // np
            // 
            this.np.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.np.Location = new System.Drawing.Point(195, 45);
            this.np.MaxLength = 50;
            this.np.Name = "np";
            this.np.Size = new System.Drawing.Size(280, 24);
            this.np.TabIndex = 1;
            this.np.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.np_KeyPress);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(121, 48);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(74, 17);
            this.label33.TabIndex = 171;
            this.label33.Text = "No Parte:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(112, 81);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(83, 17);
            this.label30.TabIndex = 169;
            this.label30.Text = "Secuencia:";
            // 
            // btn_npEdit
            // 
            this.btn_npEdit.Enabled = false;
            this.btn_npEdit.ImageIndex = 6;
            this.btn_npEdit.ImageList = this.imageList1;
            this.btn_npEdit.Location = new System.Drawing.Point(257, 156);
            this.btn_npEdit.Name = "btn_npEdit";
            this.btn_npEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_npEdit.TabIndex = 6;
            this.btn_npEdit.UseVisualStyleBackColor = true;
            this.btn_npEdit.Click += new System.EventHandler(this.btn_npEdit_Click);
            // 
            // btn_npNew
            // 
            this.btn_npNew.AutoSize = true;
            this.btn_npNew.ImageIndex = 7;
            this.btn_npNew.ImageList = this.imageList1;
            this.btn_npNew.Location = new System.Drawing.Point(201, 156);
            this.btn_npNew.Name = "btn_npNew";
            this.btn_npNew.Size = new System.Drawing.Size(28, 32);
            this.btn_npNew.TabIndex = 4;
            this.btn_npNew.UseVisualStyleBackColor = true;
            this.btn_npNew.Click += new System.EventHandler(this.btn_npNew_Click);
            // 
            // btn_npAdd
            // 
            this.btn_npAdd.Enabled = false;
            this.btn_npAdd.ImageIndex = 0;
            this.btn_npAdd.ImageList = this.imageList1;
            this.btn_npAdd.Location = new System.Drawing.Point(285, 156);
            this.btn_npAdd.Name = "btn_npAdd";
            this.btn_npAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_npAdd.TabIndex = 7;
            this.btn_npAdd.UseVisualStyleBackColor = true;
            this.btn_npAdd.Click += new System.EventHandler(this.btn_npAdd_Click);
            // 
            // btn_npSearch
            // 
            this.btn_npSearch.ImageIndex = 3;
            this.btn_npSearch.ImageList = this.imageList1;
            this.btn_npSearch.Location = new System.Drawing.Point(313, 156);
            this.btn_npSearch.Name = "btn_npSearch";
            this.btn_npSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_npSearch.TabIndex = 8;
            this.btn_npSearch.UseVisualStyleBackColor = true;
            this.btn_npSearch.Click += new System.EventHandler(this.btn_npSearch_Click);
            // 
            // btn_npDel
            // 
            this.btn_npDel.Enabled = false;
            this.btn_npDel.ImageIndex = 2;
            this.btn_npDel.ImageList = this.imageList1;
            this.btn_npDel.Location = new System.Drawing.Point(229, 156);
            this.btn_npDel.Name = "btn_npDel";
            this.btn_npDel.Size = new System.Drawing.Size(28, 32);
            this.btn_npDel.TabIndex = 5;
            this.btn_npDel.UseVisualStyleBackColor = true;
            this.btn_npDel.Click += new System.EventHandler(this.btn_npDel_Click);
            // 
            // cmbCodOp
            // 
            this.cmbCodOp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCodOp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCodOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodOp.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCodOp.FormattingEnabled = true;
            this.cmbCodOp.Location = new System.Drawing.Point(195, 15);
            this.cmbCodOp.Name = "cmbCodOp";
            this.cmbCodOp.Size = new System.Drawing.Size(160, 24);
            this.cmbCodOp.TabIndex = 0;
            this.cmbCodOp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCodOp_KeyPress);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(35, 18);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(160, 17);
            this.label31.TabIndex = 164;
            this.label31.Text = "Codigo de Operación:";
            // 
            // codOra
            // 
            this.codOra.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codOra.Location = new System.Drawing.Point(195, 108);
            this.codOra.MaxLength = 4;
            this.codOra.Name = "codOra";
            this.codOra.Size = new System.Drawing.Size(62, 24);
            this.codOra.TabIndex = 3;
            this.codOra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codOra_KeyPress);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(100, 111);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(95, 17);
            this.label32.TabIndex = 163;
            this.label32.Text = "Cod. Oracle:";
            // 
            // tabNciD
            // 
            this.tabNciD.Controls.Add(this.btn_ciEdit);
            this.tabNciD.Controls.Add(this.btn_ciNew);
            this.tabNciD.Controls.Add(this.btn_ciAdd);
            this.tabNciD.Controls.Add(this.btn_ciSearch);
            this.tabNciD.Controls.Add(this.btn_ciDel);
            this.tabNciD.Controls.Add(this.txtDesc);
            this.tabNciD.Controls.Add(this.label36);
            this.tabNciD.Controls.Add(this.txtDepto);
            this.tabNciD.Controls.Add(this.label35);
            this.tabNciD.Controls.Add(this.label34);
            this.tabNciD.Controls.Add(this.txtCi);
            this.tabNciD.Location = new System.Drawing.Point(4, 23);
            this.tabNciD.Name = "tabNciD";
            this.tabNciD.Padding = new System.Windows.Forms.Padding(3);
            this.tabNciD.Size = new System.Drawing.Size(525, 268);
            this.tabNciD.TabIndex = 8;
            this.tabNciD.Text = "Codigos Indirectos a departamentos";
            this.tabNciD.UseVisualStyleBackColor = true;
            // 
            // btn_ciEdit
            // 
            this.btn_ciEdit.Enabled = false;
            this.btn_ciEdit.ImageIndex = 6;
            this.btn_ciEdit.ImageList = this.imageList1;
            this.btn_ciEdit.Location = new System.Drawing.Point(244, 157);
            this.btn_ciEdit.Name = "btn_ciEdit";
            this.btn_ciEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_ciEdit.TabIndex = 5;
            this.btn_ciEdit.UseVisualStyleBackColor = true;
            this.btn_ciEdit.Click += new System.EventHandler(this.btn_ciEdit_Click);
            // 
            // btn_ciNew
            // 
            this.btn_ciNew.AutoSize = true;
            this.btn_ciNew.ImageIndex = 7;
            this.btn_ciNew.ImageList = this.imageList1;
            this.btn_ciNew.Location = new System.Drawing.Point(188, 157);
            this.btn_ciNew.Name = "btn_ciNew";
            this.btn_ciNew.Size = new System.Drawing.Size(28, 32);
            this.btn_ciNew.TabIndex = 3;
            this.btn_ciNew.UseVisualStyleBackColor = true;
            this.btn_ciNew.Click += new System.EventHandler(this.btn_ciNew_Click);
            // 
            // btn_ciAdd
            // 
            this.btn_ciAdd.Enabled = false;
            this.btn_ciAdd.ImageIndex = 0;
            this.btn_ciAdd.ImageList = this.imageList1;
            this.btn_ciAdd.Location = new System.Drawing.Point(272, 157);
            this.btn_ciAdd.Name = "btn_ciAdd";
            this.btn_ciAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_ciAdd.TabIndex = 6;
            this.btn_ciAdd.UseVisualStyleBackColor = true;
            this.btn_ciAdd.Click += new System.EventHandler(this.btn_ciAdd_Click);
            // 
            // btn_ciSearch
            // 
            this.btn_ciSearch.ImageIndex = 3;
            this.btn_ciSearch.ImageList = this.imageList1;
            this.btn_ciSearch.Location = new System.Drawing.Point(300, 157);
            this.btn_ciSearch.Name = "btn_ciSearch";
            this.btn_ciSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_ciSearch.TabIndex = 7;
            this.btn_ciSearch.UseVisualStyleBackColor = true;
            this.btn_ciSearch.Click += new System.EventHandler(this.btn_ciSearch_Click);
            // 
            // btn_ciDel
            // 
            this.btn_ciDel.Enabled = false;
            this.btn_ciDel.ImageIndex = 2;
            this.btn_ciDel.ImageList = this.imageList1;
            this.btn_ciDel.Location = new System.Drawing.Point(216, 157);
            this.btn_ciDel.Name = "btn_ciDel";
            this.btn_ciDel.Size = new System.Drawing.Size(28, 32);
            this.btn_ciDel.TabIndex = 4;
            this.btn_ciDel.UseVisualStyleBackColor = true;
            this.btn_ciDel.Click += new System.EventHandler(this.btn_ciDel_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(167, 92);
            this.txtDesc.MaxLength = 250;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(275, 59);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesc_KeyPress);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Verdana", 10F);
            this.label36.Location = new System.Drawing.Point(64, 94);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(94, 17);
            this.label36.TabIndex = 4;
            this.label36.Text = "Descripción:";
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(167, 64);
            this.txtDepto.MaxLength = 15;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(204, 22);
            this.txtDepto.TabIndex = 1;
            this.txtDepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepto_KeyPress);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Verdana", 10F);
            this.label35.Location = new System.Drawing.Point(44, 66);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(115, 17);
            this.label35.TabIndex = 2;
            this.label35.Text = "Departamento:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 10F);
            this.label34.Location = new System.Drawing.Point(31, 38);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(130, 17);
            this.label34.TabIndex = 1;
            this.label34.Text = "Codigo Indirecto:";
            // 
            // txtCi
            // 
            this.txtCi.Location = new System.Drawing.Point(167, 36);
            this.txtCi.MaxLength = 4;
            this.txtCi.Name = "txtCi";
            this.txtCi.Size = new System.Drawing.Size(62, 22);
            this.txtCi.TabIndex = 0;
            this.txtCi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCi_KeyPress);
            // 
            // tabEmpCoord
            // 
            this.tabEmpCoord.Controls.Add(this.button1);
            this.tabEmpCoord.Controls.Add(this.radioButton2);
            this.tabEmpCoord.Controls.Add(this.radioButton1);
            this.tabEmpCoord.Controls.Add(this.label41);
            this.tabEmpCoord.Controls.Add(this.lstBoxEmpl);
            this.tabEmpCoord.Controls.Add(this.lblerr4);
            this.tabEmpCoord.Controls.Add(this.label40);
            this.tabEmpCoord.Controls.Add(this.txtEmpName);
            this.tabEmpCoord.Controls.Add(this.btnEmS);
            this.tabEmpCoord.Controls.Add(this.txtEmp);
            this.tabEmpCoord.Controls.Add(this.label39);
            this.tabEmpCoord.Controls.Add(this.cmbEmpSup);
            this.tabEmpCoord.Controls.Add(this.btnEmpSave);
            this.tabEmpCoord.Controls.Add(this.label37);
            this.tabEmpCoord.Controls.Add(this.label38);
            this.tabEmpCoord.Location = new System.Drawing.Point(4, 23);
            this.tabEmpCoord.Name = "tabEmpCoord";
            this.tabEmpCoord.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmpCoord.Size = new System.Drawing.Size(525, 268);
            this.tabEmpCoord.TabIndex = 9;
            this.tabEmpCoord.Text = "Relacion Empleados-Coordinador";
            this.tabEmpCoord.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ImageIndex = 3;
            this.button1.Location = new System.Drawing.Point(392, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 24);
            this.button1.TabIndex = 188;
            this.button1.Text = "Listar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(293, 184);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 18);
            this.radioButton2.TabIndex = 187;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Baja";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(225, 184);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 18);
            this.radioButton1.TabIndex = 186;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Activo";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(133, 174);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(86, 38);
            this.label41.TabIndex = 185;
            this.label41.Text = "4-Status:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstBoxEmpl
            // 
            this.lstBoxEmpl.FormattingEnabled = true;
            this.lstBoxEmpl.ItemHeight = 14;
            this.lstBoxEmpl.Location = new System.Drawing.Point(225, 99);
            this.lstBoxEmpl.Name = "lstBoxEmpl";
            this.lstBoxEmpl.Size = new System.Drawing.Size(280, 74);
            this.lstBoxEmpl.TabIndex = 4;
            this.lstBoxEmpl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstBoxEmpl_KeyPress);
            // 
            // lblerr4
            // 
            this.lblerr4.Location = new System.Drawing.Point(225, 216);
            this.lblerr4.Name = "lblerr4";
            this.lblerr4.Size = new System.Drawing.Size(280, 23);
            this.lblerr4.TabIndex = 184;
            this.lblerr4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(150, 41);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(69, 17);
            this.label40.TabIndex = 183;
            this.label40.Text = "Nombre:";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(225, 36);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(280, 22);
            this.txtEmpName.TabIndex = 2;
            // 
            // btnEmS
            // 
            this.btnEmS.Location = new System.Drawing.Point(302, 7);
            this.btnEmS.Name = "btnEmS";
            this.btnEmS.Size = new System.Drawing.Size(78, 23);
            this.btnEmS.TabIndex = 1;
            this.btnEmS.Text = "Busque";
            this.btnEmS.UseVisualStyleBackColor = true;
            this.btnEmS.Click += new System.EventHandler(this.btnEmS_Click);
            this.btnEmS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnEmS_KeyPress);
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(225, 8);
            this.txtEmp.MaxLength = 10;
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(71, 22);
            this.txtEmp.TabIndex = 0;
            this.txtEmp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmp_KeyPress);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(16, 13);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(203, 17);
            this.label39.TabIndex = 179;
            this.label39.Text = "1-Busque o liste Empleado:";
            // 
            // cmbEmpSup
            // 
            this.cmbEmpSup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbEmpSup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmpSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpSup.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpSup.FormattingEnabled = true;
            this.cmbEmpSup.Location = new System.Drawing.Point(225, 67);
            this.cmbEmpSup.Name = "cmbEmpSup";
            this.cmbEmpSup.Size = new System.Drawing.Size(280, 24);
            this.cmbEmpSup.TabIndex = 3;
            this.cmbEmpSup.SelectedIndexChanged += new System.EventHandler(this.cmbEmpSup_SelectedIndexChanged);
            this.cmbEmpSup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbEmpSup_KeyPress);
            // 
            // btnEmpSave
            // 
            this.btnEmpSave.ImageIndex = 0;
            this.btnEmpSave.ImageList = this.imageList1;
            this.btnEmpSave.Location = new System.Drawing.Point(366, 179);
            this.btnEmpSave.Name = "btnEmpSave";
            this.btnEmpSave.Size = new System.Drawing.Size(61, 28);
            this.btnEmpSave.TabIndex = 5;
            this.btnEmpSave.UseVisualStyleBackColor = true;
            this.btnEmpSave.Click += new System.EventHandler(this.btnEmpSave_Click);
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(6, 94);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(225, 38);
            this.label37.TabIndex = 178;
            this.label37.Text = "3-Selecciones al coordinador:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(15, 74);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(204, 17);
            this.label38.TabIndex = 177;
            this.label38.Text = "2-Seleccione un supervisor:";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HotTracking = true;
            this.treeView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "nDep";
            treeNode1.Text = "Departamentos";
            treeNode2.Name = "nCt";
            treeNode2.Text = "Centros de Trabajo";
            treeNode3.Name = "nL";
            treeNode3.Text = "Lineas";
            treeNode4.Name = "nCo";
            treeNode4.Text = "Codigos de Operacion";
            treeNode5.Name = "nFbu";
            treeNode5.Text = "Fbus";
            treeNode6.Name = "nSup";
            treeNode6.Text = "Supervisores";
            treeNode7.Name = "nCoord";
            treeNode7.Text = "Coordinadores";
            treeNode8.Name = "nSc";
            treeNode8.Text = "Relacion Sup-Coord";
            treeNode9.Name = "nNp";
            treeNode9.Text = "Numeros de Parte";
            treeNode10.Name = "nTur";
            treeNode10.Text = "Turnos";
            treeNode11.Name = "nCiD";
            treeNode11.Text = "Codigos Ind a Deptos";
            treeNode12.Name = "nEc";
            treeNode12.Text = "Relacion Emp-Coord";
            treeNode13.Name = "nProc";
            treeNode13.Text = "Procesos";
            treeNode14.Name = "nRegresar";
            treeNode14.Text = "Salir";
            treeNode15.Name = "nHome";
            treeNode15.Text = "Opciones";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(208, 295);
            this.treeView1.TabIndex = 10;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // tabProc
            // 
            this.tabProc.Controls.Add(this.btn_pEdit);
            this.tabProc.Controls.Add(this.btn_pNew);
            this.tabProc.Controls.Add(this.btn_pAdd);
            this.tabProc.Controls.Add(this.btn_pSearch);
            this.tabProc.Controls.Add(this.btn_pDel);
            this.tabProc.Controls.Add(this.txtProc);
            this.tabProc.Controls.Add(this.label42);
            this.tabProc.Location = new System.Drawing.Point(4, 23);
            this.tabProc.Name = "tabProc";
            this.tabProc.Padding = new System.Windows.Forms.Padding(3);
            this.tabProc.Size = new System.Drawing.Size(525, 268);
            this.tabProc.TabIndex = 10;
            this.tabProc.Text = "Procesos";
            this.tabProc.UseVisualStyleBackColor = true;
            // 
            // btn_pEdit
            // 
            this.btn_pEdit.Enabled = false;
            this.btn_pEdit.ImageIndex = 6;
            this.btn_pEdit.ImageList = this.imageList1;
            this.btn_pEdit.Location = new System.Drawing.Point(232, 161);
            this.btn_pEdit.Name = "btn_pEdit";
            this.btn_pEdit.Size = new System.Drawing.Size(28, 32);
            this.btn_pEdit.TabIndex = 3;
            this.btn_pEdit.UseVisualStyleBackColor = true;
            this.btn_pEdit.Click += new System.EventHandler(this.btn_pEdit_Click);
            // 
            // btn_pNew
            // 
            this.btn_pNew.AutoSize = true;
            this.btn_pNew.ImageIndex = 7;
            this.btn_pNew.ImageList = this.imageList1;
            this.btn_pNew.Location = new System.Drawing.Point(176, 161);
            this.btn_pNew.Name = "btn_pNew";
            this.btn_pNew.Size = new System.Drawing.Size(28, 32);
            this.btn_pNew.TabIndex = 2;
            this.btn_pNew.UseVisualStyleBackColor = true;
            this.btn_pNew.Click += new System.EventHandler(this.btn_pNew_Click);
            // 
            // btn_pAdd
            // 
            this.btn_pAdd.Enabled = false;
            this.btn_pAdd.ImageIndex = 0;
            this.btn_pAdd.ImageList = this.imageList1;
            this.btn_pAdd.Location = new System.Drawing.Point(260, 161);
            this.btn_pAdd.Name = "btn_pAdd";
            this.btn_pAdd.Size = new System.Drawing.Size(28, 32);
            this.btn_pAdd.TabIndex = 4;
            this.btn_pAdd.UseVisualStyleBackColor = true;
            this.btn_pAdd.Click += new System.EventHandler(this.btn_pAdd_Click);
            // 
            // btn_pSearch
            // 
            this.btn_pSearch.ImageIndex = 3;
            this.btn_pSearch.ImageList = this.imageList1;
            this.btn_pSearch.Location = new System.Drawing.Point(288, 161);
            this.btn_pSearch.Name = "btn_pSearch";
            this.btn_pSearch.Size = new System.Drawing.Size(28, 32);
            this.btn_pSearch.TabIndex = 5;
            this.btn_pSearch.UseVisualStyleBackColor = true;
            this.btn_pSearch.Click += new System.EventHandler(this.btn_pSearch_Click);
            // 
            // btn_pDel
            // 
            this.btn_pDel.Enabled = false;
            this.btn_pDel.ImageIndex = 2;
            this.btn_pDel.ImageList = this.imageList1;
            this.btn_pDel.Location = new System.Drawing.Point(204, 161);
            this.btn_pDel.Name = "btn_pDel";
            this.btn_pDel.Size = new System.Drawing.Size(28, 32);
            this.btn_pDel.TabIndex = 173;
            this.btn_pDel.UseVisualStyleBackColor = true;
            this.btn_pDel.Click += new System.EventHandler(this.btn_pDel_Click);
            // 
            // txtProc
            // 
            this.txtProc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProc.Location = new System.Drawing.Point(149, 75);
            this.txtProc.MaxLength = 50;
            this.txtProc.Name = "txtProc";
            this.txtProc.Size = new System.Drawing.Size(280, 24);
            this.txtProc.TabIndex = 0;
            this.txtProc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(74, 78);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(69, 17);
            this.label42.TabIndex = 177;
            this.label42.Text = "Proceso:";
            // 
            // frmModIng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 295);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.treeView1);
            this.MaximizeBox = false;
            this.Name = "frmModIng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Menu Modulo de Ingenieria";
            this.tabControl.ResumeLayout(false);
            this.tabDeptos.ResumeLayout(false);
            this.tabDeptos.PerformLayout();
            this.tabCt.ResumeLayout(false);
            this.tabCt.PerformLayout();
            this.tabLine.ResumeLayout(false);
            this.tabLine.PerformLayout();
            this.tabFbu.ResumeLayout(false);
            this.tabFbu.PerformLayout();
            this.tabSc.ResumeLayout(false);
            this.tabSc.PerformLayout();
            this.tabRelsc.ResumeLayout(false);
            this.tabRelsc.PerformLayout();
            this.tabTurnos.ResumeLayout(false);
            this.tabTurnos.PerformLayout();
            this.tabNoParte.ResumeLayout(false);
            this.tabNoParte.PerformLayout();
            this.tabNciD.ResumeLayout(false);
            this.tabNciD.PerformLayout();
            this.tabEmpCoord.ResumeLayout(false);
            this.tabEmpCoord.PerformLayout();
            this.tabProc.ResumeLayout(false);
            this.tabProc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDeptos;
        private System.Windows.Forms.Button btn_dEdit;
        private System.Windows.Forms.Button btn_dNew;
        private System.Windows.Forms.Button btn_dSearch;
        private System.Windows.Forms.Button btn_dDel;
        private System.Windows.Forms.MaskedTextBox dOverHead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dFbu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox dNumDepto;
        private System.Windows.Forms.TextBox dDepto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabCt;
        private System.Windows.Forms.TabPage tabLine;
        private System.Windows.Forms.TabPage tabFbu;
        private System.Windows.Forms.TabPage tabSc;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.MaskedTextBox ohDec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_dAdd;
        private System.Windows.Forms.ComboBox ctDepto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_ctEdit;
        private System.Windows.Forms.Button btn_ctNew;
        private System.Windows.Forms.ComboBox ctFbu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_ctAdd;
        private System.Windows.Forms.MaskedTextBox ct;
        private System.Windows.Forms.Button btn_ctSearch;
        private System.Windows.Forms.TextBox ctDesc;
        private System.Windows.Forms.Button btn_ctDel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_lEdit;
        private System.Windows.Forms.Button btn_lNew;
        private System.Windows.Forms.Button btn_lAdd;
        private System.Windows.Forms.Button btn_lSearch;
        private System.Windows.Forms.Button btn_lDel;
        private System.Windows.Forms.ComboBox lCt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox lDesc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox lDepto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox lFbu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox linea;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblLineId;
        private System.Windows.Forms.Button btn_fEdit;
        private System.Windows.Forms.Button btn_fNew;
        private System.Windows.Forms.Button btn_fAdd;
        private System.Windows.Forms.Button btn_fSearch;
        private System.Windows.Forms.Button btn_fDel;
        private System.Windows.Forms.TextBox fId;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox fDesc;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_scEdit;
        private System.Windows.Forms.Button btn_scNew;
        private System.Windows.Forms.Button btn_scAdd;
        private System.Windows.Forms.Button btn_scSearch;
        private System.Windows.Forms.Button btn_scDel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox scNom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabRelsc;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.ComboBox cmbSup;
        private System.Windows.Forms.CheckedListBox chkListCoord;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.TabPage tabTurnos;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btn_tEdit;
        private System.Windows.Forms.Button btn_tNew;
        private System.Windows.Forms.Button btn_tAdd;
        private System.Windows.Forms.Button btn_tSearch;
        private System.Windows.Forms.Button btn_tDel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabNoParte;
        private System.Windows.Forms.TabPage tabNciD;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.MaskedTextBox tId;
        private System.Windows.Forms.MaskedTextBox tEnt;
        private System.Windows.Forms.MaskedTextBox td3_2;
        private System.Windows.Forms.MaskedTextBox td3_1;
        private System.Windows.Forms.MaskedTextBox td2_1;
        private System.Windows.Forms.MaskedTextBox td2_2;
        private System.Windows.Forms.MaskedTextBox td1_2;
        private System.Windows.Forms.MaskedTextBox td1_1;
        private System.Windows.Forms.MaskedTextBox tSal;
        private System.Windows.Forms.TextBox tHrs;
        private System.Windows.Forms.MaskedTextBox sec;
        private System.Windows.Forms.TextBox np;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btn_npEdit;
        private System.Windows.Forms.Button btn_npNew;
        private System.Windows.Forms.Button btn_npAdd;
        private System.Windows.Forms.Button btn_npSearch;
        private System.Windows.Forms.Button btn_npDel;
        private System.Windows.Forms.ComboBox cmbCodOp;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox codOra;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.MaskedTextBox scId;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtCi;
        private System.Windows.Forms.Button btn_ciEdit;
        private System.Windows.Forms.Button btn_ciNew;
        private System.Windows.Forms.Button btn_ciAdd;
        private System.Windows.Forms.Button btn_ciSearch;
        private System.Windows.Forms.Button btn_ciDel;
        private System.Windows.Forms.TabPage tabEmpCoord;
        private System.Windows.Forms.Label lblerr4;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Button btnEmS;
        private System.Windows.Forms.TextBox txtEmp;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cmbEmpSup;
        private System.Windows.Forms.Button btnEmpSave;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ListBox lstBoxEmpl;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabProc;
        private System.Windows.Forms.Button btn_pEdit;
        private System.Windows.Forms.Button btn_pNew;
        private System.Windows.Forms.Button btn_pAdd;
        private System.Windows.Forms.Button btn_pSearch;
        private System.Windows.Forms.Button btn_pDel;
        private System.Windows.Forms.TextBox txtProc;
        private System.Windows.Forms.Label label42;


    }
}