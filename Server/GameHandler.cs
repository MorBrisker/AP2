using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Server
{
	public class GameHandler : IClientHandler
	{
		private IController controller;

		public void HandleClient(TcpClient client)
		{
			new Task(() =>
			  {
				  using (NetworkStream stream = client.GetStream())
				  using (BinaryReader reader = new BinaryReader(stream))
				  using (BinaryWriter writer = new BinaryWriter(stream))
				  {
					  string commandLine = reader.ReadString();
					  Console.WriteLine("Got command: {0}", commandLine);
					  string result = controller.ExecuteCommand(commandLine, client);
					  writer.Write(result);
				  }
				  client.Close();
			  }).Start();
		}

		public GameHandler(IController c) 
		{
			this.controller = c;
		}
	}
}
