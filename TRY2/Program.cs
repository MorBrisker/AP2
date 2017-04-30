using System;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace TRY2
{
	class MainClassTwo
	{
		public static void Main(string[] args)
		{
			IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
			TcpClient client = new TcpClient();
			client.Connect(ep);
			Console.WriteLine("You are connected");
			using (NetworkStream stream = client.GetStream())
			using (BinaryReader reader = new BinaryReader(stream))
			using (BinaryWriter writer = new BinaryWriter(stream))
			{
				// Send data to server
				Console.Write("Please enter a number: ");
				int num = int.Parse(Console.ReadLine());
				writer.Write(num);
				// Get result from server
				int result = reader.ReadInt32();
				Console.WriteLine("Result = {0}", result);
			}
			client.Close();
		}
	}
}
