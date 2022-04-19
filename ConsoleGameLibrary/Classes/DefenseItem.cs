namespace ConsoleGameLibrary
{
    public abstract class DefenseItem : WorldObject, IDefense
    {
        public abstract int DamageDefense { get; }
    }
}
