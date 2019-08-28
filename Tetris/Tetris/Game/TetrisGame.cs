using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Tetris.Game.TetrisPiece;

namespace Tetris.Game
{
    public class TetrisGame
    {
        public enum Action
        {
            Down,
            Up,
            Left,
            Right,
            Pause,
            Resume
        }

        public bool IsGameOver { get; set; }
        public bool IsPlaying { get; set; }
        public Mode GameMode { get; set; }
        private double gravity = 1;
        public double GravityMod { get => gravity; set { gravity = value; } }

        public Cell[,] Grid { get; set; }

        public Thread Timer { get; set; }

        private bool pieceMoved = false;

        public TetrisGame()
        {
            SetupGrid();

            Timer = new Thread(Tick);
            Timer.Start();
        }

        private TetrisPiece currentPiece;

        private void SetupGrid(int width = 10, int height = 21)
        {
            Grid = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }
        }

        public void Tick()
        {
            int i = 0;
            while (true)
            {
                if (IsPlaying)
                {
                    MoveCurrentPieceDown();
                    // Do stuff

                    if (currentPiece == null)
                    {
                        SpawnNewPiece();
                        UpdatePiecePosition(0, 0);
                    }
                    pieceMoved = false;
                }
                Thread.Sleep((int)(1000 / GravityMod));
            }
        }

        public void Start()
        {
            IsPlaying = true;
        }

        public void Stop()
        {
            IsPlaying = false;
        }

        public void ProcessInput(Action action)
        {
            switch (action)
            {
                case Action.Left:
                    if (currentPiece != null)
                    {
                        pieceMoved = true;
                        UpdatePiecePosition(-1, 0);
                    }
                    break;
                case Action.Right:
                    if (currentPiece != null)
                    {
                        pieceMoved = true;
                        UpdatePiecePosition(1, 0);
                    }
                    break;
                case Action.Up:
                    if(currentPiece != null)
                    {
                        pieceMoved = true;
                        currentPiece.Rotate();
                    }
                    break;
            }
        }

        private bool UpdatePiecePosition(int xChange, int yChange)
        {
            if (currentPiece != null)
            {
                Coordinate[] coords = currentPiece.coordinates;
                foreach (Coordinate coord in coords)
                {
                    Grid[coord.X, coord.Y].Current = Cell.Piece.None;
                }

                int i;
                bool validMove = true;
                for (i = 0; i < coords.Length; i++)
                {
                    coords[i].X += xChange;
                    coords[i].Y += yChange;
                    if (coords[i].X < 0 || coords[i].X >= Grid.GetLength(0) || coords[i].Y < 0 || coords[i].Y >= Grid.GetLength(1))
                    {
                        validMove = false;
                    }
                    else if (Grid[coords[i].X, coords[i].Y].Current != Cell.Piece.None)
                    {
                        validMove = false;
                    }
                    // ALSO CHECK FOR COLLISION
                }
                //Undo the move if it's invalid
                for(int j = i-1; !validMove && j >=0; j--)
                {
                    coords[j].X -= xChange;
                    coords[j].Y -= yChange;
                }

                foreach (Coordinate coord in coords)
                {
                    Grid[coord.X, coord.Y].Current = currentPiece.PieceType;
                }
                return validMove;
            }
            return false;
        }
        private void MoveCurrentPieceDown()
        {
            if (!UpdatePiecePosition(0, 1) && !pieceMoved)
            {
                currentPiece = null;
            }
        }

        private void SpawnNewPiece()
        {
            currentPiece = new TetrisPiece(Cell.Piece.O);
        }
    }
}
