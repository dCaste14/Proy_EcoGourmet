using System.Text.RegularExpressions;

namespace ProyHack;

public partial class InicioSesion : ContentPage
{
	public InicioSesion()
	{
		InitializeComponent();
	}

    private async void OnBtnEnviarInicCliked(object sender, EventArgs e)
	{
        // Validación de campos
        if (string.IsNullOrWhiteSpace(cajacorreo.Text) || string.IsNullOrWhiteSpace(cajacontraseña.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        //Comprobar que el usuario existe y la password es correcta

        if (!Regex.IsMatch(cajacorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Error", "Correo electrónico no válido.", "OK");
            return;
        }

        if (BBDD.ValidarUser(cajacorreo.Text, cajacontraseña.Text))
        {
            await Navigation.PushAsync(new LandingPage());
        }
        else
        {
            await DisplayAlert("Error", "Correo electrónico o contraseña incorrectos", "OK");
        }

       
    }
}