using Microsoft.Data.Sqlite;
using System;
using System.IO;
using Microsoft.Maui.Storage; 

namespace ProyHack
{
    public class BBDD
    {
        //Ruta del archivo de la base de datos
        private static string dbPath = Path.Combine(FileSystem.AppDataDirectory, "userdb.db3");

        public static void InitializeDatabase()
        {

            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }

            //Establece conexion con la base de datos SQLite
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                //Definimos la estructura de la tabla de usuarios con un comando SQL
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Password TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Alimentos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId INTEGER NOT NULL,
                    Nombre TEXT NOT NULL,
                    FechaCaducidad DATE NOT NULL,
                    Categoria TEXT NOT NULL,
                    FOREIGN KEY(UserId) REFERENCES Users(Id)
                );
                ";
                command.ExecuteNonQuery(); //Crea la tabla
            }
        }

        public static void AddUser(User user)
        {
            using (var connection = new SqliteConnection($"Data Source = {dbPath}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                """
                INSERT INTO Users (Username, Email, Password) VALUES ($username, $email, $password);
                """;
                command.Parameters.AddWithValue("$username", user.Username);
                command.Parameters.AddWithValue("$email", user.Email);
                command.Parameters.AddWithValue("$password", user.Password);
                command.ExecuteNonQuery();
            }
        }

        public static void AddAlimento(Alimento alimento, int userId)
        {
            using (var connection = new SqliteConnection($"Data Source = {dbPath}"))
            {
                connection .Open();

                var command = connection.CreateCommand();
                command.CommandText =
                """
                INSERT INTO Alimentos (UserId, Nombre, FechaCaducidad, Categoria) VALUES ($userId, $nombre, $fechaCaducidad, $categoria);
                """;
                command.Parameters.AddWithValue("$userId", userId);
                command.Parameters.AddWithValue("$nombre", alimento.Nombre);
                command.Parameters.AddWithValue("$fechaCaducidad", alimento.FechaCaducidad.ToString("yyyy-MM-dd")); 
                command.Parameters.AddWithValue("$categoria", alimento.Categoria);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteAlimento(int alimentoID)
        {
            using (var connection = new SqliteConnection($"Data Source = {dbPath}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Alimentos WHERE Id = $alimentoId";
                command.Parameters.AddWithValue("$alimentoId", alimentoID);
                command.ExecuteNonQuery();
            }
        }

        public static List<Alimento> GetAlimentos(int userId)
        {
            var alimentos = new List<Alimento>();
            using (var connection = new SqliteConnection($"Data Source = {dbPath}"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Nombre, FechaCaducidad, Categoria FROM Alimentos WHERE UserId = $userId ORDER BY FechaCaducidad";
                command.Parameters.AddWithValue("$userId", userId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        alimentos.Add(new Alimento
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            FechaCaducidad = reader.GetDateTime(2),
                            Categoria = reader.GetString(3)
                        }); 
                    }
                }
            }

            return alimentos;
                
        }

        public static int ValidarUser(string email, string password)
        {
            using (var connection = new SqliteConnection($"Data Source = {dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Password FROM Users WHERE Email = $email";
                command.Parameters.AddWithValue("$email", email);

                using (var reader = command.ExecuteReader()) 
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader.GetString(1);
                        if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                        {
                            return reader.GetInt32(0);  // Return the user ID
                        }
                    }
                }
            }

            return 0;
        }
        public static bool EmailExiste(string email)
        {
            using (var connection = new SqliteConnection($"Data Source = {dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE Email = $email";
                command.Parameters.AddWithValue("$email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }
}