namespace SistemaBiblioteca.Formularios
{
    partial class FrmReportes
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
            lblTipo = new Label();
            cmbTipoReporte = new ComboBox();
            btnGenerar = new Button();
            btnCerrar = new Button();
            dgvReporte = new DataGridView();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(12, 17);
            lblTipo.Name = "lblTipo";
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de reporte:";
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Location = new Point(115, 13);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new Size(280, 23);
            cmbTipoReporte.TabIndex = 1;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(405, 11);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(100, 27);
            btnGenerar.TabIndex = 2;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(873, 11);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 27);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.AllowUserToResizeRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.BackgroundColor = SystemColors.Window;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(12, 50);
            dgvReporte.MultiSelect = false;
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(961, 400);
            dgvReporte.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(12, 460);
            lblTotal.Name = "lblTotal";
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total de registros: 0";
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 490);
            Controls.Add(lblTipo);
            Controls.Add(cmbTipoReporte);
            Controls.Add(btnGenerar);
            Controls.Add(btnCerrar);
            Controls.Add(dgvReporte);
            Controls.Add(lblTotal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "FrmReportes";
            Text = "Reportes";
            Load += FrmReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTipo;
        private ComboBox cmbTipoReporte;
        private Button btnGenerar;
        private Button btnCerrar;
        private DataGridView dgvReporte;
        private Label lblTotal;
    }
}
