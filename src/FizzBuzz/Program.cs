using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new FizzBuzzGame(Console.WriteLine);

            game.Play();

            Console.ReadKey();
        }

    }
}
