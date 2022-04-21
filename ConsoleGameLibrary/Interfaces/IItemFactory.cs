namespace ConsoleGameLibrary.Classes
{
    /// <summary>
    /// Part of the Factory Pattern
    /// </summary>
    public interface IItemFactory
    {
        IWeapon CreateWeapon(string weapon);
        IDefense CreateShield(string shield);
    }
}