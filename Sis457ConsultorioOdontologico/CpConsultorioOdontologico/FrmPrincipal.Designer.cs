namespace CpConsultorioOdontologico
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlCabeza = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pbsUsuario = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.pnlDatos = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlCabeza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbsUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::CpConsultorioOdontologico.Properties.Resources.icon;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(428, 37);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(165, 124);
            this.pbxLogo.TabIndex = 1;
            this.pbxLogo.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.BackgroundImage = global::CpConsultorioOdontologico.Properties.Resources.salida;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Location = new System.Drawing.Point(937, 15);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 73);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlCabeza
            // 
            this.pnlCabeza.BackColor = System.Drawing.Color.Transparent;
            this.pnlCabeza.Controls.Add(this.lblTitulo);
            this.pnlCabeza.Controls.Add(this.pbxLogo);
            this.pnlCabeza.Controls.Add(this.btnSalir);
            this.pnlCabeza.Location = new System.Drawing.Point(1, 0);
            this.pnlCabeza.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCabeza.Name = "pnlCabeza";
            this.pnlCabeza.Size = new System.Drawing.Size(1033, 169);
            this.pnlCabeza.TabIndex = 3;
            this.pnlCabeza.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCabeza_Paint);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(124)))), ((int)(((byte)(127)))));
            this.lblTitulo.Location = new System.Drawing.Point(15, 11);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(357, 43);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "Acceso al Sistema";
            // 
            // pbsUsuario
            // 
            this.pbsUsuario.BackgroundImage = global::CpConsultorioOdontologico.Properties.Resources.background_text;
            this.pbsUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbsUsuario.Location = new System.Drawing.Point(3, 68);
            this.pbsUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbsUsuario.Name = "pbsUsuario";
            this.pbsUsuario.Size = new System.Drawing.Size(361, 65);
            this.pbsUsuario.TabIndex = 0;
            this.pbsUsuario.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.White;
            this.txtUsuario.Location = new System.Drawing.Point(11, 94);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(332, 22);
            this.txtUsuario.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CpConsultorioOdontologico.Properties.Resources.background_text;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(4, 183);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 65);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.White;
            this.txtClave.Location = new System.Drawing.Point(11, 207);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(332, 22);
            this.txtClave.TabIndex = 3;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(124)))), ((int)(((byte)(127)))));
            this.lblUsuario.Location = new System.Drawing.Point(4, 21);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(357, 43);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "USUARIO:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(124)))), ((int)(((byte)(127)))));
            this.lblContraseña.Location = new System.Drawing.Point(3, 139);
            this.lblContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(361, 43);
            this.lblContraseña.TabIndex = 5;
            this.lblContraseña.Text = "CONTRASEÑA:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(238)))), ((int)(((byte)(245)))));
            this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.btnIngresar.FlatAppearance.BorderSize = 3;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(84)))), ((int)(((byte)(87)))));
            this.btnIngresar.Location = new System.Drawing.Point(72, 282);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(245, 43);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "Iniciar Sesión";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.Transparent;
            this.pnlDatos.Controls.Add(this.btnIngresar);
            this.pnlDatos.Controls.Add(this.lblContraseña);
            this.pnlDatos.Controls.Add(this.lblUsuario);
            this.pnlDatos.Controls.Add(this.txtClave);
            this.pnlDatos.Controls.Add(this.pictureBox1);
            this.pnlDatos.Controls.Add(this.txtUsuario);
            this.pnlDatos.Controls.Add(this.pbsUsuario);
            this.pnlDatos.Location = new System.Drawing.Point(328, 169);
            this.pnlDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(365, 348);
            this.pnlDatos.TabIndex = 0;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CpConsultorioOdontologico.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1035, 607);
            this.Controls.Add(this.pnlCabeza);
            this.Controls.Add(this.pnlDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":::Principal:::Consultorio Odontologico";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlCabeza.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbsUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlCabeza;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pbsUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Panel pnlDatos;
    }
}

