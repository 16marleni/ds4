namespace Proyecto1
{
    partial class FormCalculadora
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
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btn0 = new Button();
            btnPunto = new Button();
            btnIgual = new Button();
            btnSuma = new Button();
            btnResta = new Button();
            btnMultiplicacion = new Button();
            btnDivision = new Button();
            btnC = new Button();
            btnCE = new Button();
            btnRaiz = new Button();
            btnCuadrado = new Button();
            btnCubo = new Button();
            btnPorcentaje = new Button();
            btnCalculos = new Button();
            lbCalculos = new ListBox();
            lblResultados = new Label();
            lblHistorial = new Label();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI", 15F);
            btn1.Location = new Point(18, 243);
            btn1.Name = "btn1";
            btn1.Size = new Size(42, 42);
            btn1.TabIndex = 0;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btnNumero_Click;
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI", 15F);
            btn2.Location = new Point(65, 243);
            btn2.Name = "btn2";
            btn2.Size = new Size(42, 42);
            btn2.TabIndex = 1;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btnNumero_Click;
            // 
            // btn3
            // 
            btn3.Font = new Font("Segoe UI", 15F);
            btn3.Location = new Point(112, 243);
            btn3.Name = "btn3";
            btn3.Size = new Size(42, 42);
            btn3.TabIndex = 2;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btnNumero_Click;
            // 
            // btn4
            // 
            btn4.Font = new Font("Segoe UI", 15F);
            btn4.Location = new Point(18, 195);
            btn4.Name = "btn4";
            btn4.Size = new Size(42, 42);
            btn4.TabIndex = 3;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btnNumero_Click;
            // 
            // btn5
            // 
            btn5.Font = new Font("Segoe UI", 15F);
            btn5.Location = new Point(65, 195);
            btn5.Name = "btn5";
            btn5.Size = new Size(42, 42);
            btn5.TabIndex = 4;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btnNumero_Click;
            // 
            // btn6
            // 
            btn6.Font = new Font("Segoe UI", 15F);
            btn6.Location = new Point(112, 195);
            btn6.Name = "btn6";
            btn6.Size = new Size(42, 42);
            btn6.TabIndex = 5;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btnNumero_Click;
            // 
            // btn7
            // 
            btn7.Font = new Font("Segoe UI", 15F);
            btn7.Location = new Point(18, 147);
            btn7.Name = "btn7";
            btn7.Size = new Size(42, 42);
            btn7.TabIndex = 6;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btnNumero_Click;
            // 
            // btn8
            // 
            btn8.Font = new Font("Segoe UI", 15F);
            btn8.Location = new Point(65, 147);
            btn8.Name = "btn8";
            btn8.Size = new Size(42, 42);
            btn8.TabIndex = 7;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btnNumero_Click;
            // 
            // btn9
            // 
            btn9.Font = new Font("Segoe UI", 15F);
            btn9.Location = new Point(112, 147);
            btn9.Name = "btn9";
            btn9.Size = new Size(42, 42);
            btn9.TabIndex = 8;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btnNumero_Click;
            // 
            // btn0
            // 
            btn0.Font = new Font("Segoe UI", 15F);
            btn0.Location = new Point(18, 291);
            btn0.Name = "btn0";
            btn0.Size = new Size(42, 42);
            btn0.TabIndex = 9;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btnNumero_Click;
            // 
            // btnPunto
            // 
            btnPunto.Font = new Font("Segoe UI", 15F);
            btnPunto.Location = new Point(66, 291);
            btnPunto.Name = "btnPunto";
            btnPunto.Size = new Size(42, 42);
            btnPunto.TabIndex = 10;
            btnPunto.Text = ".";
            btnPunto.UseVisualStyleBackColor = true;
            btnPunto.Click += btnPunto_Click;
            // 
            // btnIgual
            // 
            btnIgual.Font = new Font("Segoe UI", 15F);
            btnIgual.Location = new Point(112, 291);
            btnIgual.Name = "btnIgual";
            btnIgual.Size = new Size(42, 42);
            btnIgual.TabIndex = 11;
            btnIgual.Text = "=";
            btnIgual.UseVisualStyleBackColor = true;
            btnIgual.Click += btnIgual_Click;
            // 
            // btnSuma
            // 
            btnSuma.BackColor = SystemColors.ActiveCaptionText;
            btnSuma.Font = new Font("Segoe UI", 15F);
            btnSuma.ForeColor = SystemColors.ControlLightLight;
            btnSuma.Location = new Point(160, 291);
            btnSuma.Name = "btnSuma";
            btnSuma.Size = new Size(42, 42);
            btnSuma.TabIndex = 12;
            btnSuma.Text = "+";
            btnSuma.UseVisualStyleBackColor = false;
            btnSuma.Click += btnOperador_Click;
            // 
            // btnResta
            // 
            btnResta.BackColor = SystemColors.ActiveCaptionText;
            btnResta.Font = new Font("Segoe UI", 15F);
            btnResta.ForeColor = SystemColors.ControlLightLight;
            btnResta.Location = new Point(160, 243);
            btnResta.Name = "btnResta";
            btnResta.Size = new Size(42, 42);
            btnResta.TabIndex = 13;
            btnResta.Text = "-";
            btnResta.UseVisualStyleBackColor = false;
            btnResta.Click += btnOperador_Click;
            // 
            // btnMultiplicacion
            // 
            btnMultiplicacion.BackColor = SystemColors.ActiveCaptionText;
            btnMultiplicacion.Font = new Font("Segoe UI", 15F);
            btnMultiplicacion.ForeColor = SystemColors.ControlLightLight;
            btnMultiplicacion.Location = new Point(160, 195);
            btnMultiplicacion.Name = "btnMultiplicacion";
            btnMultiplicacion.Size = new Size(42, 42);
            btnMultiplicacion.TabIndex = 14;
            btnMultiplicacion.Text = "x";
            btnMultiplicacion.UseVisualStyleBackColor = false;
            btnMultiplicacion.Click += btnOperador_Click;
            // 
            // btnDivision
            // 
            btnDivision.BackColor = SystemColors.ActiveCaptionText;
            btnDivision.Font = new Font("Segoe UI", 15F);
            btnDivision.ForeColor = SystemColors.ControlLightLight;
            btnDivision.Location = new Point(160, 147);
            btnDivision.Name = "btnDivision";
            btnDivision.Size = new Size(42, 42);
            btnDivision.TabIndex = 15;
            btnDivision.Text = "÷";
            btnDivision.UseVisualStyleBackColor = false;
            btnDivision.Click += btnOperador_Click;
            // 
            // btnC
            // 
            btnC.BackColor = SystemColors.HotTrack;
            btnC.Font = new Font("Segoe UI", 15F);
            btnC.Location = new Point(18, 51);
            btnC.Name = "btnC";
            btnC.Size = new Size(42, 42);
            btnC.TabIndex = 16;
            btnC.Text = "C";
            btnC.UseVisualStyleBackColor = false;
            btnC.Click += btnC_Click;
            // 
            // btnCE
            // 
            btnCE.BackColor = SystemColors.HotTrack;
            btnCE.Font = new Font("Segoe UI", 15F);
            btnCE.Location = new Point(66, 51);
            btnCE.Name = "btnCE";
            btnCE.Size = new Size(42, 42);
            btnCE.TabIndex = 17;
            btnCE.Text = "CE";
            btnCE.UseVisualStyleBackColor = false;
            btnCE.Click += btnCE_Click;
            // 
            // btnRaiz
            // 
            btnRaiz.BackColor = SystemColors.ActiveCaption;
            btnRaiz.Font = new Font("Segoe UI", 15F);
            btnRaiz.Location = new Point(18, 99);
            btnRaiz.Name = "btnRaiz";
            btnRaiz.Size = new Size(42, 42);
            btnRaiz.TabIndex = 18;
            btnRaiz.Text = "√";
            btnRaiz.UseVisualStyleBackColor = false;
            btnRaiz.Click += btnFuncion_Click;
            // 
            // btnCuadrado
            // 
            btnCuadrado.BackColor = SystemColors.ActiveCaption;
            btnCuadrado.Font = new Font("Segoe UI", 15F);
            btnCuadrado.Location = new Point(66, 99);
            btnCuadrado.Name = "btnCuadrado";
            btnCuadrado.Size = new Size(42, 42);
            btnCuadrado.TabIndex = 19;
            btnCuadrado.Text = "x²";
            btnCuadrado.UseVisualStyleBackColor = false;
            btnCuadrado.Click += btnFuncion_Click;
            // 
            // btnCubo
            // 
            btnCubo.BackColor = SystemColors.ActiveCaption;
            btnCubo.Font = new Font("Segoe UI", 15F);
            btnCubo.Location = new Point(112, 99);
            btnCubo.Name = "btnCubo";
            btnCubo.Size = new Size(42, 42);
            btnCubo.TabIndex = 20;
            btnCubo.Text = "x³";
            btnCubo.UseVisualStyleBackColor = false;
            btnCubo.Click += btnFuncion_Click;
            // 
            // btnPorcentaje
            // 
            btnPorcentaje.BackColor = SystemColors.ActiveCaption;
            btnPorcentaje.Font = new Font("Segoe UI", 15F);
            btnPorcentaje.Location = new Point(160, 99);
            btnPorcentaje.Name = "btnPorcentaje";
            btnPorcentaje.Size = new Size(42, 42);
            btnPorcentaje.TabIndex = 21;
            btnPorcentaje.Text = "%";
            btnPorcentaje.UseVisualStyleBackColor = false;
            btnPorcentaje.Click += btnFuncion_Click;
            // 
            // btnCalculos
            // 
            btnCalculos.BackColor = SystemColors.Info;
            btnCalculos.Font = new Font("Segoe UI", 9F);
            btnCalculos.Location = new Point(112, 51);
            btnCalculos.Name = "btnCalculos";
            btnCalculos.Size = new Size(90, 42);
            btnCalculos.TabIndex = 22;
            btnCalculos.Text = "Mostrar Cálculos";
            btnCalculos.UseVisualStyleBackColor = false;
            btnCalculos.Click += btnCalculos_Click;
            // 
            // lbCalculos
            // 
            lbCalculos.BackColor = SystemColors.Info;
            lbCalculos.FormattingEnabled = true;
            lbCalculos.ItemHeight = 15;
            lbCalculos.Location = new Point(217, 85);
            lbCalculos.Name = "lbCalculos";
            lbCalculos.Size = new Size(258, 244);
            lbCalculos.TabIndex = 23;
            // 
            // lblResultados
            // 
            lblResultados.BackColor = SystemColors.ActiveBorder;
            lblResultados.BorderStyle = BorderStyle.Fixed3D;
            lblResultados.Font = new Font("Arial", 9F);
            lblResultados.Location = new Point(18, 14);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(459, 34);
            lblResultados.TabIndex = 24;
            lblResultados.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHistorial
            // 
            lblHistorial.BackColor = SystemColors.Info;
            lblHistorial.BorderStyle = BorderStyle.Fixed3D;
            lblHistorial.Location = new Point(217, 55);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(258, 22);
            lblHistorial.TabIndex = 25;
            lblHistorial.Text = "Historial de Cálculos";
            lblHistorial.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormCalculadora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 347);
            Controls.Add(lblHistorial);
            Controls.Add(lblResultados);
            Controls.Add(lbCalculos);
            Controls.Add(btnCalculos);
            Controls.Add(btnPorcentaje);
            Controls.Add(btnCubo);
            Controls.Add(btnCuadrado);
            Controls.Add(btnRaiz);
            Controls.Add(btnCE);
            Controls.Add(btnC);
            Controls.Add(btnDivision);
            Controls.Add(btnMultiplicacion);
            Controls.Add(btnResta);
            Controls.Add(btnSuma);
            Controls.Add(btnIgual);
            Controls.Add(btnPunto);
            Controls.Add(btn0);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Name = "FormCalculadora";
            Text = "CALCULADORA";
            ResumeLayout(false);
        }

        #endregion

        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btn0;
        private Button btnPunto;
        private Button btnIgual;
        private Button btnSuma;
        private Button btnResta;
        private Button btnMultiplicacion;
        private Button btnDivision;
        private Button btnC;
        private Button btnCE;
        private Button btnRaiz;
        private Button btnCuadrado;
        private Button btnCubo;
        private Button btnPorcentaje;
        private Button btnCalculos;
        private ListBox lbCalculos;
        private Label lblResultados;
        private Label lblHistorial;
    }
}
