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

        //falta comprbar q el usuario y contraseña existen y coinciden 
    }
}