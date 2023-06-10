using PI4___Mobile_App.Models;

namespace PI4___Mobile_App;

public partial class PersonenDetails : ContentPage
{
    private Persoon persoon;
    public PersonenDetails(Persoon persoon)
    {
        InitializeComponent();
        this.persoon = persoon;
        LblVoornaam.Text = persoon.Voornaam;
        LblAchternaam.Text = persoon.Achternaam;
        LblTelefoonnummer.Text = persoon.Telefoonnummer;
    }


    async void VerwijderContact_Clicked(object sender, EventArgs e)
    {
        List<Persoon> personen = PersonenPage.Json.LeesJson();

        // Find the person to be deleted
        Persoon personToDelete = personen.FirstOrDefault(p => p.Telefoonnummer == persoon.Telefoonnummer);

        if (personToDelete != null)
        {
            personen.Remove(personToDelete); // Remove the person from the list

            // Update the JSON data
            await PersonenPage.Json.SchrijfNaarJson(personen);

            // Go back to the previous page or perform any other desired action
            await Navigation.PopAsync();
        }
    }
}