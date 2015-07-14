using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Core
{
    public class WordSearchResults
    {
        public IEnumerable<Result> Items { get; private set; }

        public WordSearchResults(IEnumerable<Result> items)
        {
            Items = items;
        }
    }

    public class Result
    {
        public string Word { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Grid.Direction Direction { get; private set; }

        public Result(string word, int x, int y, Grid.Direction direction)
        {
            Word = word;
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
