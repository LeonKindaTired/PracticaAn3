using Microsoft.Data.SqlClient;
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
    }
}
