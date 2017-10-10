namespace AutoCodeTool
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            this.panLeft = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtassembly = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtschema = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtnamespace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCreate = new SierFormsControlLibrary.SButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkEntity = new System.Windows.Forms.CheckBox();
            this.checkMapXML = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxComboBox1 = new PresentationControls.CheckBoxComboBox();
            this.btnExit = new SierFormsControlLibrary.SButton();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.btnTestLogin = new SierFormsControlLibrary.SButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cbxTables = new System.Windows.Forms.ComboBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDatas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lace = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDataVersion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkcreateBroker = new System.Windows.Forms.CheckBox();
            this.panLeft.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panLeft
            // 
            this.panLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panLeft.Controls.Add(this.groupBox2);
            this.panLeft.Controls.Add(this.btnCreate);
            this.panLeft.Controls.Add(this.groupBox1);
            this.panLeft.Controls.Add(this.panel1);
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 0);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(359, 532);
            this.panLeft.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtpath);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtassembly);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtschema);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtnamespace);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 150);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "架构";
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(88, 119);
            this.txtpath.Name = "txtpath";
            this.txtpath.ReadOnly = true;
            this.txtpath.Size = new System.Drawing.Size(238, 25);
            this.txtpath.TabIndex = 4;
            this.txtpath.Text = "SNTON";
            this.txtpath.Click += new System.EventHandler(this.txtpath_Click);
            this.txtpath.TextChanged += new System.EventHandler(this.tbxServerAddress_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "path";
            // 
            // txtassembly
            // 
            this.txtassembly.Location = new System.Drawing.Point(88, 90);
            this.txtassembly.Name = "txtassembly";
            this.txtassembly.Size = new System.Drawing.Size(238, 25);
            this.txtassembly.TabIndex = 4;
            this.txtassembly.Text = "SNTON";
            this.txtassembly.TextChanged += new System.EventHandler(this.tbxServerAddress_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "assembly";
            // 
            // txtschema
            // 
            this.txtschema.Location = new System.Drawing.Point(88, 59);
            this.txtschema.Name = "txtschema";
            this.txtschema.Size = new System.Drawing.Size(238, 25);
            this.txtschema.TabIndex = 4;
            this.txtschema.Text = "SNTON";
            this.txtschema.TextChanged += new System.EventHandler(this.tbxServerAddress_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "schema";
            // 
            // txtnamespace
            // 
            this.txtnamespace.Location = new System.Drawing.Point(88, 27);
            this.txtnamespace.Name = "txtnamespace";
            this.txtnamespace.Size = new System.Drawing.Size(238, 25);
            this.txtnamespace.TabIndex = 2;
            this.txtnamespace.Text = "SNTON.Entities.DBTables";
            this.txtnamespace.TextChanged += new System.EventHandler(this.tbxServerAddress_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "namespace";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(3, 504);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkcreateBroker);
            this.groupBox1.Controls.Add(this.checkEntity);
            this.groupBox1.Controls.Add(this.checkMapXML);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 60);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成";
            // 
            // checkEntity
            // 
            this.checkEntity.AutoSize = true;
            this.checkEntity.Location = new System.Drawing.Point(217, 24);
            this.checkEntity.Name = "checkEntity";
            this.checkEntity.Size = new System.Drawing.Size(59, 19);
            this.checkEntity.TabIndex = 0;
            this.checkEntity.Text = "实体";
            this.checkEntity.UseVisualStyleBackColor = true;
            // 
            // checkMapXML
            // 
            this.checkMapXML.AutoSize = true;
            this.checkMapXML.Location = new System.Drawing.Point(11, 24);
            this.checkMapXML.Name = "checkMapXML";
            this.checkMapXML.Size = new System.Drawing.Size(77, 19);
            this.checkMapXML.TabIndex = 0;
            this.checkMapXML.Text = "MapXML";
            this.checkMapXML.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxComboBox1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.txtServerAddress);
            this.panel1.Controls.Add(this.btnTestLogin);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.cbxTables);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxDatas);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lace);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbxDataVersion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 250);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxComboBox1
            // 
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox1.CheckBoxProperties = checkBoxProperties2;
            this.checkBoxComboBox1.DisplayMemberSingleItem = "";
            this.checkBoxComboBox1.FormattingEnabled = true;
            this.checkBoxComboBox1.Location = new System.Drawing.Point(100, 188);
            this.checkBoxComboBox1.Name = "checkBoxComboBox1";
            this.checkBoxComboBox1.Size = new System.Drawing.Size(223, 23);
            this.checkBoxComboBox1.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(100, 119);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "注销";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(100, 3);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(226, 25);
            this.txtServerAddress.TabIndex = 0;
            this.txtServerAddress.Text = "192.168.1.117";
            this.txtServerAddress.TextChanged += new System.EventHandler(this.tbxServerAddress_TextChanged);
            // 
            // btnTestLogin
            // 
            this.btnTestLogin.Location = new System.Drawing.Point(12, 119);
            this.btnTestLogin.Name = "btnTestLogin";
            this.btnTestLogin.Size = new System.Drawing.Size(83, 23);
            this.btnTestLogin.TabIndex = 3;
            this.btnTestLogin.Text = "测试连接";
            this.btnTestLogin.UseVisualStyleBackColor = true;
            this.btnTestLogin.Click += new System.EventHandler(this.btnTestLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(100, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(226, 25);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "sa";
            this.txtUsername.TextChanged += new System.EventHandler(this.tbxServerAddress_TextChanged);
            // 
            // cbxTables
            // 
            this.cbxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTables.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxTables.FormattingEnabled = true;
            this.cbxTables.Location = new System.Drawing.Point(100, 217);
            this.cbxTables.Name = "cbxTables";
            this.cbxTables.Size = new System.Drawing.Size(226, 23);
            this.cbxTables.TabIndex = 2;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(100, 83);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(226, 25);
            this.txtPwd.TabIndex = 0;
            this.txtPwd.Text = "123";
            this.txtPwd.TextChanged += new System.EventHandler(this.tbxServerAddress_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "表";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器地址";
            // 
            // cbxDatas
            // 
            this.cbxDatas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxDatas.FormattingEnabled = true;
            this.cbxDatas.Location = new System.Drawing.Point(100, 148);
            this.cbxDatas.Name = "cbxDatas";
            this.cbxDatas.Size = new System.Drawing.Size(226, 23);
            this.cbxDatas.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "登录名";
            // 
            // lace
            // 
            this.lace.AutoSize = true;
            this.lace.Location = new System.Drawing.Point(13, 151);
            this.lace.Name = "lace";
            this.lace.Size = new System.Drawing.Size(52, 15);
            this.lace.TabIndex = 1;
            this.lace.Text = "数据库";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "密码";
            // 
            // cbxDataVersion
            // 
            this.cbxDataVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDataVersion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxDataVersion.FormattingEnabled = true;
            this.cbxDataVersion.Items.AddRange(new object[] {
            "SQL 2000",
            "SQL 2005",
            "SQL 2008",
            "SQL 2012",
            "SQL 2016",
            "Oracle",
            "MySQL"});
            this.cbxDataVersion.Location = new System.Drawing.Point(100, 30);
            this.cbxDataVersion.Name = "cbxDataVersion";
            this.cbxDataVersion.Size = new System.Drawing.Size(226, 23);
            this.cbxDataVersion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库版本";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(359, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(649, 532);
            this.dataGridView1.TabIndex = 3;
            // 
            // checkcreateBroker
            // 
            this.checkcreateBroker.AutoSize = true;
            this.checkcreateBroker.Location = new System.Drawing.Point(99, 24);
            this.checkcreateBroker.Name = "checkcreateBroker";
            this.checkcreateBroker.Size = new System.Drawing.Size(107, 19);
            this.checkcreateBroker.TabIndex = 0;
            this.checkcreateBroker.Text = "创建Broker";
            this.checkcreateBroker.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 532);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panLeft);
            this.Name = "FrmMain";
            this.Text = "代码生成器";
            this.panLeft.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLeft;
        private System.Windows.Forms.ComboBox cbxDataVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox cbxTables;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxDatas;
        private System.Windows.Forms.Label lace;
        private SierFormsControlLibrary.SButton btnExit;
        private SierFormsControlLibrary.SButton btnTestLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtschema;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkEntity;
        private System.Windows.Forms.CheckBox checkMapXML;
        private SierFormsControlLibrary.SButton btnCreate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtnamespace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtassembly;
        private System.Windows.Forms.Label label7;
        private PresentationControls.CheckBoxComboBox checkBoxComboBox1;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkcreateBroker;
    }
}

