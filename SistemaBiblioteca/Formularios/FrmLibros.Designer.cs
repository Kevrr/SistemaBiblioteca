namespace SistemaBiblioteca.Formularios
{
    partial class FrmLibros
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
            lblIdLibro = new Label();
            txtIdLibro = new TextBox();
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblAutor = new Label();
            cmbAutor = new ComboBox();
            lblEditorial = new Label();
            cmbEditorial = new ComboBox();
            lblAnio = new Label();
            txtAnio = new TextBox();
            lblGenero = new Label();
            txtGenero = new TextBox();
            lblExistencias = new Label();
            nudExistencias = new NumericUpDown();
            lblDisponibles = new Label();
            txtDisponibles = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            lblBuscar = new Label();
            cmbCriterio = new ComboBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvLibros = new DataGridView();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudExistencias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblIdLibro);
            grpDatos.Controls.Add(txtIdLibro);
            grpDatos.Controls.Add(lblISBN);
            grpDatos.Controls.Add(txtISBN);
            grpDatos.Controls.Add(lblTitulo);
            grpDatos.Controls.Add(txtTitulo);
            grpDatos.Controls.Add(lblAutor);
            grpDatos.Controls.Add(cmbAutor);
            grpDatos.Controls.Add(lblEditorial);
            grpDatos.Controls.Add(cmbEditorial);
            grpDatos.Controls.Add(lblAnio);
            grpDatos.Controls.Add(txtAnio);
            grpDatos.Controls.Add(lblGenero);
            grpDatos.Controls.Add(txtGenero);
            grpDatos.Controls.Add(lblExistencias);
            grpDatos.Controls.Add(nudExistencias);
            grpDatos.Controls.Add(lblDisponibles);
            grpDatos.Controls.Add(txtDisponibles);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(340, 364);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del libro";
            // 
            // lblIdLibro
            // 
            lblIdLibro.AutoSize = true;
            lblIdLibro.Location = new Point(15, 33);
            lblIdLibro.Name = "lblIdLibro";
            lblIdLibro.TabIndex = 0;
            lblIdLibro.Text = "Código:";
            // 
            // txtIdLibro
            // 
            txtIdLibro.Location = new Point(130, 30);
            txtIdLibro.Name = "txtIdLibro";
            txtIdLibro.ReadOnly = true;
            txtIdLibro.Size = new Size(190, 23);
            txtIdLibro.TabIndex = 1;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(15, 69);
            lblISBN.Name = "lblISBN";
            lblISBN.TabIndex = 2;
            lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(130, 66);
            txtISBN.MaxLength = 20;
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(190, 23);
            txtISBN.TabIndex = 3;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(15, 105);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(130, 102);
            txtTitulo.MaxLength = 150;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(190, 23);
            txtTitulo.TabIndex = 5;
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(15, 141);
            lblAutor.Name = "lblAutor";
            lblAutor.TabIndex = 6;
            lblAutor.Text = "Autor:";
            // 
            // cmbAutor
            // 
            cmbAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAutor.FormattingEnabled = true;
            cmbAutor.Location = new Point(130, 138);
            cmbAutor.Name = "cmbAutor";
            cmbAutor.Size = new Size(190, 23);
            cmbAutor.TabIndex = 7;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(15, 177);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.TabIndex = 8;
            lblEditorial.Text = "Editorial:";
            // 
            // cmbEditorial
            // 
            cmbEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditorial.FormattingEnabled = true;
            cmbEditorial.Location = new Point(130, 174);
            cmbEditorial.Name = "cmbEditorial";
            cmbEditorial.Size = new Size(190, 23);
            cmbEditorial.TabIndex = 9;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(15, 213);
            lblAnio.Name = "lblAnio";
            lblAnio.TabIndex = 10;
            lblAnio.Text = "Año publicación:";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(130, 210);
            txtAnio.MaxLength = 4;
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(190, 23);
            txtAnio.TabIndex = 11;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Location = new Point(15, 249);
            lblGenero.Name = "lblGenero";
            lblGenero.TabIndex = 12;
            lblGenero.Text = "Género:";
            // 
            // txtGenero
            // 
            txtGenero.Location = new Point(130, 246);
            txtGenero.MaxLength = 50;
            txtGenero.Name = "txtGenero";
            txtGenero.Size = new Size(190, 23);
            txtGenero.TabIndex = 13;
            // 
            // lblExistencias
            // 
            lblExistencias.AutoSize = true;
            lblExistencias.Location = new Point(15, 285);
            lblExistencias.Name = "lblExistencias";
            lblExistencias.TabIndex = 14;
            lblExistencias.Text = "Existencias:";
            // 
            // nudExistencias
            // 
            nudExistencias.Location = new Point(130, 282);
            nudExistencias.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudExistencias.Name = "nudExistencias";
            nudExistencias.Size = new Size(190, 23);
            nudExistencias.TabIndex = 15;
            // 
            // lblDisponibles
            // 
            lblDisponibles.AutoSize = true;
            lblDisponibles.Location = new Point(15, 321);
            lblDisponibles.Name = "lblDisponibles";
            lblDisponibles.TabIndex = 16;
            lblDisponibles.Text = "Disponibles:";
            // 
            // txtDisponibles
            // 
            txtDisponibles.Location = new Point(130, 318);
            txtDisponibles.Name = "txtDisponibles";
            txtDisponibles.ReadOnly = true;
            txtDisponibles.Size = new Size(190, 23);
            txtDisponibles.TabIndex = 17;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 388);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 32);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(98, 388);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 32);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(184, 388);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(80, 32);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(270, 388);
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
            // cmbCriterio
            // 
            cmbCriterio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriterio.FormattingEnabled = true;
            cmbCriterio.Location = new Point(425, 13);
            cmbCriterio.Name = "cmbCriterio";
            cmbCriterio.Size = new Size(100, 23);
            cmbCriterio.TabIndex = 6;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(533, 13);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Escriba para buscar...";
            txtBuscar.Size = new Size(347, 23);
            txtBuscar.TabIndex = 7;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(888, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 27);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.AllowUserToResizeRows = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.BackgroundColor = SystemColors.Window;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(370, 50);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.RowHeadersVisible = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(593, 408);
            dgvLibros.TabIndex = 9;
            dgvLibros.CellClick += dgvLibros_CellClick;
            // 
            // FrmLibros
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
            Controls.Add(cmbCriterio);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(dgvLibros);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "FrmLibros";
            Text = "Gestión de Libros";
            Load += FrmLibros_Load;
            ((System.ComponentModel.ISupportInitialize)nudExistencias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Label lblIdLibro;
        private TextBox txtIdLibro;
        private Label lblISBN;
        private TextBox txtISBN;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblAutor;
        private ComboBox cmbAutor;
        private Label lblEditorial;
        private ComboBox cmbEditorial;
        private Label lblAnio;
        private TextBox txtAnio;
        private Label lblGenero;
        private TextBox txtGenero;
        private Label lblExistencias;
        private NumericUpDown nudExistencias;
        private Label lblDisponibles;
        private TextBox txtDisponibles;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCerrar;
        private Label lblBuscar;
        private ComboBox cmbCriterio;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvLibros;
    }
}
