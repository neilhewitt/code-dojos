﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts.Core
{
    public class Piece
    {
        private Board _board;
        private int _row;
        private int _column;

        public PieceColour Colour { get; }
        public bool IsCrowned { get; internal set; }

        public Player Owner { get; }

        internal void Move(Move move)
        {
            foreach(MoveStep step in move.Steps)
            {
                Square square = _board[step.Row, step.Column];
                if (step == move.Steps.First())
                {
                    _board.Clear(step.Row, step.Column);
                }
                if (step == move.Steps.Last())
                {
                    _board.Occupy(step.Row, step.Column, this);
                    _row = square.Row;
                    _column = square.Column;
                }
                else
                {
                    if (square.IsOccupied)
                    {
                        _board.Clear(step.Row, step.Column);
                        Owner.CapturedAPiece();
                    }
                }
            }

            if ((_row == 0 && Colour == PieceColour.White) || (_row == 7 && Colour == PieceColour.Black))
            {
                IsCrowned = true;
                _board.Occupy(_row, _column, this);
            }
        }

        internal IEnumerable<Move> GetMoves()
        {
            return new MoveMap(_board, _row, _column).Moves;
        }

        public Piece(PieceColour colour, Board board, int row, int column, Player player)
        {
            _board = board;
            _row = row;
            _column = column;
            Owner = player;
            Colour = colour;
        }
    }

    public enum PieceColour
    {
        Black, White
    }
}
