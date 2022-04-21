using System;
using ConsoleGameLibrary;
using ConsoleGameLibrary.Classes;
using System.Threading;
using System.Threading.Tasks;
using ConsoleGameLibrary.Classes.StrategyPattern;
using ConsoleGameLibrary.GUI;
using ConsoleGameLibrary.Interfaces;

namespace GameTest
{
    public class Game
    {


        public void Run()
        {
            //Create weapons and defensive items
            //Factory Pattern
            IItemFactory factory = new ItemFactory();
            IAttackStrategySelector attackStrategySelector = new AttackStrategySelector();


            Console.WriteLine("Sword has been created");
            IWeapon sword = factory.CreateWeapon("sword");
            sword.Lootable = true;

            Console.WriteLine("Shield has been created");
            IDefense shield = factory.CreateShield("great");
            shield.Lootable = true;

            Thread.Sleep(500);
            Console.WriteLine("Hero has been created");
            ICreature Hero = new Creature("Hero", 100, 0, 0, 5, "T");

            ICreature Enemy = new Creature("Enemy", 100, 0, 0, 5, "T");

            Thread.Sleep(500);
            Console.WriteLine("Hero looted a sword and a shield");

            Hero.Loot(sword as WorldObject);
            Hero.Loot(shield as WorldObject);

            Thread.Sleep(500);
            Console.WriteLine($"Hero equipped the sword {sword.Name}, that does {sword.Damage} damage");
            sword.IsEquipped = true;
            Thread.Sleep(500);
            Console.WriteLine(
                $"Hero now has a shield called {shield.Name}, that does {shield.DamageDefense} damage defense");

            Thread.Sleep(1000);
            Console.WriteLine("Your hero has encountered a enemy they will begin fighting");

            // while (!Hero.IsDead)
            // {
            //hero has 100 hitpoints and the enemy has 100 hitpoints
            Console.WriteLine(
                $"hero has {Hero.HitPoints} and enemy has {Enemy.HitPoints} and after hero attacks \n #################################### ");
            attackStrategySelector.SelectAttackStrategy(Hero.HitPoints).Hit(Enemy, Hero);
            Console.WriteLine($"hero has {Hero.HitPoints} and enemy has {Enemy.HitPoints}");
            // }

            Console.WriteLine(
                "Now hero has under 50 hp and the enemy will go back to 100, so we will see the strategy patern changing the damage output\n ####################################\n ####################################");
            Hero.HitPoints = 30;
            Enemy.HitPoints = 100;
            Console.WriteLine(
                $"hero has {Hero.HitPoints} and enemy has {Enemy.HitPoints} and after hero attacks \n #################################### ");
            attackStrategySelector.SelectAttackStrategy(Hero.HitPoints).Hit(Enemy, Hero);
            Console.WriteLine($"hero has {Hero.HitPoints} and enemy has {Enemy.HitPoints}");

            Console.WriteLine("##############" +
                              "##############");

            WorldObject rock = new WorldObject();
            rock.Name = "Rock";
            rock.Lootable = true;
            
            Hero.Loot(rock);
            Console.WriteLine("Hero has the following misc items:");
            foreach (var item in Hero.MiscInventory)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            Console.ReadKey();
        }


        //////////////////////////////////////////////
        ////////////////////////////////EXPERIMENTAL also need to refactor and fit it inside the framework
        private World _myWorld;
        private World _mySecondWorld;
        private ICreature player;

        public void Start()
        {
            string[,] grid =
                LevelParser.ParseFileTo2DArray(@"C:\Users\pc\source\repos\ConsoleGameLibrary\ConsoleGameLibrary\GUI\level1.txt");
            string[,] grid2 =
                LevelParser.ParseFileTo2DArray(@"C:\Users\pc\source\repos\ConsoleGameLibrary\ConsoleGameLibrary\GUI\level2.txt");
            _myWorld = new World(grid);
            player = new Creature("player", 100, 2,2, 5, "@");
            _mySecondWorld = new World(grid2);

            GameLoop();
        }

        private void GameLoop()
        {

            while (true)
            {
                Frame();
                HandleInput();

            }
        }

        public void Frame()
        {
            _myWorld.Draw();
           // _mySecondWorld.Draw();
            player.Draw();
        }

        private void HandleInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.W:
                    if (_myWorld.IsWalkable(player.X, player.Y - 1))
                    {
                        player.Y -= 1;

                    }

                    break;

                case ConsoleKey.A:
                    if (_myWorld.IsWalkable(player.X - 1, player.Y))
                    {
                        player.X -= 1;

                    }

                    break;

                case ConsoleKey.S:
                    if (_myWorld.IsWalkable(player.X, player.Y + 1))
                    {
                        player.Y += 1;
                    }

                    break;

                case ConsoleKey.D:
                    if (_myWorld.IsWalkable(player.X + 1, player.Y)) player.X += 1;
                    break;
            }


        }

        public class Program
        {
            static void Main(string[] args)
            {
                Game game = new Game();

                //Assignemnt
                game.Run();

                //2D
                //game.Start();
            }
        }
    }
}
