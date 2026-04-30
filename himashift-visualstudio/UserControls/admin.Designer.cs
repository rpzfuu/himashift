namespace HIMASHIFT.UserControls
{
    partial class admin
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
            tb_name = new TextBox();
            lbl_nim = new Label();
            SuspendLayout();
            // 
            // btn_masuk
            // 
            btn_masuk.AutoSize = true;
            btn_masuk.BackColor = Color.White;
            btn_masuk.FlatStyle = FlatStyle.Flat;
            btn_masuk.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btn_masuk.ForeColor = Color.Black;
            btn_masuk.Location = new Point(641, 409);
            btn_masuk.Name = "btn_masuk";
            btn_masuk.Size = new Size(89, 37);
            btn_masuk.TabIndex = 14;
            btn_masuk.Text = "Masuk";
            btn_masuk.UseVisualStyleBackColor = false;
            btn_masuk.Click += btn_masuk_Click;
            // 
            // tb_pw
            // 
            tb_pw.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tb_pw.Location = new Point(335, 330);
            tb_pw.Name = "tb_pw";
            tb_pw.Size = new Size(395, 34);
            tb_pw.TabIndex = 13;
            tb_pw.UseSystemPasswordChar = true;
            // 
            // lbl_pw
            // 
            lbl_pw.AutoSize = true;
            lbl_pw.BackColor = Color.Transparent;
            lbl_pw.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_pw.ForeColor = Color.White;
            lbl_pw.Location = new Point(335, 281);
            lbl_pw.Name = "lbl_pw";
            lbl_pw.Size = new Size(110, 25);
            lbl_pw.TabIndex = 15;
            lbl_pw.Text = "Password";
            // 
            // tb_name
            // 
            tb_name.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tb_name.Location = new Point(335, 223);
            tb_name.Name = "tb_name";
            tb_name.Size = new Size(395, 34);
            tb_name.TabIndex = 11;
            // 
            // lbl_nim
            // 
            lbl_nim.AutoSize = true;
            lbl_nim.BackColor = Color.Transparent;
            lbl_nim.Font = new Font("Inter", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_nim.ForeColor = Color.White;
            lbl_nim.Location = new Point(335, 174);
            lbl_nim.Name = "lbl_nim";
            lbl_nim.Size = new Size(113, 25);
            lbl_nim.TabIndex = 12;
            lbl_nim.Text = "Username";
            // 
            // admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btn_masuk);
            Controls.Add(tb_pw);
            Controls.Add(lbl_pw);
            Controls.Add(tb_name);
            Controls.Add(lbl_nim);
            Name = "admin";
            Size = new Size(1064, 620);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_masuk;
        private TextBox tb_pw;
        private Label lbl_pw;
        private TextBox tb_name;
        private Label lbl_nim;
    }
}
