using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameLibrary
{
    public class WorldObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Lootable { get; set; }
        public bool Removable { get; set; }
        public string Name { get; set; }
    }
}
