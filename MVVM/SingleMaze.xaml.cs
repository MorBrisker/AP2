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
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Windows.Threading;

namespace MVVM
{
    public partial class SingleMaze : Window
    {
        private SinglePlayerViewModel vm;

        public SingleMaze(SinglePlayerViewModel vm)
        {
            this.vm = vm;
            this.DataContext = vm;
            InitializeComponent();
        }

        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += Grid_KeyDown;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            mazey.mazeCanvas_KeyDown(sender, e.Key);
            mazey.msgShow();
        }

        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
     new Action(() => mazey.RestarGame()));

        }

        public string FromJSON(string str)
        {
            string solution;
            JObject solObj = JObject.Parse(str);
            solution = (string)solObj["Solution"];
            return solution;
        }

        private void SolveMaze_Click(object sender, RoutedEventArgs e)
        {
            string soultion = vm.SolveMaze();
            string sol = FromJSON(soultion);
            for (int i = 0; i < sol.Length; i++)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                    new Action(() => move(sender, sol, i)));
            }
        }

        public void move(Object sender, string sol, int i)
        {
            if (sol[i] == '0')
            {
                Key k = Key.Left;
                mazey.mazeCanvas_KeyDown(sender, k);
            }
            else if (sol[i] == '1')
            {
                Key k = Key.Right;
                mazey.mazeCanvas_KeyDown(sender, k);
            }
            else if (sol[i] == '2')
            {
                Key k = Key.Up;
                mazey.mazeCanvas_KeyDown(sender, k);
            }
            else if (sol[i] == '3')
            {
                Key k = Key.Down;
                mazey.mazeCanvas_KeyDown(sender, k);
            }
            Thread.Sleep(300);
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }
    }
}
