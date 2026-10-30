namespace SistemaBiblioteca.Formularios
{
    partial class FrmEditoriales
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
            lblIdEditorial = new Label();
            txtIdEditorial = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPais = new Label();
            txtPais = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvEditoriales = new DataGridView();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblIdEditorial);
            grpDatos.Controls.Add(txtIdEditorial);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblPais);
            grpDatos.Controls.Add(txtPais);
            grpDatos.Controls.Add(lblTelefono);
            grpDatos.Controls.Add(txtTelefono);
            grpDatos.Controls.Add(lblCorreo);
            grpDatos.Controls.Add(txtCorreo);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(340, 220);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos de la editorial";
            // 
            // lblIdEditorial
            // 
            lblIdEditorial.AutoSize = true;
            lblIdEditorial.Location = new Point(15, 33);
            lblIdEditorial.Name = "lblIdEditorial";
            lblIdEditorial.TabIndex = 0;
            lblIdEditorial.Text = "Código:";
            // 
            // txtIdEditorial
            // 
            txtIdEditorial.Location = new Point(130, 30);
            txtIdEditorial.Name = "txtIdEditorial";
            txtIdEditorial.ReadOnly = true;
            txtIdEditorial.Size = new Size(190, 23);
            txtIdEditorial.TabIndex = 1;
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
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(190, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Location = new Point(15, 105);
            lblPais.Name = "lblPais";
            lblPais.TabIndex = 4;
            lblPais.Text = "País:";
            // 
            // txtPais
            // 
            txtPais.Location = new Point(130, 102);
            txtPais.MaxLength = 50;
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(190, 23);
            txtPais.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(15, 141);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(130, 138);
            txtTelefono.MaxLength = 20;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(190, 23);
            txtTelefono.TabIndex = 7;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(15, 177);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.TabIndex = 8;
            lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(130, 174);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(190, 23);
            txtCorreo.TabIndex = 9;
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
            // dgvEditoriales
            // 
            dgvEditoriales.AllowUserToAddRows = false;
            dgvEditoriales.AllowUserToDeleteRows = false;
            dgvEditoriales.AllowUserToResizeRows = false;
            dgvEditoriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEditoriales.BackgroundColor = SystemColors.Window;
            dgvEditoriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEditoriales.Location = new Point(370, 50);
            dgvEditoriales.MultiSelect = false;
            dgvEditoriales.Name = "dgvEditoriales";
            dgvEditoriales.ReadOnly = true;
            dgvEditoriales.RowHeadersVisible = false;
            dgvEditoriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEditoriales.Size = new Size(593, 408);
            dgvEditoriales.TabIndex = 8;
            dgvEditoriales.CellClick += dgvEditoriales_CellClick;
            // 
            // FrmEditoriales
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
            Controls.Add(dgvEditoriales);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "FrmEditoriales";
            Text = "Gestión de Editoriales";
            Load += FrmEditoriales_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEditoriales).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Label lblIdEditorial;
        private TextBox txtIdEditorial;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPais;
        private TextBox txtPais;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnCerrar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvEditoriales;
    }
}
