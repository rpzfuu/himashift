using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIMASHIFT.UserControls
{
    public partial class dashboard_profil : UserControl
    {
        public string nim { get; set; }
        public dashboard_profil()
        {
            InitializeComponent();
            this.Load += Dashboard_Load;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Ini akan dijalankan setelah form dimuat dan properti 'nim' sudah diatur
            
            string divisi = "";
            string nama = "";
            string connectionString = "Server=localhost;Port=3306;Database=himashift;Uid=root;Pwd=";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT mahasiswa.nama, divisi.nama_divisi FROM mahasiswa JOIN mahasiswa_divisi ON mahasiswa.nim = mahasiswa_divisi.nim JOIN divisi ON mahasiswa_divisi.id_divisi = divisi.id_divisi WHERE mahasiswa.nim = @nim";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nim", nim);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                     nama = reader["nama"].ToString();
                     divisi = reader["nama_divisi"].ToString();
                }
            }
            connection.Close();

            lbl_nim.Text = nim;
            lbl_divisi.Text = divisi;
            lbl_nama.Text=nama;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbl_nama_Click(object sender, EventArgs e)
        {

        }
    }
}
