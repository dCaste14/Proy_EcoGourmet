using MySql.Data.MySqlClient;

string connString = "server=localhost;port=3306;database=ecogourmet;uid=root;pwd=tu_contraseña;";
using(var connection = new MySqlConnection(connString))
{
    class BBDD
    {
        try
        {
            connection.Open();
            Console.WriteLine("Conexión exitosa");
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Error al conectar: " + e.Message);
        }
        bool usuario_existe(string usuario)
        {
            string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario";
            using(var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
    
    
}
