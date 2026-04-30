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

namespace HIMASHIFT.UserControls
{
    public partial class dashboard_event : UserControl
    {
        public dashboard_event()
        {
            InitializeComponent();
            this.Load += Dashboard_Load;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=3306;Database=himashift;Uid=root;Pwd=";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT nama_acara, tanggal, ketua_pelaksana FROM event";
            MySqlCommand command = new MySqlCommand(query, connection);
            DataTable dataTable = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }

            dataTable.Columns.Add("No", typeof(int));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i]["No"] = i + 1;
            }

            // Pindahkan kolom "No" ke posisi pertama
            dataTable.Columns["No"].SetOrdinal(0);

            tabel.DataSource = dataTable;
            connection.Close();

            tabel.Columns["No"].HeaderText = "No";
            tabel.Columns[1].HeaderText = "Nama Acara";
            tabel.Columns[2].HeaderText = "Tanggal";
            tabel.Columns[3].HeaderText = "Ketua Pelaksana";


        }
    }
}
