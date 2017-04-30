using System;
using System.Net.Sockets;
using MazeLib;
namespace Server
{
	public class Game
	{
        private string dani;
		private string name;
		private Maze maze;
		private bool isAvailable;
		private TcpClient home;
		private TcpClient away;

		public Game(string name, Maze maze)
		{
            this.dani = "123";
			this.Name = name;
			this.Maze = maze;
			this.IsAvailable = true;
        }

		public string Name { get => name; set => name = value; }
		public Maze Maze { get => maze; set => maze = value; }
		public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
        public TcpClient GetHome()
        {
            return this.home;
        }
        public void SetHome(TcpClient home)
        {
            this.home = home;
        }
        public TcpClient GetAway()
        {
            return this.away;
        }
        public void SetAway(TcpClient away)
        {
            this.away = away;
        }
    }
}
