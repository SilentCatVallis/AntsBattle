using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntsBattle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var data = new StartWindowData();
            Application.Run(new StartWindow(data));

            
            //var world = new World(args);

            ////Определяем правила интерпретации символов.
            //new WorldLoader()
            //    .AddRule('#', loc => new Wall(loc))
            //    .AddRule('F', loc => new Frog(loc))
            //    .AddRule('E', loc => new Food(loc))
            //    .AddRule('W', loc => new WhiteAnt(loc))
            //    .AddRule('B', loc => new BlackAnt(loc))
            //    .Load("Maps\\" + args[5], world);

            //var mainForm = new AntForm(new Images(".\\images"), world);
            //var resultForm = new ResultsForm(world);

            //Application.Run(mainForm);
            //Application.Run(resultForm);
        }
    }
}
