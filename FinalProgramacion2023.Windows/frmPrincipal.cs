using FinalProgramacion2023.Datos;
using FinalProgramacion2023.Entidades;
using System.Windows.Forms;

namespace FinalProgramacion2023.Windows
{
    public partial class frmPrincipal : Form
    {
        private RepositorioDeCuadrilatero repo;
        private List<Cuadrilatero> lista;
        int valorFiltro;
        bool filterOn = false;
        public frmPrincipal()
        {
            InitializeComponent();
            repo = new RepositorioDeCuadrilatero();
            ActualizarCantidadDeRegistros();
            txtCantidad.Text = repo.GetCantidad().ToString();
        }
        public int ContarCuadrilaterosMostrados()
        {
            return dgvDatos.Rows.Count;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCuadrilatero Form = new frmCuadrilatero() { Text = "Agregar Cuadrilatero" };
            DialogResult dr = Form.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            Cuadrilatero cuadrilatero = Form.GetCuadrilatero();
            if (!repo.Existe(cuadrilatero))
            {
                repo.Agregar(cuadrilatero);
                ActualizarCantidadDeRegistros();
                DataGridViewRow l = ConstruirFila();
                SetearFila(l, cuadrilatero);
                AgregarFila(l);

                MessageBox.Show("Registro añadido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Registro existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void AgregarFila(DataGridViewRow l)
        {
            dgvDatos.Rows.Add(l);
        }
        private void SetearFila(DataGridViewRow l, Cuadrilatero cuadrilatero)
        {
            l.Cells[colLadoA.Index].Value = cuadrilatero.GetLadoA();
            l.Cells[colLadoB.Index].Value = cuadrilatero.GetLadoB();
            l.Cells[colColor.Index].Value = cuadrilatero.ColorRelleno;
            l.Cells[colBorde.Index].Value = cuadrilatero.TipoDeBorde;
            l.Cells[colArea.Index].Value = cuadrilatero.GetArea().ToString(".000");
            l.Cells[colPerimetro.Index].Value = cuadrilatero.GetPerimetro().ToString(".000");
            l.Cells[colTipoDeCuadrilatero.Index].Value = cuadrilatero.GetTipoDeCuadrilatero();
            l.Tag = cuadrilatero;
        }
        private DataGridViewRow ConstruirFila()
        {
            var l = new DataGridViewRow();
            l.CreateCells(dgvDatos);
            return l;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (repo.GetCantidad() > 0)
            {
                RecargarGrilla();
            }
        }
        private void RecargarGrilla()
        {
            valorFiltro = 0;
            filterOn = false;
            tsbFiltrar.BackColor = SystemColors.Control;
            lista = repo.GetLista();
            MostrarDatosEnGrilla();
            ActualizarCantidadDeRegistros();
        }
        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var cuad in lista)
            {
                DataGridViewRow l = ConstruirFila();
                SetearFila(l, cuad);
                AgregarFila(l);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("¿Borrar la fila seleccionada?", "Confirmar", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            else
            {
                var l = dgvDatos.SelectedRows[0];
                QuitarFila(l);
                var cuadrilateroBorrar = (Cuadrilatero)l.Tag;
                repo.Borrar(cuadrilateroBorrar);
                ActualizarCantidadDeRegistros();
                MessageBox.Show("Fila eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ActualizarCantidadDeRegistros()
        {
            if (valorFiltro > 0)
            {
                txtCantidad.Text = repo.GetCantidad(valorFiltro).ToString();
            }
            else
            {
                txtCantidad.Text = repo.GetCantidad().ToString();
            }
        }
        private void QuitarFila(DataGridViewRow l)
        {
            dgvDatos.Rows.Remove(l);
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {

            if (!filterOn)
            {
                var entradaValorFiltro = Microsoft.VisualBasic.Interaction.InputBox("Ingrese un valor para filtrar por color \n \n 1 = Rojo \n 2 = Azul \n 3 = Verde",
            "Filtrar por Color:",
            "0", 200, 200);
                if (!int.TryParse(entradaValorFiltro, out valorFiltro))
                {
                    return;
                }
                if (valorFiltro <= 0)
                {
                    return;
                }
                lista = repo.Filtrar(valorFiltro);
                filterOn = true;
                MostrarDatosEnGrilla();
                ActualizarContador();

            }
            else
            {
                MessageBox.Show("Filtro aplicado! \n Debe actualizar la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizarContador()
        {
            txtCantidad.Text = ContarCuadrilaterosMostrados().ToString();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var FilaSeleccionada = dgvDatos.SelectedRows[0];
            Cuadrilatero cuadrilatero = (Cuadrilatero)FilaSeleccionada.Tag;
            Cuadrilatero cuadrilateroCopia = (Cuadrilatero)cuadrilatero.Clone();
            frmCuadrilatero frm = new frmCuadrilatero() { Text = "Editar cuadrilatero" };
            frm.SetCuadrilatero(cuadrilatero);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            cuadrilatero = frm.GetCuadrilatero();
            if (!repo.Existe(cuadrilatero))
            {
                repo.Editar(cuadrilateroCopia, cuadrilatero);
                SetearFila(FilaSeleccionada, cuadrilatero);
                MessageBox.Show("Fila editada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SetearFila(FilaSeleccionada, cuadrilateroCopia);
                MessageBox.Show("Registro existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
