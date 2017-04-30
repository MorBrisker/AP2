using System;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Configuration;

namespace Client
{
    class Client
    {
        public static void Main(string[] args)
        {
            TcpClient client = null;
            bool isConnect = false;
            string command = null;
            BinaryReader reader = null;
            BinaryWriter writer = null;
            int port = int.Parse(ConfigurationManager.AppSettings["PORT"]);
            IPAddress ip = IPAddress.Parse(ConfigurationManager.AppSettings["IP"]);
            //IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            IPEndPoint ep = new IPEndPoint(ip, port);
            command = Console.ReadLine();
            while (true)
            {
                if (!isConnect)
                {
                    client = new TcpClient();
                    client.Connect(ep);
                    isConnect = true;
                    Console.WriteLine("You are connected");
                    NetworkStream stream = client.GetStream();
                    reader = new BinaryReader(stream);
                    writer = new BinaryWriter(stream);
                    Task reciever = new Task(() =>
                    {
                        string result = "";
                        while (true)
                        {
                            if (result == null)
                            {
                                //dont need to close the tcp- allready close in the server side
                                stream.Close();
                                break;
                            }
                            result = reader.ReadString();
                            if (result.Contains("isClose"))
                            {
                                writer.Flush();
                                writer.Write("isClose");
                                writer.Flush();
                                client.Close();
                                isConnect = false;
                                break;
                            }
                            Console.WriteLine(result);
                            if ((command.Contains("generate")) || (command.Contains("solve")) ||
                            (command.Contains("list")) || (command.Contains("close")))
                            {
                                client.Close();
                                isConnect = false;
                                break;
                            }
                        }
                    }); reciever.Start();
                }
                writer.Flush();
                writer.Write(command);
                writer.Flush();
                command = Console.ReadLine();
            }
        }
    }
}