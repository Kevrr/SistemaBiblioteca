namespace SistemaBiblioteca.Formularios
{
    partial class FrmPrestamos
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
            lblIdPrestamo = new Label();
            txtIdPrestamo = new TextBox();
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            lblLibro = new Label();
            cmbLibro = new ComboBox();
            lblFechaPrestamo = new Label();
            dtpFechaPrestamo = new DateTimePicker();
            lblFechaPrevista = new Label();
            dtpFechaPrevista = new DateTimePicker();
            lblEstado = new Label();
            txtEstado = new TextBox();
            lblFechaDevolucion = new Label();
            txtFechaDevolucion = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            grpDevolucion = new GroupBox();
            lblFechaDevolucionNueva = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            btnDevolver = new Button();
            lblFiltro = new Label();
            cmbFiltroEstado = new ComboBox();
            lblLeyenda = new Label();
            dgvPrestamos = new DataGridView();
            grpDatos.SuspendLayout();
            grpDevolucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblIdPrestamo);
            grpDatos.Controls.Add(txtIdPrestamo);
            grpDatos.Controls.Add(lblUsuario);
            grpDatos.Controls.Add(cmbUsuario);
            grpDatos.Controls.Add(lblLibro);
            grpDatos.Controls.Add(cmbLibro);
            grpDatos.Controls.Add(lblFechaPrestamo);
            grpDatos.Controls.Add(dtpFechaPrestamo);
            grpDatos.Controls.Add(lblFechaPrevista);
            grpDatos.Controls.Add(dtpFechaPrevista);
            grpDatos.Controls.Add(lblEstado);
            grpDatos.Controls.Add(txtEstado);
            grpDatos.Controls.Add(lblFechaDevolucion);
            grpDatos.Controls.Add(txtFechaDevolucion);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(360, 280);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del préstamo";
            // 
            // lblIdPrestamo
            // 
            lblIdPrestamo.AutoSize = true;
            lblIdPrestamo.Location = new Point(15, 33);
            lblIdPrestamo.Name = "lblIdPrestamo";
            lblIdPrestamo.TabIndex = 0;
            lblIdPrestamo.Text = "Código:";
            // 
            // txtIdPrestamo
            // 
            txtIdPrestamo.Location = new Point(140, 30);
            txtIdPrestamo.Name = "txtIdPrestamo";
            txtIdPrestamo.ReadOnly = true;
            txtIdPrestamo.Size = new Size(205, 23);
            txtIdPrestamo.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(15, 68);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(140, 65);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(205, 23);
            cmbUsuario.TabIndex = 3;
            // 
            // lblLibro
            // 
            lblLibro.AutoSize = true;
            lblLibro.Location = new Point(15, 103);
            lblLibro.Name = "lblLibro";
            lblLibro.TabIndex = 4;
            lblLibro.Text = "Libro:";
            // 
            // cmbLibro
            // 
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLibro.FormattingEnabled = true;
            cmbLibro.Location = new Point(140, 100);
            cmbLibro.Name = "cmbLibro";
            cmbLibro.Size = new Size(205, 23);
            cmbLibro.TabIndex = 5;
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Location = new Point(15, 138);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.TabIndex = 6;
            lblFechaPrestamo.Text = "Fecha préstamo:";
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Format = DateTimePickerFormat.Short;
            dtpFechaPrestamo.Location = new Point(140, 135);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(205, 23);
            dtpFechaPrestamo.TabIndex = 7;
            // 
            // lblFechaPrevista
            // 
            lblFechaPrevista.AutoSize = true;
            lblFechaPrevista.Location = new Point(15, 173);
            lblFechaPrevista.Name = "lblFechaPrevista";
            lblFechaPrevista.TabIndex = 8;
            lblFechaPrevista.Text = "Devolución prevista:";
            // 
            // dtpFechaPrevista
            // 
            dtpFechaPrevista.Format = DateTimePickerFormat.Short;
            dtpFechaPrevista.Location = new Point(140, 170);
            dtpFechaPrevista.Name = "dtpFechaPrevista";
            dtpFechaPrevista.Size = new Size(205, 23);
            dtpFechaPrevista.TabIndex = 9;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(15, 208);
            lblEstado.Name = "lblEstado";
            lblEstado.TabIndex = 10;
            lblEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(140, 205);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(205, 23);
            txtEstado.TabIndex = 11;
            // 
            // lblFechaDevolucion
            // 
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Location = new Point(15, 243);
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.TabIndex = 12;
            lblFechaDevolucion.Text = "Fecha devolución:";
            // 
            // txtFechaDevolucion
            // 
            txtFechaDevolucion.Location = new Point(140, 240);
            txtFechaDevolucion.Name = "txtFechaDevolucion";
            txtFechaDevolucion.ReadOnly = true;
            txtFechaDevolucion.Size = new Size(205, 23);
            txtFechaDevolucion.TabIndex = 13;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 304);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(85, 32);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(103, 304);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 32);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(194, 304);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(85, 32);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(285, 304);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(85, 32);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // grpDevolucion
            // 
            grpDevolucion.Controls.Add(lblFechaDevolucionNueva);
            grpDevolucion.Controls.Add(dtpFechaDevolucion);
            grpDevolucion.Controls.Add(btnDevolver);
            grpDevolucion.Location = new Point(12, 350);
            grpDevolucion.Name = "grpDevolucion";
            grpDevolucion.Size = new Size(360, 100);
            grpDevolucion.TabIndex = 5;
            grpDevolucion.TabStop = false;
            grpDevolucion.Text = "Registrar devolución";
            // 
            // lblFechaDevolucionNueva
            // 
            lblFechaDevolucionNueva.AutoSize = true;
            lblFechaDevolucionNueva.Location = new Point(15, 33);
            lblFechaDevolucionNueva.Name = "lblFechaDevolucionNueva";
            lblFechaDevolucionNueva.TabIndex = 0;
            lblFechaDevolucionNueva.Text = "Fecha devolución:";
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            dtpFechaDevolucion.Location = new Point(140, 30);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Size = new Size(205, 23);
            dtpFechaDevolucion.TabIndex = 1;
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(140, 60);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(205, 30);
            btnDevolver.TabIndex = 2;
            btnDevolver.Text = "Registrar devolución";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Click += btnDevolver_Click;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(390, 17);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.TabIndex = 6;
            lblFiltro.Text = "Mostrar:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Location = new Point(450, 13);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(150, 23);
            cmbFiltroEstado.TabIndex = 7;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            // 
            // lblLeyenda
            // 
            lblLeyenda.AutoSize = true;
            lblLeyenda.ForeColor = Color.Firebrick;
            lblLeyenda.Location = new Point(615, 17);
            lblLeyenda.Name = "lblLeyenda";
            lblLeyenda.TabIndex = 8;
            lblLeyenda.Text = "Las filas en rojo son préstamos vencidos.";
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.AllowUserToDeleteRows = false;
            dgvPrestamos.AllowUserToResizeRows = false;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestamos.BackgroundColor = SystemColors.Window;
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Location = new Point(390, 50);
            dgvPrestamos.MultiSelect = false;
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.RowHeadersVisible = false;
            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamos.Size = new Size(640, 400);
            dgvPrestamos.TabIndex = 9;
            dgvPrestamos.CellClick += dgvPrestamos_CellClick;
            dgvPrestamos.CellFormatting += dgvPrestamos_CellFormatting;
            // 
            // FrmPrestamos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 465);
            Controls.Add(grpDatos);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(btnCerrar);
            Controls.Add(grpDevolucion);
            Controls.Add(lblFiltro);
            Controls.Add(cmbFiltroEstado);
            Controls.Add(lblLeyenda);
            Controls.Add(dgvPrestamos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "FrmPrestamos";
            Text = "Gestión de Préstamos y Devoluciones";
            Load += FrmPrestamos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpDevolucion.ResumeLayout(false);
            grpDevolucion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Label lblIdPrestamo;
        private TextBox txtIdPrestamo;
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblLibro;
        private ComboBox cmbLibro;
        private Label lblFechaPrestamo;
        private DateTimePicker dtpFechaPrestamo;
        private Label lblFechaPrevista;
        private DateTimePicker dtpFechaPrevista;
        private Label lblEstado;
        private TextBox txtEstado;
        private Label lblFechaDevolucion;
        private TextBox txtFechaDevolucion;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCerrar;
        private GroupBox grpDevolucion;
        private Label lblFechaDevolucionNueva;
        private DateTimePicker dtpFechaDevolucion;
        private Button btnDevolver;
        private Label lblFiltro;
        private ComboBox cmbFiltroEstado;
        private Label lblLeyenda;
        private DataGridView dgvPrestamos;
    }
}
