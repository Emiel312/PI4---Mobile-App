using PI4___Mobile_App.Models;

namespace PI4___Mobile_App;

public partial class PersonenDetails : ContentPage
{
    public PersonenDetails(Persoon persoon)
    {
        InitializeComponent();
        LblVoornaam.Text = persoon.Voornaam;
        LblAchternaam.Text = persoon.Achternaam;
    }
    async void VerwijderContact_Clicked(object sender, EventArgs e)
    {

    }
}