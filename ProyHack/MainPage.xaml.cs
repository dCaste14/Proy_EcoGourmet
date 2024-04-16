using Microsoft.Win32;

namespace ProyHack
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavegar1Cliked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Registro());
        }

        private async void OnNavegar2Cliked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new InicioSesion());
        }
    }

}
