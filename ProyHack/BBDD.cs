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
          
            //Establece conexion con la base de datos SQLite
            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                //Definimos la estructura de la tabla de usuarios con un comando SQL
                var command = connection.CreateCommand();
                command.CommandText =
                """
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Password TEXT NOT NULL
                );
                """;
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
    }
}