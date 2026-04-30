namespace HIMASHIFT
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(beranda));
            navbar = new Panel();
            btn_exit = new Button();
            btn_anggota = new Button();
            btn_beranda = new Button();
            lbl_himashift = new Label();
            ikon = new PictureBox();
            panelContainer = new Panel();
            navbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ikon).BeginInit();
            SuspendLayout();
            // 
            // navbar
            // 
            navbar.BackColor = Color.FromArgb(30, 86, 160);
            navbar.Controls.Add(btn_exit);
            navbar.Controls.Add(btn_anggota);
            navbar.Controls.Add(btn_beranda);
            navbar.Controls.Add(lbl_himashift);
            navbar.Controls.Add(ikon);
            navbar.Dock = DockStyle.Top;
            navbar.Location = new Point(0, 0);
            navbar.Name = "navbar";
            navbar.Size = new Size(1064, 61);
            navbar.TabIndex = 0;
            // 
            // btn_exit
            // 
            btn_exit.AutoSize = true;
            btn_exit.BackColor = Color.Brown;
            btn_exit.FlatStyle = FlatStyle.Flat;
            btn_exit.Font = new Font("Inter Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_exit.ForeColor = Color.White;
            btn_exit.Location = new Point(1004, 9);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(48, 45);
            btn_exit.TabIndex = 2;
            btn_exit.Text = "X";
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_anggota
            // 
            btn_anggota.AutoSize = true;
            btn_anggota.BackColor = Color.Transparent;
            btn_anggota.FlatStyle = FlatStyle.Flat;
            btn_anggota.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_anggota.ForeColor = Color.White;
            btn_anggota.Location = new Point(840, 9);
            btn_anggota.Name = "btn_anggota";
            btn_anggota.Size = new Size(134, 45);
            btn_anggota.TabIndex = 2;
            btn_anggota.Text = "Anggota";
            btn_anggota.UseVisualStyleBackColor = false;
            btn_anggota.Click += btn_anggota_Click;
            // 
            // btn_beranda
            // 
            btn_beranda.AutoSize = true;
            btn_beranda.BackColor = Color.Transparent;
            btn_beranda.FlatStyle = FlatStyle.Flat;
            btn_beranda.Font = new Font("Inter", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_beranda.ForeColor = Color.White;
            btn_beranda.Location = new Point(669, 9);
            btn_beranda.Name = "btn_beranda";
            btn_beranda.Size = new Size(134, 45);
            btn_beranda.TabIndex = 2;
            btn_beranda.Text = "Beranda";
            btn_beranda.UseVisualStyleBackColor = false;
            btn_beranda.Click += btn_beranda_Click;
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
            // panelContainer
            // 
            panelContainer.BackgroundImage = (Image)resources.GetObject("panelContainer.BackgroundImage");
            panelContainer.BackgroundImageLayout = ImageLayout.Stretch;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 61);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1064, 620);
            panelContainer.TabIndex = 1;
            // 
            // beranda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 681);
            Controls.Add(panelContainer);
            Controls.Add(navbar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "beranda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "beranda";
            navbar.ResumeLayout(false);
            navbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ikon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel navbar;
        private PictureBox ikon;
        private Label lbl_himashift;
        private Panel panelContainer;
        private Button btn_anggota;
        private Button btn_beranda;
        private Button btn_exit;
    }
}