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
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox7 = new TextBox();
            label7 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(95, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(338, 23);
            textBox1.TabIndex = 0;
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
            // textBox2
            // 
            textBox2.Location = new Point(95, 41);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(338, 23);
            textBox2.TabIndex = 0;
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
            // textBox3
            // 
            textBox3.Location = new Point(95, 70);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(338, 23);
            textBox3.TabIndex = 0;
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
            // textBox4
            // 
            textBox4.Location = new Point(95, 99);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(338, 23);
            textBox4.TabIndex = 0;
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
            // textBox5
            // 
            textBox5.Location = new Point(95, 128);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(338, 23);
            textBox5.TabIndex = 0;
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
            // textBox6
            // 
            textBox6.Location = new Point(95, 157);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(338, 23);
            textBox6.TabIndex = 0;
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
            // textBox7
            // 
            textBox7.Location = new Point(95, 186);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(338, 23);
            textBox7.TabIndex = 0;
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
            // button1
            // 
            button1.Location = new Point(150, 215);
            button1.Name = "button1";
            button1.Size = new Size(201, 23);
            button1.TabIndex = 2;
            button1.Text = "Xác nhận";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmClientDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 252);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmClientDetail";
            Text = "QL XUẤT KHO -KTSX TRÀ VINH";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox7;
        private Label label7;
        private Button button1;
    }
}