using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Core
{
    public class WordSearcher
    {
        private Grid _grid;
        private string[] _words;

        public Grid WordGrid { get { return _grid; } }

        public WordSearchResults Solve()
        {
            List<Result> items = new List<Result>();
            foreach(string word in _words)
            {
                Result item = FindWord(word);
                if (item != null)
                {
                    items.Add(item);
                }
                else
                {
                    return null;
                }
            }

            WordSearchResults solution = new WordSearchResults(items);
            return solution;
        }

        public Result FindWord(string word)
        {
            int thisX = 1, thisY = 1;
            foreach (Grid.Row row in _grid.Rows)
            {
                foreach(char column in row.Columns)
                {
                    foreach(string name in Enum.GetNames(typeof(Grid.Direction)))
                    {
                        Grid.Direction thisDirection = (Grid.Direction)Enum.Parse(typeof(Grid.Direction), name);
                        string test = _grid.StringAt(thisX, thisY, word.Length, thisDirection);
                        if (test.Length == word.Length && test.ToLowerInvariant() == word.ToLowerInvariant())
                        {
                            // found it!
                            return new Result(word, thisX, thisY, thisDirection);
                        }
                    }
                    thisX++;
                }
                thisX = 1;
                thisY++;
            }

            return null;
        }

        public WordSearcher(string[] gridLines, string[] words)
        {
            int gridWidth = gridLines[0].Length;
            if (gridLines.Any(line => line.Length != gridWidth))
            {
                throw new Exception("Invalid grid - all rows must be the same length");
            }

            _grid = new Grid(gridLines);
            _words = words;
        }
    }
}
