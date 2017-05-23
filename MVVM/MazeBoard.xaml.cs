
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
using MazeLib;
using System.Threading;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for Maze.xaml
    /// </summary>
    public partial class MazeBoard : UserControl
    {
        Position currentPos;
        Rectangle[,] rectanglesArr;

        public MazeBoard()
        {
            InitializeComponent();
        }


        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DrawMaze();
        }

        public string MString
        {
            get { return (string)GetValue(MStringProperty); }
            set { SetValue(MStringProperty, value); }
        }
        public static readonly DependencyProperty MStringProperty = DependencyProperty.Register("MString", typeof(string), typeof(MazeBoard));

        public Position CalcCurrentPos()
        {

        }
        public void CalcMazeToDraw()
        {

        }
        public void CreateMaze ()
        {
            while (MString == null)
            {
                Thread.Sleep(1);
            }
            Maze m = Maze.FromJSON(MString);
            int rows = m.Rows;
            int cols = m.Cols;
            string name = m.Name;
            
            if (rows == 0 || cols == 0 || name == null)
            {
                return;
            }

            int recHeight = (int)mazeCanvas.Height / rows;
            int recWidth = (int)mazeCanvas.Width / cols;
            rectanglesArr = new Rectangle[rows, cols];
            string charArr = m.ToString();
            currentPos = m.InitialPos;
        }
        public void DrawMaze()
        {

            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = recHeight;
                    rect.Width = recWidth;
                    rectanglesArr[i, j] = rect;
                    if (charArr[counter] == '1')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
                    }
                    else if (charArr[counter] == '0')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.White);
                    }
                    else if (charArr[counter] == '*')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
                    }
                    else if (charArr[counter] == '#')
                    {
                        rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
                    }
                    else
                    {
                        counter++;
                        continue;
                    }
                    mazeCanvas.Children.Add(rectanglesArr[i, j]);
                    Canvas.SetLeft(rectanglesArr[i, j], recWidth * j);
                    Canvas.SetTop(rectanglesArr[i, j], recHeight * i);
                    counter++;
                }
                counter += 2;
            }
        }


    }
}
