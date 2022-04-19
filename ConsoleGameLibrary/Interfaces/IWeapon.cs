namespace ConsoleGameLibrary
{
    public interface IWeapon
    {
        int Damage { get; }
        int Range { get; }
        bool IsEquipped { get; set; }
        int X { get; set; }
        int Y { get; set; }
        bool Lootable { get; set; }
        bool Removable { get; set; }
        string Name { get; set; }
    }
}