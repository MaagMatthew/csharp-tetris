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
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public Options()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            List<ColorScheme> colorSchemes = new List<ColorScheme>();
            //colorSchemes.Add(new ColorScheme() { Name = "Ocean Breeze", Color1 = "#B3473B", Color2 = "#E8FF87", Color3 = "#FF7D6E", Color4 = "#437FCC", Color5 = "#4474B3", Color6 = "#DE5849", Color7 = "#1C1F10", DarkText = true });
            //colorSchemes.Add(new ColorScheme() { Name = "GreyScale", Color1 = "#000000", Color2 = "#181818", Color3 = "#282828", Color4 = "#404040", Color5 = "#505050", Color6 = "#666666", Color7 = "#808080", DarkText = false });
            colorCombo.Items.Add("Ocean Breeze");
            colorCombo.Items.Add("Grey Scale");

        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
