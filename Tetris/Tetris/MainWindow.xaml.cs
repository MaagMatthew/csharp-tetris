using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));

            // This is where you add the color schemes
            if (ColorScheme.schemes.Count == 0)
            {
                ColorScheme.schemes.Add("Ocean Breeze", new ColorScheme() {
                    Name = "Ocean Breeze",
                    IColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#B3473B")), 
                    JColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8FF87")), 
                    LColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF7D6E")), 
                    OColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#437FCC")), 
                    SColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4474B3")), 
                    TColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DE5849")), 
                    ZColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1C1F10")), 
                    Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#111111")),
                    DarkText = true }
                );
                ColorScheme.schemes.Add("Greyscale", new ColorScheme() {
                    Name = "GreyScale",
                    IColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000")),
                    JColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#181818")),
                    LColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#282828")),
                    OColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#404040")),
                    SColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#505050")),
                    TColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#666666")),
                    ZColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#808080")),
                    Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF")),
                    DarkText = false });
            }

        }
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            Options win2 = new Options();
            win2.Show();
            this.Close();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Start_Game(object sender, RoutedEventArgs e)
        {
            Difficulty win3 = new Difficulty();
            win3.Show();
            this.Close();
        }

    }
}
