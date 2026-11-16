using Microsoft.Data.Sqlite;

string connectionString = "Data Source=videojuegos.db";

// 1. Crear la conexión (se crea el archivo .db si no existe)
using var connection = new SqliteConnection(connectionString);
connection.Open();
Console.WriteLine("Conexion a SQLite establecida.\n");

// 2. Crear la tabla (4 columnas)
using (var createCmd = connection.CreateCommand())
{
    createCmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Videojuegos (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Titulo TEXT NOT NULL,
            Genero TEXT NOT NULL,
            Anio INTEGER NOT NULL
        );";
    createCmd.ExecuteNonQuery();
}

// 3. Insertar registros solo si la tabla esta vacia
long total;
using (var countCmd = connection.CreateCommand())
{
    countCmd.CommandText = "SELECT COUNT(*) FROM Videojuegos;";
    total = (long)countCmd.ExecuteScalar()!;
}

if (total == 0)
{
    var juegos = new (string Titulo, string Genero, int Anio)[]
    {
        ("The Legend of Zelda: Breath of the Wild", "Aventura", 2017),
        ("Minecraft", "Sandbox", 2011),
        ("Hollow Knight", "Metroidvania", 2017)
    };

    foreach (var j in juegos)
    {
        using var insertCmd = connection.CreateCommand();
        insertCmd.CommandText =
            "INSERT INTO Videojuegos (Titulo, Genero, Anio) VALUES ($titulo, $genero, $anio);";
        insertCmd.Parameters.AddWithValue("$titulo", j.Titulo);
        insertCmd.Parameters.AddWithValue("$genero", j.Genero);
        insertCmd.Parameters.AddWithValue("$anio", j.Anio);
        insertCmd.ExecuteNonQuery();
        Console.WriteLine($"Insertado: {j.Titulo}");
    }
    Console.WriteLine();
}
else
{
    Console.WriteLine("Los datos ya existian en la base de datos (persistencia).\n");
}

// 4. Consultar y mostrar con DataReader
using var selectCmd = connection.CreateCommand();
selectCmd.CommandText = "SELECT Id, Titulo, Genero, Anio FROM Videojuegos;";
using var reader = selectCmd.ExecuteReader();

Console.WriteLine("Registros almacenados:");
while (reader.Read())
{
    Console.WriteLine($"{reader.GetInt32(0)} | {reader.GetString(1)} | {reader.GetString(2)} | {reader.GetInt32(3)}");
}