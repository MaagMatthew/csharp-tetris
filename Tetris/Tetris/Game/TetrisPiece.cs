using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.Game.Cell;

namespace Tetris.Game
{
    public class TetrisPiece
    {
        public struct Coordinate
        {
            public Coordinate(int x, int y) : this()
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }


        }

        public Coordinate[] coordinates { get; } = new Coordinate[4];
        public Piece PieceType { get; set; }

        public TetrisPiece(Piece pieceType)
        {
            PieceType = pieceType;
            for(int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = new Coordinate(0, i);
            }
        }

        public void Rotate()
        {

        }

        public void UndoRotate()
        {

        }
    }
}
