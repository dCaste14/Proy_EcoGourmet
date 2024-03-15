namespace ProyHack;

public partial class Registro : ContentPage
{
    public Registro()
    {
        InitializeComponent();
    }


    private void MiMetodo()
    {
        // Accediendo al texto de la caja de texto
        string texto = cajacorreo.Text;
    }

    private async void OnNavegarVolverCliked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new MainPage());
    }
}