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

        public TetrisPiece(Piece pieceType, int startX = 0)
        {
            PieceType = pieceType;
            SetPiece(pieceType, startX);
        }

        private void SetPiece(Piece pieceType, int startX)
        {
            switch (pieceType)
            {
                case Piece.I:
                    coordinates[0] = new Coordinate(startX, 0);
                    coordinates[1] = new Coordinate(startX, 1);
                    coordinates[2] = new Coordinate(startX, 2);
                    coordinates[3] = new Coordinate(startX, 3);
                    break;
                case Piece.J:
                    coordinates[0] = new Coordinate(startX, 0);
                    coordinates[1] = new Coordinate(startX, 1);
                    coordinates[2] = new Coordinate(startX, 2);
                    coordinates[3] = new Coordinate(startX + 1, 2);
                    break;
                case Piece.L:
                    coordinates[0] = new Coordinate(startX, 0);
                    coordinates[1] = new Coordinate(startX, 1);
                    coordinates[2] = new Coordinate(startX, 2);
                    coordinates[3] = new Coordinate(startX + 1, 0);
                    break;
                case Piece.O:
                    coordinates[0] = new Coordinate(startX, 0);
                    coordinates[1] = new Coordinate(startX, 1);
                    coordinates[2] = new Coordinate(startX + 1, 0);
                    coordinates[3] = new Coordinate(startX + 1, 1);
                    break;
                case Piece.S:
                    coordinates[0] = new Coordinate(startX + 0, 1);
                    coordinates[1] = new Coordinate(startX + 1, 1);
                    coordinates[2] = new Coordinate(startX + 1, 0);
                    coordinates[3] = new Coordinate(startX + 2, 0);
                    break;
                case Piece.Z:
                    coordinates[0] = new Coordinate(startX + 0, 0);
                    coordinates[1] = new Coordinate(startX + 1, 0);
                    coordinates[2] = new Coordinate(startX + 1, 1);
                    coordinates[3] = new Coordinate(startX + 2, 1);
                    break;
                case Piece.T:
                    coordinates[0] = new Coordinate(startX + 0, 0);
                    coordinates[1] = new Coordinate(startX + 1, 0);
                    coordinates[2] = new Coordinate(startX + 2, 0);
                    coordinates[3] = new Coordinate(startX + 1, 1);
                    break;
                default:
                    coordinates[0] = new Coordinate(0, 0);
                    coordinates[1] = new Coordinate(0, 0);
                    coordinates[2] = new Coordinate(0, 0);
                    coordinates[3] = new Coordinate(0, 0);
                    break;
            }
        }

        public void Rotate()
        {
            int xOffset = int.MaxValue, yOffset = int.MaxValue;
            foreach(var coord in coordinates)
            {
                xOffset = Math.Min(xOffset, coord.X);
                yOffset = Math.Min(yOffset, coord.Y);
            }
            bool[,] pieces = new bool[4, 4];
            foreach(Coordinate coord in coordinates)
            {
                pieces[coord.X - xOffset, coord.Y - yOffset] = true;
            }

            bool emptyBottomRow = true;
            while (emptyBottomRow)
            {
                for(int i = 0; emptyBottomRow && i < pieces.GetLength(0); i++)
                {
                    emptyBottomRow = !pieces[i, pieces.GetLength(1) - 1];
                }
                if (emptyBottomRow)
                {
                    for(int i = pieces.GetLength(1) - 1; i > 0; i--)
                    {
                        for(int j = pieces.GetLength(0) - 1; j >= 0; j--)
                        {
                            pieces[j, i] = pieces[j, i - 1];
                        }
                    }
                    for(int i = 0; i < pieces.GetLength(0); i++)
                    {
                        pieces[i, 0] = false;
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < pieces.GetLength(1); i++)
            {
                for (int j = 0; j < pieces.GetLength(0); j++)
                {
                    if(pieces[i, j])
                    {
                        coordinates[count++] = new Coordinate(xOffset + (pieces.GetLength(0) - j), yOffset + i);
                    }
                }
            }
        }
    }
}
