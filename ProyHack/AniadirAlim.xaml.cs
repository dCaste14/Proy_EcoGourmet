namespace ProyHack;
using System;
using System.Windows;
public partial class AniadirAlim : ContentPage
{
	public AniadirAlim()
	{
		InitializeComponent();
        DatePicker FechaCad = new DatePicker();
      
    }

    private async void OnNavegar1Cliked(object sender, EventArgs e)
    {
        // Obtengo el id del usuario
        int userId = SesionDeUsuario.CurrentUser;

        var alimento = new Alimento()
        {
            Nombre = cajanombre.Text,
            FechaCaducidad = FechaCad.Date,
            Categoria = cajanombre2.Text,
        };


        try
        {
            BBDD.AddAlimento(alimento, userId);
            await DisplayAlert("Exito", "Alimento añadido correctamente", "OK");
            await Navigation.PushAsync(new LandingPage());
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Error", "No se pudo añadir el alimento: " + ex.Message, "OK");
        }

       
    }
}