namespace SistemaBiblioteca.Formularios
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
            pnlContenido = new Panel();
            pnlMenu = new Panel();
            lblMenuTitulo = new Label();
            btnInicio = new Button();
            btnLibros = new Button();
            btnUsuarios = new Button();
            btnAutores = new Button();
            btnEditoriales = new Button();
            btnPrestamos = new Button();
            btnReportes = new Button();
            btnSalir = new Button();
            lblBienvenida = new Label();
            lblDescripcion = new Label();
            lblFecha = new Label();
            grpResumen = new GroupBox();
            lblTotalLibros = new Label();
            lblTotalEjemplares = new Label();
            lblTotalUsuarios = new Label();
            lblPrestamosActivos = new Label();
            lblPrestamosVencidos = new Label();
            lblAviso = new Label();
            pnlContenido.SuspendLayout();
            pnlMenu.SuspendLayout();
            grpResumen.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.White;
            pnlContenido.Controls.Add(lblBienvenida);
            pnlContenido.Controls.Add(lblDescripcion);
            pnlContenido.Controls.Add(lblFecha);
            pnlContenido.Controls.Add(grpResumen);
            pnlContenido.Controls.Add(lblAviso);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(790, 600);
            pnlContenido.TabIndex = 0;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(32, 56, 100);
            pnlMenu.Controls.Add(lblMenuTitulo);
            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Controls.Add(btnLibros);
            pnlMenu.Controls.Add(btnUsuarios);
            pnlMenu.Controls.Add(btnAutores);
            pnlMenu.Controls.Add(btnEditoriales);
            pnlMenu.Controls.Add(btnPrestamos);
            pnlMenu.Controls.Add(btnReportes);
            pnlMenu.Controls.Add(btnSalir);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(210, 600);
            pnlMenu.TabIndex = 1;
            // 
            // lblMenuTitulo
            // 
            lblMenuTitulo.AutoSize = true;
            lblMenuTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMenuTitulo.ForeColor = Color.White;
            lblMenuTitulo.Location = new Point(20, 20);
            lblMenuTitulo.Name = "lblMenuTitulo";
            lblMenuTitulo.TabIndex = 0;
            lblMenuTitulo.Text = "BIBLIOTECA";
            // 
            // btnInicio
            // 
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(15, 80);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(180, 40);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnLibros
            // 
            btnLibros.Cursor = Cursors.Hand;
            btnLibros.FlatStyle = FlatStyle.Flat;
            btnLibros.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLibros.ForeColor = Color.White;
            btnLibros.Location = new Point(15, 130);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(180, 40);
            btnLibros.TabIndex = 2;
            btnLibros.Text = "Libros";
            btnLibros.UseVisualStyleBackColor = true;
            btnLibros.Click += btnLibros_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(15, 180);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(180, 40);
            btnUsuarios.TabIndex = 3;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnAutores
            // 
            btnAutores.Cursor = Cursors.Hand;
            btnAutores.FlatStyle = FlatStyle.Flat;
            btnAutores.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAutores.ForeColor = Color.White;
            btnAutores.Location = new Point(15, 230);
            btnAutores.Name = "btnAutores";
            btnAutores.Size = new Size(180, 40);
            btnAutores.TabIndex = 4;
            btnAutores.Text = "Autores";
            btnAutores.UseVisualStyleBackColor = true;
            btnAutores.Click += btnAutores_Click;
            // 
            // btnEditoriales
            // 
            btnEditoriales.Cursor = Cursors.Hand;
            btnEditoriales.FlatStyle = FlatStyle.Flat;
            btnEditoriales.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditoriales.ForeColor = Color.White;
            btnEditoriales.Location = new Point(15, 280);
            btnEditoriales.Name = "btnEditoriales";
            btnEditoriales.Size = new Size(180, 40);
            btnEditoriales.TabIndex = 5;
            btnEditoriales.Text = "Editoriales";
            btnEditoriales.UseVisualStyleBackColor = true;
            btnEditoriales.Click += btnEditoriales_Click;
            // 
            // btnPrestamos
            // 
            btnPrestamos.Cursor = Cursors.Hand;
            btnPrestamos.FlatStyle = FlatStyle.Flat;
            btnPrestamos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrestamos.ForeColor = Color.White;
            btnPrestamos.Location = new Point(15, 330);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(180, 40);
            btnPrestamos.TabIndex = 6;
            btnPrestamos.Text = "Préstamos";
            btnPrestamos.UseVisualStyleBackColor = true;
            btnPrestamos.Click += btnPrestamos_Click;
            // 
            // btnReportes
            // 
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(15, 380);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(180, 40);
            btnReportes.TabIndex = 7;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnSalir
            // 
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(15, 450);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(180, 40);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenida.ForeColor = Color.FromArgb(32, 56, 100);
            lblBienvenida.Location = new Point(30, 30);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Sistema de Gestión de Biblioteca";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(32, 75);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Seleccione un módulo en el menú de la izquierda para comenzar.";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(32, 100);
            lblFecha.Name = "lblFecha";
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // grpResumen
            // 
            grpResumen.Controls.Add(lblTotalLibros);
            grpResumen.Controls.Add(lblTotalEjemplares);
            grpResumen.Controls.Add(lblTotalUsuarios);
            grpResumen.Controls.Add(lblPrestamosActivos);
            grpResumen.Controls.Add(lblPrestamosVencidos);
            grpResumen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpResumen.Location = new Point(32, 140);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(520, 250);
            grpResumen.TabIndex = 3;
            grpResumen.TabStop = false;
            grpResumen.Text = "Resumen de la biblioteca";
            // 
            // lblTotalLibros
            // 
            lblTotalLibros.AutoSize = true;
            lblTotalLibros.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalLibros.Location = new Point(25, 40);
            lblTotalLibros.Name = "lblTotalLibros";
            lblTotalLibros.TabIndex = 0;
            lblTotalLibros.Text = "Títulos registrados: 0";
            // 
            // lblTotalEjemplares
            // 
            lblTotalEjemplares.AutoSize = true;
            lblTotalEjemplares.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalEjemplares.Location = new Point(25, 80);
            lblTotalEjemplares.Name = "lblTotalEjemplares";
            lblTotalEjemplares.TabIndex = 1;
            lblTotalEjemplares.Text = "Ejemplares disponibles: 0";
            // 
            // lblTotalUsuarios
            // 
            lblTotalUsuarios.AutoSize = true;
            lblTotalUsuarios.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalUsuarios.Location = new Point(25, 120);
            lblTotalUsuarios.Name = "lblTotalUsuarios";
            lblTotalUsuarios.TabIndex = 2;
            lblTotalUsuarios.Text = "Usuarios registrados: 0";
            // 
            // lblPrestamosActivos
            // 
            lblPrestamosActivos.AutoSize = true;
            lblPrestamosActivos.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrestamosActivos.Location = new Point(25, 160);
            lblPrestamosActivos.Name = "lblPrestamosActivos";
            lblPrestamosActivos.TabIndex = 3;
            lblPrestamosActivos.Text = "Préstamos activos: 0";
            // 
            // lblPrestamosVencidos
            // 
            lblPrestamosVencidos.AutoSize = true;
            lblPrestamosVencidos.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrestamosVencidos.Location = new Point(25, 200);
            lblPrestamosVencidos.Name = "lblPrestamosVencidos";
            lblPrestamosVencidos.TabIndex = 4;
            lblPrestamosVencidos.Text = "Préstamos vencidos: 0";
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = Color.Firebrick;
            lblAviso.Location = new Point(32, 410);
            lblAviso.Name = "lblAviso";
            lblAviso.TabIndex = 4;
            lblAviso.Text = "";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlContenido);
            Controls.Add(pnlMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "FrmPrincipal";
            Text = "Sistema de Gestión de Biblioteca";
            Load += FrmPrincipal_Load;
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContenido;
        private Panel pnlMenu;
        private Label lblMenuTitulo;
        private Button btnInicio;
        private Button btnLibros;
        private Button btnUsuarios;
        private Button btnAutores;
        private Button btnEditoriales;
        private Button btnPrestamos;
        private Button btnReportes;
        private Button btnSalir;
        private Label lblBienvenida;
        private Label lblDescripcion;
        private Label lblFecha;
        private GroupBox grpResumen;
        private Label lblTotalLibros;
        private Label lblTotalEjemplares;
        private Label lblTotalUsuarios;
        private Label lblPrestamosActivos;
        private Label lblPrestamosVencidos;
        private Label lblAviso;
    }
}
