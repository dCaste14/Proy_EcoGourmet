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
        await Navigation.PushAsync(new LandingPage());
    }
}