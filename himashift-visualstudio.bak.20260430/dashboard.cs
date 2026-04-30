using HIMASHIFT.UserControls;
using K4os.Compression.LZ4.Encoders;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIMASHIFT
{
    public partial class dashboard : Form
    {

        public string nim { get; set; }
        public dashboard()
        {
            InitializeComponent();
            this.Load += Dashboard_Load;

        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Ini akan dijalankan setelah form dimuat dan properti 'nim' sudah diatur
            string nama="";
            string connectionString = "Server=localhost;Port=3306;Database=himashift;Uid=root;Pwd=";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT nama FROM mahasiswa WHERE nim=@nim";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nim", nim);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    nama = reader["nama"].ToString();
                }
            }
            connection.Close();
            lbl_user.Text = nama;
        }
        private void AddUserControlToPanel()
        {
            dashboard_profil userControl = new dashboard_profil();
            userControl.nim = nim;
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btn_profil_Click(object sender, EventArgs e)
        {
            UserControls.dashboard_profil uc = new UserControls.dashboard_profil();
            uc.nim = nim;
            addUserControl(uc);
        }

        private void btn_keluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_absensi_Click(object sender, EventArgs e)
        {
            UserControls.dashboard_absensi uc = new UserControls.dashboard_absensi();
            uc.nim = nim;
            addUserControl(uc);
        }

        private void btn_event_Click(object sender, EventArgs e)
        {
            UserControls.dashboard_event uc = new UserControls.dashboard_event();
            addUserControl(uc);
        }

        private void btn_sertifikat_Click(object sender, EventArgs e)
        {
            UserControls.dashboard_sertifikat uc = new UserControls.dashboard_sertifikat();
            uc.nim = nim;
            addUserControl(uc);
        }

        private void lbl_user_Click(object sender, EventArgs e)
        {

        }
    }
}
