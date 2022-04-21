using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameLibrary.Interfaces;

namespace ConsoleGameLibrary.Classes.StrategyPattern
{
    /// <summary>
    /// Part of strategy design
    /// Class that selects which attack strategy to used. It uses player hitpoints to define if the attack will have full damage or partial damage
    /// </summary>
    public class AttackStrategySelector : IAttackStrategySelector
    {
        public IAttackStrategy SelectAttackStrategy(int hitpoints)
        {
            if (hitpoints < 50)
            {
                return new AttackDamageHurt();
            }

            return new AttackDamageFull();
        }
    }
}
