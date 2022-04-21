using System;
using ConsoleGameLibrary.Classes.Shields;
using ConsoleGameLibrary.Classes.TraceLogger;
using ConsoleGameLibrary.Classes.Weapons;


namespace ConsoleGameLibrary.Classes
{
    /// <summary>
    /// Class that creates new weapons or new defensive shields
    /// </summary>
    public class ItemFactory : IItemFactory
    {
        /// <summary>
        /// Takes in a string a returns a new weapon based of the string
        /// </summary>
        /// <param name="weapon">String that identifies which type of weapon you want</param>
        /// <returns></returns>
        public IWeapon CreateWeapon(string weapon)
        {
            Trace.ts.TraceInformation("Creating new Weapon");
            switch (weapon.ToLower())
            {
                case "greatsword":
                    return new Greatsword();
                case "sword":
                    return new Sword();
                case "bow":
                    return new Bow();
                case "dagger":
                    return new Dagger();
                default:
                    throw new ArgumentException("Invalid weapon name");
            }
        }
        /// <summary>
        /// Takes in a string a returns a new shield based of the string
        /// </summary>
        /// <param name="shield">String that identifies which type of shield you want</param>
        /// <returns></returns>
        public IDefense CreateShield(string shield)
        {
            Trace.ts.TraceInformation("Creating new Shield");
            switch (shield.ToLower())
            {
                case "small":
                    return new SmallShield();
                case "buckler":
                    return new BucklerShield();
                case "great":
                    return new GreatShield();
                default:
                    throw new ArgumentException("Invalid shield name");
            }
            
        }
        
    }

    
}
