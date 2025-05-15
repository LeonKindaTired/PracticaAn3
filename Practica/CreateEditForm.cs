using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practica.Model;
using Practica.Repositories;

namespace Practica
{
    public partial class CreateEditForm : Form
    {
        public CreateEditForm()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private int productId = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Produs product = new Produs();
            product.id_produs = this.productId;
            product.cod = txtCod.Text.Trim();
            product.nume = txtNume.Text.Trim();
            product.tip = cmbTip.SelectedItem?.ToString() ?? "";
            product.pret = decimal.Parse(nudPret.Text);
            product.continut_ciocolata = (int)nudCiocolata.Value;
            product.ingrediente = txtIngrediente.Text.Trim();
            product.pentru_diabetici = chkDiabetici.Checked;
            product.stoc = (int)nudStoc.Value;

            var repo = new ProdusRepository();

            try
            {
                if (string.IsNullOrWhiteSpace(product.cod))
                {
                    MessageBox.Show("Codul produsului este obligatoriu!");
                    return;
                }

                if (product.pret <= 0)
                {
                    MessageBox.Show("Prețul trebuie să fie pozitiv!");
                    return;
                }

                if (product.id_produs == 0)
                {
                    repo.CreateProdus(product);
                }
                else
                {
                    repo.UpdateProdus(product);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}");
            }
        }
    }
}
