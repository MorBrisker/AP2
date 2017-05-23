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

namespace MVVM
{

    public partial class MultiMaze : Window
    {
        public MultiMaze()
        {
            InitializeComponent();
        }
        private void backToMainMenu_Click(object sender, RoutedEventArgs e) { }
        private void Grid_KeyDown(object sender, KeyEventArgs e) { }
        public void UserControl_Loaded(object sender, RoutedEventArgs e) { }

    }
}
