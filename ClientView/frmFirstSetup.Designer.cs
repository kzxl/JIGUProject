namespace ClientView
{
    partial class frmFirstSetup
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
            label1 = new Label();
            txtLine = new TextBox();
            label2 = new Label();
            txtAPIUrl = new TextBox();
            label3 = new Label();
            txtFolder = new TextBox();
            btSave = new Button();
            btCheckAPI = new Button();
            dxErr = new ErrorProvider(components);
            fbdFolder = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)dxErr).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 15);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "LINE";
            // 
            // txtLine
            // 
            txtLine.Location = new Point(106, 12);
            txtLine.Name = "txtLine";
            txtLine.Size = new Size(271, 23);
            txtLine.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 44);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 0;
            label2.Text = "API Url";
            // 
            // txtAPIUrl
            // 
            txtAPIUrl.Location = new Point(106, 41);
            txtAPIUrl.Name = "txtAPIUrl";
            txtAPIUrl.Size = new Size(216, 23);
            txtAPIUrl.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 73);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 0;
            label3.Text = "Folder Log";
            // 
            // txtFolder
            // 
            txtFolder.Location = new Point(106, 70);
            txtFolder.Name = "txtFolder";
            txtFolder.Size = new Size(271, 23);
            txtFolder.TabIndex = 1;
            txtFolder.Click += txtFolder_Click;
            // 
            // btSave
            // 
            btSave.Location = new Point(106, 99);
            btSave.Name = "btSave";
            btSave.Size = new Size(271, 23);
            btSave.TabIndex = 2;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btCheckAPI
            // 
            btCheckAPI.Location = new Point(328, 41);
            btCheckAPI.Name = "btCheckAPI";
            btCheckAPI.Size = new Size(49, 23);
            btCheckAPI.TabIndex = 3;
            btCheckAPI.Text = "Check";
            btCheckAPI.UseVisualStyleBackColor = true;
            btCheckAPI.Click += btCheckAPI_Click;
            // 
            // dxErr
            // 
            dxErr.ContainerControl = this;
            // 
            // frmFirstSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 139);
            Controls.Add(btCheckAPI);
            Controls.Add(btSave);
            Controls.Add(txtFolder);
            Controls.Add(label3);
            Controls.Add(txtAPIUrl);
            Controls.Add(label2);
            Controls.Add(txtLine);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmFirstSetup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmFirstSetup";
            Load += frmClientFirstSetup_Load;
            ((System.ComponentModel.ISupportInitialize)dxErr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtLine;
        private Label label2;
        private TextBox txtAPIUrl;
        private Label label3;
        private TextBox txtFolder;
        private Button btSave;
        private Button btCheckAPI;
        private ErrorProvider dxErr;
        private FolderBrowserDialog fbdFolder;
    }
}