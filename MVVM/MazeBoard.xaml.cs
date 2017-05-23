
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
        private Position currentPos;
        private Rectangle[,] rectanglesArr;
        private Maze m;
        private int recHeight, recWidth;
        private string charArr;
        private Image myImage;

        public MazeBoard()
        {
            InitializeComponent();
        }


        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CreateMaze();
        }

        public string MString
        {
            get { return (string)GetValue(MStringProperty); }
            set { SetValue(MStringProperty, value); }
        }
        public static readonly DependencyProperty MStringProperty = DependencyProperty.Register("MString", typeof(string), typeof(MazeBoard));

        public Position CalcCurrentPos()
        {
            return new Position();
        }

        public void CreateMaze ()
        {
            while (MString == null)
            {
                Thread.Sleep(1);
            }
            this.m = Maze.FromJSON(MString);            
            if (m.Rows == 0 || m.Cols == 0 || m.Name == null)
            {
                return;
            }

            this.recHeight = (int)mazeCanvas.Height / m.Rows;
            this.recWidth = (int)mazeCanvas.Width / m.Cols;
            this.rectanglesArr = new Rectangle[m.Rows, m.Cols];
            this.charArr = m.ToString();
            this.currentPos = m.InitialPos;
            DrawMaze();
        }
        public void DrawMaze()
        {
            int counter = 0;
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = recHeight;
                    rect.Width = recWidth;
                    this.rectanglesArr[i, j] = rect;
                    if (this.charArr[counter] == '1')
                    {
                        this.rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
                    }
                    else if (this.charArr[counter] == '0')
                    {
                        this.rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
                    }
                    else if (this.charArr[counter] == '*')
                    {
                        this.rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
                        myImage = new Image()
                        {

                            Source = new BitmapImage(new Uri(@"C:\Users\מור\Source\Repos\AP2\MVVM\unicorn.jpg")),
                            Width = this.recWidth,
                            Height = this.recHeight
                        };
                        mazeCanvas.Children.Add(myImage);
                        Canvas.SetLeft(myImage, this.recWidth * m.InitialPos.Col);
                        Canvas.SetTop(myImage, this.recHeight * m.InitialPos.Row);
                        counter++;
                        break;
                    }
                    else if (this.charArr[counter] == '#')
                    {
                        this.rectanglesArr[i, j].Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
                    }
                    else
                    {
                        counter++;
                        continue;
                    }
                    mazeCanvas.Children.Add(this.rectanglesArr[i, j]);
                    Canvas.SetLeft(this.rectanglesArr[i, j], this.recWidth * j);
                    Canvas.SetTop(this.rectanglesArr[i, j], this.recHeight * i);
                    counter++;
                }
                counter += 2;
            }
        }

        public void mazeCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            int row = this.currentPos.Row;
            int col = this.currentPos.Col;
            if (e.Key == Key.Left)
            {
                if (col - 1 >= 0 && m[row,col-1] == CellType.Free)
                {
                    Canvas.SetLeft(myImage, this.recWidth * (col-1));
                    Canvas.SetTop(myImage, this.recHeight * row);
                    this.currentPos.Col -= 1;
                }
            }
            if (e.Key == Key.Right)
            {
                if (col + 1 < m.Cols && m[row, col + 1] == CellType.Free)
                {
                    Canvas.SetLeft(myImage, this.recWidth * (col+1));
                    Canvas.SetTop(myImage, this.recHeight * row);
                    this.currentPos.Col += 1;
                }
            }
            if (e.Key == Key.Up)
            {
                if (row - 1 >= 0 && m[row - 1, col] == CellType.Free)
                {
                    Canvas.SetLeft(myImage, this.recWidth * col);
                    Canvas.SetTop(myImage, this.recHeight * (row - 1));
                    this.currentPos.Row -= 1;

                }
            }
            if (e.Key == Key.Down)
            {
                if (row + 1 < m.Rows && m[row + 1, col] == CellType.Free)
                {
                    Canvas.SetLeft(myImage, this.recWidth * col);
                    Canvas.SetTop(myImage, this.recHeight * (row + 1));
                    this.currentPos.Row += 1;

                }
            }
        }


    }
}
