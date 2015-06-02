using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Square
    {
        private Ship _ship;
        private bool _hasBeenBombed = false;

        public bool HasBeenBombed => _hasBeenBombed;
        public bool IsPartOfShip => _ship != null;

        public void Bomb()
        {
            _hasBeenBombed = true;
        }

        public void AddShip(Ship ship)
        {
            _ship = ship;
        }

        public Square()
        {
        }
    }
}
