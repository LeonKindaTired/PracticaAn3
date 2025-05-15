using Microsoft.Data.SqlClient;
using Practica.Model;
using Practica.Repositories;
using System.Data;

namespace Practica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ReadProducts()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("id_produs", typeof(int));
            dataTable.Columns.Add("cod", typeof(string));
            dataTable.Columns.Add("nume", typeof(string));
            dataTable.Columns.Add("tip", typeof(string));
            dataTable.Columns.Add("pret", typeof(decimal));
            dataTable.Columns.Add("continut_ciocolata", typeof(int));
            dataTable.Columns.Add("ingrediente", typeof(string));
            dataTable.Columns.Add("pentru_diabetici", typeof(bool));
            dataTable.Columns.Add("stoc", typeof(int));
            dataTable.Columns.Add("volum_vanzari", typeof(int));

            var repo = new ProdusRepository();
            var products = repo.GetProduse();

            foreach (var product in products)
            {
                var row = dataTable.NewRow();

                row["id_produs"] = product.id_produs;
                row["cod"] = product.cod;
                row["nume"] = product.nume;
                row["tip"] = product.tip;
                row["pret"] = product.pret;
                row["continut_ciocolata"] = product.continut_ciocolata;
                row["ingrediente"] = product.ingrediente;
                row["pentru_diabetici"] = product.pentru_diabetici;
                row["stoc"] = product.stoc;
                row["volum_vanzari"] = product.volum_vanzari;

                dataTable.Rows.Add(row);
            }

            this.productsDataGrid.DataSource = dataTable;

            productsDataGrid.Columns["pret"].DefaultCellStyle.Format = "C2";
            productsDataGrid.Columns["continut_ciocolata"].HeaderText = "Cacao (%)";
            productsDataGrid.Columns["pentru_diabetici"].HeaderText = "Pentru Diabetici";
            productsDataGrid.Columns["volum_vanzari"].HeaderText = "Vânzări";

            productsDataGrid.Columns["pentru_diabetici"].ValueType = typeof(bool);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateEditForm form = new CreateEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ReadProducts();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cod = txtDeleteCod.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(cod))
            {
                MessageBox.Show("Introduceți un cod valid!");
                return;
            }

            try
            {
                var repo = new ProdusRepository();
                repo.DeleteProdusByCod(cod);

                ReadProducts();
                MessageBox.Show("Produs șters cu succes!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Nu puteți șterge un produs cu comenzi asociate!");
                }
                else
                {
                    MessageBox.Show($"Eroare la ștergere: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare neașteptată: {ex.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var repo = new ProdusRepository();
                Produs? cheapest = repo.GetCheapestCaramela();

                if (cheapest != null)
                {
                    string message = $"Cel mai ieftin produs caramelă:\n\n" +
                                    $"Nume: {cheapest.nume}\n" +
                                    $"Cod: {cheapest.cod}\n" +
                                    $"Preț: {cheapest.pret.ToString("C2")}\n" +
                                    $"Ingrediente: {cheapest.ingrediente}";

                    MessageBox.Show(message, "Rezultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nu există produse de tip caramelă în baza de date!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var repo = new ProdusRepository();
                var sugarProducts = repo.GetBomboaneCuZahar();

                if (sugarProducts.Any())
                {
                    Form resultForm = new Form();
                    DataGridView dgv = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AutoGenerateColumns = true,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    };

                    // Use DataTable for reliable binding
                    DataTable table = new DataTable();
                    table.Columns.Add("cod", typeof(string));
                    table.Columns.Add("nume", typeof(string));
                    table.Columns.Add("tip", typeof(string));
                    table.Columns.Add("pret", typeof(decimal));
                    table.Columns.Add("ingrediente", typeof(string));

                    foreach (var p in sugarProducts)
                    {
                        table.Rows.Add(p.cod, p.nume, p.tip, p.pret, p.ingrediente);
                    }

                    dgv.DataSource = table;

                    if (dgv.Columns.Contains("pret"))
                    {
                        dgv.Columns["pret"].DefaultCellStyle.Format = "C2";
                        dgv.Columns["pret"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    if (dgv.Columns.Contains("ingrediente"))
                    {
                        dgv.Columns["ingrediente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    resultForm.Text = "Bomboane cu zahăr sau înlocuitori";
                    resultForm.Size = new Size(1000, 600);
                    resultForm.Controls.Add(dgv);
                    resultForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nu s-au găsit bomboane cu zahăr sau înlocuitori de zahăr!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCiocolata.Text.Trim(), out int x) || x < 0 || x > 100)
            {
                MessageBox.Show("Introduceți un procent valid (0-100)!");
                return;
            }

            try
            {
                var repo = new ProdusRepository();
                var products = repo.GetProduseByCiocolata(x);

                if (products.Count > 0)
                {
                    Form resultForm = new Form();
                    DataGridView dgv = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AutoGenerateColumns = false
                    };

                    DataTable table = new DataTable();
                    table.Columns.Add("Cod", typeof(string));
                    table.Columns.Add("Nume", typeof(string));
                    table.Columns.Add("Tip", typeof(string));
                    table.Columns.Add("Pret", typeof(decimal));
                    table.Columns.Add("ContinutCiocolata", typeof(int));
                    table.Columns.Add("Stoc", typeof(int));

                    foreach (var p in products)
                    {
                        table.Rows.Add(p.cod, p.nume, p.tip, p.pret, p.continut_ciocolata, p.stoc);
                    }

                    var codColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Cod",
                        HeaderText = "Cod",
                        Name = "Cod"
                    };
                    dgv.Columns.Add(codColumn);

                    var numeColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Nume",
                        HeaderText = "Nume",
                        Name = "Nume"
                    };
                    dgv.Columns.Add(numeColumn);

                    var tipColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Tip",
                        HeaderText = "Tip",
                        Name = "Tip"
                    };
                    dgv.Columns.Add(tipColumn);

                    var pretColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pret",
                        HeaderText = "Preț",
                        Name = "Pret" 
                    };
                    dgv.Columns.Add(pretColumn);

                    var ciocolataColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "ContinutCiocolata",
                        HeaderText = "% Ciocolată",
                        Name = "ContinutCiocolata"
                    };
                    dgv.Columns.Add(ciocolataColumn);

                    var stocColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Stoc",
                        HeaderText = "Stoc",
                        Name = "Stoc"
                    };
                    dgv.Columns.Add(stocColumn);

                    dgv.DataSource = table;

                    pretColumn.DefaultCellStyle.Format = "C2";
                    ciocolataColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    resultForm.Text = $"Produse cu {x}% ciocolată";
                    resultForm.Size = new Size(1000, 500);
                    resultForm.Controls.Add(dgv);
                    resultForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Nu există produse cu {x}% ciocolată!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }
    }
}
