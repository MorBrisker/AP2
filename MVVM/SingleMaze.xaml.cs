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
using MazeLib;
using MVVM.ViewModel;

namespace MVVM
{
    public partial class SingleMaze : Window
    {
        private ViewModel.ViewModel vm;
        public SingleMaze(SinglePlayerViewModel vm)
        {
            this.vm = vm;
            this.DataContext = vm;

            InitializeComponent();
            //mazey.UserControl_Loaded();
        }
        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += Grid_KeyDown;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            mazey.mazeCanvas_KeyDown(sender, e);
        }
        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void SolveMaze_Click(object sender, RoutedEventArgs e)
        {

        }


        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
