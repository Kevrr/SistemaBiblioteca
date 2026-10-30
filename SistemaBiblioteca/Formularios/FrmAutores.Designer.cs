namespace SistemaBiblioteca.Formularios
{
    partial class FrmAutores
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
            lblIdAutor = new Label();
            txtIdAutor = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblNacionalidad = new Label();
            txtNacionalidad = new TextBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvAutores = new DataGridView();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblIdAutor);
            grpDatos.Controls.Add(txtIdAutor);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblApellido);
            grpDatos.Controls.Add(txtApellido);
            grpDatos.Controls.Add(lblNacionalidad);
            grpDatos.Controls.Add(txtNacionalidad);
            grpDatos.Controls.Add(lblFechaNacimiento);
            grpDatos.Controls.Add(dtpFechaNacimiento);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(340, 220);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del autor";
            // 
            // lblIdAutor
            // 
            lblIdAutor.AutoSize = true;
            lblIdAutor.Location = new Point(15, 33);
            lblIdAutor.Name = "lblIdAutor";
            lblIdAutor.TabIndex = 0;
            lblIdAutor.Text = "Código:";
            // 
            // txtIdAutor
            // 
            txtIdAutor.Location = new Point(130, 30);
            txtIdAutor.Name = "txtIdAutor";
            txtIdAutor.ReadOnly = true;
            txtIdAutor.Size = new Size(190, 23);
            txtIdAutor.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(15, 69);
            lblNombre.Name = "lblNombre";
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 66);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(190, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(15, 105);
            lblApellido.Name = "lblApellido";
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(130, 102);
            txtApellido.MaxLength = 60;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(190, 23);
            txtApellido.TabIndex = 5;
            // 
            // lblNacionalidad
            // 
            lblNacionalidad.AutoSize = true;
            lblNacionalidad.Location = new Point(15, 141);
            lblNacionalidad.Name = "lblNacionalidad";
            lblNacionalidad.TabIndex = 6;
            lblNacionalidad.Text = "Nacionalidad:";
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(130, 138);
            txtNacionalidad.MaxLength = 50;
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(190, 23);
            txtNacionalidad.TabIndex = 7;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(15, 177);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.TabIndex = 8;
            lblFechaNacimiento.Text = "Fecha nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(130, 174);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.ShowCheckBox = true;
            dtpFechaNacimiento.Size = new Size(190, 23);
            dtpFechaNacimiento.TabIndex = 9;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 244);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 32);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(98, 244);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 32);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(184, 244);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(80, 32);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(270, 244);
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
            // dgvAutores
            // 
            dgvAutores.AllowUserToAddRows = false;
            dgvAutores.AllowUserToDeleteRows = false;
            dgvAutores.AllowUserToResizeRows = false;
            dgvAutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutores.BackgroundColor = SystemColors.Window;
            dgvAutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutores.Location = new Point(370, 50);
            dgvAutores.MultiSelect = false;
            dgvAutores.Name = "dgvAutores";
            dgvAutores.ReadOnly = true;
            dgvAutores.RowHeadersVisible = false;
            dgvAutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutores.Size = new Size(593, 408);
            dgvAutores.TabIndex = 8;
            dgvAutores.CellClick += dgvAutores_CellClick;
            // 
            // FrmAutores
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
            Controls.Add(dgvAutores);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "FrmAutores";
            Text = "Gestión de Autores";
            Load += FrmAutores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAutores).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Label lblIdAutor;
        private TextBox txtIdAutor;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblNacionalidad;
        private TextBox txtNacionalidad;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCerrar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvAutores;
    }
}
