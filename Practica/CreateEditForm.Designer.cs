namespace Practica
{
    partial class CreateEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtCod = new TextBox();
            txtNume = new TextBox();
            label5 = new Label();
            cmbTip = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtIngrediente = new TextBox();
            label10 = new Label();
            chkDiabetici = new CheckBox();
            label11 = new Label();
            nudStoc = new NumericUpDown();
            nudPret = new NumericUpDown();
            nudCiocolata = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)nudStoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPret).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCiocolata).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(538, 29);
            label1.TabIndex = 0;
            label1.Text = "Adaugare Produs";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 81);
            label2.Name = "label2";
            label2.Size = new Size(19, 17);
            label2.TabIndex = 1;
            label2.Text = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 81);
            label3.Name = "label3";
            label3.Size = new Size(0, 17);
            label3.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 116);
            label4.Name = "label4";
            label4.Size = new Size(33, 17);
            label4.TabIndex = 3;
            label4.Text = "Cod";
            // 
            // txtCod
            // 
            txtCod.Location = new Point(177, 113);
            txtCod.Name = "txtCod";
            txtCod.Size = new Size(214, 23);
            txtCod.TabIndex = 4;
            // 
            // txtNume
            // 
            txtNume.Location = new Point(177, 154);
            txtNume.Name = "txtNume";
            txtNume.Size = new Size(214, 23);
            txtNume.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 157);
            label5.Name = "label5";
            label5.Size = new Size(45, 17);
            label5.TabIndex = 5;
            label5.Text = "Nume";
            // 
            // cmbTip
            // 
            cmbTip.FormattingEnabled = true;
            cmbTip.Items.AddRange(new object[] { "Caramela", "Ciocolata", "Bomboana", "Zefir", "Inghetata" });
            cmbTip.Location = new Point(177, 197);
            cmbTip.Name = "cmbTip";
            cmbTip.Size = new Size(214, 25);
            cmbTip.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 200);
            label6.Name = "label6";
            label6.Size = new Size(28, 17);
            label6.TabIndex = 8;
            label6.Text = "Tip";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 246);
            label7.Name = "label7";
            label7.Size = new Size(34, 17);
            label7.TabIndex = 9;
            label7.Text = "Pret";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(45, 289);
            label8.Name = "label8";
            label8.Size = new Size(122, 17);
            label8.TabIndex = 11;
            label8.Text = "Continut Ciocolata";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(45, 329);
            label9.Name = "label9";
            label9.Size = new Size(79, 17);
            label9.TabIndex = 13;
            label9.Text = "Ingrediente";
            // 
            // txtIngrediente
            // 
            txtIngrediente.Location = new Point(177, 326);
            txtIngrediente.Multiline = true;
            txtIngrediente.Name = "txtIngrediente";
            txtIngrediente.Size = new Size(214, 53);
            txtIngrediente.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(45, 411);
            label10.Name = "label10";
            label10.Size = new Size(108, 17);
            label10.TabIndex = 15;
            label10.Text = "Pentru Diabetici";
            // 
            // chkDiabetici
            // 
            chkDiabetici.AutoSize = true;
            chkDiabetici.Location = new Point(177, 411);
            chkDiabetici.Name = "chkDiabetici";
            chkDiabetici.Size = new Size(48, 21);
            chkDiabetici.TabIndex = 16;
            chkDiabetici.Text = "Da";
            chkDiabetici.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(45, 451);
            label11.Name = "label11";
            label11.Size = new Size(36, 17);
            label11.TabIndex = 18;
            label11.Text = "Stoc";
            // 
            // nudStoc
            // 
            nudStoc.Location = new Point(177, 449);
            nudStoc.Name = "nudStoc";
            nudStoc.Size = new Size(214, 23);
            nudStoc.TabIndex = 19;
            // 
            // nudPret
            // 
            nudPret.Location = new Point(177, 244);
            nudPret.Name = "nudPret";
            nudPret.Size = new Size(214, 23);
            nudPret.TabIndex = 20;
            // 
            // nudCiocolata
            // 
            nudCiocolata.Location = new Point(177, 287);
            nudCiocolata.Name = "nudCiocolata";
            nudCiocolata.Size = new Size(214, 23);
            nudCiocolata.TabIndex = 21;
            // 
            // button1
            // 
            button1.Location = new Point(45, 509);
            button1.Name = "button1";
            button1.Size = new Size(226, 29);
            button1.TabIndex = 22;
            button1.Text = "Adaugare";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(296, 509);
            button2.Name = "button2";
            button2.Size = new Size(226, 29);
            button2.TabIndex = 23;
            button2.Text = "Anulare";
            button2.UseVisualStyleBackColor = true;
            // 
            // CreateEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 567);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(nudCiocolata);
            Controls.Add(nudPret);
            Controls.Add(nudStoc);
            Controls.Add(label11);
            Controls.Add(chkDiabetici);
            Controls.Add(label10);
            Controls.Add(txtIngrediente);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cmbTip);
            Controls.Add(txtNume);
            Controls.Add(label5);
            Controls.Add(txtCod);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "CreateEditForm";
            Text = "CreateEditForm";
            ((System.ComponentModel.ISupportInitialize)nudStoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPret).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCiocolata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtCod;
        private TextBox txtNume;
        private Label label5;
        private ComboBox cmbTip;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtIngrediente;
        private Label label10;
        private CheckBox chkDiabetici;
        private Label label11;
        private NumericUpDown nudStoc;
        private NumericUpDown nudPret;
        private NumericUpDown nudCiocolata;
        private Button button1;
        private Button button2;
    }
}