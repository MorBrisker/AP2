using System;
using System.Collections.Generic;
using System.Text;
using SearchAlgorithmsLib;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace Server
{
	public class MazeSolution
	{
		private String sol;
		private Solution<Position> path;
		private int numOfNodesEvaluated;
		private String mazeName;

		public MazeSolution(Solution<Position> path, string mazeName, int numOfNodesEvaluated)
		{
			this.path = path;
			this.numOfNodesEvaluated = numOfNodesEvaluated;
			this.mazeName = mazeName;
		}
		public void SolutionPath() {
			StringBuilder sb = new StringBuilder();
			Stack<State<Position>> stack = this.path.GetStack();
			Position before = stack.Pop().GetStateType();
			//Position after = this.stack.Pop().GetStateType();

			while (stack.Count != 0) {
				Position after = stack.Pop().GetStateType();
				if (before.Row + 1 == after.Row) {
					sb.Append("3");
				} else if (before.Row - 1 == after.Row) {
					sb.Append("2");
				} else if (before.Col + 1 == after.Col) {
					sb.Append("1");
				} else {
					sb.Append("0");
				}

				before = after;
			}

			this.sol = sb.ToString();
		}

		public string GetPath() {
			return this.sol;
		}

		public string ToJSON()
		{
			JObject mazeSolObj = new JObject();
			mazeSolObj["Name"] = this.mazeName;
			mazeSolObj["Solution"] = this.sol;
			mazeSolObj["NodesEvaluated"] = this.numOfNodesEvaluated;


			return mazeSolObj.ToString();
		}

        public string SolToString()
        {
            return this.sol;
        }
    }
}
