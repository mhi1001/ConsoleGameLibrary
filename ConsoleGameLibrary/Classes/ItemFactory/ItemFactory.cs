using System;
using ConsoleGameLibrary.Classes.Shields;
using ConsoleGameLibrary.Classes.TraceLogger;
using ConsoleGameLibrary.Classes.Weapons;


namespace ConsoleGameLibrary.Classes
{
    public class ItemFactory : IItemFactory
    {
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
