using System.Collections.Generic;
using ConsoleGameLibrary.Classes.CompositeDesignInventory;

namespace ConsoleGameLibrary
{
    public interface ICreature
    {
        int X { get; set; }
        int Y { get; set; }
        int HitPoints { get; set; }
        string Name { get; set; }
        List<AttackItem> AttackSlots { get; set; }
        List<DefenseItem> DefenseSlots { get; set; }
        MiscInventory MiscInventory { get; set; }
        bool IsDead { get; }

        /// <summary>
        /// Method that goes through your Attack weapons list, sums the damage of equipped weapons.
        /// </summary>
        /// <param name="enemy">The creature that will be getting hit</param>
        //Commented to implement the strategy pattern for Attacks
        //void Hit(Creature enemy);

        void Loot(WorldObject item);

        /// <summary>
        /// Receives the total damage from a hit and then calculates the amount of HitPoints you lose based of your defense items.
        /// </summary>
        /// <param name="damageTaken">The ammount of raw damage taken from a hit</param>
        void ReceiveHit(int damageTaken);

        public void Draw();
    }
}