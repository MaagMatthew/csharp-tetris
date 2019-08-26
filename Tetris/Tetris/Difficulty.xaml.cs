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
    /// Interaction logic for Difficulty.xaml
    /// </summary>
    public partial class Difficulty : Window
    {
        public Difficulty()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            GameWindow.mode = Mode.EASY;
            GameWindow.gravityMod = 1.05;
            Start_Game();
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {

            GameWindow.mode = Mode.MEDIUM;
            GameWindow.gravityMod = 1.1;
            Start_Game();
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {

            GameWindow.mode = Mode.HARD;
            GameWindow.gravityMod = 1.2;
            Start_Game();
        }

        private void Nightmare_Click(object sender, RoutedEventArgs e)
        {

            GameWindow.mode = Mode.NIGHTMARE;
            GameWindow.gravityMod = 1.666;
            Start_Game();
        }

        private void Start_Game()
        {
            GameWindow win4 = new GameWindow();
            win4.Show();
            this.Close();
        }
    }
}
