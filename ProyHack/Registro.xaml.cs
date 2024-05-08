using BCrypt.Net;
using System.Text.RegularExpressions;

namespace ProyHack
{
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private async void OnBtnEnviarRegClicked (object sender, EventArgs e)
        {
            // Validaci�n de campos
            if (string.IsNullOrWhiteSpace(cajanombre.Text) || string.IsNullOrWhiteSpace(cajacorreo.Text)
                || string.IsNullOrWhiteSpace(cajacontrase�a.Text) || string.IsNullOrWhiteSpace(cajarepetircontrase�a.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            if (!Regex.IsMatch(cajacorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                await DisplayAlert("Error", "Correo electr�nico no v�lido.", "OK");
                return;
            }

            if (cajacontrase�a.Text != cajarepetircontrase�a.Text)
            {
                await DisplayAlert("Error", "Las contrase�as no coinciden.", "OK");
                return;
            }

         
            var hashedPassword = await Task.Run(() => BCrypt.Net.BCrypt.HashPassword(cajacontrase�a.Text, workFactor: 10));

            //Creacion de usuario y guardar en base de datos
            var user = new User()
            {
                Username = cajanombre.Text,
                Email = cajacorreo.Text,
                Password = hashedPassword,
            };

            BBDD.AddUser(user);
            await DisplayAlert("Completo", $"Usuario registrado correctamente, {FileSystem.Current.AppDataDirectory}", "OK");

            await Navigation.PushAsync(new MainPage());
        }

        
    }
}