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

        /// <summary>
        /// set grid to xSize and ySize and all False
        /// </summary>
        /// <param name="grid">bool[,]</param>
        /// <param name="xSize">integer that is 20 by default</param>
        /// <param name="ySize">integer that is 20 by default</param>
        static void init(out bool[,] grid, int xSize = 20, int ySize = 20)
        {
            bool[,] result = new bool[ySize, xSize];
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    result[i, j] = false;
                }
            }
            grid = result;
        }
        static bool[,] GetRandomGrid(int xSize = 20, int ySize = 20, int lifeCount = 100)
        {
            bool[,] result = new bool[ySize, xSize];
            init(out result, xSize, ySize);
            Random rnd = new Random();
            int x = 0;
            int y = 0;
            for(int i = 0; i < lifeCount;i++)
            {
                x = rnd.Next(xSize);
                y = rnd.Next(ySize);
                result[y,x]= true;
            }
            //Console.WriteLine("RandomExit");
            return result;
        }
        static void DrawGrid(bool[,] grid, int xSize, int ySize)
        {
           // Console.WriteLine("xsize:" + xSize);
           // Console.WriteLine("gridx" + grid);
            for (int i = 0; i < ySize; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < xSize; j++)
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
        static bool IsValid(int xchecker, int ychecker, int xLimit = 20, int yLimit = 20)
        {
            bool valid = false;
            // how do we check if it's valid???
            if (xchecker >= 0 && xchecker < xLimit && ychecker >= 0 && ychecker < yLimit)
            {
                valid = true;
            }
            return valid;
        }
        static bool[,] EvaluateGrid(bool[,] grid, int xSize = 20, int ySize =20)
        {

            bool[,] result = new bool[ySize, xSize];
            int LiveNeighbors = 0;
            // Console.Write("\nHere's the life count");
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    LiveNeighbors = 0;
                    if (IsValid(x - 1, y - 1, xSize, ySize) && grid[y - 1, x - 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x-1, y, xSize, ySize) && grid[y, x - 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x - 1, y +1, xSize, ySize) && grid[y + 1, x - 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x , y- 1, xSize, ySize) && grid[y - 1, x] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x , y+ 1, xSize, ySize) && grid[y + 1, x] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x + 1, y - 1,xSize, ySize) && grid[y - 1, x + 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x+ 1, y ,xSize, ySize) && grid[y, x + 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    if (IsValid(x + 1, y + 1,xSize,ySize) && grid[y + 1, x + 1] == true)
                    {
                        LiveNeighbors++;
                    }
                    //Console.Write(LiveNeighbors);

                    if (LiveNeighbors > 2 || LiveNeighbors < 3)
                    {
                        result[y, x] = false;
                    }
                    if (LiveNeighbors == 3)
                    { result[y, x] = true; }
                    if (grid[y, x] == true)
                    {
                        if (LiveNeighbors == 2)
                        {
                            result[y, x] = true;
                        }
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
           // Console.SetWindowSize(200, 150);
            int xSize = 150;
            int ySize = 35;
            int sleep = (1000 / 60) * 2;
            bool [,] grid = GetRandomGrid(xSize,ySize, 2960);
            DrawGrid(grid, xSize, ySize);
            Console.ReadLine();
            for (int i = 0; i < 5000; i++)
            {
                Console.Clear();
                grid = EvaluateGrid(grid,xSize,ySize);
                DrawGrid(grid,xSize,ySize);
                System.Threading.Thread.Sleep(sleep);
            }
            Console.ReadLine();
        }
    }
}