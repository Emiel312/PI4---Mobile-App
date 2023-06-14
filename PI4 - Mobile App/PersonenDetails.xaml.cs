using PI4___Mobile_App.Models;

namespace PI4___Mobile_App
{
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
            ImgPersoon.Source = "person.png";
        }

        async void VerwijderContact_Clicked(object sender, EventArgs e)
        {
            List<Persoon> personen = PersonenPage.Json.LeesJson();

            // Zoek de persoon die verwijderd moet worden
            Persoon persoonOmTeVerwijderen = personen.FirstOrDefault(p => p.Telefoonnummer == persoon.Telefoonnummer);

            if (persoonOmTeVerwijderen != null)
            {
                personen.Remove(persoonOmTeVerwijderen); // Verwijder de persoon uit de lijst

                // Werk de JSON-gegevens bij
                await PersonenPage.Json.SchrijfNaarJson(personen);

                // Ga terug naar de vorige pagina of voer een andere gewenste actie uit
                await Navigation.PopAsync();
            }
        }
        private void DialNumber(string telefoonNummer)
        {
            try
            {
                PhoneDialer.Open(telefoonNummer);
            }
            catch (Exception ex)
            {
                string errorMessage = "Kan het huidige nummer niet bellen";
            }
        }
        private void PhoneDialer_Clicked(object sender, EventArgs e)
        {
            DialNumber(persoon.Telefoonnummer);
        }

    }
}
