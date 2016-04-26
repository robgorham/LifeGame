using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication13
{
    class GamOfLife
    {
        static bool[,] GetGrid()
        {
            bool[,] grid = new bool[20, 20];
            System.IO.StreamReader file = new System.IO.StreamReader("./readme.txt");
            string line;
            int m = 0;
            while ((line = file.ReadLine()) != null)
            {
                char[] characters = line.ToCharArray();
                for (int n = 0; n < 20; n++)
                {
                    if (characters[n] == '1')
                    {
                        grid[m, n] = true;
                    }
                    else
                    {
                        grid[m, n] = false;
                    }
                }
                m++;
            }
            return grid;
        }
        static void DrawGrid(bool[,] grid)
        {
            
            for (int i = 0; i < 20; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < 20; j++)
                {
                    if (grid[i, j] == true)
                    {
                        Console.Write((char)219);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
        }
        static bool IsValid(int xchecker, int ychecker)
        {
            bool valid = false;
            // how do we check if it's valid???
            if (xchecker >= 0 && xchecker < 20 && ychecker >= 0 && ychecker < 20)
            {
                valid = true;
            }
            return valid;
        }
        static bool[,] EvaluateGrid(bool[,] grid)
        {
            bool[,] result = new bool[20, 20];
            int LiveNeighbors = 0;
            // Console.Write("\nHere's the life count");
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    LiveNeighbors = 0;
                    if (IsValid(x - 1, y - 1) && grid[x - 1, y - 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x, y - 1) && grid[x, y - 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x + 1, y - 1) && grid[x + 1, y - 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x - 1, y) && grid[x - 1, y] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x + 1, y) && grid[x + 1, y] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x - 1, y + 1) && grid[x - 1, y + 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x, y + 1) && grid[x, y + 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x + 1, y + 1) && grid[x + 1, y + 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    //Console.Write(LiveNeighbors);

                    if (LiveNeighbors > 2 || LiveNeighbors < 3)
                    {
                        result[x, y] = false;
                    }
                    if (LiveNeighbors == 3)
                    { result[x, y] = true; }
                    if (grid[x, y] == true)
                    {
                        if (LiveNeighbors == 2)
                        {
                            result[x, y] = true;
                        }
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.Unicode;
            bool[,] grid = new bool[20, 20];
            grid = GetGrid();
            DrawGrid(grid);
            Console.ReadLine();
            for (int i = 0; i < 500; i++)
            {   Console.Clear();
                grid = EvaluateGrid(grid);
                DrawGrid(grid);
                System.Threading.Thread.Sleep(75);                
            }
            Console.ReadLine();
        }
    }
}