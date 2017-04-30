using System;
using System.Net.Sockets;

namespace Server
{
	public class JoinGameCommand : ICommand
	{
		IModel model;

		public JoinGameCommand(IModel model) 
		{
			this.model = model;
		}

		public string Execute(string[] args, TcpClient client)
		{
			string name = args[1];
			MazeLib.Maze m = model.JoinGame(name, client);
			return m.ToJSON();
		}
	}
}
