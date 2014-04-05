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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var world = new World();

            //Определяем правила интерпретации символов.
            new WorldLoader()
                .AddRule('#', loc => new Wall(loc))
                .AddRule('F', loc => new Frog(loc))
                .AddRule('E', loc => new Food(loc))
                .AddRule('W', loc => new WhiteAnt(loc))
                .AddRule('B', loc => new BlackAnt(loc))

                .Load("maps\\map.txt", world);

            var mainForm = new AntForm(new Images(".\\images"), world);

            Application.Run(mainForm);
        }
    }
}
