namespace HIMASHIFT
{
    partial class dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboard));
            navbar = new Panel();
            btn_keluar = new Button();
            lbl_user = new Label();
            lbl_himashift = new Label();
            pct_profil = new PictureBox();
            ikon = new PictureBox();
            panel1 = new Panel();
            btn_sertifikat = new Button();
            btn_event = new Button();
            btn_absensi = new Button();
            btn_profil = new Button();
            lbl_menu = new Label();
            panelContainer = new Panel();
            navbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pct_profil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ikon).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // navbar
            // 
            navbar.BackColor = Color.FromArgb(30, 86, 160);
            navbar.Controls.Add(btn_keluar);
            navbar.Controls.Add(lbl_user);
            navbar.Controls.Add(lbl_himashift);
            navbar.Controls.Add(pct_profil);
            navbar.Controls.Add(ikon);
            navbar.Dock = DockStyle.Top;
            navbar.Location = new Point(0, 0);
            navbar.Name = "navbar";
            navbar.Size = new Size(1064, 61);
            navbar.TabIndex = 1;
            // 
            // btn_keluar
            // 
            btn_keluar.AutoSize = true;
            btn_keluar.BackColor = Color.White;
            btn_keluar.FlatStyle = FlatStyle.Flat;
            btn_keluar.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_keluar.ForeColor = Color.Black;
            btn_keluar.Location = new Point(906, 9);
            btn_keluar.Name = "btn_keluar";
            btn_keluar.Size = new Size(134, 45);
            btn_keluar.TabIndex = 2;
            btn_keluar.Text = "Keluar";
            btn_keluar.UseVisualStyleBackColor = false;
            btn_keluar.Click += btn_keluar_Click;
            // 
            // lbl_user
            // 
            lbl_user.AutoSize = true;
            lbl_user.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_user.ForeColor = Color.White;
            lbl_user.Location = new Point(671, 15);
            lbl_user.Name = "lbl_user";
            lbl_user.Size = new Size(229, 33);
            lbl_user.TabIndex = 1;
            lbl_user.Text = "Reni Triyaningsih";
            lbl_user.Click += lbl_user_Click;
            // 
            // lbl_himashift
            // 
            lbl_himashift.AutoSize = true;
            lbl_himashift.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_himashift.ForeColor = Color.White;
            lbl_himashift.Location = new Point(79, 15);
            lbl_himashift.Name = "lbl_himashift";
            lbl_himashift.Size = new Size(161, 33);
            lbl_himashift.TabIndex = 1;
            lbl_himashift.Text = "HIMASHIFT";
            // 
            // pct_profil
            // 
            pct_profil.Image = (Image)resources.GetObject("pct_profil.Image");
            pct_profil.Location = new Point(615, 4);
            pct_profil.Name = "pct_profil";
            pct_profil.Size = new Size(50, 50);
            pct_profil.SizeMode = PictureBoxSizeMode.StretchImage;
            pct_profil.TabIndex = 0;
            pct_profil.TabStop = false;
            // 
            // ikon
            // 
            ikon.Image = (Image)resources.GetObject("ikon.Image");
            ikon.Location = new Point(10, 6);
            ikon.Name = "ikon";
            ikon.Size = new Size(50, 50);
            ikon.SizeMode = PictureBoxSizeMode.Zoom;
            ikon.TabIndex = 0;
            ikon.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(214, 228, 240);
            panel1.Controls.Add(btn_sertifikat);
            panel1.Controls.Add(btn_event);
            panel1.Controls.Add(btn_absensi);
            panel1.Controls.Add(btn_profil);
            panel1.Controls.Add(lbl_menu);
            panel1.Location = new Point(0, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 623);
            panel1.TabIndex = 2;
            // 
            // btn_sertifikat
            // 
            btn_sertifikat.AutoSize = true;
            btn_sertifikat.BackColor = Color.White;
            btn_sertifikat.FlatStyle = FlatStyle.Flat;
            btn_sertifikat.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_sertifikat.ForeColor = Color.Black;
            btn_sertifikat.Location = new Point(48, 403);
            btn_sertifikat.Name = "btn_sertifikat";
            btn_sertifikat.Size = new Size(143, 45);
            btn_sertifikat.TabIndex = 2;
            btn_sertifikat.Text = "Sertifikat";
            btn_sertifikat.UseVisualStyleBackColor = false;
            btn_sertifikat.Click += btn_sertifikat_Click;
            // 
            // btn_event
            // 
            btn_event.AutoSize = true;
            btn_event.BackColor = Color.White;
            btn_event.FlatStyle = FlatStyle.Flat;
            btn_event.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_event.ForeColor = Color.Black;
            btn_event.Location = new Point(48, 315);
            btn_event.Name = "btn_event";
            btn_event.Size = new Size(143, 45);
            btn_event.TabIndex = 2;
            btn_event.Text = "Event";
            btn_event.UseVisualStyleBackColor = false;
            btn_event.Click += btn_event_Click;
            // 
            // btn_absensi
            // 
            btn_absensi.AutoSize = true;
            btn_absensi.BackColor = Color.White;
            btn_absensi.FlatStyle = FlatStyle.Flat;
            btn_absensi.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_absensi.ForeColor = Color.Black;
            btn_absensi.Location = new Point(48, 227);
            btn_absensi.Name = "btn_absensi";
            btn_absensi.Size = new Size(143, 45);
            btn_absensi.TabIndex = 2;
            btn_absensi.Text = "Absensi";
            btn_absensi.UseVisualStyleBackColor = false;
            btn_absensi.Click += btn_absensi_Click;
            // 
            // btn_profil
            // 
            btn_profil.AutoSize = true;
            btn_profil.BackColor = Color.White;
            btn_profil.FlatStyle = FlatStyle.Flat;
            btn_profil.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_profil.ForeColor = Color.Black;
            btn_profil.Location = new Point(48, 139);
            btn_profil.Name = "btn_profil";
            btn_profil.Size = new Size(143, 45);
            btn_profil.TabIndex = 2;
            btn_profil.Text = "Profil";
            btn_profil.UseVisualStyleBackColor = false;
            btn_profil.Click += btn_profil_Click;
            // 
            // lbl_menu
            // 
            lbl_menu.AutoSize = true;
            lbl_menu.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_menu.ForeColor = Color.Black;
            lbl_menu.Location = new Point(12, 39);
            lbl_menu.Name = "lbl_menu";
            lbl_menu.Size = new Size(87, 33);
            lbl_menu.TabIndex = 1;
            lbl_menu.Text = "Menu";
            // 
            // panelContainer
            // 
            panelContainer.Location = new Point(255, 61);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(810, 621);
            panelContainer.TabIndex = 3;
            // 
            // dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 681);
            Controls.Add(panelContainer);
            Controls.Add(panel1);
            Controls.Add(navbar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "dashboard";
            navbar.ResumeLayout(false);
            navbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pct_profil).EndInit();
            ((System.ComponentModel.ISupportInitialize)ikon).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel navbar;
        private Button btn_keluar;
        private Label lbl_himashift;
        private PictureBox ikon;
        private PictureBox pct_profil;
        private Label lbl_user;
        private Panel panel1;
        private Button btn_sertifikat;
        private Button btn_event;
        private Button btn_absensi;
        private Button btn_profil;
        private Label lbl_menu;
        private Panel panelContainer;
    }
}