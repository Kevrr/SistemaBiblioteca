namespace SistemaBiblioteca.Formularios
{
    partial class FrmUsuarios
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
            grpDatos = new GroupBox();
            lblIdUsuario = new Label();
            txtIdUsuario = new TextBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblFechaRegistro = new Label();
            dtpFechaRegistro = new DateTimePicker();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvUsuarios = new DataGridView();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblIdUsuario);
            grpDatos.Controls.Add(txtIdUsuario);
            grpDatos.Controls.Add(lblDocumento);
            grpDatos.Controls.Add(txtDocumento);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblApellido);
            grpDatos.Controls.Add(txtApellido);
            grpDatos.Controls.Add(lblTelefono);
            grpDatos.Controls.Add(txtTelefono);
            grpDatos.Controls.Add(lblCorreo);
            grpDatos.Controls.Add(txtCorreo);
            grpDatos.Controls.Add(lblFechaRegistro);
            grpDatos.Controls.Add(dtpFechaRegistro);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(340, 292);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del usuario";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Location = new Point(15, 33);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.TabIndex = 0;
            lblIdUsuario.Text = "Código:";
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Location = new Point(130, 30);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.ReadOnly = true;
            txtIdUsuario.Size = new Size(190, 23);
            txtIdUsuario.TabIndex = 1;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(15, 69);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.TabIndex = 2;
            lblDocumento.Text = "Documento:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(130, 66);
            txtDocumento.MaxLength = 20;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(190, 23);
            txtDocumento.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 105);
            lblNombre.Name = "lblNombre";
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 102);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(190, 23);
            txtNombre.TabIndex = 5;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(15, 141);
            lblApellido.Name = "lblApellido";
            lblApellido.TabIndex = 6;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(130, 138);
            txtApellido.MaxLength = 60;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(190, 23);
            txtApellido.TabIndex = 7;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(15, 177);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.TabIndex = 8;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(130, 174);
            txtTelefono.MaxLength = 20;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(190, 23);
            txtTelefono.TabIndex = 9;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(15, 213);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.TabIndex = 10;
            lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(130, 210);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(190, 23);
            txtCorreo.TabIndex = 11;
            // 
            // lblFechaRegistro
            // 
            lblFechaRegistro.AutoSize = true;
            lblFechaRegistro.Location = new Point(15, 249);
            lblFechaRegistro.Name = "lblFechaRegistro";
            lblFechaRegistro.TabIndex = 12;
            lblFechaRegistro.Text = "Fecha registro:";
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Enabled = false;
            dtpFechaRegistro.Format = DateTimePickerFormat.Short;
            dtpFechaRegistro.Location = new Point(130, 246);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(190, 23);
            dtpFechaRegistro.TabIndex = 13;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 316);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 32);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(98, 316);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 32);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(184, 316);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(80, 32);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(270, 316);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(80, 32);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(370, 17);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.TabIndex = 5;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(425, 13);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Escriba para buscar...";
            txtBuscar.Size = new Size(455, 23);
            txtBuscar.TabIndex = 6;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(888, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 27);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = SystemColors.Window;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(370, 50);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(593, 408);
            dgvUsuarios.TabIndex = 8;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 470);
            Controls.Add(grpDatos);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(btnCerrar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(dgvUsuarios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "FrmUsuarios";
            Text = "Gestión de Usuarios";
            Load += FrmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Label lblIdUsuario;
        private TextBox txtIdUsuario;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblFechaRegistro;
        private DateTimePicker dtpFechaRegistro;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCerrar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvUsuarios;
    }
}
