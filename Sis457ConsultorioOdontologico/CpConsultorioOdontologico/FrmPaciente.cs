using ClnConsultorioOdontologico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpConsultorioOdontologico
{
    public partial class FrmPaciente : Form
    {
        bool esNuevo = false;
        public FrmPaciente()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var paciente = PacienteCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = paciente;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombres"].HeaderText = "Nombre";
            dgvLista.Columns["cedulaIdentidad"].HeaderText = "Cedula de Identidad";
            dgvLista.Columns["alergias"].HeaderText = "Alergias";
            dgvLista.Columns["fechaNacimiento"].HeaderText = "Fecha de Nacimiento";
            dgvLista.Columns["celular"].HeaderText = "Celular";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha del Registro";
            btnEditar.Enabled = paciente.Count > 0;
            btnEliminar.Enabled = paciente.Count > 0;
            if (paciente.Count > 0) dgvLista.Rows[0].Cells["nombres"].Selected = true;

        }

        private void FrmPaciente_Load(object sender, EventArgs e)
        {
            Size = new Size(776, 344);
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Size = new Size(776, 493);
            esNuevo = true;
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Size = new Size(776, 493);
            esNuevo = false;

            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            var paciente = PacienteCln.get(id);
            txtNombre.Text = paciente.nombres;
            txtCedulaIdentidad.Text = paciente.cedulaIdentidad;
            txtAlergias.Text = paciente.alergias;
            //txtFechaNacimiento.Text = paciente.fechaNacimiento;
            //txtCelular.Text = paciente.celular;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(776, 344);
            limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
            txtNombre.Text = string.Empty;
            txtCedulaIdentidad.Text = string.Empty;
            txtAlergias.Text = string.Empty;
        }
    }
}
