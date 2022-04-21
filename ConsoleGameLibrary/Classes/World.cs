using System;
using System.Collections.Generic;

namespace ConsoleGameLibrary
{
    public class World
    {
        private string[,] Grid;
        public List<Creature> Creatures { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    Console.Write(element);
                }
            }
        }

        public bool IsWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }

            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
    }
}
