namespace ProyHack;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
    }

    private async void OnBtnEnviarRegCliked(object sender, EventArgs e)
    {
        // Validaci�n de campos
        if (string.IsNullOrWhiteSpace(cajanombre.Text) || string.IsNullOrWhiteSpace(cajacorreo.Text) 
            || string.IsNullOrWhiteSpace(cajacontrase�a.Text) || string.IsNullOrWhiteSpace(cajarepetircontrase�a.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        if (cajacontrase�a.Text != cajarepetircontrase�a.Text)
        {
            await DisplayAlert("Error", "Las contrase�as no coinciden.", "OK");
            return;
        }

        await Navigation.PushAsync(new LandingPage());
    }
}