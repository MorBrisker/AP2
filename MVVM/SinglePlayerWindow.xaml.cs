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
using MVVM.ViewModel;

namespace MVVM
{
    public partial class SinglePlayerWindow : Window
    {
        private SinglePlayerViewModel vm;
        
        public SinglePlayerWindow()
        {
            vm = new SinglePlayerViewModel();
            this.DataContext = vm;
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            vm.Start();
            Window singleMaze = new SingleMaze(vm);
            singleMaze.Show();
            this.Hide();
        }
    }
}