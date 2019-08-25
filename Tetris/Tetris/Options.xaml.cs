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
using System.IO;

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
            colorCombo.ItemsSource = ColorScheme.schemes.Keys;
            string[] lines = new string[2];
            try
            {
                lines = File.ReadAllLines("settings.set");
                colorCombo.SelectedItem = lines[0];
                Mute.IsChecked = lines[1].ToLower() == "true" ? true : false;
            }
            catch (FileNotFoundException)
            {
                using (StreamWriter file = new StreamWriter("settings.set"))
                {
                    string scheme = ColorScheme.schemes.Keys.ToList()[0];
                    bool mute = false;
                    file.Write(scheme + "\n" + mute);
                    lines[0] = scheme;
                    lines[1] = "" + mute;
                }
            }

        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            using(StreamWriter file = new StreamWriter("settings.set"))
            {
                file.Write(colorCombo.SelectedItem + "\n" + Mute.IsChecked);
            }
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
