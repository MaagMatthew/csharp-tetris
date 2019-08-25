using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class ColorScheme
    {
        public static Dictionary<string, ColorScheme> schemes = new Dictionary<string, ColorScheme>();
        public string Name { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string Color4 { get; set; }
        public string Color5 { get; set; }
        public string Color6 { get; set; }
        public string Color7 { get; set; }
        public bool DarkText { get; set; }
    }
}
