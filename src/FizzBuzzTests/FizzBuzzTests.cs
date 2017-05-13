using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private ListWriter Output { get; } = new ListWriter();

        private FizzBuzzGame FizzBuzz { get; }

        public FizzBuzzTests()
        {
            FizzBuzz = new FizzBuzzGame(Output.Write);
        }

        [Test]
        [TestCaseSource(nameof(Digits))]
        public void ShouldOutputDigitsFromOneToOneHundred(int number)
        {
            FizzBuzz.Play();

            Output.For(number).Should().Be(number.ToString());
        }

        [Test]
        [TestCaseSource(nameof(MultiplesOfThree))]
        public void ShouldOutputFizzForMultiplesOfThree(int number)
        {
            FizzBuzz.Play();

            Output.For(number).Should().Be("Fizz");
        }

        [Test]
        [TestCaseSource(nameof(MultiplesOfFive))]
        public void ShouldOutputBuzzForMultiplesOfFive(int number)
        {
            FizzBuzz.Play();

            Output.For(number).Should().Be("Buzz");
        }

        [Test]
        [TestCaseSource(nameof(MultiplesOfFifteen))]
        public void ShouldOutputFizzBuzzForMultiplesOfThreeAndFive(int number)
        {
            FizzBuzz.Play();

            Output.For(number).Should().Be("FizzBuzz");
        }

        private static IEnumerable<int> Digits()
        {
            var list = new List<int>();

            for (var i = 1; i <= 100; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                    list.Add(i);
            }

            return list;
        }

        private static IEnumerable<int> MultiplesOfThree()
        {
            var list = new List<int>();

            for (var i = 1; i <= 33; i++)
            {
                if (i % 5 != 0)
                    list.Add(i * 3);
            }

            return list;
        }

        private static IEnumerable<int> MultiplesOfFive()
        {
            var list = new List<int>();

            for (var i = 1; i <= 20; i++)
            {
                if (i % 3 != 0)
                    list.Add(i * 5);
            }

            return list;
        }

        private static IEnumerable<int> MultiplesOfFifteen()
        {
            var list = new List<int>();

            for (var i = 1; i <= 6; i++)
            {
                    list.Add(i * 15);
            }

            return list;
        }
    }

    internal class ListWriter
    {
        private readonly List<string> _innerList = new List<string>();

        public void Write(string result)
        {
            _innerList.Add(result);
        }

        public string For(int number)
        {
            return _innerList[number - 1];
        }
    }

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
