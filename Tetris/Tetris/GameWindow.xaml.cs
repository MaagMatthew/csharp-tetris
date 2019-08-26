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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public static Mode mode = Mode.EASY;
        readonly MediaPlayer mediaPlayer = new MediaPlayer();
        public static double gravityMod = 0;


        public GameWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            string[] lines = new string[2];
            try
            {
                lines = File.ReadAllLines("settings.set");

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
            if (lines[1].ToLower().Contains("false"))
            {
                mediaPlayer.Open(new Uri("../../Music/Tetris_-_Theme_A_by_Gori_Fater.mp3", UriKind.Relative));
                mediaPlayer.Volume = 100;
                mediaPlayer.MediaEnded += MusicEnded;
                if(mode == Mode.NIGHTMARE)
                {
                    mediaPlayer.SpeedRatio = .5;
                    Background = Brushes.Black;
                    Foreground = Brushes.Red;
                }
                mediaPlayer.Play();

            }
        }

        void MusicEnded(Object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds(0);
            mediaPlayer.Play();
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mediaPlayer.Stop();
            mainWindow.Show();
            this.Close();
        }
    }
}
