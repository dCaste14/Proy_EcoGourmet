using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ProyHack;

public partial class ListaAlimentos : ContentPage
{
	public ListaAlimentos()
	{
        InitializeComponent();
       
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        int userId = SesionDeUsuario.CurrentUser;
        LoadAlimentos(userId);
    }

    private void LoadAlimentos(int userId)
    {
        StackLayout stackLayout = (StackLayout)FindByName("alimentosStack");

        stackLayout.Children.Clear();

        List<Alimento> alimentos = BBDD.GetAlimentos(userId);
        foreach (var alimento in alimentos)
        {
            StackLayout alimentoLayout = new StackLayout();

            Label alimentoLabel = new Label()
            {
                Text = $"{alimento.Nombre} - Expira: {alimento.FechaCaducidad.ToShortDateString()} - Categoria: {alimento.Categoria}",
                FontSize = 18,
                Margin = new Thickness(5)
            };

            //Boton para eliminar alimento
            Button deleteButton = new Button()
            {
                Text = "Eliminar",
                FontSize = 18,
                Margin = new Thickness(5),
                CommandParameter = alimento.Id,
                BackgroundColor = Color.FromHex("#7DCEA0")
            };
            deleteButton.Clicked += OnDeleteButtonClicked;
            

            alimentoLayout.Children.Add(alimentoLabel);
            alimentoLayout.Children.Add(deleteButton);

            stackLayout.Children.Add(alimentoLayout);

        }
    }
    private async void OnNavegar1Cliked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LandingPage());
    }

    private async void OnNavegar2Cliked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AniadirAlim());
    }

    private async void MostrarNotificacion_Click(object sender, EventArgs e)
    {
        await DisplayAlert("RECETAS", "Proximamente estará disponible la página de RECETAS ...", "OK");
    }

    private async void OnDeleteButtonClicked(object? sender, EventArgs e)
    {
        if (sender == null)
            return;

        Button delete = (Button)sender;
        int alimentoID = (int)delete.CommandParameter;

        bool res = await DisplayAlert("Confirmar", "¿Seguro que quieres eliminar este alimento?", "Sí", "Cancelar");

        if(res)
        { 
            try
            {
                BBDD.DeleteAlimento(alimentoID); //Lo elimina de la base de datos

                // Recargar la lista de alimentos luego de eliminar
                int userId = SesionDeUsuario.CurrentUser;
                LoadAlimentos(userId);

                await DisplayAlert("Exito", "Alimento eliminado correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo eliminar el alimento: " + ex.Message, "OK");
            }
        }
    }

}