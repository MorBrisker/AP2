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
	public class ListGamesCommand : ICommand
	{
		private IModel model;

		public ListGamesCommand(IModel model)
		{
			this.model = model;
		}

		public string Execute(string[] args, TcpClient client) 
		{
			return model.ListGames();
		}
	}
}