using ConsoleGameLibrary.CompositeDesignInventory;

namespace ConsoleGameLibrary
{
    public abstract class DefenseItem : WorldObject, IDefense, IMiscInventory
    {
        public abstract int DamageDefense { get; }
    }
}
