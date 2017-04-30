using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;

namespace Server
{

    public class Model : IModel
	{
		private IController controller;
		private Dictionary<String, Maze> mazeCache;
		private Dictionary<String, MazeSolution> mazeSolutionCache;
		private List<Game> games;
		//private List<string> games;
		//private delegate Solution<T> Search(ISearchable<T> searchable);

		public Model(IController c)
		{
			this.controller = c;
			this.mazeCache = new Dictionary<string, Maze>();
			this.mazeSolutionCache = new Dictionary<string, MazeSolution>();
			this.games = new List<Game>();
		}

		public Maze GenerateMaze(string name, int rows, int cols)
		{
			IMazeGenerator mg = new DFSMazeGenerator();
			Maze m = mg.Generate(rows, cols);
			m.Name = name;
			if (this.mazeCache.ContainsKey(name))
			{
				return null;
			}
			this.mazeCache.Add(m.Name, m);
			return m;
		}

		public MazeSolution SolveMaze(string name, int alg)
		{
			Solution<Position> sol;
			int nodesEvaluated;

			if (this.mazeSolutionCache.ContainsKey(name))
			{
				return this.mazeSolutionCache[name];
			}

			if (this.mazeCache.ContainsKey(name))
			{
				Maze m = this.mazeCache[name];
				if (alg == 0)
				{
					BFS<Position> bfs = new BFS<Position>();
					ISearchable<Position> newMaze = new MazeAdapter(m);
					sol = bfs.Search(newMaze);
					nodesEvaluated = bfs.GetNumOfNodesEvaluated();
				}
				else
				{
					DFS<Position> dfs = new DFS<Position>();
					ISearchable<Position> newMaze = new MazeAdapter(m);
					sol = dfs.Search(newMaze);
					nodesEvaluated = dfs.GetNumOfNodesEvaluated();
				}
				MazeSolution ms = new MazeSolution(sol, name, nodesEvaluated);
				ms.SolutionPath();
				this.mazeSolutionCache.Add(name, ms);
				return ms;
			}
			else
			{
				return null;
			}
		}

		public Maze StartGame(string name, int rows, int cols, TcpClient client) {
			IMazeGenerator mg = new DFSMazeGenerator();
			Maze m = mg.Generate(rows, cols);
			m.Name = name;
			Game g = new Game(name, m);
            g.SetHome(client);
			this.games.Add(g);
			while (g.IsAvailable) {}
			return m;
		}
		public Maze JoinGame(string name, TcpClient client) {
			Game game = null;
			foreach (Game g in this.games) {
				if (g.Name == name) {
					game = g;
				}
			}
			game.IsAvailable = false;
            game.SetAway(client);
			return game.Maze;
		}
		public string ListGames()
		{
			JArray gameList = new JArray();
			foreach (Game g in this.games) {
				if (g.IsAvailable) {
					gameList.Add(g.Name);
				}
			}
			return gameList.ToString();
		}
       
        public Game GetGame(TcpClient client)
        {
            foreach (Game g in this.games)
            {
                if (g.GetHome().Equals(client) || g.GetAway().Equals(client))
                {
                    return g;
                }
            }
            return null;
        }

        /*public Game PlayGame(TcpClient client)
        {
            TcpClient away=null;
            string name=null;
            foreach (Game g in this.games)
            {
                if (g.GetHome().Equals(client) || g.GetAway().Equals(client))
                {
                    return g;
                }
            }
            return null;
            JObject playObj = new JObject();
            playObj["Name"] = name;
            playObj["Direction"] = direction;
            MessageDetails det = new MessageDetails(away, playObj.ToString());
            return away;
        }*/

        public string CloseGame(string name)
        {
            TcpClient away;
            foreach (Game g in this.games)
            {
                if (g.Name.Equals(name))
                {
                    // TODO: send empty message to away
                    away = g.GetAway();
                    //away.
                }
            }
            return null;
        }
    }
}