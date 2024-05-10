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

        // Obtengo el valor de cantidad ingresado por el usuario
        int cantidadAlimentos = 1; // Valor predeterminado
        if (!string.IsNullOrEmpty(cantidad.Text))
        {
            if (!int.TryParse(cantidad.Text, out cantidadAlimentos))
            {
                await DisplayAlert("Error", "Ingrese un valor numérico válido para la cantidad", "OK");
                return;
            }
        }

        // Creo y agrego la cantidad de alimentos especificada por el usuario
        for (int i = 0; i < cantidadAlimentos; i++)
        {
            var alimento = new Alimento()
            {
                Nombre = cajanombre.Text,
                FechaCaducidad = SelectedDate,
                Categoria = SelectedElement,
            };

            try
            {
                BBDD.AddAlimento(alimento, userId);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo añadir el alimento: " + ex.Message, "OK");
                return;
            }
        }

        await DisplayAlert("Exito", $"Alimento(s) añadido(s) correctamente ({cantidadAlimentos})", "OK");
        await Navigation.PushAsync(new LandingPage());
    }
    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        SelectedDate = e.NewDate;
        // Aquí puedes usar SelectedDate para lo que necesites
    }
}


