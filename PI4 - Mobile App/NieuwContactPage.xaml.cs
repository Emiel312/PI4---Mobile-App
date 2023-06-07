using PI4___Mobile_App.Models;

namespace PI4___Mobile_App;

[QueryProperty("Item", "Item")]
public partial class NieuwContactPage : ContentPage
{
    Persoon persoon;
    public Persoon Persoon
    {
        get => BindingContext as Persoon;
        set
        {
            BindingContext = value;
            LoadPersoon(value);
        }
    }

    private void LoadPersoon(Persoon persoon)
    {
        // Load the item details into the form
        VoornaamEntry.Text = persoon.Voornaam;
        AchternaamEntry.Text = persoon.Achternaam;
        TelefoonnummerEntry.Text = persoon.Telefoonnummer;
    }
    public NieuwContactPage()
	{
		InitializeComponent();
	}

    async void OnSaveClicked(object sender, EventArgs e)
    {

        // Create a new Persoon object from the Item data
        Persoon persoon = new Persoon()

        {
            Voornaam = VoornaamEntry.Text,
            Achternaam = AchternaamEntry.Text,
            Telefoonnummer = TelefoonnummerEntry.Text,
            Geslacht = TelefoonnummerEntry.Text
        };

    

        // Save the Persoon object to JSON file
        await PersonenPage.Json.SchrijfNaarJson(persoon);
        await Shell.Current.GoToAsync("..");
    }
}
