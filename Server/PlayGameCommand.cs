using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class PlayGameCommand : ICommand
    {
        private IModel model;
        private IClientHandler i;

        public PlayGameCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client)
        {
            Game game = model.GetGame(client);
            TcpClient dest;
            if (game.GetHome().Equals(client))
            {
                dest = game.GetAway();
            }
            else
            {
                dest = game.GetHome();
            }
            string name = game.Maze.Name;
            JObject playObj = new JObject();
            playObj["Name"] = name;
            playObj["Direction"] = args[1];
            NetworkStream stream = dest.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Flush();
            writer.Write(playObj.ToString());
            writer.Flush();
            return playObj.ToString();
        }
    }
}
