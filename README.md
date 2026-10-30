# Sistema de Gestión de Biblioteca

Aplicación de escritorio desarrollada en **C#**, **Windows Forms** y **SQL Server** para administrar los procesos de una biblioteca: libros, autores, editoriales, usuarios, préstamos, devoluciones y reportes.

Proyecto final de la asignatura **Programación Avanzada**.

## Tecnologías utilizadas

| Herramienta | Versión |
|---|---|
| Lenguaje | C# |
| Plataforma | .NET 10 (Windows Forms) |
| IDE | Visual Studio Community 2026 |
| Base de datos | SQL Server Express 2025 |
| Administración BD | SQL Server Management Studio 22 |
| Conector | Microsoft.Data.SqlClient |
| Control de versiones | Git y GitHub |

## Funcionalidades

- **Inicio:** pantalla principal con menú de navegación y resumen de la biblioteca.
- **Libros:** registrar, consultar, editar y eliminar libros. Búsqueda por título, ISBN o autor. Control de existencias y ejemplares disponibles.
- **Autores:** CRUD de autores.
- **Editoriales:** CRUD de editoriales.
- **Usuarios:** CRUD de usuarios de la biblioteca.
- **Préstamos:** registro de préstamos, edición, eliminación, filtro por estado (prestado, devuelto, vencido).
- **Devoluciones:** registro de la devolución con actualización del estado y de los ejemplares disponibles.
- **Reportes:** resumen general, libros, autores, editoriales, usuarios, préstamos activos, devueltos, vencidos, historial y libros más prestados.

## Reglas del sistema

- No se puede prestar un libro que no tenga ejemplares disponibles.
- Un usuario puede tener máximo 3 préstamos activos.
- Un usuario no puede tener el mismo libro prestado dos veces al mismo tiempo.
- El plazo del préstamo no puede ser mayor a 30 días.
- No se pueden eliminar autores, editoriales, libros o usuarios que tengan registros relacionados.
- No se permiten documentos de usuario, ISBN ni nombres de editorial repetidos.

## Estructura del proyecto

```
SistemaBiblioteca/
├── BaseDatos/
│   └── BibliotecaDB.sql          Script de la base de datos con datos de prueba
├── SistemaBiblioteca.sln
└── SistemaBiblioteca/
    ├── Modelos/                  Clases de las entidades (Persona, Autor, Usuario, Libro...)
    ├── Datos/                    Acceso a datos y conexión con SQL Server
    ├── Negocio/                  Reglas y validaciones del sistema
    ├── Formularios/              Formularios de Windows Forms
    ├── Utilidades/               Mensajes, validaciones y formato de tablas
    └── Program.cs
```

El proyecto está organizado en una arquitectura por capas: **Presentación** (Formularios), **Lógica de negocio** (Negocio), **Acceso a datos** (Datos) y **Base de datos** (SQL Server).

## Instrucciones de ejecución

1. **Crear la base de datos**
   - Abrir SQL Server Management Studio y conectarse a `localhost\SQLEXPRESS`.
   - Abrir el archivo `BaseDatos/BibliotecaDB.sql` y ejecutarlo.
   - Se crea la base `BibliotecaDB` con las tablas y los datos de prueba.

2. **Revisar la cadena de conexión**
   - Abrir `SistemaBiblioteca/Datos/Conexion.cs`.
   - Si la instancia de SQL Server tiene otro nombre, cambiar el valor de `Server`.

3. **Ejecutar la aplicación**
   - Abrir `SistemaBiblioteca.sln` con Visual Studio.
   - Ejecutar. La primera vez Visual Studio descarga el paquete `Microsoft.Data.SqlClient`.

## Capturas de pantalla

Las capturas del sistema se encuentran en la carpeta `Capturas/`.

## Autor

- Nombre: Kevin Rodriguez
- Asignatura: Programación Avanzada
