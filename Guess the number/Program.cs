using System;
using Microsoft.EntityFrameworkCore;
using Guess_the_number.Database.Repository;

namespace Guess_the_number
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            game.Play();
        }


    }
}
