namespace SistemaBiblioteca.Utilidades
{
    /// <summary>
    /// Métodos de ayuda para dar formato a los DataGridView.
    /// </summary>
    public static class Grilla
    {
        public static void OcultarColumnas(DataGridView dgv, params string[] columnas)
        {
            foreach (string nombre in columnas)
            {
                if (dgv.Columns.Contains(nombre))
                    dgv.Columns[nombre].Visible = false;
            }
        }

        public static void CambiarTitulo(DataGridView dgv, string columna, string titulo)
        {
            if (dgv.Columns.Contains(columna))
                dgv.Columns[columna].HeaderText = titulo;
        }

        // Organiza las columnas en el orden que se le pasa
        public static void OrdenarColumnas(DataGridView dgv, params string[] columnas)
        {
            int posicion = 0;
            foreach (string nombre in columnas)
            {
                if (dgv.Columns.Contains(nombre))
                {
                    dgv.Columns[nombre].DisplayIndex = posicion;
                    posicion++;
                }
            }
        }

        public static void FormatoFecha(DataGridView dgv, params string[] columnas)
        {
            foreach (string nombre in columnas)
            {
                if (dgv.Columns.Contains(nombre))
                    dgv.Columns[nombre].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        // Pone formato de fecha a todas las columnas que sean DateTime (para los reportes)
        public static void FormatoFechasAutomatico(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.ValueType == typeof(DateTime))
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
    }
}
