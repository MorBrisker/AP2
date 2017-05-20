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

namespace MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            Window singlePlayerWindow = new SinglePlayerWindow();
            singlePlayerWindow.Show();
            this.Hide();
        }
        private void MultiPlayer_Click(object sender, RoutedEventArgs e)
        {
            Window multiPlayerWindow = new MultiPlayerWindow();
            multiPlayerWindow.Show();
            this.Hide();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Window settingsWindow = new SettingsWindow();
            settingsWindow.Show();
            this.Hide();
        }
    }
}
