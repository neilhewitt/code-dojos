using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Core
{
    public class Grid
    {
        private int _dimension;
        private string[] _grid;

        public IEnumerable<Row> Rows
        {
            get
            {
                return _grid.Select(row => new Row(row));
            }
        }

        public char CharAt(int x, int y)
        {
            if (x > _dimension || y > _dimension)
            {
                throw new IndexOutOfRangeException("Coordinate is out of range.");
            }

            return _grid[y - 1][x - 1];
        }

        public string StringAt(int x, int y, int length, Direction direction)
        {
            string output = "";
            if (x < 1 || x > _dimension || y < 1 || y > _dimension)
            {
                throw new IndexOutOfRangeException("Coordinate is out of range.");
            }

            for (int count = 0; count < length; count++)
            {
                if (x < 1 || x > _dimension || y < 1 || y > _dimension)
                {
                    return output;
                }

                output += CharAt(x, y);
                x = x + (direction == Direction.E || direction == Direction.NE || direction == Direction.SE ? 1 : 0)
                      - (direction == Direction.W || direction == Direction.NW || direction == Direction.SW ? 1 : 0);
                y = y + (direction == Direction.S || direction == Direction.SE || direction == Direction.SW ? 1 : 0)
                      - (direction == Direction.N || direction == Direction.NE || direction == Direction.NW ? 1 : 0);
            }

            return output;
        }

        public enum Direction
        {
            N, NE, E, SE, S, SW, W, NW
        }

        public Grid(IEnumerable<string> rows)
        {
            _dimension = rows.First().Length;
            _grid = new string[_dimension];

            int y = 0;
            foreach (string row in rows)
            {
                _grid[y++] = row;
            }
        }

        public class Row
        {
            public IEnumerable<char> Columns { get; private set; }

            public Row(IEnumerable<char> columns)
            {
                Columns = columns;
            }
        }
    }
}
