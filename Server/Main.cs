using System;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using MazeLib;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
using System.Configuration;

namespace Server
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			IController c = new Controller();
			IModel m = new Model(c);
			c.SetModel(m);
			c.AddCommands();
			IClientHandler ch = new ClientHandler(c);
            int port = int.Parse(ConfigurationManager.AppSettings["PORT"]);
			Server server = new Server(port, ch);
			server.Start();
			//string command2 = "generate maze 5 5";
			//string result = c.ExecuteCommand(command2, null);
			/*string[] dani = new string[3];
			dani[0] = "dani";
			dani[1] = "5";
			dani[2] = "5";
			ICommand com = new GenerateMazeCommand(m);
			Console.WriteLine(com.Execute(dani, null));

			dani[0] = "mua";
			dani[1] = "5";
			dani[2] = "5";
			com = new GenerateMazeCommand(m);
			Console.WriteLine(com.Execute(dani, null));*/

			/*IMazeGenerator mg = new DFSMazeGenerator();
			Maze maze = mg.Generate(5, 5);
			Console.WriteLine(maze.ToString());

			BFS<Position> bfs = new BFS<Position>();
			ISearchable<Position> newMaze = new MazeAdapter(maze);
			Solution<Position> sol = bfs.Search(newMaze);
			MazeSolution ms = new MazeSolution(sol, maze.Name, bfs.GetNumOfNodesEvaluated());
			ms.SolutionPath();
			Console.WriteLine(ms.ToJSON());*/

		}
	}
}
