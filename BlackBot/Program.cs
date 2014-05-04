using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AntsBattle;

namespace BlackBot
{
    class Program
    {
        public static IAntAI BlackAntAI;
        static void Main(string[] args)
        {
            var path = args[0];
            BlackAntAI = (IAntAI)Activator.CreateInstance(Assembly.UnsafeLoadFrom(path)
                        .GetTypes()
                        .First(type => type.GetInterfaces().Any(i => i == typeof(IAntAI))));
           // var world = new World();
            while (true)
            {
                var location = Console.ReadLine();
                //var a = BlackAntAI.GetDirection(new Point(1,1), )
            }
        }
    }
}
