using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject
{
    public class Data
    {
        public List<string> Players;
        public List<string> Maps;

        public Data()
        {
            var info = new DirectoryInfo(@"Players");
            var files = info.GetFiles();
            Players = new List<string>();
            foreach (var file in files)
                Players.Add(file.ToString());

            var mapsInfo = new DirectoryInfo(@"Maps");
            var maps = mapsInfo.GetFiles();
            Maps = new List<string>();
            foreach (var map in maps)
                Maps.Add(map.ToString());
        }
    }
}
