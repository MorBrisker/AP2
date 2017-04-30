using System;
using System.Net.Sockets;
using MazeLib;

namespace Server
{
	public class StartGameCommand : ICommand
	{
		private IModel model;

		public StartGameCommand(IModel m)
		{
			this.model = m;
		}

		public string Execute(string[] args, TcpClient client)
		{
			string name = args[1];
			int rows = int.Parse(args[2]);
			int cols = int.Parse(args[3]);
			Maze m = model.StartGame(name, rows, cols, client);
			return m.ToJSON();
		}
	}
}
