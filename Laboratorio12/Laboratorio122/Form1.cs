namespace Laboratorio122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            try //Para manejar errores de datos ingresados por el usuario
            {
                double Nota1 = double.Parse(txtNota1.Text);
                double Nota2 = double.Parse(txtNota2.Text);
                double Nota3 = double.Parse(txtNota3.Text);

                Promedio promedio = new Promedio(Nota1, Nota2, Nota3);
                double resultado = promedio.CalcularPromedio(); //Está utilizando la clase promedio con su método calcular promedio

                txtNotaPromedio.Text = resultado.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Mensaje de error que se mostrará
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtNotaPromedio.Clear();
            txtNota1.Focus(); // Pone el cursor de nuevo en Nota 1
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        private void Form1_Load(object sender, EventArgs e) { } //Se crea cuando el formulario se crea por primera vez, se puede utilizar para mostrar valores de inicio
    }
}
