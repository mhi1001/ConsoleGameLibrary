namespace ConsoleGameLibrary
{
    public abstract class AttackItem : WorldObject, IWeapon
    {
        public abstract int Damage { get; }
        public abstract int Range { get; }
        public bool IsEquipped { get; set;  }
    }
}
