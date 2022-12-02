using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;


namespace GameOfLive
{
	class Program
	{
		static void Main(string[] args)
		{
			[DllImport("kernel32.dll", SetLastError = true)]
			static extern IntPtr GetConsoleWindow();

			try
			{
				var gameState = Game.GetInitialState();
				var width = gameState.GetLength(0);
				var height = gameState.GetLength(1);
				using var gfx = Graphics.FromHwnd(GetConsoleWindow());
				var coefW = gfx.VisibleClipBounds.Width / width;
				var coefH = gfx.VisibleClipBounds.Height / height;
				using Pen pen = new(new SolidBrush(Color.Green));
				gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				while (true)
				{
					gfx.Clear(Color.Black);
					for (var i = 0; i < width; i++)
					{
						for (var j = 0; j < height; j++)
						{
							if (!gameState[i, j]) continue;
							
							var rectangle = new Rectangle(i * (int)coefW + 10, j * (int)coefH + 10, 9, 9);
							gfx.FillRectangle(Brushes.Green, rectangle);
						}
					}

					Thread.Sleep(1000);

					gameState = Game.GetNextState(gameState);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}