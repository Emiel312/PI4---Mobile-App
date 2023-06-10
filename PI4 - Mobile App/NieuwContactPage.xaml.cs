using PI4___Mobile_App.Models;

namespace PI4___Mobile_App
{
    // Pagina voor het maken van een nieuw contact
    [QueryProperty("Item", "Item")]
    public partial class NieuwContactPage : ContentPage
    {
        Persoon persoon;

        // Eigenschap voor het binden van de Persoon aan de BindingContext
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
            // Laad de gegevens van het item in het formulier
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
            // Maak een nieuwe Persoon aan op basis van de invoer
            Persoon persoon = new Persoon()
            {
                Voornaam = VoornaamEntry.Text,
                Achternaam = AchternaamEntry.Text,
                Telefoonnummer = TelefoonnummerEntry.Text,
                Geslacht = TelefoonnummerEntry.Text // TODO: Voeg de juiste invoer toe voor het geslacht
            };

            // Sla de Persoon op naar het JSON-bestand
            await PersonenPage.Json.SchrijfNaarJson(persoon);

            // Navigeer terug naar de vorige pagina of voer een andere gewenste actie uit
            await Shell.Current.GoToAsync("..");
        }
    }
}
