namespace HIMASHIFT.UserControls
{
    partial class dashboard_sertifikat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_masuk = new Button();
            tb_pw = new TextBox();
            lbl_pw = new Label();
            tb_nim = new TextBox();
            lbl_nim = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // btn_masuk
            // 
            btn_masuk.AutoSize = true;
            btn_masuk.BackColor = Color.White;
            btn_masuk.FlatStyle = FlatStyle.Flat;
            btn_masuk.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_masuk.ForeColor = Color.Black;
            btn_masuk.Location = new Point(342, 474);
            btn_masuk.Name = "btn_masuk";
            btn_masuk.Size = new Size(124, 37);
            btn_masuk.TabIndex = 13;
            btn_masuk.Text = "Download";
            btn_masuk.UseVisualStyleBackColor = false;
            // 
            // tb_pw
            // 
            tb_pw.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tb_pw.Location = new Point(207, 271);
            tb_pw.Name = "tb_pw";
            tb_pw.Size = new Size(395, 34);
            tb_pw.TabIndex = 12;
            tb_pw.UseSystemPasswordChar = true;
            // 
            // lbl_pw
            // 
            lbl_pw.AutoSize = true;
            lbl_pw.BackColor = Color.Transparent;
            lbl_pw.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_pw.ForeColor = Color.Black;
            lbl_pw.Location = new Point(207, 231);
            lbl_pw.Name = "lbl_pw";
            lbl_pw.Size = new Size(134, 25);
            lbl_pw.TabIndex = 14;
            lbl_pw.Text = "Nama Acara";
            // 
            // tb_nim
            // 
            tb_nim.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tb_nim.Location = new Point(207, 152);
            tb_nim.Name = "tb_nim";
            tb_nim.Size = new Size(395, 34);
            tb_nim.TabIndex = 10;
            // 
            // lbl_nim
            // 
            lbl_nim.AutoSize = true;
            lbl_nim.BackColor = Color.Transparent;
            lbl_nim.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_nim.ForeColor = Color.Black;
            lbl_nim.Location = new Point(207, 114);
            lbl_nim.Name = "lbl_nim";
            lbl_nim.Size = new Size(104, 25);
            lbl_nim.TabIndex = 11;
            lbl_nim.Text = "Job Desk";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(207, 343);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 14;
            label1.Text = "Tanggal";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(207, 383);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(395, 34);
            textBox1.TabIndex = 12;
            textBox1.UseSystemPasswordChar = true;
            // 
            // dashboard_sertifikat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btn_masuk);
            Controls.Add(textBox1);
            Controls.Add(tb_pw);
            Controls.Add(label1);
            Controls.Add(lbl_pw);
            Controls.Add(tb_nim);
            Controls.Add(lbl_nim);
            Name = "dashboard_sertifikat";
            Size = new Size(810, 621);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_masuk;
        private TextBox tb_pw;
        private Label lbl_pw;
        private TextBox tb_nim;
        private Label lbl_nim;
        private Label label1;
        private TextBox textBox1;
    }
}
