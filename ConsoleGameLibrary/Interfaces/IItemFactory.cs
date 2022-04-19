namespace ConsoleGameLibrary.Classes
{
    public interface IItemFactory
    {
        IWeapon CreateWeapon(string weapon);
        IDefense CreateShield(string shield);
    }
}