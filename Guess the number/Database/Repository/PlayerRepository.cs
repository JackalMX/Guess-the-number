using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Guess_the_number.Database.Repository
{
    class PlayerRepository
    {
        public string JsonPath
        { 
            get
            {
                var dllPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var appPath = Path.GetDirectoryName(dllPath);

                return Path.Combine(appPath, "Players.json");
            }
        }

        public List<Player> GetAll()
        {
            var json = File.ReadAllText(JsonPath);
            
            var players = JsonSerializer.Deserialize<List<Player>>(json);

            return players;
        }

        public void Save(Player player)
        {
            var allPlayers = GetAll();
            allPlayers.Add(player);
            var jsonString = JsonSerializer.Serialize(allPlayers);
            File.WriteAllText(JsonPath, jsonString);
        }
    }
}
