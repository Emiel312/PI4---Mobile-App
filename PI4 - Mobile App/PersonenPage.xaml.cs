using PI4___Mobile_App.Models;
using System.Collections.Generic;
using System.IO;
using PI4___Mobile_App.Data;


namespace PI4___Mobile_App;

public partial class PersonenPage : ContentPage
{
    List<Persoon> allePersonen = Data.Json.Deserialize();   

    public PersonenPage()
    {
        InitializeComponent();
        Json.Serialize("Henk", "Pieters", "Onbekend", "+31612345678", "lelijk.jpg");
        LvAllePersonen.ItemsSource = allePersonen;
 
    }

    private void LvAllePersonen_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedItem = e.SelectedItem as Persoon;
        Navigation.PushAsync(new PersonenDetails(selectedItem));

    }



    void SearchBar_TextChanged(object sender, EventArgs e)
    {
       /* string searchText = e.NewTextValue;
        LvAllePersonen.ItemsSource = allePersonen.SearchPersonen(searchText);*/
    }

    
}