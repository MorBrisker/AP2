using System;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using Server;

namespace TRY
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			IController c = new Controller();
			IModel m = new Model(c);
			c.SetModel(m);
			c.AddCommands();

			IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
			TcpListener listener = new TcpListener(ep);
			listener.Start();
			Console.WriteLine("Waiting for client connections...");
			TcpClient client = listener.AcceptTcpClient();
			Console.WriteLine("Client connected");
			using (NetworkStream stream = client.GetStream())
			using (BinaryReader reader = new BinaryReader(stream))
			using (BinaryWriter writer = new BinaryWriter(stream))
			{
				while (true) {
					//Console.WriteLine("Waiting for a number");
					string command = reader.ReadString();
					//string command2 = "generate maze 5 5";
					string result = c.ExecuteCommand(command, client);
					//Console.WriteLine(command);
					writer.Write(result);
				}

			}

			client.Close();
			listener.Stop();

		}
	}
}
