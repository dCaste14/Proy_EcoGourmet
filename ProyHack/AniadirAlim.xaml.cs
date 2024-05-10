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

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        SelectedDate = e.NewDate;
        // Aquí puedes usar SelectedDate para lo que necesites

    }
}