namespace ClientView
{
    partial class frmClient
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
            groupBox1 = new GroupBox();
            lbLine = new Label();
            groupBox2 = new GroupBox();
            txtCF = new TextBox();
            groupBox3 = new GroupBox();
            txtCODE = new TextBox();
            groupBox4 = new GroupBox();
            txtQuantity = new TextBox();
            btSend = new Button();
            dxErr = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dxErr).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbLine);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(470, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "LINE";
            // 
            // lbLine
            // 
            lbLine.AutoSize = true;
            lbLine.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLine.Location = new Point(180, 37);
            lbLine.Name = "lbLine";
            lbLine.Size = new Size(83, 32);
            lbLine.TabIndex = 0;
            lbLine.Text = "label1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtCF);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 100);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(470, 100);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "TÊN C/F";
            // 
            // txtCF
            // 
            txtCF.Location = new Point(12, 41);
            txtCF.Name = "txtCF";
            txtCF.Size = new Size(446, 23);
            txtCF.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtCODE);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 200);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(470, 100);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "CODE";
            // 
            // txtCODE
            // 
            txtCODE.Location = new Point(12, 37);
            txtCODE.Name = "txtCODE";
            txtCODE.Size = new Size(446, 23);
            txtCODE.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtQuantity);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(0, 300);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(470, 100);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "SỐ LƯỢNG";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(12, 41);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(446, 23);
            txtQuantity.TabIndex = 0;
            // 
            // btSend
            // 
            btSend.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btSend.Location = new Point(120, 406);
            btSend.Name = "btSend";
            btSend.Size = new Size(216, 50);
            btSend.TabIndex = 4;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // dxErr
            // 
            dxErr.ContainerControl = this;
            // 
            // frmClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 468);
            Controls.Add(btSend);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmClient";
            Text = "frmClient";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dxErr).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button btSend;
        private Label lbLine;
        private TextBox txtCF;
        private TextBox txtCODE;
        private TextBox txtQuantity;
        private ErrorProvider dxErr;
    }
}