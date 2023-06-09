using PI4___Mobile_App.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace PI4___Mobile_App
{
    public partial class PersonenPage : ContentPage
    {
        public PersonenPage()
        {
            InitializeComponent();
        }

        // Forceren van vernieuwing bij het betreden van de pagina
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LvAllePersonen.ItemsSource = Json.LeesJson();
        }

        private void NieuwContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NieuwContactPage());
        }

        private void LvAllePersonen_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as Persoon;
            Navigation.PushAsync(new PersonenDetails(selectedItem));
        }

        public class Json
        {
            // Methode om naar JSON te schrijven voor het toevoegen van een persoon
            public static async Task<string> SchrijfNaarJson(Persoon persoon)
            {
                List<Persoon> personen = LeesJson();
                personen.Add(persoon);
                string path = Path.Combine(FileSystem.AppDataDirectory, "persons.json");
                using FileStream createStream = File.Create(path);
                await JsonSerializer.SerializeAsync(createStream, personen);
                await createStream.DisposeAsync();

                return File.ReadAllText(path);
            }

            // Methode om naar JSON te schrijven voor het verwijderen van personen
            public static async Task<string> SchrijfNaarJson(List<Persoon> personen)
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "persons.json");
                using FileStream createStream = File.Create(path);
                await JsonSerializer.SerializeAsync(createStream, personen);
                await createStream.DisposeAsync();

                return File.ReadAllText(path);
            }

            // Methode om JSON te lezen en een lijst van personen terug te geven
            public static List<Persoon> LeesJson()
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "persons.json");
                List<Persoon> Personen = new();
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    Personen = JsonSerializer.Deserialize<List<Persoon>>(jsonString)!;
                }
                return Personen;
            }
        }
        private void ZoekbalkPersonen_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = ZoekbalkPersonen.Text;
            List<Persoon> searchResults = Json.LeesJson().Where(p =>
                p.Voornaam.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                p.Achternaam.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                p.Telefoonnummer.Contains(searchText, StringComparison.OrdinalIgnoreCase)
            ).ToList();
            LvAllePersonen.ItemsSource = searchResults;
        }
    }
}