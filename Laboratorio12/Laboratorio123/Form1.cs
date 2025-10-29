namespace Laboratorio123
{
    public partial class Form1 : Form
    {
        private Calculos calculos;
        public Form1()
        {
            InitializeComponent(); //Inicializa todos los controles visuales
        }

        private void btnSemiperimetro_Click(object sender, EventArgs e)
        {
            try //Para manejar errores de datos ingresados por el usuario
            {
                double LadoA = double.Parse(txtLadoA.Text);
                double LadoB = double.Parse(txtLadoB.Text);
                double LadoC = double.Parse(txtLadoC.Text);

                calculos = new Calculos(LadoA, LadoB, LadoC);
                double resultadoSemiperimetro = calculos.CalcularSemiperimetro(); //Está utilizando la clase calculos con su método calcular semiperimetro

                txtSemiperimetro.Text = resultadoSemiperimetro.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Mensaje de error que se mostrará
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            try
            {
                // Se verifica que calculos no sea null
                if (calculos != null)
                {
                    double resultadosArea = calculos.CalcularArea();
                    txtArea.Text = resultadosArea.ToString();
                }
                else
                {
                    MessageBox.Show("Primero debes calcular el semiperímetro.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLadoA.Clear();
            txtLadoB.Clear();
            txtLadoC.Clear();
            txtSemiperimetro.Clear();
            txtArea.Clear();
            txtLadoA.Focus(); // Pone el cursor de nuevo en LadoA
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        private void Form1_Load(object sender, EventArgs e) { } //Se crea cuando el formulario se crea por primera vez, se puede utilizar para mostrar valores de inicio
    }
}
