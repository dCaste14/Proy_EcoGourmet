namespace ProyHack;
using System;
using System.Windows;

public partial class AniadirAlim : ContentPage
{
    public string SelectedElement { get; set; }
    public DateTime SelectedDate { get; set; }

    public AniadirAlim()
	{
		InitializeComponent();
        DatePicker FechaCad = new DatePicker();
      
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        SelectedElement = picker.SelectedItem.ToString();
        // Aquí puedes usar SelectedElement para lo que necesites
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

private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
    SelectedDate = e.NewDate;
    // Aquí puedes usar SelectedDate para lo que necesites
}
}