Estudiante: Carlos David Ariza Ospino

# Registro de Videojuegos - ADO.NET con SQLite

Programa de consola en C# que demuestra el acceso a datos con ADO.NET
y SQLite. Desarrollado como actividad de la asignatura Programación
en C# con .NET (Semana 12).

## ¿Qué hace el programa?

- Crea una base de datos SQLite (`videojuegos.db`).
- Se conecta a ella con `SqliteConnection`.
- Crea la tabla `Videojuegos` con las columnas Id, Titulo, Genero y Anio.
- Inserta 3 registros con `SqliteCommand` y parámetros.
- Consulta y muestra los registros con `SqliteDataReader`.
- Usa `using` para liberar los recursos correctamente.

## Requisitos

- .NET SDK 8.0 o superior
- Git

## Cómo ejecutarlo

1. Clonar el repositorio:
   git clone https://github.com/TU_USUARIO/RegistroVideojuegos.git
2. Entrar a la carpeta:
   cd RegistroVideojuegos
3. Restaurar los paquetes:
   dotnet restore
4. Ejecutar:
   dotnet run

## Resultado esperado

En la primera ejecución se crea `videojuegos.db`, se insertan los 3
videojuegos y se muestra la lista. En las siguientes ejecuciones el
programa detecta que los datos ya existen (persistencia) y solo los
muestra.

## Tecnologías

- C# / .NET 8
- ADO.NET
- Microsoft.Data.Sqlite (SQLite)

