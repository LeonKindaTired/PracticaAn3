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
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

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
            StyleLoginForm();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse
        );

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void StyleLoginForm()
        {
            this.BackColor = Color.FromArgb(255, 245, 225);
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            Color buttonColor = Color.FromArgb(247, 200, 215);
            Color cancelColor = Color.FromArgb(220, 220, 220);
            Color hoverColor = Color.FromArgb(255, 220, 230);
            Color cancelHover = Color.FromArgb(240, 240, 240);

            ApplyButtonStyle(btnLogin, buttonColor, hoverColor, "Login");
            ApplyButtonStyle(btnCancel, cancelColor, cancelHover, "Cancel");
            ApplyButtonStyle(button1, buttonColor, hoverColor, "Creare Utilizator");

            StyleTextBox(txtUsername, "Username");
            StyleTextBox(txtPassword, "Password");

        }

        private void ApplyButtonStyle(Button btn, Color backColor, Color hoverColor, string text)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.FromArgb(80, 80, 80);
            btn.Font = new Font("Arial", 10f, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Text = text;

            btn.Height = 30;
            btn.MinimumSize = new Size(150, 30);

            btn.FlatAppearance.MouseOverBackColor = hoverColor;

            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 15, 15));
        }

        private void StyleTextBox(TextBox textBox, string placeholder)
        {
            textBox.BackColor = Color.White;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Arial", 18f);
            textBox.Height = 80;

            textBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox.Width, textBox.Height, 12, 12));

            textBox.Padding = new Padding(10);

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = SystemColors.GrayText;
                }
            };

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = SystemColors.GrayText;
            }
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
