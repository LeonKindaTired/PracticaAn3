using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Practica.Repositories;

namespace Practica
{
    public partial class CreareUtilizator : Form
    {
        private readonly AuthService _authService;
        private readonly string _connectionString;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
        public CreareUtilizator(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _authService = new AuthService(connectionString);

            this.Text = "Create New Admin User";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CreateStyledUI();
        }

        private void CreateStyledUI()
        {
            this.ClientSize = new Size(400, 250);
            this.BackColor = Color.FromArgb(255, 245, 225);
            this.Font = new Font("Arial", 10f);

            int padding = 30;
            int yStart = 20;
            int controlHeight = 40;
            int buttonHeight = 42;

            Label lblUsername = CreateLabel("Username:", 20, yStart);
            Label lblPassword = CreateLabel("Password:", 20, yStart + controlHeight + 15);
            Label lblConfirm = CreateLabel("Confirm Password:", 20, yStart + 2 * (controlHeight + 15));

            TextBox txtUsername = CreateTextBox(yStart);
            TextBox txtPassword = CreatePasswordBox(yStart + controlHeight + 15);
            TextBox txtConfirm = CreatePasswordBox(yStart + 2 * (controlHeight + 15));

            Button btnCreate = CreateButton("Create User", 100, yStart + 3 * (controlHeight + 15),
                Color.FromArgb(247, 200, 215), Color.FromArgb(255, 220, 230));

            Button btnCancel = CreateButton("Cancel", 230, yStart + 3 * (controlHeight + 15),
                Color.FromArgb(220, 220, 220), Color.FromArgb(240, 240, 240));

            btnCreate.Click += (sender, e) =>
            {
                if (txtPassword.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Username cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string passwordHash = _authService.HashPassword(txtPassword.Text);

                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        string sql = "INSERT INTO Users (Username, PasswordHash) VALUES (@username, @passwordHash)";

                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@passwordHash", passwordHash);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    MessageBox.Show("Username already exists! Please choose a different username.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnCancel.Click += (sender, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.AddRange(new Control[] {
            lblUsername, txtUsername,
            lblPassword, txtPassword,
            lblConfirm, txtConfirm,
            btnCreate, btnCancel
        });
        }

        private Label CreateLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y + 10),
                AutoSize = true,
                Font = new Font("Arial", 12f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 100, 100)
            };
        }

        private TextBox CreateTextBox(int y)
        {
            var txt = new TextBox
            {
                Location = new Point(180, y),
                Size = new Size(200, 36),
                Font = new Font("Arial", 16f),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            ApplyRoundedStyle(txt, 10);
            txt.Padding = new Padding(10, 8, 10, 8);
            return txt;
        }

        private TextBox CreatePasswordBox(int y)
        {
            var txt = CreateTextBox(y);
            txt.UseSystemPasswordChar = true;
            txt.PasswordChar = '•';
            return txt;
        }

        private Button CreateButton(string text, int x, int y, Color bgColor, Color hoverColor)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(120, 42),
                Font = new Font("Arial", 12f, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 80),
                BackColor = bgColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            ApplyRoundedStyle(btn, 15);
            return btn;
        }

        private void ApplyRoundedStyle(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(
                0, 0, control.Width, control.Height, radius, radius
            ));
        }
    }
}
