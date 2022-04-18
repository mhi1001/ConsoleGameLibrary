using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameLibrary
{
    public class AttackItem : WorldObject
    {
        public int Damage { get; set; }
        public int Range { get; set; }
        public bool IsEquipped { get; set; }
    }
}
