using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaBiblioteca.Datos
{
    /// <summary>
    /// Consultas para el módulo de reportes y el resumen de la pantalla de inicio.
    /// Devuelven DataTable porque se muestran directamente en el DataGridView.
    /// </summary>
    public class ReporteDatos
    {
        public DataTable LibrosRegistrados()
        {
            string sql = @"SELECT L.ISBN, L.Titulo AS [Título], A.Nombre + ' ' + A.Apellido AS Autor,
                                  E.Nombre AS Editorial, L.AnioPublicacion AS [Año], L.Genero AS [Género],
                                  L.Existencias, L.Disponibles
                           FROM Libros L
                           INNER JOIN Autores A ON A.IdAutor = L.IdAutor
                           INNER JOIN Editoriales E ON E.IdEditorial = L.IdEditorial
                           ORDER BY L.Titulo";
            return EjecutarConsulta(sql);
        }

        public DataTable LibrosSinDisponibles()
        {
            string sql = @"SELECT L.ISBN, L.Titulo AS [Título], A.Nombre + ' ' + A.Apellido AS Autor,
                                  L.Existencias, L.Disponibles
                           FROM Libros L
                           INNER JOIN Autores A ON A.IdAutor = L.IdAutor
                           WHERE L.Disponibles = 0
                           ORDER BY L.Titulo";
            return EjecutarConsulta(sql);
        }

        public DataTable AutoresConLibros()
        {
            string sql = @"SELECT A.Nombre + ' ' + A.Apellido AS Autor, A.Nacionalidad,
                                  COUNT(L.IdLibro) AS [Libros registrados]
                           FROM Autores A
                           LEFT JOIN Libros L ON L.IdAutor = A.IdAutor
                           GROUP BY A.IdAutor, A.Nombre, A.Apellido, A.Nacionalidad
                           ORDER BY Autor";
            return EjecutarConsulta(sql);
        }

        public DataTable EditorialesConLibros()
        {
            string sql = @"SELECT E.Nombre AS Editorial, E.Pais AS [País],
                                  COUNT(L.IdLibro) AS [Libros registrados]
                           FROM Editoriales E
                           LEFT JOIN Libros L ON L.IdEditorial = E.IdEditorial
                           GROUP BY E.IdEditorial, E.Nombre, E.Pais
                           ORDER BY E.Nombre";
            return EjecutarConsulta(sql);
        }

        public DataTable UsuariosRegistrados()
        {
            string sql = @"SELECT U.Documento, U.Nombre, U.Apellido, U.Telefono AS [Teléfono], U.Correo,
                                  U.FechaRegistro AS [Fecha registro],
                                  (SELECT COUNT(*) FROM Prestamos P
                                   WHERE P.IdUsuario = U.IdUsuario AND P.Estado = 'Prestado') AS [Préstamos activos]
                           FROM Usuarios U
                           ORDER BY U.Apellido, U.Nombre";
            return EjecutarConsulta(sql);
        }

        // estado: "Prestado", "Devuelto" o null para todos
        public DataTable Prestamos(string estado)
        {
            string sql = @"SELECT P.IdPrestamo AS [N°], U.Documento, U.Nombre + ' ' + U.Apellido AS Usuario,
                                  L.Titulo AS Libro, P.FechaPrestamo AS [Fecha préstamo],
                                  P.FechaDevolucionPrevista AS [Devolución prevista],
                                  P.FechaDevolucion AS [Fecha devolución], P.Estado
                           FROM Prestamos P
                           INNER JOIN Usuarios U ON U.IdUsuario = P.IdUsuario
                           INNER JOIN Libros L ON L.IdLibro = P.IdLibro
                           WHERE (@estado IS NULL OR P.Estado = @estado)
                           ORDER BY P.FechaPrestamo DESC";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@estado", SqlDbType.NVarChar, 10).Value = Conexion.ValorONulo(estado);
                return LlenarTabla(cmd);
            }
        }

        public DataTable PrestamosVencidos()
        {
            string sql = @"SELECT P.IdPrestamo AS [N°], U.Nombre + ' ' + U.Apellido AS Usuario, U.Telefono AS [Teléfono],
                                  L.Titulo AS Libro, P.FechaDevolucionPrevista AS [Devolución prevista],
                                  DATEDIFF(DAY, P.FechaDevolucionPrevista, CAST(GETDATE() AS DATE)) AS [Días de retraso]
                           FROM Prestamos P
                           INNER JOIN Usuarios U ON U.IdUsuario = P.IdUsuario
                           INNER JOIN Libros L ON L.IdLibro = P.IdLibro
                           WHERE P.Estado = 'Prestado' AND P.FechaDevolucionPrevista < CAST(GETDATE() AS DATE)
                           ORDER BY [Días de retraso] DESC";
            return EjecutarConsulta(sql);
        }

        public DataTable LibrosMasPrestados()
        {
            string sql = @"SELECT TOP 10 L.Titulo AS [Título], A.Nombre + ' ' + A.Apellido AS Autor,
                                  COUNT(P.IdPrestamo) AS [Veces prestado]
                           FROM Libros L
                           INNER JOIN Autores A ON A.IdAutor = L.IdAutor
                           INNER JOIN Prestamos P ON P.IdLibro = L.IdLibro
                           GROUP BY L.IdLibro, L.Titulo, A.Nombre, A.Apellido
                           ORDER BY [Veces prestado] DESC, L.Titulo";
            return EjecutarConsulta(sql);
        }

        // Resumen general (información consolidada)
        public DataTable ResumenGeneral()
        {
            string sql = @"SELECT 'Títulos registrados' AS Concepto, COUNT(*) AS Cantidad FROM Libros
                           UNION ALL SELECT 'Ejemplares en total', ISNULL(SUM(Existencias), 0) FROM Libros
                           UNION ALL SELECT 'Ejemplares disponibles', ISNULL(SUM(Disponibles), 0) FROM Libros
                           UNION ALL SELECT 'Autores', COUNT(*) FROM Autores
                           UNION ALL SELECT 'Editoriales', COUNT(*) FROM Editoriales
                           UNION ALL SELECT 'Usuarios', COUNT(*) FROM Usuarios
                           UNION ALL SELECT 'Préstamos activos', COUNT(*) FROM Prestamos WHERE Estado = 'Prestado'
                           UNION ALL SELECT 'Préstamos devueltos', COUNT(*) FROM Prestamos WHERE Estado = 'Devuelto'
                           UNION ALL SELECT 'Préstamos vencidos', COUNT(*) FROM Prestamos
                                     WHERE Estado = 'Prestado' AND FechaDevolucionPrevista < CAST(GETDATE() AS DATE)";
            return EjecutarConsulta(sql);
        }

        private DataTable EjecutarConsulta(string sql)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                return LlenarTabla(cmd);
            }
        }

        private DataTable LlenarTabla(SqlCommand cmd)
        {
            DataTable tabla = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(tabla);
            }
            return tabla;
        }
    }
}
