using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Game
{
    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public enum Piece
        {
            I,
            J,
            L,
            O,
            T,
            Z,
            S,
            None
        }

        private Piece current = Piece.None;
        public Piece Current
        {
            get => current; set {
                current = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Current"));
            }
        }
    }
}
