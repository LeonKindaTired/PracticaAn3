using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Practica.Model;

namespace Practica.Repositories
{
    public class AuthService
    {
        private readonly string _connectionString;

        public AuthService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Authenticate(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT PasswordHash FROM Users WHERE Username = @username";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string storedHash = result.ToString();
                        string inputHash = HashPassword(password);
                        return storedHash == inputHash;
                    }
                }
            }
            return false;
        }

        public string HashPassword(string password)
        {
            using (var sha512 = System.Security.Cryptography.SHA512.Create())
            {
                byte[] hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
