using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVM.Model;
using MazeLib;

namespace MVVM.ViewModel
{
    public class SinglePlayerViewModel : ViewModel
    {
        private int rows;
        private int cols;
        private string name, mazeString;
        private Maze mazePuzzle;

        private SinglePlayerModel m;
        //private Window v;
        
        public SinglePlayerViewModel()
        {
            this.m = new SinglePlayerModel();
            //this.v = v;
        }

        public int MazeRows {
            get { return this.rows; }
            set {
                this.rows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
        public int MazeCols
        {
            get { return this.cols; }
            set {
                this.cols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }

        public string MazeName
        {
            get { return this.name; }
            set {
                this.name = value;
                NotifyPropertyChanged("MazeName");
            }
        }

        public Maze MazePuzzle
        {
            get { return this.mazePuzzle; }
            set
            {
                this.mazePuzzle = value;
                NotifyPropertyChanged("MazePuzzle");
            }
        }

        public string MazeString
        {
            get { return this.mazeString; }
            set
            {
                this.mazeString = value;
                NotifyPropertyChanged("MazeString");
               
            }
        }

        public void Start()
        {
            string command = "generate " + name + " " + rows + " " + cols;
            MazeString = m.StartGame(command);
            MazePuzzle = Maze.FromJSON(MazeString);
            NotifyPropertyChanged("MazeString");
            NotifyPropertyChanged("MazePuzzle");
        }
    }
}
