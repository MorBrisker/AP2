using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MessageDetails
    {
        private TcpClient dest;
        private string message;
        public MessageDetails(TcpClient dest, string message)
        {
            this.dest = dest;
            this.message = message;
        }
        public TcpClient GetClient()
        {
            return this.dest;
        }
        public string GetMessage()
        {
            return this.message;
        }
    }
}
