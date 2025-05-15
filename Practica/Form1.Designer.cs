namespace Practica
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            productsDataGrid = new DataGridView();
            txtDeleteCod = new TextBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            txtCiocolata = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)productsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(1062, 49);
            label1.TabIndex = 0;
            label1.Text = "Cofetarius";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.Location = new Point(12, 70);
            button1.Name = "button1";
            button1.Size = new Size(138, 29);
            button1.TabIndex = 1;
            button1.Text = "Adaugare Produs";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(541, 70);
            button2.Name = "button2";
            button2.Size = new Size(148, 29);
            button2.TabIndex = 2;
            button2.Text = "Actualizare Produs";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(695, 70);
            button3.Name = "button3";
            button3.Size = new Size(125, 29);
            button3.TabIndex = 3;
            button3.Text = "Stergere Produs";
            button3.UseVisualStyleBackColor = true;
            // 
            // productsDataGrid
            // 
            productsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            productsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsDataGrid.Location = new Point(12, 105);
            productsDataGrid.MultiSelect = false;
            productsDataGrid.Name = "productsDataGrid";
            productsDataGrid.RowHeadersWidth = 51;
            productsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productsDataGrid.Size = new Size(808, 345);
            productsDataGrid.TabIndex = 4;
            // 
            // txtDeleteCod
            // 
            txtDeleteCod.Location = new Point(849, 107);
            txtDeleteCod.Name = "txtDeleteCod";
            txtDeleteCod.PlaceholderText = "Cod de sters";
            txtDeleteCod.Size = new Size(125, 27);
            txtDeleteCod.TabIndex = 6;
            // 
            // button4
            // 
            button4.Location = new Point(980, 105);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 7;
            button4.Text = "Sterge";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(849, 151);
            button5.Name = "button5";
            button5.Size = new Size(225, 29);
            button5.TabIndex = 8;
            button5.Text = "Ieftina Caramela";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(849, 186);
            button6.Name = "button6";
            button6.Size = new Size(225, 29);
            button6.TabIndex = 9;
            button6.Text = "Bomboane Cu Zahar";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(849, 254);
            button7.Name = "button7";
            button7.Size = new Size(225, 29);
            button7.TabIndex = 11;
            button7.Text = "Continut Ciocolata";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // txtCiocolata
            // 
            txtCiocolata.Location = new Point(949, 221);
            txtCiocolata.Name = "txtCiocolata";
            txtCiocolata.PlaceholderText = "%";
            txtCiocolata.Size = new Size(125, 27);
            txtCiocolata.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(849, 224);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 12;
            label2.Text = "% Ciocolata";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 462);
            Controls.Add(label2);
            Controls.Add(button7);
            Controls.Add(txtCiocolata);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(txtDeleteCod);
            Controls.Add(productsDataGrid);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)productsDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView productsDataGrid;
        private TextBox txtDeleteCod;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private TextBox txtCiocolata;
        private Label label2;
    }
}
