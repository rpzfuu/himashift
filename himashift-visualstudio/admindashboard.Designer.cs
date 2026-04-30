namespace HIMASHIFT
{
    partial class admindashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admindashboard));
            lbl_user = new Label();
            ikon = new PictureBox();
            navbar = new Panel();
            btn_keluar = new Button();
            lbl_himashift = new Label();
            pct_profil = new PictureBox();
            btn_absensi = new Button();
            lbl_menu = new Label();
            panel1 = new Panel();
            btn_kehadiran = new Button();
            btn_event = new Button();
            btn_mahasiswa = new Button();
            panelContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)ikon).BeginInit();
            navbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pct_profil).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_user
            // 
            lbl_user.AutoSize = true;
            lbl_user.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_user.ForeColor = Color.White;
            lbl_user.Location = new Point(763, 15);
            lbl_user.Name = "lbl_user";
            lbl_user.Size = new Size(95, 33);
            lbl_user.TabIndex = 1;
            lbl_user.Text = "Admin";
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
            navbar.TabIndex = 4;
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
            pct_profil.Location = new Point(707, 6);
            pct_profil.Name = "pct_profil";
            pct_profil.Size = new Size(50, 50);
            pct_profil.SizeMode = PictureBoxSizeMode.StretchImage;
            pct_profil.TabIndex = 0;
            pct_profil.TabStop = false;
            // 
            // btn_absensi
            // 
            btn_absensi.AutoSize = true;
            btn_absensi.BackColor = Color.White;
            btn_absensi.FlatStyle = FlatStyle.Flat;
            btn_absensi.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_absensi.ForeColor = Color.Black;
            btn_absensi.Location = new Point(32, 225);
            btn_absensi.Name = "btn_absensi";
            btn_absensi.Size = new Size(168, 45);
            btn_absensi.TabIndex = 2;
            btn_absensi.Text = "Absensi";
            btn_absensi.UseVisualStyleBackColor = false;
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
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(214, 228, 240);
            panel1.Controls.Add(btn_kehadiran);
            panel1.Controls.Add(btn_event);
            panel1.Controls.Add(btn_absensi);
            panel1.Controls.Add(btn_mahasiswa);
            panel1.Controls.Add(lbl_menu);
            panel1.Location = new Point(0, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 623);
            panel1.TabIndex = 5;
            // 
            // btn_kehadiran
            // 
            btn_kehadiran.AutoSize = true;
            btn_kehadiran.BackColor = Color.White;
            btn_kehadiran.FlatStyle = FlatStyle.Flat;
            btn_kehadiran.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_kehadiran.ForeColor = Color.Black;
            btn_kehadiran.Location = new Point(32, 311);
            btn_kehadiran.Name = "btn_kehadiran";
            btn_kehadiran.Size = new Size(168, 45);
            btn_kehadiran.TabIndex = 2;
            btn_kehadiran.Text = "Kehadiran";
            btn_kehadiran.UseVisualStyleBackColor = false;
            // 
            // btn_event
            // 
            btn_event.AutoSize = true;
            btn_event.BackColor = Color.White;
            btn_event.FlatStyle = FlatStyle.Flat;
            btn_event.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_event.ForeColor = Color.Black;
            btn_event.Location = new Point(32, 397);
            btn_event.Name = "btn_event";
            btn_event.Size = new Size(168, 45);
            btn_event.TabIndex = 2;
            btn_event.Text = "Event";
            btn_event.UseVisualStyleBackColor = false;
            // 
            // btn_mahasiswa
            // 
            btn_mahasiswa.AutoSize = true;
            btn_mahasiswa.BackColor = Color.White;
            btn_mahasiswa.FlatStyle = FlatStyle.Flat;
            btn_mahasiswa.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_mahasiswa.ForeColor = Color.Black;
            btn_mahasiswa.Location = new Point(32, 139);
            btn_mahasiswa.Name = "btn_mahasiswa";
            btn_mahasiswa.Size = new Size(168, 45);
            btn_mahasiswa.TabIndex = 2;
            btn_mahasiswa.Text = "Mahasiswa";
            btn_mahasiswa.UseVisualStyleBackColor = false;
            btn_mahasiswa.Click += btn_mahasiswa_Click;
            // 
            // panelContainer
            // 
            panelContainer.Location = new Point(255, 60);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(810, 621);
            panelContainer.TabIndex = 6;
            // 
            // admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 681);
            Controls.Add(navbar);
            Controls.Add(panel1);
            Controls.Add(panelContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "admin";
            ((System.ComponentModel.ISupportInitialize)ikon).EndInit();
            navbar.ResumeLayout(false);
            navbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pct_profil).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_user;
        private PictureBox ikon;
        private Panel navbar;
        private Button btn_keluar;
        private Label lbl_himashift;
        private Button btn_absensi;
        private Label lbl_menu;
        private Panel panel1;
        private Button btn_kehadiran;
        private Button btn_event;
        private Button btn_mahasiswa;
        private Panel panelContainer;
        private PictureBox pct_profil;
    }
}