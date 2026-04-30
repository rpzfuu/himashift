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
    public partial class beranda : Form
    {
        public beranda()
        {
            InitializeComponent();
            UserControls.beranda uc = new UserControls.beranda();
            addUserControl(uc);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btn_beranda_Click(object sender, EventArgs e)
        {
            UserControls.beranda uc = new UserControls.beranda();
            addUserControl(uc);
        }

        private void btn_anggota_Click(object sender, EventArgs e)
        {
            UserControls.anggota uc = new UserControls.anggota();
            addUserControl(uc);
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            UserControls.admin uc = new UserControls.admin();
            addUserControl(uc);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
