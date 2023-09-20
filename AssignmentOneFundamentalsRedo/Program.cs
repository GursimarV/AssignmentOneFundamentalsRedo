/*
 Made by: Gursimar Virdi
 Date: September 13th, 2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwoFundamentals
{
    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string[] MapNames { get; set; }
    }

    public class GameInfo
    {
        public GameInfo()
        {
            MetaData = new List<Info>();

            Info info1 = new Info();
            info1.Id = 0;
            info1.Name = "Monkey Island";
            info1.Genre = "Point & Click";
            info1.MapNames = new string[] { "Guybrush Mansion", "LeChuck Hideout", "Melee Island", "SCUMM Bar" };
            MetaData.Add(info1);

            Info info2 = new Info();
            info2.Id = 1;
            info2.Name = "Mario Odyssey";
            info2.Genre = "Adventure";
            info2.MapNames = new string[] { "Mushroom Kingdom", "Cap Kingdom", "Cloud Kingdom", "Snow Kingdom" };
            MetaData.Add(info2);

            Info info3 = new Info();
            info3.Id = 2;
            info3.Name = "Final Fantasy 10";
            info3.Genre = "Adventure";
            info3.MapNames = new string[] { "Besaid Island", "Bevelle", "Calm Lands", "Baaj Temple" };
            MetaData.Add(info3);

            Info info4 = new Info();
            info4.Id = 3;
            info4.Name = "Valkyra 4";
            info4.Genre = "Tactical RPG";
            info4.MapNames = new string[] { "Battle of Siegval", "Other Kai", "Azure Flame", "Midnight Run" };
            MetaData.Add(info4);
        }
        public List<Info> MetaData { get; set; }
    }
    class Program
    {
        static void Main()
        {
            GameInfo gameInfo = new GameInfo();
            List<Info> metaData = gameInfo.MetaData;

            // This part of the code counts the number of games in the Meta Data List
            int numberOfGames = metaData.Count;
            // This reads out the number of games from the list which is 4
            Console.WriteLine($"Number of games: {numberOfGames}");

            // This part of the code shows the most frequent genre from the Meta Data List
            var mostFrequentGenre = metaData
                .GroupBy(info => info.Genre)
                .OrderByDescending(group => group.Count())
                .First()
                .Key;
            // This reads out the most frequent genre which is Adventure
            Console.WriteLine($"Most frequent genre: {mostFrequentGenre}");

            // This part of the code finds the map names that have the most number of characters excluding spaces, and which game they belong to from the Meta Data List
            var maxCharacterCount = metaData
                .SelectMany(info => info.MapNames)
                .Max(name => name.Count(c => !char.IsWhiteSpace(c)));

            var longestMapNames = metaData
                .SelectMany(info => info.MapNames)
                .Where(name => name.Count(c => !char.IsWhiteSpace(c)) == maxCharacterCount)
                .Distinct();
            // This reads out the list of map name with the most characters not including a spaces from the meta data list 
            Console.WriteLine($"Map names with the most characters (excluding spaces):");
            foreach (var mapName in longestMapNames)
            {
                var gameNames = metaData.Where(info => info.MapNames.Contains(mapName)).Select(info => info.Name);
                Console.WriteLine($"- {mapName} (Game(s): {string.Join(", ", gameNames)})");
            }

            // This part of the code uses a dictionary that uses the Id Property as a Key and Info object as a value with the Meta Data List above
            Dictionary<int, Info> infoDictionary = metaData.ToDictionary(info => info.Id, info => info);

            // This reads out the dictionary in a loop from the Meta Data List above
            Console.WriteLine("Information using a loop:");
            foreach (var kvp in infoDictionary)
            {
                var info = kvp.Value;
                Console.WriteLine($"ID: {info.Id}");
                Console.WriteLine($"Name: {info.Name}");
                Console.WriteLine($"Genre: {info.Genre}");
                Console.WriteLine($"Map Names: {string.Join(", ", info.MapNames)}");
                Console.WriteLine();
            }

            // This part of the code finds any map name in the Meta Data List that has a 'z' and will output it
            var mapNamesWithZ = metaData
                .SelectMany(info => info.MapNames)
                .Where(name => name.Contains("z", StringComparison.OrdinalIgnoreCase))
                .Distinct();

            // This reads out the map names that have a 'z' in it which is only one "Azure Flame"
            Console.WriteLine("Map names with the letter 'z':");
            foreach (var mapName in mapNamesWithZ)
            {
                Console.WriteLine($"- {mapName}");
            }
        }
    }
}