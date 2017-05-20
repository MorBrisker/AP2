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
    /// <summary>
    /// Interaction logic for Maze.xaml
    /// </summary>
    public partial class Maze : UserControl
    {
        Label[] tiles;

        public Maze()
        {
            InitializeComponent();
            tiles = new Label[9];
            tiles[0] = l1;
            tiles[1] = l2;
            tiles[2] = l3;
            tiles[3] = l4;
            tiles[4] = l5;
            tiles[5] = l6;
            tiles[6] = l7;
            tiles[7] = l8;
            tiles[8] = l9;
        }

        public string Order
        {
            get
            {
                string s = "";
                foreach (Label l in tiles)
                    s += l.Content.ToString();
                return s;
            }
            set
            {
                string s = value;
                for (int i = 0; i < 9; i++)
                {
                    tiles[i].Content = s[i];
                    if (s[i] == ' ')
                        tiles[i].Background = Brushes.Gray;
                    else
                        tiles[i].Background = Brushes.White;
                }
            }

        }
        private void l_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            char[] s = Order.ToCharArray();
            int lenght = s.Length;
            //int c = maze.column;
            int i;
            for (i = 0; i < lenght; i++)
            {
                if (s[i].Equals(sender))
                    break;
            }
            if (i - 1 >= 0 && s[i - 1] == ' ')
                s[i - 1] = s[i];
            else if (i + 1 < lenght && s[i + 1] == ' ')
                s[i + 1] = s[i];
            //TODO-rectangle
            else if (s[(int)Math.Sqrt(lenght)] == ' ')
                s[(int)Math.Sqrt(lenght)] = s[i];
            s[i] = ' ';
            Order = new String(s);
        }
    }
}
