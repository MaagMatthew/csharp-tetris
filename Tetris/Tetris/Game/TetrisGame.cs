using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Tetris.Game.Cell;
using static Tetris.Game.TetrisPiece;

namespace Tetris.Game
{
    public class TetrisGame : INotifyPropertyChanged
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

        public int score = 0;
        public int Score { get => score; set { score = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score")); } }
        public int rows;
        public int Rows { get => rows; set { rows = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Rows")); } }

        public bool gameOver = false;
        public bool IsGameOver { get => gameOver; set { gameOver = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsGameOver")); } }
        public bool IsPlaying { get; set; }
        public Mode GameMode { get; set; }
        private double gravity = 1;
        public double GravityMod { get => gravity; set { gravity = value; } }

        public Cell[,] Grid { get; set; }

        public Thread Timer { get; set; }

        private bool pieceMoved = false;
        private bool hidden = false;
        private static Random rand = new Random();

        public TetrisGame()
        {
            SetupGrid();

            Timer = new Thread(GameLoop);
            Timer.Start();
        }

        private TetrisPiece currentPiece;
        private Piece nextType = RandomPieceType();

        public event PropertyChangedEventHandler PropertyChanged;

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

        public void GameLoop()
        {
            SpawnNewPiece();
            while (true)
            {
                Tick();

                Thread.Sleep((int)(1000 / GravityMod));
            }
        }

        public void Tick()
        {
            if (IsPlaying)
            {
                MoveCurrentPieceDown();
                // Do stuff

                if (currentPiece == null)
                {
                    Score += 10;
                    ClearFullRows();

                    SpawnNewPiece();
                }
                pieceMoved = false;
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
                        UpdatePiecePositionFull(-1, 0);
                    }
                    break;
                case Action.Right:
                    if (currentPiece != null)
                    {
                        pieceMoved = true;
                        UpdatePiecePositionFull(1, 0);
                    }
                    break;
                case Action.Up:
                    if (currentPiece != null)
                    {
                        pieceMoved = true;
                        HidePiece();
                        currentPiece.Rotate();
                        UpdatePiecePosition(-1, 0);
                        ShiftIfCollide();
                        ShowPiece();
                    }
                    break;
                case Action.Down:
                    if (currentPiece != null)
                    {
                        MoveCurrentPieceDown();
                    }
                    break;
            }
        }

        private void HidePiece()
        {
            if (currentPiece != null && !hidden)
            {
                hidden = true;
                Coordinate[] coords = currentPiece.coordinates;
                foreach (Coordinate coord in coords)
                {
                    Grid[coord.X, coord.Y].Current = Cell.Piece.None;
                }
            }
        }

        private void ShowPiece()
        {
            if (currentPiece != null && hidden)
            {
                hidden = false;
                Coordinate[] coords = currentPiece.coordinates;
                foreach (Coordinate coord in coords)
                {
                    Grid[coord.X, coord.Y].Current = currentPiece.PieceType;
                }
            }
        }

        private bool UpdatePiecePositionFull(int xChange, int yChange)
        {
            HidePiece();
            bool value = UpdatePiecePosition(xChange, yChange);
            ShowPiece();
            return value;
        }

        private bool UpdatePiecePosition(int xChange, int yChange)
        {
            if (currentPiece != null)
            {
                Coordinate[] coords = currentPiece.coordinates;

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
                }
                //Undo the move if it's invalid
                for (int j = i - 1; !validMove && j >= 0; j--)
                {
                    coords[j].X -= xChange;
                    coords[j].Y -= yChange;
                }

                return validMove;
            }
            return false;
        }

        private void ShiftIfCollide()
        {
            for (int i = 0; i < currentPiece.coordinates.Length; i++)
            {
                var coord = currentPiece.coordinates[i];
                if (coord.X >= Grid.GetLength(0))
                {
                    UpdatePiecePosition(-1, 0);
                    i--;
                }
            }
        }

        private void MoveCurrentPieceDown()
        {
            if (!UpdatePiecePositionFull(0, 1) && !pieceMoved)
            {
                currentPiece = null;
            }
        }

        private void SpawnNewPiece()
        {
            IsGameOver = CheckForLoss();
            if (IsGameOver)
            {
                IsPlaying = false;
            }
            else
            {
                currentPiece = new TetrisPiece(nextType, rand.Next(Grid.GetLength(0) - 3));

                nextType = RandomPieceType();
                UpdatePiecePosition(0, 0);
            }
        }

        private bool CheckForLoss()
        {
            bool lost = false;
            for (int i = 0; !lost && i < Grid.GetLength(0); i++)
            {
                lost = Grid[i, 0].Current != Piece.None;
            }
            return lost;
        }

        private void ClearFullRows()
        {
            bool rowCleared = false;
            for (int i = Grid.GetLength(1) - 1; i >= 0; i--)
            {
                bool rowFull = true;
                for (int j = 0; rowFull && j < Grid.GetLength(0); j++)
                {
                    rowFull = Grid[j, i].Current != Piece.None;
                }

                if (rowFull)
                {
                    rowCleared = true;
                    Score += 100;
                    Rows++;
                    ShiftAllRows(i);
                    i++;
                }
            }
            if (rowCleared)
            {
                GravityMod *= GameWindow.gravityMod;
            }
        }

        private void ShiftAllRows(int startY)
        {
            for (int i = startY; i > 0; i--)
            {
                for (int j = 0; j < Grid.GetLength(0); j++)
                {
                    Grid[j, i].Current = Grid[j, i - 1].Current;
                }
            }
        }

        private static Piece RandomPieceType()
        {
            var types = Enum.GetValues(typeof(Piece));
            Piece type = Piece.None;
            while (type == Piece.None)
            {
                type = (Piece)types.GetValue(rand.Next(types.Length));
            }
            return type;
        }
    }
}
