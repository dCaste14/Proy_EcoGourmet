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
        // Validaci�n de campos
        if (string.IsNullOrWhiteSpace(cajacorreo.Text) || string.IsNullOrWhiteSpace(cajacontrase�a.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        //Comprobar que el usuario existe y la password es correcta

        if (!Regex.IsMatch(cajacorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Error", "Correo electr�nico no v�lido.", "OK");
            return;
        }

        int userId = BBDD.ValidarUser(cajacorreo.Text, cajacontrase�a.Text);

        if (userId > 0)
        {
            SesionDeUsuario.SetCurrentUser(userId);  //Asigna un id al usuario que ha inicidado sesion
            await Navigation.PushAsync(new LandingPage());
        }
        else
        {
            await DisplayAlert("Error", "Correo electr�nico o contrase�a incorrectos", "OK");
        }


    }
}