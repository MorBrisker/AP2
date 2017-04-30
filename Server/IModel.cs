using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using System.Net.Sockets;

namespace Server
{
    public interface IModel
	{
		Maze GenerateMaze(string name, int rows, int cols);
		MazeSolution SolveMaze(string name, int alg);
		string ListGames();
		Maze StartGame(string name, int rows, int cols, TcpClient client);
		Maze JoinGame(string name, TcpClient client);
        Game GetGame(TcpClient client);
        string CloseGame(string name);
	}
}
