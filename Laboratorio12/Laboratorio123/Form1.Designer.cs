namespace Laboratorio123
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
            btnSemiperimetro = new Button();
            btnArea = new Button();
            btnReset = new Button();
            btnSalida = new Button();
            lblLadoA = new Label();
            lblLadoB = new Label();
            lblLadoC = new Label();
            lblSemiperimetro = new Label();
            lblArea = new Label();
            txtLadoA = new TextBox();
            txtLadoB = new TextBox();
            txtLadoC = new TextBox();
            txtSemiperimetro = new TextBox();
            txtArea = new TextBox();
            SuspendLayout();
            // 
            // btnSemiperimetro
            // 
            btnSemiperimetro.Location = new Point(12, 125);
            btnSemiperimetro.Name = "btnSemiperimetro";
            btnSemiperimetro.Size = new Size(97, 23);
            btnSemiperimetro.TabIndex = 0;
            btnSemiperimetro.Text = "Semiperímetro";
            btnSemiperimetro.UseVisualStyleBackColor = true;
            btnSemiperimetro.Click += btnSemiperimetro_Click;
            // 
            // btnArea
            // 
            btnArea.Location = new Point(118, 125);
            btnArea.Name = "btnArea";
            btnArea.Size = new Size(75, 23);
            btnArea.TabIndex = 1;
            btnArea.Text = "Área";
            btnArea.UseVisualStyleBackColor = true;
            btnArea.Click += btnArea_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(202, 125);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSalida
            // 
            btnSalida.Location = new Point(287, 125);
            btnSalida.Name = "btnSalida";
            btnSalida.Size = new Size(75, 23);
            btnSalida.TabIndex = 3;
            btnSalida.Text = "Salida";
            btnSalida.UseVisualStyleBackColor = true;
            btnSalida.Click += btnSalir_Click;
            // 
            // lblLadoA
            // 
            lblLadoA.AutoSize = true;
            lblLadoA.Location = new Point(20, 20);
            lblLadoA.Name = "lblLadoA";
            lblLadoA.Size = new Size(161, 15);
            lblLadoA.TabIndex = 4;
            lblLadoA.Text = "Ingresa la longitud del lado A";
            // 
            // lblLadoB
            // 
            lblLadoB.AutoSize = true;
            lblLadoB.Location = new Point(21, 54);
            lblLadoB.Name = "lblLadoB";
            lblLadoB.Size = new Size(160, 15);
            lblLadoB.TabIndex = 5;
            lblLadoB.Text = "Ingresa la longitud del lado B";
            // 
            // lblLadoC
            // 
            lblLadoC.AutoSize = true;
            lblLadoC.Location = new Point(21, 91);
            lblLadoC.Name = "lblLadoC";
            lblLadoC.Size = new Size(161, 15);
            lblLadoC.TabIndex = 6;
            lblLadoC.Text = "Ingresa la longitud del lado C";
            // 
            // lblSemiperimetro
            // 
            lblSemiperimetro.AutoSize = true;
            lblSemiperimetro.Location = new Point(21, 170);
            lblSemiperimetro.Name = "lblSemiperimetro";
            lblSemiperimetro.Size = new Size(131, 15);
            lblSemiperimetro.TabIndex = 7;
            lblSemiperimetro.Text = "Calcular Semiperímetro";
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Location = new Point(21, 205);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(103, 15);
            lblArea.TabIndex = 8;
            lblArea.Text = "Área del Triángulo";
            // 
            // txtLadoA
            // 
            txtLadoA.Location = new Point(194, 12);
            txtLadoA.Name = "txtLadoA";
            txtLadoA.Size = new Size(100, 23);
            txtLadoA.TabIndex = 9;
            // 
            // txtLadoB
            // 
            txtLadoB.Location = new Point(194, 46);
            txtLadoB.Name = "txtLadoB";
            txtLadoB.Size = new Size(100, 23);
            txtLadoB.TabIndex = 10;
            // 
            // txtLadoC
            // 
            txtLadoC.Location = new Point(194, 83);
            txtLadoC.Name = "txtLadoC";
            txtLadoC.Size = new Size(100, 23);
            txtLadoC.TabIndex = 11;
            // 
            // txtSemiperimetro
            // 
            txtSemiperimetro.Location = new Point(194, 162);
            txtSemiperimetro.Name = "txtSemiperimetro";
            txtSemiperimetro.Size = new Size(100, 23);
            txtSemiperimetro.TabIndex = 12;
            // 
            // txtArea
            // 
            txtArea.Location = new Point(194, 197);
            txtArea.Name = "txtArea";
            txtArea.Size = new Size(100, 23);
            txtArea.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 450);
            Controls.Add(txtArea);
            Controls.Add(txtSemiperimetro);
            Controls.Add(txtLadoC);
            Controls.Add(txtLadoB);
            Controls.Add(txtLadoA);
            Controls.Add(lblArea);
            Controls.Add(lblSemiperimetro);
            Controls.Add(lblLadoC);
            Controls.Add(lblLadoB);
            Controls.Add(lblLadoA);
            Controls.Add(btnSalida);
            Controls.Add(btnReset);
            Controls.Add(btnArea);
            Controls.Add(btnSemiperimetro);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSemiperimetro;
        private Button btnArea;
        private Button btnReset;
        private Button btnSalida;
        private Label lblLadoA;
        private Label lblLadoB;
        private Label lblLadoC;
        private Label lblSemiperimetro;
        private Label lblArea;
        private TextBox txtLadoA;
        private TextBox txtLadoB;
        private TextBox txtLadoC;
        private TextBox txtSemiperimetro;
        private TextBox txtArea;
    }
}
