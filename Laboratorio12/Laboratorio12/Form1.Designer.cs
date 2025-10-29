namespace Laboratorio12
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
            lblTitulo = new Label();
            lblVelocidad = new Label();
            lblTiempo = new Label();
            txtVelocidad = new TextBox();
            txtTiempo = new TextBox();
            txtResultado = new TextBox();
            lblResultado = new Label();
            btnCalcular = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(133, 39);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(194, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CALCULAR DISTANCIA RECORRIDA";
            // 
            // lblVelocidad
            // 
            lblVelocidad.AutoSize = true;
            lblVelocidad.Location = new Point(87, 85);
            lblVelocidad.Name = "lblVelocidad";
            lblVelocidad.Size = new Size(158, 15);
            lblVelocidad.TabIndex = 1;
            lblVelocidad.Text = "Ingresar velocidad del móvil:";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(87, 131);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(145, 15);
            lblTiempo.TabIndex = 2;
            lblTiempo.Text = "Ingresar tiempo del móvil:";
            // 
            // txtVelocidad
            // 
            txtVelocidad.Location = new Point(274, 77);
            txtVelocidad.Name = "txtVelocidad";
            txtVelocidad.Size = new Size(100, 23);
            txtVelocidad.TabIndex = 3;
            // 
            // txtTiempo
            // 
            txtTiempo.Location = new Point(274, 123);
            txtTiempo.Name = "txtTiempo";
            txtTiempo.Size = new Size(100, 23);
            txtTiempo.TabIndex = 4;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(245, 212);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(100, 23);
            txtResultado.TabIndex = 5;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(124, 220);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(108, 15);
            lblResultado.TabIndex = 6;
            lblResultado.Text = "Distancia recorrida:";
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(100, 168);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(75, 23);
            btnCalcular.TabIndex = 7;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(194, 168);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(290, 168);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCalcular);
            Controls.Add(lblResultado);
            Controls.Add(txtResultado);
            Controls.Add(txtTiempo);
            Controls.Add(txtVelocidad);
            Controls.Add(lblTiempo);
            Controls.Add(lblVelocidad);
            Controls.Add(lblTitulo);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblVelocidad;
        private Label lblTiempo;
        private TextBox txtVelocidad;
        private TextBox txtTiempo;
        private TextBox txtResultado;
        private Label lblResultado;
        private Button btnCalcular;
        private Button btnLimpiar;
        private Button btnSalir;
    }
}
