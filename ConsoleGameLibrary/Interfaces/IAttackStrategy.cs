namespace ConsoleGameLibrary.Interfaces
{
    /// <summary>
    /// Part of the strategy pattern
    /// </summary>
    public interface IAttackStrategy
    {
        void Hit(ICreature creature, ICreature player);
    }
}