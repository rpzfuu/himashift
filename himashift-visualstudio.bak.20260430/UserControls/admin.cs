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
    public partial class admin : UserControl
    {
        string connectionString = "Server=localhost;Port=3306;Database=himashift;Uid=root;Pwd=";
        private bool loginkan;
        public admin()
        {
            InitializeComponent();
        }
        private void ceklogin()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE name = @name AND password = @password";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", tb_name.Text);
            command.Parameters.AddWithValue("@password", tb_pw.Text);
            int userCount = Convert.ToInt32(command.ExecuteScalar());

            if (userCount > 0)
            {
                loginkan = true;

            }
            connection.Close();
        }

        private void btn_masuk_Click(object sender, EventArgs e)
        {
            loginkan = false;
            ceklogin();
            if (loginkan)
            {
                string name = tb_name.Text;
                admindashboard formAdmin = new admindashboard();
                formAdmin.Show();
                tb_name.Clear();
                tb_pw.Clear();
            }
            else
            {
                MessageBox.Show("NIM atau password salah, silakan coba lagi.");
                tb_pw.Clear();
            }
        }
    }
}
