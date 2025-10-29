namespace Laboratorio122
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
            btnPromedio = new Button();
            btnReset = new Button();
            btnSalir = new Button();
            lblTitulo = new Label();
            lblNota1 = new Label();
            lblNota2 = new Label();
            lblNota3 = new Label();
            txtNota1 = new TextBox();
            txtNota2 = new TextBox();
            txtNota3 = new TextBox();
            txtNotaPromedio = new TextBox();
            lblNotaPromedio = new Label();
            SuspendLayout();
            // 
            // btnPromedio
            // 
            btnPromedio.Location = new Point(35, 155);
            btnPromedio.Name = "btnPromedio";
            btnPromedio.Size = new Size(75, 23);
            btnPromedio.TabIndex = 0;
            btnPromedio.Text = "Promedio";
            btnPromedio.UseVisualStyleBackColor = true;
            btnPromedio.Click += btnPromedio_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(125, 155);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(217, 155);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(119, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(88, 15);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Nota Promedio";
            // 
            // lblNota1
            // 
            lblNota1.AutoSize = true;
            lblNota1.Location = new Point(61, 56);
            lblNota1.Name = "lblNota1";
            lblNota1.Size = new Size(69, 15);
            lblNota1.TabIndex = 4;
            lblNota1.Text = "NOTA No. 1";
            // 
            // lblNota2
            // 
            lblNota2.AutoSize = true;
            lblNota2.Location = new Point(61, 90);
            lblNota2.Name = "lblNota2";
            lblNota2.Size = new Size(69, 15);
            lblNota2.TabIndex = 5;
            lblNota2.Text = "NOTA No. 2";
            // 
            // lblNota3
            // 
            lblNota3.AutoSize = true;
            lblNota3.Location = new Point(61, 124);
            lblNota3.Name = "lblNota3";
            lblNota3.Size = new Size(69, 15);
            lblNota3.TabIndex = 6;
            lblNota3.Text = "NOTA No. 3";
            // 
            // txtNota1
            // 
            txtNota1.Location = new Point(168, 48);
            txtNota1.Name = "txtNota1";
            txtNota1.Size = new Size(100, 23);
            txtNota1.TabIndex = 7;
            // 
            // txtNota2
            // 
            txtNota2.Location = new Point(168, 82);
            txtNota2.Name = "txtNota2";
            txtNota2.Size = new Size(100, 23);
            txtNota2.TabIndex = 8;
            // 
            // txtNota3
            // 
            txtNota3.Location = new Point(168, 116);
            txtNota3.Name = "txtNota3";
            txtNota3.Size = new Size(100, 23);
            txtNota3.TabIndex = 9;
            // 
            // txtNotaPromedio
            // 
            txtNotaPromedio.Location = new Point(168, 198);
            txtNotaPromedio.Name = "txtNotaPromedio";
            txtNotaPromedio.Size = new Size(100, 23);
            txtNotaPromedio.TabIndex = 10;
            // 
            // lblNotaPromedio
            // 
            lblNotaPromedio.AutoSize = true;
            lblNotaPromedio.Location = new Point(61, 206);
            lblNotaPromedio.Name = "lblNotaPromedio";
            lblNotaPromedio.Size = new Size(88, 15);
            lblNotaPromedio.TabIndex = 11;
            lblNotaPromedio.Text = "Nota Promedio";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 450);
            Controls.Add(lblNotaPromedio);
            Controls.Add(txtNotaPromedio);
            Controls.Add(txtNota3);
            Controls.Add(txtNota2);
            Controls.Add(txtNota1);
            Controls.Add(lblNota3);
            Controls.Add(lblNota2);
            Controls.Add(lblNota1);
            Controls.Add(lblTitulo);
            Controls.Add(btnSalir);
            Controls.Add(btnReset);
            Controls.Add(btnPromedio);
            Name = "Form1";
            Text = "Calcular Promedio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPromedio;
        private Button btnReset;
        private Button btnSalir;
        private Label lblTitulo;
        private Label lblNota1;
        private Label lblNota2;
        private Label lblNota3;
        private TextBox txtNota1;
        private TextBox txtNota2;
        private TextBox txtNota3;
        private TextBox txtNotaPromedio;
        private Label lblNotaPromedio;
    }
}
