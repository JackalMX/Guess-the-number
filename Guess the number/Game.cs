using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    class Game
    {
        private int maxValue;
        private const int attempts = 5;

        private LoginService _loginService = new LoginService();

        public void Play()
        {
            int i = 0;
            int playerNumber;
            var number = new Random();

            var player = _loginService.Login();

            Console.WriteLine($"Hello, {player.Name}! \nEnter a maximum value:");

            ReadDataFromConsole();

            int guessNumber = number.Next(0, maxValue);

            do
            {
                if (int.TryParse(Console.ReadLine(), out playerNumber))
                {
                    Console.WriteLine($"\nLet's check your number....");
                    Console.WriteLine($"--------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine($"Enter a number (int). Now you have {attempts - (i + 1)} tries.");
                    i++;
                }

                if (playerNumber == guessNumber)
                {
                    Console.WriteLine("You won!");
                    player.Score += CalculateScore(attempts);
                    Console.WriteLine($"Your score now is: {player.Score}");
                }
                else
                {
                    i++;
                    Console.WriteLine($"Wrong. Now you have {attempts - i} tries\n");
                }

                if (i == attempts)
                {
                    Console.WriteLine("Game over.");
                    break;
                }
            } while (playerNumber != guessNumber);
        }

        public void ReadDataFromConsole()
        {
            Console.WriteLine("--------------------------------------------------------------------");

            if (int.TryParse(Console.ReadLine(), out maxValue))
            {
                Console.WriteLine($"Now try to guess the number. You have {attempts} tries.");
            }
            else
            {
                Console.WriteLine("Enter a number (int)");
            }
        }

        public int CalculateScore(int attemptsLeft)
        {
            return attemptsLeft * maxValue;
        }
    }
}
