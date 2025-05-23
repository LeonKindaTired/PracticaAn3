using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using Practica.Model;
using Practica.Repositories;
using System.Data;
using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel;

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

        public void ExportToExcel(List<string> ingredients)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Ingrediente");

                worksheet.Cells[1, 1].Value = "Listă Ingrediente Bomboane Z";
                worksheet.Cells[1, 1].Style.Font.Bold = true;

                int row = 3;
                foreach (var ingredient in ingredients.Distinct().OrderBy(i => i))
                {
                    worksheet.Cells[row, 1].Value = ingredient;
                    row++;
                }

                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Files|*.xlsx";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveDialog.FileName, package.GetAsByteArray());
                    }
                }
            }
        }

        //public void ExportToWord(List<string> ingredients)
        //{
        //    using (var document = WordprocessingDocument.Create("temp.docx", WordprocessingDocumentType.Document))
        //    {
        //        MainDocumentPart mainPart = document.AddMainDocumentPart();
        //        mainPart.Document = new Document();
        //        Body body = mainPart.Document.AppendChild(new Body());

        //        Paragraph titlePara = body.AppendChild(new Paragraph());
        //        Run titleRun = titlePara.AppendChild(new Run());
        //        titleRun.AppendChild(new Text("Listă Ingrediente Bomboane Z"));
        //        titleRun.RunProperties = new RunProperties(new Bold());

        //        foreach (var ingredient in ingredients.Distinct().OrderBy(i => i))
        //        {
        //            Paragraph para = body.AppendChild(new Paragraph());
        //            Run run = para.AppendChild(new Run());
        //            run.AppendChild(new Text($"• {ingredient}"));
        //        }

        //        using (var saveDialog = new SaveFileDialog())
        //        {
        //            saveDialog.Filter = "Word Documents|*.docx";
        //            if (saveDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                document.SaveAs(saveDialog.FileName);
        //            }
        //        }
        //    }
        //}

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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var repo = new ProdusRepository();
                var products = repo.GetBomboaneZ();

                if (!products.Any())
                {
                    MessageBox.Show("Nu există bomboane Z în baza de date!");
                    return;
                }

                var allIngredients = new List<string>();
                foreach (var p in products)
                {
                    var ingredients = p.ingrediente.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    allIngredients.AddRange(ingredients.Select(i => i.Trim()));
                }

                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Excel File|*.xlsx|Word Document|*.docx";
                    dialog.Title = "Exportă ingrediente";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (dialog.FileName.EndsWith(".xlsx"))
                        {
                            ExportToExcel(allIngredients);
                        }

                        MessageBox.Show("Export finalizat cu succes!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la export: {ex.Message}");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                var repo = new ProdusRepository();
                decimal? averagePrice = repo.GetMediaPreturilor();

                if (averagePrice.HasValue)
                {
                    MessageBox.Show($"Media prețurilor tuturor produselor: {averagePrice.Value.ToString("C2")}",
                                    "Medie Prețuri",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nu există produse în baza de date!",
                                    "Medie Prețuri",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var repo = new ProdusRepository();
                var produseDiabetici = repo.GetProdusePentruDiabetici();

                if (produseDiabetici.Any())
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
                    table.Columns.Add("Ingrediente", typeof(string));

                    foreach (var p in produseDiabetici)
                    {
                        table.Rows.Add(p.cod, p.nume, p.tip, p.pret, p.ingrediente);
                    }

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Cod",
                        HeaderText = "Cod",
                        Name = "Cod"
                    });

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Nume",
                        HeaderText = "Denumire",
                        Name = "Nume"
                    });

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Tip",
                        HeaderText = "Categorie",
                        Name = "Tip"
                    });

                    var pretColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pret",
                        HeaderText = "Preț",
                        Name = "Pret"
                    };
                    dgv.Columns.Add(pretColumn);

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Ingrediente",
                        HeaderText = "Ingrediente",
                        Name = "Ingrediente"
                    });

                    dgv.DataSource = table;

                    pretColumn.DefaultCellStyle.Format = "C2";
                    pretColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    resultForm.Text = "Produse pentru diabetici";
                    resultForm.Size = new Size(1200, 600);
                    resultForm.Controls.Add(dgv);
                    resultForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nu există produse pentru diabetici în stoc!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                var repo = new ProdusRepository();
                var topProducts = repo.GetCeleMaiVanduteProduse();

                if (topProducts.Any())
                {
                    Form resultForm = new Form();
                    DataGridView dgv = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AutoGenerateColumns = false
                    };

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Produs",
                        HeaderText = "Produs",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Vanzi",
                        HeaderText = "Vânzări",
                        DefaultCellStyle = new DataGridViewCellStyle
                        {
                            Alignment = DataGridViewContentAlignment.MiddleRight
                        }
                    });

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "StocKg",
                        HeaderText = "Stoc (kg)",
                        DefaultCellStyle = new DataGridViewCellStyle
                        {
                            Alignment = DataGridViewContentAlignment.MiddleRight,
                            Format = "N0"
                        }
                    });

                    dgv.DataSource = topProducts;

                    resultForm.Text = "Top produse vândute și stocuri";
                    resultForm.Size = new Size(800, 600);
                    resultForm.Controls.Add(dgv);
                    resultForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nu există date despre vânzări!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ProdusRepository repo = new ProdusRepository();
            repo.CreateAndPopulateZefirTable();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                var repo = new ProdusRepository();
                var produseZefir = repo.GetProduseZefirRoz();

                if (produseZefir.Any())
                {
                    Form resultForm = new Form();
                    DataGridView dgv = new DataGridView
                    {
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AutoGenerateColumns = false
                    };

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Cod", 
                        HeaderText = "Cod"
                    });

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Nume",
                        HeaderText = "Nume"
                    });

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Tip",
                        HeaderText = "Tip"
                    });

                    var pretColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "pret",
                        HeaderText = "Preț"
                    };
                    dgv.Columns.Add(pretColumn);

                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "stoc",
                        HeaderText = "Stoc"
                    });

                    pretColumn.DefaultCellStyle.Format = "C2";
                    pretColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgv.DataSource = produseZefir;

                    resultForm.Text = "Produse Zefir Roz";
                    resultForm.Size = new Size(800, 600);
                    resultForm.Controls.Add(dgv);
                    resultForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nu există produse în tabelul Zefir Roz!",
                                    "Informație",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 208) 
                {
                    MessageBox.Show("Tabelul 'ProduseZefirRoz' nu există!\nCreați-l mai întâi.",
                                    "Eroare",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Eroare SQL: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
