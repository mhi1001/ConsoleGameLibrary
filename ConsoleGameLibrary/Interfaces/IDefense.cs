namespace ConsoleGameLibrary
{
    public interface IDefense
    {
        int DamageDefense { get; }
        int X { get; set; }
        int Y { get; set; }
        bool Lootable { get; set; }
        bool Removable { get; set; }
        string Name { get; set; }
    }
}