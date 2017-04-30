using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Server
{
	public interface IController
	{
		void SetModel(IModel m);
		void SetClientHandler(IClientHandler ch);
		string ExecuteCommand(string commandLine, TcpClient client);
		void AddCommands();
	}
}
