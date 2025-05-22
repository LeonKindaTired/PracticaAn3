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
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            ((System.ComponentModel.ISupportInitialize)productsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(1147, 49);
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
            button2.Location = new Point(626, 70);
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
            button3.Location = new Point(780, 70);
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
            productsDataGrid.Size = new Size(893, 345);
            productsDataGrid.TabIndex = 4;
            // 
            // txtDeleteCod
            // 
            txtDeleteCod.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDeleteCod.Location = new Point(934, 107);
            txtDeleteCod.Name = "txtDeleteCod";
            txtDeleteCod.PlaceholderText = "Cod de sters";
            txtDeleteCod.Size = new Size(125, 27);
            txtDeleteCod.TabIndex = 6;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(1065, 105);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 7;
            button4.Text = "Sterge";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(934, 151);
            button5.Name = "button5";
            button5.Size = new Size(225, 29);
            button5.TabIndex = 8;
            button5.Text = "Ieftina Caramela";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.Location = new Point(934, 186);
            button6.Name = "button6";
            button6.Size = new Size(225, 29);
            button6.TabIndex = 9;
            button6.Text = "Bomboane Cu Zahar";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.Location = new Point(934, 254);
            button7.Name = "button7";
            button7.Size = new Size(225, 29);
            button7.TabIndex = 11;
            button7.Text = "Continut Ciocolata";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // txtCiocolata
            // 
            txtCiocolata.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCiocolata.Location = new Point(1034, 221);
            txtCiocolata.Name = "txtCiocolata";
            txtCiocolata.PlaceholderText = "%";
            txtCiocolata.Size = new Size(125, 27);
            txtCiocolata.TabIndex = 10;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(934, 224);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 12;
            label2.Text = "% Ciocolata";
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.Location = new Point(934, 289);
            button8.Name = "button8";
            button8.Size = new Size(225, 29);
            button8.TabIndex = 13;
            button8.Text = "Export";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button9.Location = new Point(934, 324);
            button9.Name = "button9";
            button9.Size = new Size(225, 29);
            button9.TabIndex = 14;
            button9.Text = "Media Preturilor";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button10.Location = new Point(934, 359);
            button10.Name = "button10";
            button10.Size = new Size(225, 29);
            button10.TabIndex = 15;
            button10.Text = "Lista Pentru Diabetici";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button11.Location = new Point(934, 394);
            button11.Name = "button11";
            button11.Size = new Size(225, 29);
            button11.TabIndex = 16;
            button11.Text = "Top Vanzari";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 462);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
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
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
    }
}
