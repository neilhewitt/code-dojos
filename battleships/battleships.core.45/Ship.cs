using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Ship
    {
        private ShipType _type;
        private int _hitsRemaining;

        public bool Destroyed => _hitsRemaining == 0;

        public void Bomb()
        {
            _hitsRemaining--;
        }

        public void ReType(ShipType type, int hitsRemaining)
        {
            _type = type;
            _hitsRemaining = hitsRemaining;
        }

        public Ship(ShipType type)
        {
            _type = type;
            _hitsRemaining = (int)type;
        }
    }

    public enum ShipType
    {
        Carrier = 5,
        Battleship = 4,
        Submarine = 3,
        Destroyer = 3,
        PatrolBoat = 2,
        Unknown = -1
    }

    public enum ShipOrientation
    {
        Horizontal,
        Vertical
    }

}
