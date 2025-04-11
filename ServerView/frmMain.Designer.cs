namespace ServerView
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            gv = new DataGridView();
            Line = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            lbLine = new Label();
            groupBox3 = new GroupBox();
            lbCF = new Label();
            groupBox4 = new GroupBox();
            lbCode = new Label();
            groupBox5 = new GroupBox();
            lbQuantity = new Label();
            groupBox6 = new GroupBox();
            lbLocation = new Label();
            lbQuantity2 = new Label();
            lbQuantity1 = new Label();
            ckLocation2 = new CheckBox();
            ckLocation1 = new CheckBox();
            btConfirm = new Button();
            btSetting = new Button();
            updateDateTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)gv).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // gv
            // 
            gv.AllowUserToAddRows = false;
            gv.AllowUserToDeleteRows = false;
            gv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gv.Columns.AddRange(new DataGridViewColumn[] { Line, Date });
            gv.Dock = DockStyle.Fill;
            gv.Location = new Point(3, 19);
            gv.Name = "gv";
            gv.ReadOnly = true;
            gv.Size = new Size(393, 608);
            gv.TabIndex = 0;
            gv.CellClick += gv_CellClick;
            // 
            // Line
            // 
            Line.DataPropertyName = "Line";
            Line.HeaderText = "LINE";
            Line.Name = "Line";
            Line.ReadOnly = true;
            Line.Width = 200;
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "Ngày gửi";
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 150;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(gv);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 630);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "LINE";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lbLine);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(399, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(700, 100);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "LINE";
            // 
            // lbLine
            // 
            lbLine.AutoSize = true;
            lbLine.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLine.Location = new Point(300, 34);
            lbLine.Name = "lbLine";
            lbLine.Size = new Size(79, 40);
            lbLine.TabIndex = 0;
            lbLine.Text = "LINE";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbCF);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(399, 100);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(700, 100);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tên CF";
            // 
            // lbCF
            // 
            lbCF.AutoSize = true;
            lbCF.Location = new Point(65, 43);
            lbCF.Name = "lbCF";
            lbCF.Size = new Size(16, 15);
            lbCF.TabIndex = 0;
            lbCF.Text = "...";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbCode);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(399, 200);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(700, 100);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "CODE";
            // 
            // lbCode
            // 
            lbCode.AutoSize = true;
            lbCode.Location = new Point(65, 49);
            lbCode.Name = "lbCode";
            lbCode.Size = new Size(16, 15);
            lbCode.TabIndex = 0;
            lbCode.Text = "...";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(lbQuantity);
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Location = new Point(399, 300);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(700, 100);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Quantity";
            // 
            // lbQuantity
            // 
            lbQuantity.AutoSize = true;
            lbQuantity.Location = new Point(65, 62);
            lbQuantity.Name = "lbQuantity";
            lbQuantity.Size = new Size(16, 15);
            lbQuantity.TabIndex = 0;
            lbQuantity.Text = "...";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lbLocation);
            groupBox6.Controls.Add(lbQuantity2);
            groupBox6.Controls.Add(lbQuantity1);
            groupBox6.Controls.Add(ckLocation2);
            groupBox6.Controls.Add(ckLocation1);
            groupBox6.Dock = DockStyle.Top;
            groupBox6.Location = new Point(399, 400);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(700, 100);
            groupBox6.TabIndex = 3;
            groupBox6.TabStop = false;
            groupBox6.Text = "Vị Trí";
            // 
            // lbLocation
            // 
            lbLocation.AutoSize = true;
            lbLocation.Location = new Point(65, 72);
            lbLocation.Name = "lbLocation";
            lbLocation.Size = new Size(16, 15);
            lbLocation.TabIndex = 0;
            lbLocation.Text = "...";
            // 
            // lbQuantity2
            // 
            lbQuantity2.AutoSize = true;
            lbQuantity2.Location = new Point(474, 44);
            lbQuantity2.Name = "lbQuantity2";
            lbQuantity2.Size = new Size(48, 15);
            lbQuantity2.TabIndex = 1;
            lbQuantity2.Text = "Hiện có";
            // 
            // lbQuantity1
            // 
            lbQuantity1.AutoSize = true;
            lbQuantity1.Location = new Point(152, 44);
            lbQuantity1.Name = "lbQuantity1";
            lbQuantity1.Size = new Size(48, 15);
            lbQuantity1.TabIndex = 1;
            lbQuantity1.Text = "Hiện có";
            // 
            // ckLocation2
            // 
            ckLocation2.AutoSize = true;
            ckLocation2.Location = new Point(474, 22);
            ckLocation2.Name = "ckLocation2";
            ckLocation2.Size = new Size(74, 19);
            ckLocation2.TabIndex = 0;
            ckLocation2.Text = "Vị trí mới";
            ckLocation2.UseVisualStyleBackColor = true;
            // 
            // ckLocation1
            // 
            ckLocation1.AutoSize = true;
            ckLocation1.Location = new Point(152, 22);
            ckLocation1.Name = "ckLocation1";
            ckLocation1.Size = new Size(66, 19);
            ckLocation1.TabIndex = 0;
            ckLocation1.Text = "Vị trí cũ";
            ckLocation1.UseVisualStyleBackColor = true;
            // 
            // btConfirm
            // 
            btConfirm.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btConfirm.Location = new Point(604, 522);
            btConfirm.Name = "btConfirm";
            btConfirm.Size = new Size(320, 86);
            btConfirm.TabIndex = 4;
            btConfirm.Text = "Confirm";
            btConfirm.UseVisualStyleBackColor = true;
            btConfirm.Click += btConfirm_Click;
            // 
            // btSetting
            // 
            btSetting.Location = new Point(405, 506);
            btSetting.Name = "btSetting";
            btSetting.Size = new Size(75, 23);
            btSetting.TabIndex = 5;
            btSetting.Text = "Setting";
            btSetting.UseVisualStyleBackColor = true;
            btSetting.Click += btSetup_Click;
            // 
            // updateDateTimer
            // 
            updateDateTimer.Enabled = true;
            updateDateTimer.Interval = 1500;
            updateDateTimer.Tick += updateDateTimer_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 630);
            Controls.Add(btSetting);
            Controls.Add(btConfirm);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMain";
            FormClosed += frmServer_FormClosed;
            Load += frmServer_Load;
            ((System.ComponentModel.ISupportInitialize)gv).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gv;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Button btConfirm;
        private Button btSetting;
        private Label lbQuantity2;
        private Label lbQuantity1;
        private CheckBox ckLocation2;
        private CheckBox ckLocation1;
        private Label lbLine;
        private Label lbCF;
        private Label lbCode;
        private Label lbQuantity;
        private Label lbLocation;
        private DataGridViewTextBoxColumn Line;
        private DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Timer updateDateTimer;
    }
}