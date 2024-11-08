// See https://aka.ms/new-console-template for more information
using Serial1exo;
using System.Text.Json;


// TODO Désérialiser un seul fichier

Character sofiene = new Character
{
    FirstName = "Angel",
    LastName = "Batista",
    Description = "Honnête et altruiste",
    PlayedBy = new Actor
    {
       FirstName = "Sofiene",
       LastName = "Belkhiria",
       BirthDate = new DateTime(2006, 3, 1), // Exemple de date : 12 mai 1993
       Country = "Tunisie",
       IsAlive = true,
    }
};


string jsonString = JsonSerializer.Serialize(sofiene);

string filePath = $"../../../myData.json";

// Lire le contenu du fichier JSON
string fghhgv = File.ReadAllText(filePath);

Character perso = JsonSerializer.Deserialize<Character>(fghhgv);

Console.WriteLine(fghhgv);

// TODO Désérialiser un seul fichier
Console.WriteLine($"Le personnage de {perso.FirstName} {perso.LastName} est joué par {perso.PlayedBy.FirstName} {perso.PlayedBy.LastName}");