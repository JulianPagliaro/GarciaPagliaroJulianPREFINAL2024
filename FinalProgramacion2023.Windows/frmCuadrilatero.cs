using FinalProgramacion2023.Entidades;

namespace FinalProgramacion2023.Windows
{
    public partial class frmCuadrilatero : Form
    {
        public frmCuadrilatero()
        {
            InitializeComponent();
        }
        private Cuadrilatero cuadrilatero;

        public Cuadrilatero GetCuadrilatero()
        { return cuadrilatero; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboColorRelleno();

            if (cuadrilatero != null)
            {
                txtLadoA.Text = cuadrilatero.LadoA.ToString();
                txtLadoB.Text = cuadrilatero.LadoB.ToString();

                cboRelleno.SelectedItem = cuadrilatero.ColorRelleno;

                if (cuadrilatero.TipoDeBorde == Borde.Linea)
                {
                    rbtLineal.Checked = true;
                }
                else if (cuadrilatero.TipoDeBorde == Borde.Rayas)
                {
                    rbtRayas.Checked = true;
                }
                else
                {
                    rbtPuntos.Checked = true;
                }
            }
        }
        private void CargarDatosComboColorRelleno()
        {
            var listaColores = Enum.GetValues(typeof(Entidades.Color)).Cast<Entidades.Color>().ToList();
            cboRelleno.DataSource = listaColores;
            cboRelleno.SelectedIndex = 0;
        }
        public void SetCuadrilatero(Cuadrilatero cuadrilatero)
        {
            this.cuadrilatero = cuadrilatero;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cuadrilatero == null)
                {
                    cuadrilatero = new Cuadrilatero();
                }

                cuadrilatero.SetLadoA(int.Parse(txtLadoA.Text));
                cuadrilatero.SetLadoB(int.Parse(txtLadoB.Text));
                cuadrilatero.ColorRelleno = (Entidades.Color)cboRelleno.SelectedItem;

                if (rbtLineal.Checked)
                {
                    cuadrilatero.TipoDeBorde = Borde.Linea;
                }
                else if (rbtRayas.Checked)
                {
                    cuadrilatero.TipoDeBorde = Borde.Rayas;
                }
                else
                {
                    cuadrilatero.TipoDeBorde = Borde.Puntos;
                }
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            ladoAErrorProvider.Clear();
            ladoBErrorProvider.Clear();

            if (!int.TryParse(txtLadoA.Text, out int lado1) || lado1 <= 0)
            {
                valido = false;
                ladoAErrorProvider.SetError(txtLadoA, "Valor inválido");
            }

            if (!int.TryParse(txtLadoB.Text, out int lado2) || lado2 <= 0)
            {
                valido = false;
                ladoBErrorProvider.SetError(txtLadoB, "Valor inválido");
            }
            return valido;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtLadoA.Text = "";
            txtLadoB.Text = "";
        }
    }
}
