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
using Menu.controls;
namespace Menu
{
    //test
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Single_Player_Click(object sender, RoutedEventArgs e)
        {
            var singlePlayerWindow = new Window();
            singlePlayerWindow.Title = "Single Player Menu";
            SinglePlayerMenu singlePlayerMenu = new SinglePlayerMenu();
            singlePlayerWindow.Content = singlePlayerMenu;
            singlePlayerWindow.Show();
        }

        private void Multi_Player_Click(object sender, RoutedEventArgs e)
        {
            var multiPlayerWindow = new Window();
            multiPlayerWindow.Title = "Multi Player Menu";
            MultiPlayerMenu multiPlayerMenu = new MultiPlayerMenu();
            multiPlayerWindow.Content = multiPlayerMenu;
            multiPlayerWindow.Show();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //var settingsWindow = new Window();
            //settingsWindow.Title = "Settings Player Menu";
            SettingsWindow settingsMenu = new SettingsWindow();
            //settingsWindow.Content = settingsMenu;
            settingsMenu.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //puzzle.Order = "12345678 ";
        }
    }
}
