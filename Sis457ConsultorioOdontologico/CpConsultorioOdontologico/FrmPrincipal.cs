using ClnConsultorioOdontologico;
using MySql.Data.MySqlClient;
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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        MySqlConnection conexionDB = UsuarioCln.conexion();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool validar()
        {
            bool esValido = true;
            erpUsuario.SetError(txtUsuario, "");
            erpClave.SetError(txtClave, "");
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                erpUsuario.SetError(txtUsuario, "El campo usuario es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                erpClave.SetError(txtClave, "El campo contraseña es obligatorio");
                esValido = false;
            }
            return esValido;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                FrmPaciente llamar = new FrmPaciente();
                llamar.Show();
                Size = new Size(776, 344);
                this.Hide();
            }
            //try
            //{
            //    conexionDB.Open();
            //}
            //catch (Exception ex)
            //{
            //  MessageBox.Show(ex.Message);
            //}
            //MySqlCommand codigo = new MySqlCommand();
            //codigo.Connection = conexionDB;

            //codigo.CommandText = ("SELECT * FROM usuario WHERE usuario = '" + txtUsuario.Text + "'and clave = '" + txtClave.Text + "' ");

            //MySqlDataReader leer = codigo.ExecuteReader();

            //if (leer.Read())
            //{
            //   FrmPaciente llamar = new FrmPaciente();
            //   llamar.Show();
            //   Size = new Size(776, 344);
            //   this.Hide();
            // }
            //else
            //{
            //   MessageBox.Show("Usuario o Contraseña Incorrecta");
            //   txtUsuario.Clear();
            //    txtClave.Clear();
            // }
            // conexionDB.Close();

        }

        private void pnlCabeza_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        int posY = 0;
        int posX = 0;
        private void pnlCabeza_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }
    }
}
