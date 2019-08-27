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
    /// Interaction logic for GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        public GameOverWindow()
        {
            InitializeComponent();
        }

        private void Try_Again(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow();
            game.Show();
            this.Close();
        }

        private void Leaderboard(object sender, RoutedEventArgs e)
        {
            LeaderboardWindow leaderboard = new LeaderboardWindow();
            leaderboard.Show();
            this.Close();
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
