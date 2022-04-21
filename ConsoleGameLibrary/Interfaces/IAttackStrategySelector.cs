namespace ConsoleGameLibrary.Interfaces
{
    public interface IAttackStrategySelector
    {
        IAttackStrategy SelectAttackStrategy(int hitpoints);
    }
}