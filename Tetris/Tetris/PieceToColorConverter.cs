using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Tetris.Game;
using static Tetris.Game.Cell;

namespace Tetris
{
    class PieceToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = null;
            if (targetType == typeof(Brush) && value.GetType() == typeof(Piece))
            {
                Piece piece = (Piece)value;
                switch (piece)
                {
                    case Piece.I:
                        brush = new SolidColorBrush(Color.FromRgb(0, 0, 255));
                        break;
                    case Piece.J:
                        brush = new SolidColorBrush(Color.FromRgb(0, 255, 255));
                        break;
                    case Piece.L:
                        brush = new SolidColorBrush(Color.FromRgb(255, 0, 255));
                        break;
                    case Piece.None:
                        brush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        break;
                    case Piece.O:
                        brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        break;
                    case Piece.S:
                        brush = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                        break;
                    case Piece.T:
                        brush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        break;
                    case Piece.Z:
                        brush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                        break;
                    default:
                        brush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                        break;
                }
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
