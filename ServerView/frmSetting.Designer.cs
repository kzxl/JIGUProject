namespace ServerView
{
    partial class frmSetting
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
            label1 = new Label();
            txtCF = new TextBox();
            btSave = new Button();
            label2 = new Label();
            txtLogs = new TextBox();
            label3 = new Label();
            txtAPI = new TextBox();
            fbdPath = new FolderBrowserDialog();
            ofdPath = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "CF File";
            // 
            // txtCF
            // 
            txtCF.Location = new Point(126, 12);
            txtCF.Name = "txtCF";
            txtCF.Size = new Size(303, 23);
            txtCF.TabIndex = 1;
            txtCF.Click += txtCF_Click;
            // 
            // btSave
            // 
            btSave.Location = new Point(173, 99);
            btSave.Name = "btSave";
            btSave.Size = new Size(190, 23);
            btSave.TabIndex = 2;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 73);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 0;
            label2.Text = "Log Folder";
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(126, 70);
            txtLogs.Name = "txtLogs";
            txtLogs.Size = new Size(303, 23);
            txtLogs.TabIndex = 1;
            txtLogs.Click += txtLogs_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 44);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 0;
            label3.Text = "Server IP";
            // 
            // txtAPI
            // 
            txtAPI.Location = new Point(126, 41);
            txtAPI.Name = "txtAPI";
            txtAPI.Size = new Size(303, 23);
            txtAPI.TabIndex = 1;
            // 
            // ofdPath
            // 
            ofdPath.FileName = "openFileDialog1";
            // 
            // frmSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 150);
            Controls.Add(btSave);
            Controls.Add(txtAPI);
            Controls.Add(label3);
            Controls.Add(txtLogs);
            Controls.Add(label2);
            Controls.Add(txtCF);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmSetting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSetting";
            FormClosed += frmServer_Setting_FormClosed;
            Load += frmServer_Setting_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCF;
        private Button btSave;
        private Label label2;
        private TextBox txtLogs;
        private Label label3;
        private TextBox txtAPI;
        private FolderBrowserDialog fbdPath;
        private OpenFileDialog ofdPath;
    }
}