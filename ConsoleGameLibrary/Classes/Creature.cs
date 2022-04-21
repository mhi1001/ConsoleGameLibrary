using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ConsoleGameLibrary.Classes.CompositeDesignInventory;
using ConsoleGameLibrary.Classes.TraceLogger;
using ConsoleGameLibrary.Classes.Weapons;

namespace ConsoleGameLibrary
{
    /// <summary>
    /// Creature class is the base class for all the enemies/allies/players in the game.
    /// </summary>
    public class Creature : ICreature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int HitPoints { get; set; }
        public string Name { get; set; }
        public List<AttackItem> AttackSlots { get; set; }
        public List<DefenseItem> DefenseSlots { get; set; }
        public MiscInventory MiscInventory { get; set; }
        public string Marker { get; set; }



        /// <summary>
        /// Creates a new enemy, ally or player
        /// </summary>
        /// <param name="name">Name of the creature</param>
        /// <param name="maxHitPoints">Max health of the creature </param>
        /// <param name="x">X coordinate so you know where is located in the matrix</param>
        /// <param name="y">Y coordinate so you know where is located in the matrix</param>
        /// <param name="inventoryMaxSpace"> Integer that determines max amount of defense items and attack items you can carry</param>
        public Creature(string name, int maxHitPoints, int x, int y, int inventoryMaxSpace, string marker)
        {
            Name = name;
            HitPoints = maxHitPoints;
            //Where is the creature located at
            X = x;
            Y = y;
            //Initializes the Inventory and sets a limit of items
            AttackSlots = new List<AttackItem>(inventoryMaxSpace);
            DefenseSlots = new List<DefenseItem>(inventoryMaxSpace);
            MiscInventory = new MiscInventory();
            Marker = marker;

        }


        public bool IsDead { get; set; }

        /// <summary>
        /// Method that goes through your Attack weapons list, sums the damage of equipped weapons.
        /// </summary>
        /// <param name="enemy">The creature that will be getting hit</param>
        /// Commented for the strategy pattern attack
        //public void Hit(Creature enemy)
        //{
        //    Trace.ts.TraceInformation("Attacking.....");
        //    int rawDamage = AttackSlots.Where(w => w.IsEquipped).Sum(w => w.Damage);
        //    enemy.ReceiveHit(rawDamage);
        //}

        public void Loot(WorldObject item)
        {
            Trace.ts.TraceInformation("Looting....");

            if (item is AttackItem && item.Lootable)
            {
                AttackSlots.Add(item as AttackItem);
            }
            else if (item is DefenseItem && item.Lootable)
            {
                DefenseSlots.Add(item as DefenseItem);
            }
            else if (item.Lootable)
            {
                MiscInventory.AddItem(item);
            }
            else
            {
                throw new Exception("Looted invalid type/Looted a non-lootable object");
            }
            Trace.ts.Flush();
        }

        /// <summary>
        /// Receives the total damage from a hit and then calculates the amount of HitPoints you lose based of your defense items.
        /// </summary>
        /// <param name="damageTaken">The ammount of raw damage taken from a hit</param>
        public void ReceiveHit(int damageTaken)
        {
            Trace.ts.TraceInformation("Taking damage......");
            int dmgDefense = DefenseSlots.Sum(d => d.DamageDefense);
            if (dmgDefense > damageTaken) damageTaken = 0;
            HitPoints -= (damageTaken - dmgDefense);
            if (HitPoints <= 0)
            {
                IsDead = true;
                HitPoints = 0;
            }
            else
            {
                IsDead = false;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X, Y);
            Console.Write(Marker);
            Console.ResetColor();
        }

    }
}
