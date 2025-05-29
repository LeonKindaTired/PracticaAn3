using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using Practica.Model;
using Practica.Repositories;

namespace Practica
{
    public partial class Login : Form
    {
        private readonly AuthService _authService;
        public User AuthenticatedUser { get; private set; }
        string connectionString = "Data Source=WIN-QHARUPHBGU0\\SQLEXPRESS;Initial Catalog=Cofetarie;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public Login(string connectionString)
        {
            InitializeComponent();
            _authService = new AuthService(connectionString);
            this.AcceptButton = btnLogin;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password");
                return;
            }

            if (_authService.Authenticate(username, password))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CreareUtilizator createForm = new CreareUtilizator(connectionString))
            {
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("New admin user created successfully!");
                }
            }
        }
    }
}
