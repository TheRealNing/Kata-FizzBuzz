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

        private static IEnumerable<TestCaseData> Digits()
        {
            return BuildList(1, null, i => i % 3 == 0 || i % 5 == 0);
        }

        private static IEnumerable<TestCaseData> MultiplesOfThree()
        {
            return BuildList(3, "Fizz", i => i % 5 == 0);
        }

        private static IEnumerable<TestCaseData> MultiplesOfFive()
        {
            return BuildList(5, "Buzz", i => i % 3 == 0);
        }

        private static IEnumerable<TestCaseData> MultiplesOfFifteen()
        {
            return BuildList(15, "FizzBuzz");
        }

        private static IEnumerable<TestCaseData> BuildList(int multiple, string result, Func<int, bool> filter = null)
        {
            filter = filter ?? (i => false);
            var list = new List<TestCaseData>();

            for (var i = 1; i <= 100 / multiple; i++)
            {
                if (!filter(i))
                {
                    var value = i * multiple;
                    result = result ?? i.ToString();
                    list.Add(new TestCaseData(value).SetName($"{value} = {result}"));
                }
            }

            return list;
        }
    }
}
