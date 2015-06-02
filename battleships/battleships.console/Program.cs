using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships;

namespace Battleships.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Grid grid = game.MyGrid;
            grid.AddShip(ShipType.Carrier, new Coordinate(0,0), ShipOrientation.Horizontal);
            grid.AddShip(ShipType.PatrolBoat, new Coordinate(5,5), ShipOrientation.Vertical);

            GridConsoleAdapter gridAdapter= new GridConsoleAdapter();
            GameConsoleAdapter gameAdapter = new GameConsoleAdapter(game, Console.Write, Console.ReadLine, gridAdapter);
            gameAdapter.PrintMyGrid();
            Console.ReadLine();
            gameAdapter.PrintOpponentGrid();
            Console.ReadLine();
        }
    }
}
