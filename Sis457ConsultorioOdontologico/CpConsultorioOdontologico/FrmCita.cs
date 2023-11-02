﻿using CadConsultorioOdontologico;
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
    public partial class FrmCita : Form
    {
        bool esNuevo = false;
        public FrmCita()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var cita = CitaCln.listarPa(txtParametro.Text.Trim());
            dgvLista.DataSource = cita;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["fecha"].HeaderText = "Fecha de la Consulta";
            dgvLista.Columns["hora"].HeaderText = "Hora de la Consulta";
            dgvLista.Columns["tratamiento"].HeaderText = "Tratamiento";
            dgvLista.Columns["pago"].HeaderText = "Historial de Pago";
            dgvLista.Columns["aCuenta"].HeaderText = "A Cuenta";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha del Registro";
            btnEditar.Enabled = cita.Count > 0;
            btnEliminar.Enabled = cita.Count > 0;
            if (cita.Count > 0) dgvLista.Rows[0].Cells["tratamiento"].Selected = true;

        }

        private void FrmCita_Load(object sender, EventArgs e)
        {
            Size = new Size(776, 344);
            listar();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Size = new Size(776, 493);
            esNuevo = true;
            txtTratamiento.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Size = new Size(776, 493);
            esNuevo = false;

            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            var cita = CitaCln.get(id);
            dtpFecha.Value = cita.fecha;
            txtTratamiento.Text = cita.tratamiento;
            cbxPago.Text = cita.pago;
            txtAcuenta.Text = cita.aCuenta;
            txtHora.Text = cita.hora;
        }

        private void button2_Click(object sender, EventArgs e)//Cancelar
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
        private bool validar()
        {
            bool esValido = true;
            erpFecha.SetError(dtpFecha, "");
            erpTratamiento.SetError(txtTratamiento, "");
            erpPago.SetError(cbxPago, "");
            erpAcuenta.SetError(txtAcuenta, "");
            erpHora.SetError(txtHora, "");
            if (string.IsNullOrEmpty(dtpFecha.Text))
            {
                esValido = false;
                erpFecha.SetError(dtpFecha, "El campo Fecha es obligatorio");
            }
            if (string.IsNullOrEmpty(txtTratamiento.Text))
            {
                esValido = false;
                erpTratamiento.SetError(txtTratamiento, "El campo Tratamiento es obligatorio");
            }
            if (string.IsNullOrEmpty(cbxPago.Text))
            {
                esValido = false;
                erpPago.SetError(cbxPago, "El campo Pago es obligatorio");
            }
            if (string.IsNullOrEmpty(txtAcuenta.Text))
            {
                esValido = false;
                erpAcuenta.SetError(txtAcuenta, "El campo a Cuenta es obligatorio");
            }
            if (string.IsNullOrEmpty(txtHora.Text))
            {
                esValido = false;
                erpHora.SetError(txtHora, "El campo Hora es obligatorio");
            }
            return esValido;
        }

        private void button1_Click(object sender, EventArgs e)//Guardar
        {
            //var nombrePaciente = MessageBox.Show("Ingrese el nombre del paciente:", "Ingrese el nombre del paciente",
            //MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            var cita = new Cita();
            cita.fecha = dtpFecha.Value;
            cita.tratamiento = txtTratamiento.Text.Trim();
            cita.pago = cbxPago.Text;
            cita.aCuenta = txtAcuenta.Text.Trim();
            cita.hora = txtHora.Text.Trim();
            cita.usuarioRegistro = "SIS457";

            if (esNuevo)
            {
                cita.fechaRegistro = DateTime.Now;
                cita.estado = 1;
                cita.idPaciente = 4;//solo para el paciente con id 4 
                CitaCln.insertar(cita);
            }
            else
            {
                int index = dgvLista.CurrentCell.RowIndex;
                cita.id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
                CitaCln.actualizar(cita);
            }
            listar();
            btnCancelar.PerformClick();
            MessageBox.Show("Cita guardada correctamente", "::: Consultorio Odontologico - Mensaje::: ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void limpiar()
        {
            dtpFecha.Value = DateTime.Now;
            txtTratamiento.Text = string.Empty;
            cbxPago.SelectedIndex = -1;
            txtAcuenta.Text = string.Empty;
            txtHora.Text = string.Empty;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                int index = dgvLista.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
                string fecha = dgvLista.Rows[index].Cells["fecha"].Value.ToString();
                DialogResult dialog = MessageBox.Show($"¿Está seguro de eliminar la Cita {fecha}?",
                    "::: Consultorio Odontologico - Mensaje :::", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    CitaCln.eliminar(id, "SIS457");
                    listar();
                    MessageBox.Show("Cita eliminada correctamente", "::: Consultorio Odontologico - Mensaje :::",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            FrmPaciente llamar = new FrmPaciente();
            llamar.Show();
            Size = new Size(776, 344);
            this.Hide();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            FrmCita llamar = new FrmCita();
            llamar.Show();
            Size = new Size(776, 344);
            this.Hide();
        }
    }
}
