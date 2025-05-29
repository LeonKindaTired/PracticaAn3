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
using System.Runtime.InteropServices;

namespace Practica
{
    public partial class CreateEditForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        public CreateEditForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            StyleForm();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void StyleForm()
        {
            this.BackColor = Color.FromArgb(255, 245, 225);
            this.Font = new Font("Arial", 10f);
            this.Padding = new Padding(20);

            Color buttonColor = Color.FromArgb(247, 200, 215);
            Color hoverColor = Color.FromArgb(255, 220, 230);
            Color cancelColor = Color.FromArgb(220, 220, 220);
            Color cancelHover = Color.FromArgb(240, 240, 240);

            StyleButton(button1, buttonColor, hoverColor, "Adaugare");
            StyleButton(button2, cancelColor, cancelHover, "Cancel");

            StyleInputControl(txtCod);
            StyleInputControl(txtNume);
            StyleInputControl(txtIngrediente);
            StyleInputControl(cmbTip);
            StyleInputControl(nudPret);
            StyleInputControl(nudCiocolata);
            StyleInputControl(nudStoc);

            foreach (Control c in this.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.Font = new Font("Arial", 10f, FontStyle.Bold);
                    lbl.ForeColor = Color.FromArgb(100, 100, 100);
                }
            }

            chkDiabetici.FlatStyle = FlatStyle.Flat;
            chkDiabetici.Font = new Font("Arial", 10f);
            chkDiabetici.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void StyleButton(Button btn, Color backColor, Color hoverColor, string text)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.FromArgb(80, 80, 80);
            btn.Font = new Font("Arial", 10f, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Text = text;
            btn.Height = 42;
            btn.MinimumSize = new Size(120, 42);
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 15, 15));
        }

        private void StyleInputControl(Control control)
        {
            control.BackColor = Color.White;
            control.Font = new Font("Arial", 10f);
            control.Height = 38;
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, 10, 10));

            if (control is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.None;
                textBox.Padding = new Padding(10, 8, 10, 8);
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else if (control is NumericUpDown numeric)
            {
                numeric.BorderStyle = BorderStyle.None;
                numeric.Controls[0].Visible = false;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
