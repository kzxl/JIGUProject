namespace ClientView
{
    partial class frmClientDetail
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
            txtCF = new TextBox();
            label1 = new Label();
            txtCODE = new TextBox();
            label2 = new Label();
            txtQuantity = new TextBox();
            label3 = new Label();
            txtContent = new TextBox();
            label4 = new Label();
            txtReason = new TextBox();
            label5 = new Label();
            txtFullname = new TextBox();
            label6 = new Label();
            txtUsername = new TextBox();
            label7 = new Label();
            btConfirm = new Button();
            dxErr = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dxErr).BeginInit();
            SuspendLayout();
            // 
            // txtCF
            // 
            txtCF.Location = new Point(95, 12);
            txtCF.Name = "txtCF";
            txtCF.Size = new Size(338, 23);
            txtCF.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Tên CF";
            // 
            // txtCODE
            // 
            txtCODE.Location = new Point(95, 41);
            txtCODE.Name = "txtCODE";
            txtCODE.Size = new Size(338, 23);
            txtCODE.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 44);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "CODE";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(95, 70);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(338, 23);
            txtQuantity.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 73);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 1;
            label3.Text = "Số Lượng";
            // 
            // txtContent
            // 
            txtContent.Location = new Point(95, 99);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(338, 23);
            txtContent.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 102);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 1;
            label4.Text = "Nội Dung";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(95, 128);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(338, 23);
            txtReason.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 131);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 1;
            label5.Text = "Nguyên Nhân";
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(95, 157);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(338, 23);
            txtFullname.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 160);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 1;
            label6.Text = "Tên  Nhân Viên";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(95, 186);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(338, 23);
            txtUsername.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 189);
            label7.Name = "label7";
            label7.Size = new Size(82, 15);
            label7.TabIndex = 1;
            label7.Text = "Mã Nhân Viên";
            // 
            // btConfirm
            // 
            btConfirm.Location = new Point(150, 215);
            btConfirm.Name = "btConfirm";
            btConfirm.Size = new Size(201, 23);
            btConfirm.TabIndex = 2;
            btConfirm.Text = "Xác nhận";
            btConfirm.UseVisualStyleBackColor = true;
            btConfirm.Click += btConfirm_Click;
            // 
            // dxErr
            // 
            dxErr.ContainerControl = this;
            // 
            // frmClientDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 252);
            Controls.Add(btConfirm);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(txtFullname);
            Controls.Add(txtReason);
            Controls.Add(txtContent);
            Controls.Add(txtQuantity);
            Controls.Add(txtCODE);
            Controls.Add(txtCF);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmClientDetail";
            Text = "QL XUẤT KHO -KTSX TRÀ VINH";
            FormClosing += frmClientDetail_FormClosing;
            FormClosed += frmClientDetail_FormClosed;
            Load += frmClientDetail_Load;
            ((System.ComponentModel.ISupportInitialize)dxErr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCF;
        private Label label1;
        private TextBox txtCODE;
        private Label label2;
        private TextBox txtQuantity;
        private Label label3;
        private TextBox txtContent;
        private Label label4;
        private TextBox txtReason;
        private Label label5;
        private TextBox txtFullname;
        private Label label6;
        private TextBox txtUsername;
        private Label label7;
        private Button btConfirm;
        private ErrorProvider dxErr;
    }
}