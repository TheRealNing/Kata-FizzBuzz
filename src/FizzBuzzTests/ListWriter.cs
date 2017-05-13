using System.Collections.Generic;

namespace FizzBuzz
{
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
}