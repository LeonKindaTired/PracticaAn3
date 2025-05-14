using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica.Model;
using Microsoft.Data.SqlClient;

namespace Practica.Repositories
{
    public class ProdusRepository
    {
        private readonly string connectionString = "Data Source=WIN-QHARUPHBGU0\\SQLEXPRESS;Initial Catalog=Cofetarie;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public List<Produs> GetProduse()
        {
            var produse = new List<Produs>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Produse ORDER BY IDProdus DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produs produs = new Produs();
                            produs.id_produs = reader.GetInt32(0);
                            produs.cod = reader.GetString(1);
                            produs.nume = reader.GetString(2);
                            produs.tip = reader.GetString(3);
                            produs.pret = reader.GetDecimal(4);
                            produs.continut_ciocolata = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            produs.ingrediente = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            produs.pentru_diabetici = reader.GetBoolean(7);
                            produs.stoc = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                            produs.volum_vanzari = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);

                            produse.Add(produs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return produse;
        }

        public Produs? GetProdus(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Produse WHERE IDProdus = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Produs produs = new Produs();
                                produs.id_produs = reader.GetInt32(0);
                                produs.cod = reader.GetString(1);
                                produs.nume = reader.GetString(2);
                                produs.tip = reader.GetString(3);
                                produs.pret = reader.GetDecimal(4);
                                produs.continut_ciocolata = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                                produs.ingrediente = reader.IsDBNull(6) ? "" : reader.GetString(6);
                                produs.pentru_diabetici = reader.GetBoolean(7);
                                produs.stoc = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                                produs.volum_vanzari = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);

                                return produs;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            return null;
        }

        public void CreateProdus(Produs produs)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"INSERT INTO Produse 
                                (Cod, Nume, Tip, Pret, ContinutCiocolata, Ingrediente, PentruDiabetici, Stoc, VolumVanzari)
                                VALUES
                                (@cod, @nume, @tip, @pret, @continutCiocolata, @ingrediente, @pentruDiabetici, @stoc, @volumVanzari)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cod", produs.cod);
                        command.Parameters.AddWithValue("@nume", produs.nume);
                        command.Parameters.AddWithValue("@tip", produs.tip);
                        command.Parameters.AddWithValue("@pret", produs.pret);
                        command.Parameters.AddWithValue("@continutCiocolata", produs.continut_ciocolata);
                        command.Parameters.AddWithValue("@ingrediente", produs.ingrediente);
                        command.Parameters.AddWithValue("@pentruDiabetici", produs.pentru_diabetici);
                        command.Parameters.AddWithValue("@stoc", produs.stoc);
                        command.Parameters.AddWithValue("@volumVanzari", produs.volum_vanzari);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void UpdateProdus(Produs produs)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"UPDATE Produse SET
                                Cod = @cod,
                                Nume = @nume,
                                Tip = @tip,
                                Pret = @pret,
                                ContinutCiocolata = @continutCiocolata,
                                Ingrediente = @ingrediente,
                                PentruDiabetici = @pentruDiabetici,
                                Stoc = @stoc,
                                VolumVanzari = @volumVanzari
                                WHERE IDProdus = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cod", produs.cod);
                        command.Parameters.AddWithValue("@nume", produs.nume);
                        command.Parameters.AddWithValue("@tip", produs.tip);
                        command.Parameters.AddWithValue("@pret", produs.pret);
                        command.Parameters.AddWithValue("@continutCiocolata", produs.continut_ciocolata);
                        command.Parameters.AddWithValue("@ingrediente", produs.ingrediente);
                        command.Parameters.AddWithValue("@pentruDiabetici", produs.pentru_diabetici);
                        command.Parameters.AddWithValue("@stoc", produs.stoc);
                        command.Parameters.AddWithValue("@volumVanzari", produs.volum_vanzari);
                        command.Parameters.AddWithValue("@id", produs.id_produs);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void DeleteProdus(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Produse WHERE IDProdus = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
}
