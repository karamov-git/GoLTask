using System;

namespace GameOfLive
{
	public static class Game
	{
		private static Random _random = new Random();

		public static bool[,] GetNextState(bool[,] currentState)
		{
			currentState[_random.Next(0, 100), _random.Next(0, 100)] = true;
			return currentState;
		}

		public static bool[,] GetInitialState()
		{
			var result = new bool[100, 100];
			result[50, 50] = result[51, 50] = result[52, 50] = true;
			return result;
		}
	}
}