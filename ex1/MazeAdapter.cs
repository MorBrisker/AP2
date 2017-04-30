using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;

namespace ex1
{
	public class MazeAdapter : ISearchable<Position>
	{
		private Maze maze;
		private string Name;

		public MazeAdapter(Maze maze)
		{
			this.maze = maze;
		}
		public State<Position> GetInitialState()
		{
			State<Position> s = State<Position>.StatePool.GetObject(maze.InitialPos);
			return s;
		}
		public State<Position> GetGoalState()
		{
			State<Position> s = State<Position>.StatePool.GetObject(maze.GoalPos);
			return s;
		}
		public List<State<Position>> GetAllPossibleStates(State<Position> s)
		{
			List<State<Position>> list = new List<State<Position>>();
			Position p = s.GetStateType();
			if (p.Row + 1 < maze.Rows)
			{
				if (maze[p.Row + 1, p.Col] == CellType.Free)
				{
					//State<Position> s = State<Position>.StatePool.GetObject(maze.GoalPos);
					list.Add(State<Position>.StatePool.GetObject((new Position(p.Row + 1, p.Col))));

					//Position newP = new Position(p.Row + 1, p.Col);
					//list.Add(new State<Position>(newP));
				}
			}
			if (p.Col + 1 < maze.Cols)
			{
				if (maze[p.Row, p.Col + 1] == CellType.Free)
				{
					/*Position newP = new Position(p.Col, p.Row + 1);
                    list.Add(new State<Position>(newP));*/
					list.Add(State<Position>.StatePool.GetObject((new Position(p.Row, p.Col + 1))));

				}
			}
			if (p.Row != 0)
			{
				if (maze[p.Row - 1, p.Col] == CellType.Free)
				{
					/*Position newP = new Position(p.Row - 1, p.Col);
                    list.Add(new State<Position>(newP));*/
					list.Add(State<Position>.StatePool.GetObject((new Position(p.Row - 1, p.Col))));

				}
			}
			if (p.Col != 0)
			{
				if (maze[p.Row, p.Col - 1] == CellType.Free)
				{
					/*Position newP = new Position(p.Row, p.Col - 1);
                    list.Add(new State<Position>(newP));*/
					list.Add(State<Position>.StatePool.GetObject((new Position(p.Row, p.Col - 1))));

				}
			}
			return list;
		}
		public string GetName()
		{
			return this.Name;
		}
	}

}
