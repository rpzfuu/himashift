namespace HIMASHIFT.UserControls
{
    partial class beranda
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
            label1 = new Label();
            btn_masuk = new Button();
            tb_pw = new TextBox();
            lbl_pw = new Label();
            tb_nim = new TextBox();
            lbl_nim = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Inter", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(86, 162);
            label1.Name = "label1";
            label1.Size = new Size(392, 296);
            label1.TabIndex = 10;
            label1.Text = "HIMASHIFT\r\n\r\n \r\nHIMASHIFT adalah layanan online untuk Himpunan Mahasiswa Sistem Informasi, memfasilitasi pengecekan jadwal, absensi, dan pelacakan pencapaian kepengurusan.";
            // 
            // btn_masuk
            // 
            btn_masuk.AutoSize = true;
            btn_masuk.BackColor = Color.White;
            btn_masuk.FlatStyle = FlatStyle.Flat;
            btn_masuk.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_masuk.ForeColor = Color.Black;
            btn_masuk.Location = new Point(889, 421);
            btn_masuk.Name = "btn_masuk";
            btn_masuk.Size = new Size(89, 37);
            btn_masuk.TabIndex = 8;
            btn_masuk.Text = "Masuk";
            btn_masuk.UseVisualStyleBackColor = false;
            btn_masuk.Click += btn_masuk_Click;
            // 
            // tb_pw
            // 
            tb_pw.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tb_pw.Location = new Point(583, 342);
            tb_pw.Name = "tb_pw";
            tb_pw.Size = new Size(395, 34);
            tb_pw.TabIndex = 7;
            tb_pw.UseSystemPasswordChar = true;
            // 
            // lbl_pw
            // 
            lbl_pw.AutoSize = true;
            lbl_pw.BackColor = Color.Transparent;
            lbl_pw.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_pw.ForeColor = Color.White;
            lbl_pw.Location = new Point(583, 293);
            lbl_pw.Name = "lbl_pw";
            lbl_pw.Size = new Size(110, 25);
            lbl_pw.TabIndex = 9;
            lbl_pw.Text = "Password";
            // 
            // tb_nim
            // 
            tb_nim.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tb_nim.Location = new Point(583, 235);
            tb_nim.Name = "tb_nim";
            tb_nim.Size = new Size(395, 34);
            tb_nim.TabIndex = 5;
            // 
            // lbl_nim
            // 
            lbl_nim.AutoSize = true;
            lbl_nim.BackColor = Color.Transparent;
            lbl_nim.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_nim.ForeColor = Color.White;
            lbl_nim.Location = new Point(583, 186);
            lbl_nim.Name = "lbl_nim";
            lbl_nim.Size = new Size(53, 25);
            lbl_nim.TabIndex = 6;
            lbl_nim.Text = "NIM";
            // 
            // beranda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(label1);
            Controls.Add(btn_masuk);
            Controls.Add(tb_pw);
            Controls.Add(lbl_pw);
            Controls.Add(tb_nim);
            Controls.Add(lbl_nim);
            Name = "beranda";
            Size = new Size(1064, 620);
            Load += beranda_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_masuk;
        private TextBox tb_pw;
        private Label lbl_pw;
        private TextBox tb_nim;
        private Label lbl_nim;
    }
}
