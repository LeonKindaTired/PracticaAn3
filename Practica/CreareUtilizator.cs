using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            CreateUI();
        }

        private void CreateUI()
        {
            Label lblUsername = new Label { Text = "Username:", Location = new Point(20, 20), AutoSize = true };
            Label lblPassword = new Label { Text = "Password:", Location = new Point(20, 60), AutoSize = true };
            Label lblConfirm = new Label { Text = "Confirm Password:", Location = new Point(20, 100), AutoSize = true };

            TextBox txtUsername = new TextBox { Location = new Point(150, 20), Size = new Size(200, 20) };
            TextBox txtPassword = new TextBox { Location = new Point(150, 60), Size = new Size(200, 20), UseSystemPasswordChar = true };
            TextBox txtConfirm = new TextBox { Location = new Point(150, 100), Size = new Size(200, 20), UseSystemPasswordChar = true };

            Button btnCreate = new Button { Text = "Create User", Location = new Point(150, 140), Size = new Size(100, 30) };
            Button btnCancel = new Button { Text = "Cancel", Location = new Point(260, 140), Size = new Size(100, 30) };

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
    }
}
