using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Game
    {
        private Grid _myGrid;
        private Grid _opponentGrid;

        public Grid MyGrid => _myGrid;
        public Grid OpponentGrid => _opponentGrid;

        public Game()
        {
            _myGrid = new Grid();
            _opponentGrid = new Grid();
        }
    }  
}
