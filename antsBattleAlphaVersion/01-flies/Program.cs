using System;
using System.Windows.Forms;
using mazes;

namespace Ants
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var world = new World();
			
			//Определяем правила интерпретации символов.
			new WorldLoader()
				.AddRule('#', loc => new Wall(loc))
				.AddRule('S', loc => new Source(loc))
                .AddRule('F', loc => new Frog(loc))
                .AddRule('E', loc => new Food(loc))
                .AddRule('A', loc => new Ant1(loc))
                .AddRule('a', loc => new Ant2(loc))
                .Load("mazes\\maze.txt", world);

			var mainForm = new MazeForm(new Images(".\\images"), world);
			
			Application.Run(mainForm);
		}
	}
}
