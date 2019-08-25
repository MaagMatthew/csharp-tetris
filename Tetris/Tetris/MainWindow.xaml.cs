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
                ColorScheme.schemes.Add("Ocean Breeze", new ColorScheme() { Name = "Ocean Breeze", Color1 = "#B3473B", Color2 = "#E8FF87", Color3 = "#FF7D6E", Color4 = "#437FCC", Color5 = "#4474B3", Color6 = "#DE5849", Color7 = "#1C1F10", DarkText = true });
                ColorScheme.schemes.Add("Greyscale", new ColorScheme() { Name = "GreyScale", Color1 = "#000000", Color2 = "#181818", Color3 = "#282828", Color4 = "#404040", Color5 = "#505050", Color6 = "#666666", Color7 = "#808080", DarkText = false });
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
