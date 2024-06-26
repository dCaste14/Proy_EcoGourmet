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
            // Validación de campos
            if (string.IsNullOrWhiteSpace(cajanombre.Text) || string.IsNullOrWhiteSpace(cajacorreo.Text)
                || string.IsNullOrWhiteSpace(cajacontraseña.Text) || string.IsNullOrWhiteSpace(cajarepetircontraseña.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            if (!Regex.IsMatch(cajacorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                await DisplayAlert("Error", "Correo electrónico no válido.", "OK");
                return;
            }

            if (cajacontraseña.Text != cajarepetircontraseña.Text)
            {
                await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
                return;
            }

            if (BBDD.EmailExiste(cajacorreo.Text))
            {
                await DisplayAlert("Error", "Este correo electrónico ya está registrado.", "OK");
                return;
            }


            var hashedPassword = await Task.Run(() => BCrypt.Net.BCrypt.HashPassword(cajacontraseña.Text, workFactor: 10));

            //Creacion de usuario y guardar en base de datos
            var user = new User()
            {
                Username = cajanombre.Text,
                Email = cajacorreo.Text,
                Password = hashedPassword,
            };

            try
            {
                BBDD.AddUser(user);
                await DisplayAlert("Completo", "Usuario registrado correctamente", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo registrar el usuario: " + ex.Message, "OK");
            }
        }

        
    }
}