namespace ProyHack;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
    }

    private async void OnBtnEnviarRegCliked(object sender, EventArgs e)
    {
        // Validación de campos
        if (string.IsNullOrWhiteSpace(cajanombre.Text) || string.IsNullOrWhiteSpace(cajacorreo.Text) 
            || string.IsNullOrWhiteSpace(cajacontraseña.Text) || string.IsNullOrWhiteSpace(cajarepetircontraseña.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        if (cajacontraseña.Text != cajarepetircontraseña.Text)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        await Navigation.PushAsync(new LandingPage());
    }
}