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

        public void DeleteProdusByCod(string cod)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Produse WHERE Cod = @cod";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cod", cod);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                throw;
            }
        }

        public Produs? GetCheapestCaramela()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT TOP 1 * 
                         FROM Produse 
                         WHERE Tip = @tip 
                         ORDER BY Pret ASC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tip", "Caramela");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Produs
                                {
                                    id_produs = reader.GetInt32(0),
                                    cod = reader.GetString(1),
                                    nume = reader.GetString(2),
                                    tip = reader.GetString(3),
                                    pret = reader.GetDecimal(4),
                                    continut_ciocolata = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                    ingrediente = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    pentru_diabetici = reader.GetBoolean(7),
                                    stoc = reader.GetInt32(8),
                                    volum_vanzari = reader.GetInt32(9)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }

        public List<Produs> GetBomboaneCuZahar()
        {
            var products = new List<Produs>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT 
                        IDProdus AS id_produs,
                        Cod AS cod,
                        Nume AS nume,
                        Tip AS tip,
                        Pret AS pret,
                        ContinutCiocolata AS continut_ciocolata,
                        Ingrediente AS ingrediente,
                        PentruDiabetici AS pentru_diabetici,
                        Stoc AS stoc,
                        VolumVanzari AS volum_vanzari
                        FROM Produse 
                        WHERE LOWER(Ingrediente) LIKE '%zahar%' 
                           OR LOWER(Ingrediente) LIKE '%miere%'
                           OR LOWER(Ingrediente) LIKE '%înlocuitor%'
                           OR LOWER(Ingrediente) LIKE '%edulcorant%'
                           OR LOWER(Ingrediente) LIKE '%zaharis%'
                        ORDER BY Pret DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Produs
                                {
                                    id_produs = reader.GetInt32(0),
                                    cod = reader.GetString(1),
                                    nume = reader.GetString(2),
                                    tip = reader.GetString(3),
                                    pret = reader.GetDecimal(4),
                                    continut_ciocolata = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                    ingrediente = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    pentru_diabetici = reader.GetBoolean(7),
                                    stoc = reader.GetInt32(8),
                                    volum_vanzari = reader.GetInt32(9)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            return products;
        }

        public List<Produs> GetProduseByCiocolata(int continutCiocolata)
        {
            var products = new List<Produs>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT 
                        IDProdus AS id_produs,
                        Cod AS cod,
                        Nume AS nume,
                        Tip AS tip,
                        Pret AS pret,
                        ContinutCiocolata AS continut_ciocolata,
                        Ingrediente AS ingrediente,
                        PentruDiabetici AS pentru_diabetici,
                        Stoc AS stoc,
                        VolumVanzari AS volum_vanzari
                        FROM Produse 
                        WHERE ContinutCiocolata = @continut";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@continut", continutCiocolata);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var prod = new Produs();
                                prod.id_produs = reader.GetInt32(0);
                                prod.cod = reader.GetString(1);
                                prod.nume = reader.GetString(2);
                                prod.tip = reader.GetString(3);
                                prod.pret = reader.GetDecimal(4);
                                prod.continut_ciocolata = reader.GetInt32(5);
                                prod.ingrediente = reader.IsDBNull(6) ? "" : reader.GetString(6);
                                prod.pentru_diabetici = reader.GetBoolean(7);
                                prod.stoc = reader.GetInt32(8);
                                prod.volum_vanzari = reader.GetInt32(9);

                                products.Add(prod);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB Error: {ex.Message}");
            }
            return products;
        }

        public List<Produs> GetBomboaneZ()
        {
            var products = new List<Produs>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT Ingrediente, Cod, Nume 
                     FROM Produse 
                     WHERE Cod LIKE @codPattern";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@codPattern", "Z%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Produs
                            {
                                cod = reader.GetString(1),
                                nume = reader.GetString(2),
                                ingrediente = reader.IsDBNull(0) ? "" : reader.GetString(0)
                            });
                        }
                    }
                }
            }
            return products;
        }

        public decimal? GetMediaPreturilor()
        {
            decimal? media = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT AVG(Pret) FROM Produse";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            media = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la calculul mediei: {ex.Message}");
            }
            return media;
        }

        public List<Produs> GetProdusePentruDiabetici()
        {
            List<Produs> products = new List<Produs>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT 
                        IDProdus AS id_produs,
                        Cod AS cod,
                        Nume AS nume,
                        Tip AS tip,
                        Pret AS pret,
                        ContinutCiocolata AS continut_ciocolata,
                        Ingrediente AS ingrediente,
                        PentruDiabetici AS pentru_diabetici,
                        Stoc AS stoc,
                        VolumVanzari AS volum_vanzari
                        FROM Produse 
                        WHERE PentruDiabetici = 1
                        ORDER BY Nume ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Produs
                                {
                                    id_produs = reader.GetInt32(0),
                                    cod = reader.GetString(1),
                                    nume = reader.GetString(2),
                                    tip = reader.GetString(3),
                                    pret = reader.GetDecimal(4),
                                    continut_ciocolata = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                    ingrediente = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                    pentru_diabetici = reader.GetBoolean(7),
                                    stoc = reader.GetInt32(8),
                                    volum_vanzari = reader.GetInt32(9)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea produselor: {ex.Message}");
            }
            return products;
        }

        public List<ProdusVanzari> GetCeleMaiVanduteProduse()
        {
            List<ProdusVanzari> lista = new List<ProdusVanzari>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"SELECT 
                        Nume AS Produs,
                        VolumVanzari AS Vanzi,
                        Stoc AS StocKg
                        FROM Produse
                        ORDER BY VolumVanzari DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ProdusVanzari
                            {
                                Produs = reader["Produs"].ToString(),
                                Vanzi = Convert.ToInt32(reader["Vanzi"]),
                                StocKg = Convert.ToInt32(reader["StocKg"])
                            });
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea datelor: {ex.Message}");
            }
            return lista;
        }

        public void CreateAndPopulateZefirTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string createTableSql = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ProduseZefirRoz')
                BEGIN
                    CREATE TABLE ProduseZefirRoz (
                        IDProdus INT PRIMARY KEY,
                        Cod VARCHAR(10) UNIQUE NOT NULL,
                        Nume NVARCHAR(100) NOT NULL,
                        Tip NVARCHAR(50) NOT NULL,
                        Pret DECIMAL(10,2) CHECK (Pret > 0),
                        ContinutCiocolata INT,
                        Ingrediente NVARCHAR(MAX),
                        PentruDiabetici BIT DEFAULT 0,
                        Stoc INT CHECK (Stoc >= 0),
                        VolumVanzari INT DEFAULT 0
                    )
                END";

                    using (SqlCommand createCommand = new SqlCommand(createTableSql, connection))
                    {
                        createCommand.ExecuteNonQuery();
                    }

                    string copyDataSql = @"
                INSERT INTO ProduseZefirRoz 
                SELECT 
                    IDProdus, Cod, Nume, Tip, Pret,
                    ContinutCiocolata, Ingrediente,
                    PentruDiabetici, Stoc, VolumVanzari
                FROM Produse 
                WHERE Nume = @NumeProdus
                AND IDProdus NOT IN (SELECT IDProdus FROM ProduseZefirRoz)";

                    using (SqlCommand copyCommand = new SqlCommand(copyDataSql, connection))
                    {
                        copyCommand.Parameters.AddWithValue("@NumeProdus", "Zefir de culoare roz");
                        int rowsAffected = copyCommand.ExecuteNonQuery();
                        MessageBox.Show($"Au fost copiate {rowsAffected} înregistrări.");
                    }
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 2714: 
                            MessageBox.Show("Tabelul există deja. Datele au fost actualizate.");
                            break;
                        case 2627: 
                            MessageBox.Show("Produsul există deja în tabelul nou.");
                            break;
                        default:
                            MessageBox.Show($"Eroare SQL: {ex.Number} - {ex.Message}");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare generală: {ex.Message}");
                }
            }
        }

        public List<Produs> GetProduseZefirRoz()
        {
            List<Produs> produse = new List<Produs>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT 
                        IDProdus, 
                        Cod, 
                        Nume, 
                        Tip, 
                        Pret, 
                        ContinutCiocolata, 
                        Ingrediente, 
                        PentruDiabetici, 
                        Stoc, 
                        VolumVanzari 
                    FROM ProduseZefirRoz";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produse.Add(new Produs
                            {
                                id_produs = reader.GetInt32(0),
                                cod = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                nume = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                tip = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                pret = reader.GetDecimal(4),
                                continut_ciocolata = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                ingrediente = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                pentru_diabetici = reader.GetBoolean(7),
                                stoc = reader.GetInt32(8),
                                volum_vanzari = reader.GetInt32(9)
                            });
                        }
                    }
                }
            }
            return produse;
        }
    }
}
