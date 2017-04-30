using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MazeLib;
using MazeGeneratorLib;

namespace Server
{
	public class GenerateMazeCommand : ICommand
	{
		private IModel model;

		public GenerateMazeCommand(IModel model)
		{
			this.model = model;
		}
		public string Execute(string[] args, TcpClient client)
		{
			string name = args[1];
			int rows = int.Parse(args[2]);
			int cols = int.Parse(args[3]);
			Maze maze = model.GenerateMaze(name, rows, cols);
			if (maze == null) {
				return "maze already exists";
			}
			return maze.ToJSON();
		}
	}
}