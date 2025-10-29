namespace Laboratorio12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try //Para manejar errores de datos ingresados por el usuario
            {
                double Velocidad = double.Parse(txtVelocidad.Text);
                double Tiempo = double.Parse(txtTiempo.Text);

                Movimiento movimiento = new Movimiento(Velocidad, Tiempo);
                double distancia = movimiento.CalcularDistancia(); //Está utilizando la clase movimiento con su método calcular distancia

                txtResultado.Text = distancia.ToString() ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtVelocidad.Clear();
            txtTiempo.Clear();
            txtResultado.Clear();
            txtVelocidad.Focus(); // Pone el cursor de nuevo en velocidad
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        private void Form1_Load(object sender, EventArgs e) { } //Se crea cuando el formulario se crea por primera vez, se puede utilizar para mostrar valores de inicio
    }
}
