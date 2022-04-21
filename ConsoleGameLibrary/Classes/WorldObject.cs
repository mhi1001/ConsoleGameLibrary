using ConsoleGameLibrary.CompositeDesignInventory;

namespace ConsoleGameLibrary
{
    public class WorldObject : IMiscInventory
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Lootable { get; set; }
        public bool Removable { get; set; }
        public string Name { get; set; }
    }
}
