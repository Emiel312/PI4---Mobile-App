using PI4___Mobile_App.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;


namespace PI4___Mobile_App;

public partial class PersonenPage : ContentPage
{
    List<Persoon> allePersonen = new List<Persoon>()
    {
        new Persoon(){Voornaam="Chantal", Achternaam="Bastiaans", Geslacht="Vrouw", Telefoonnummer="0612345678", Afbeelding="person1.png"},
        new Persoon(){Voornaam="Jan", Achternaam="Klaassen", Geslacht="Vrouw", Telefoonnummer="0612345678",Afbeelding="person2.png"  },
        new Persoon(){Voornaam="Aldina", Achternaam="Hassan", Geslacht="Vrouw", Telefoonnummer="0612345678", Afbeelding="person3.png" },
        new Persoon(){Voornaam="Afua", Achternaam="Akachi", Geslacht="Onbekend", Telefoonnummer="0612345678",Afbeelding="person4.png" },
        new Persoon(){Voornaam="Verena", Achternaam="Hamers", Geslacht="Vrouw", Telefoonnummer="0612345678",Afbeelding="person5.png" },
        new Persoon(){Voornaam="Sjakie", Achternaam="Lederen tassies", Geslacht="Man", Telefoonnummer="0612345678",Afbeelding="person6.png" },
        new Persoon(){Voornaam="Piet", Achternaam="van Straten", Geslacht="Vrouw", Telefoonnummer="0612345678" }
    };

    /*
    string fileName = "personen.json";
    var serializedData = JsonSerializer.Serialize(Persoon);
    File.WriteAllText(fileName, jsonString); */

    public PersonenPage()
    {
        InitializeComponent();
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