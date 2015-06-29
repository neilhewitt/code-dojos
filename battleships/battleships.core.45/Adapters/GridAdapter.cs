using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public interface IGridAdapter
    {
        string Render(Grid grid, bool showShips, bool showHitsAndMisses);
    }

    public class GridConsoleAdapter : IGridAdapter
    {
        public string Render(Grid grid, bool showShips, bool showHitsAndMisses)
        {
            string output = "   A B C D E F G H I J\n  ---------------------\n";
            for (int i = 0; i < 10; i++)
            {
                output += (i + 1).ToString().PadLeft(2);
                for (int j = 0; j < 10; j++)
                {
                    Square square = grid.SquareAt(i, j);
                    string squareAsString =
                        showShips && square.IsPartOfShip && !square.HasBeenBombed ? "S" :
                        showHitsAndMisses && square.IsPartOfShip && square.HasBeenBombed ? "#" :
                        showHitsAndMisses && !square.IsPartOfShip && square.HasBeenBombed ? "X" :
                        " ";
                    output += "|" + squareAsString;

                }
                output += "|\n";
                if (i < 9) output += "  ---------------------\n";
            }
            output += "  ---------------------\n";
            return output;
        }
    }
}
