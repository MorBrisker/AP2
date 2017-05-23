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
