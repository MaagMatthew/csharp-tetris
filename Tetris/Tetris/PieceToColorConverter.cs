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
        public static ColorScheme scheme;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = null;
            if (targetType == typeof(Brush) && value.GetType() == typeof(Piece))
            {
                Piece piece = (Piece)value;
                switch (piece)
                {
                    case Piece.I:
                        brush = scheme.IColor;
                        break;
                    case Piece.J:
                        brush = scheme.JColor;
                        break;
                    case Piece.L:
                        brush = scheme.LColor;
                        break;
                    case Piece.None:
                        brush = scheme.Background;
                        break;
                    case Piece.O:
                        brush = scheme.OColor;
                        break;
                    case Piece.S:
                        brush = scheme.SColor;
                        break;
                    case Piece.T:
                        brush = scheme.TColor;
                        break;
                    case Piece.Z:
                        brush = scheme.ZColor;
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
