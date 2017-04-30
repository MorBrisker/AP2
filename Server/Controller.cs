using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Server
{
	public class Controller : IController
	{
		private Dictionary<string, ICommand> commands;
		private IModel model;
		private IClientHandler clientHandler;

		public Controller()
		{
			commands = new Dictionary<string, ICommand>();
		}

		public string ExecuteCommand(string commandLine, TcpClient client)
		{
			string[] arr = commandLine.Split(' ');
			string commandKey = arr[0];
			if (!commands.ContainsKey(commandKey))
				return "Command not found";
			ICommand command = commands[commandKey];
			return command.Execute(arr, client);
		}

		public void SetModel(IModel m)
		{
			this.model = m;
		}

		public void SetClientHandler(IClientHandler ch)
		{
			this.clientHandler = ch;
		}

		public void AddCommands() {
			commands.Add("generate", new GenerateMazeCommand(model));
			commands.Add("solve", new SolveMazeCommand(model));
			commands.Add("list", new ListGamesCommand(model));
			commands.Add("start", new StartGameCommand(model));
			commands.Add("join", new JoinGameCommand(model));
            commands.Add("play", new PlayGameCommand(model));
            commands.Add("close", new CloseGameCommand(model));
        }
    }
}