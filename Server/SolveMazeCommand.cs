using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using MazeLib;
using MazeGeneratorLib;
using SearchAlgorithmsLib;

namespace Server
{
	class SolveMazeCommand : ICommand
	{
		private IModel model;

		public SolveMazeCommand(IModel model)
		{
			this.model = model;
		}
		public string Execute(string[] args, TcpClient client)
		{
			string name = args[1];
			int alg = int.Parse(args[2]);
			MazeSolution ms = model.SolveMaze(name, alg);
			if (ms == null)
			{
				return "maze does not exist";
			}
			return ms.ToJSON();
		}

	}
}