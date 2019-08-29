using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris
{
    public class ColorScheme
    {
        public static Dictionary<string, ColorScheme> schemes = new Dictionary<string, ColorScheme>();
        public string Name { get; set; }
        public SolidColorBrush IColor { get; set; }
        public SolidColorBrush JColor { get; set; }
        public SolidColorBrush LColor { get; set; }
        public SolidColorBrush OColor { get; set; }
        public SolidColorBrush SColor { get; set; }
        public SolidColorBrush TColor { get; set; }
        public SolidColorBrush ZColor { get; set; }
        public SolidColorBrush Background { get; set; }
        public bool DarkText { get; set; }
    }
}
