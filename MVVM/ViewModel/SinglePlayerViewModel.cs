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
        private int rows, cols, algo;
        private string name, mazeString;
        private Maze mazePuzzle;
        private SinglePlayerModel m;

        public SinglePlayerViewModel()
        {
            MazeCols = MVVM.Properties.Settings.Default.MazeCols;
            MazeRows = MVVM.Properties.Settings.Default.MazeRows;
            Algo = MVVM.Properties.Settings.Default.SearchAlgorithm;
            this.m = new SinglePlayerModel();
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

        public int Algo
        {
            get { return this.algo; }
            set
            {
                this.algo = value;
                //NotifyPropertyChanged("SearchAlgorithm");
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
        public string SolveMaze()
        {
            string command = "solve " + name + " " + Algo;
            return m.StartGame(command);
         }
    }
}
