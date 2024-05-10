namespace ProyHack;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
	}

    private async void OnNavegar1Cliked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LandingPage());
    }

    private async void OnNavegar2Cliked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AniadirAlim());
    }

    private async void OnNavegar3Cliked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaAlimentos());
    }

    private async void MostrarNotificacion_Click(object sender, EventArgs e)
    {
        await DisplayAlert("RECETAS","Proximamente estará disponible la página de RECETAS ...","OK");
    }
}