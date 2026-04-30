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
    public partial class dashboard_absensi : UserControl
    {
        public string nim { get; set; } = "";
        private string connectionString = "";
        private DataTable dataTable = new DataTable();

        public dashboard_absensi()
        {
            InitializeComponent();
            this.Load += Dashboard_Load;
        }

        private void Dashboard_Load(object? sender, EventArgs e)
        {
            connectionString = "Server=localhost;Port=3306;Database=himashift;Uid=root;Pwd=rafumazta;";
            string query = "SELECT absen.id_absen, absen.mulai, absen.akhir, kehadiran.status_kehadiran FROM mahasiswa JOIN kehadiran ON mahasiswa.nim=kehadiran.nim JOIN absen ON absen.id_absen=kehadiran.id_absen WHERE mahasiswa.nim=@nim";

            dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@nim", nim);
                connection.Open();
                adapter.Fill(dataTable);
            }

            dataTable.Columns.Add("No", typeof(int));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i]["No"] = i + 1;
            }
            // Pindahkan kolom "No" ke posisi pertama
            dataTable.Columns["No"]!.SetOrdinal(0);

            tabel.DataSource = dataTable;

            tabel.Columns["No"]!.HeaderText = "No";
            tabel.Columns["id_absen"]!.Visible = false;
            tabel.Columns["mulai"]!.HeaderText = "Mulai";
            tabel.Columns["akhir"]!.HeaderText = "Akhir";
            tabel.Columns["status_kehadiran"]!.HeaderText = "Status Kehadiran";

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Aksi";
            btnColumn.Text = "Absen";
            btnColumn.Name = "Absen";
            btnColumn.UseColumnTextForButtonValue = true;
            tabel.Columns.Add(btnColumn);

            tabel.CellContentClick += new DataGridViewCellEventHandler(Tabel_CellContentClick);
        }

        private void Tabel_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tabel.Columns["Absen"]!.Index)
            {
                int rowIndex = e.RowIndex;
                object idAbsen = dataTable.Rows[rowIndex]["id_absen"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand updateCommand = new MySqlCommand("UPDATE kehadiran SET status_kehadiran = 'Hadir' WHERE nim = @nim AND id_absen = @id_absen", connection))
                {
                    updateCommand.Parameters.AddWithValue("@nim", nim);
                    updateCommand.Parameters.AddWithValue("@id_absen", idAbsen);
                    connection.Open();
                    updateCommand.ExecuteNonQuery();
                }

                // Update status kehadiran pada DataTable dan DataGridView
                dataTable.Rows[rowIndex]["status_kehadiran"] = "Hadir";
                tabel.DataSource = dataTable;
            }
        }
    }
}
