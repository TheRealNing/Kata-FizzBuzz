using System;
using System.Diagnostics.CodeAnalysis;

namespace FizzBuzz
{
    [ExcludeFromCodeCoverage]
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
