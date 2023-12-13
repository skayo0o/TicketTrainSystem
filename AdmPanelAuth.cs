using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AdmPanelAuth : Form
    {
        public AdmPanelAuth()
        {
            InitializeComponent();
        }

        readonly string login = "admin";
        readonly string password = "admin";

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginBox.Text == login && pwrdBox.Text == password)
            {
                MessageBox.Show("Auth successful");
                AdminForm newForm = new AdminForm();
                newForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Auth failed");
            }
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            LoadForm newForm = new LoadForm();
            newForm.Show();
        }
    }
}
