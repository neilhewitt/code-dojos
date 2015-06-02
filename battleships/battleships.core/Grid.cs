using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Grid
    {
        private Square[,] _squares;

        public Square SquareAt(int x, int y)
        {
            return _squares[x, y];
        }

        public void AddShip(ShipType type, Coordinate coordinate, ShipOrientation orientation)
        {
            Ship ship = new Ship(type);
            bool isHorizontal = orientation == ShipOrientation.Horizontal;
            int start = (isHorizontal ? coordinate.X : coordinate.Y);
            for (int i = start; i < start + (int)type; i++)
            {
                Square square = _squares[(isHorizontal ? coordinate.Y : i), (isHorizontal ? i : coordinate.X)];
                square.AddShip(ship);
            }
        }

        public Grid()
        {
            _squares = new Square[10, 10];
            Enumerable.Range(0, 10).ForEach(row => Enumerable.Range(0, 10).ForEach(column => _squares[row, column] = new Square()));
        }
    }

    public struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
