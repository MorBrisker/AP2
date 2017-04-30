using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeGeneratorLib;
using MazeLib;

namespace ex1
{
	public class Program
	{
		public static void CompareSolvers()
		{
			IMazeGenerator mg = new DFSMazeGenerator();
			Maze maze = mg.Generate(5, 5);
			Console.WriteLine(maze.ToString());

			BFS<Position> bfs = new BFS<Position>();
			ISearchable<Position> newMaze = new MazeAdapter(maze);
			bfs.Search(newMaze);
			Console.WriteLine(bfs.GetNumOfNodesEvaluated());

			DFS<Position> dfs = new DFS<Position>();
			//ISearchable<Position> newMaze = new MazeAdapter(maze);
			dfs.Search(newMaze);

			//CellType C = maze[1, 1];
			Console.WriteLine(dfs.GetNumOfNodesEvaluated());


		}
		static void Main(string[] args)
		{
			Program.CompareSolvers();
		}
	}
}