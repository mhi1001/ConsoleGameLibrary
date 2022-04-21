using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameLibrary.Classes.TraceLogger;
using ConsoleGameLibrary.Interfaces;

namespace ConsoleGameLibrary.Classes.StrategyPattern
{
    /// <summary>
    /// Strategy Pattern, it will deal partial damage if the player is below 50 hp
    /// </summary>
    class AttackDamageHurt : IAttackStrategy
    {
        /// <summary>
        /// Attack method that partial damage based of the equipped weapons.
        /// </summary>
        /// <param name="enemy">Enemy that you will be hitting</param>
        /// <param name="player">Player that will be doing the hitting</param>
        public void Hit(ICreature enemy, ICreature player)
        {
            Trace.ts.TraceInformation("Attacking.....");
            int rawDamage = player.AttackSlots.Where(w => w.IsEquipped).Sum(w => w.Damage);
            rawDamage = rawDamage * (100 - 35) / 100;
            enemy.ReceiveHit(rawDamage);
        }
    }
}
