namespace ProyHack;

public partial class ListaAlimentos : ContentPage
{
	public ListaAlimentos()
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
}