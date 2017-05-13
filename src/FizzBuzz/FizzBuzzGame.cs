using System;

namespace FizzBuzz
{
    public class FizzBuzzGame
    {
        private readonly Action<string> _output;

        public FizzBuzzGame(Action<string> output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Play()
        {
            for (var i = 1; i < 101; i++)
            {
                if (i % 15 == 0)
                    _output("FizzBuzz");
                else if (i % 5 == 0)
                    _output("Buzz");
                else if (i % 3 == 0)
                    _output("Fizz");
                else
                    _output(i.ToString());
            }
        }
    }
}