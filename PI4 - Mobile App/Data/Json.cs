using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using PI4___Mobile_App.Models;
using System.IO;

namespace PI4___Mobile_App.Data
{
    public class Json
    {

        public static void Serialize(string voornaam,string achternaam, string geslacht,string telefoonnummer, string afbeelding)
        {
            var Persoon = new Persoon
            {
                Voornaam = voornaam, 
                Achternaam= achternaam, 
                Geslacht= geslacht, 
                Telefoonnummer= telefoonnummer, 
                Afbeelding= afbeelding
            };

            var jsonString = JsonSerializer.Serialize(Persoon);

            var localDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(localDataFolder, "personen.json");
                        
            File.WriteAllText(filePath, jsonString);
        }

        public static List<Persoon> Deserialize()
        {
            var localDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(localDataFolder, "personen.json");
            var jsonString = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<List<Persoon>>(jsonString);

            return data;
        }
    }
}
