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
    class CloseGameCommand : ICommand
    {
        private IModel model;
        public CloseGameCommand(IModel model)
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
            JObject playObj = new JObject();
            playObj["isClose"] = true;
            NetworkStream stream = dest.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Flush();
            writer.Write(playObj.ToString());
            writer.Flush();
            return playObj.ToString();
        }

    }
}
