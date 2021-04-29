using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guess_the_number.Database;
using Guess_the_number.Database.Repository;

namespace Guess_the_number
{
    class LoginService
    {
        private PlayerRepository _playerRepository = new PlayerRepository();

        public Player Login()
        {
            Console.WriteLine("Enter your name:");
            var playerName = Console.ReadLine();

            var playerByName = _playerRepository.GetAll().FirstOrDefault(x => x.Name == playerName);

            if (playerByName == null)
            {
                return Register(playerName);
            }

            Console.WriteLine("Enter a password:");
            var password = Console.ReadLine();

            return password == playerByName.Password ? playerByName : null;
        }

        private Player Register(string playerName)
        {
            Console.WriteLine($"There's no player with name '{playerName}'. Now you have to register.");

            Console.WriteLine("Enter a password:");
            var password = Console.ReadLine();

            var player =  new Player()
            {
                Name = playerName,
                Password = password
            };

            _playerRepository.Save(player);

            return player;
        }
    }
}
