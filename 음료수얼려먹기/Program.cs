using System;

namespace 음료수얼려먹기
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve solve = new Solve();

            solve.Init();
            solve.Calculate();
            solve.Log();
        }
    }

    public class Solve
    {
        int width = 0;
        int height = 0;

        int[,] iceTray;
        int howManyIcecream = 0;

        public void Init()
        {
            // Input Height, Width
            string inputLine = System.Console.ReadLine();

            string[] split = inputLine.Split(" ");

            if (split.Length != 2)
            {
                Console.WriteLine("Wrong input");
                return;
            }

            height = Int32.Parse(split[0]);
            width = Int32.Parse(split[1]);

            iceTray = new int[height, width];

            // Input icetray
            for (int x = 0; x < height; x++)
            {
                inputLine = System.Console.ReadLine();

                char[] splitArray = inputLine.ToCharArray();

                if (splitArray.Length != width)
                {
                    Console.WriteLine($"Wrong input {splitArray.Length} {width}");
                    return;
                }

                for (int y = 0; y < width; y++)
                {
                    iceTray[x, y] = (int)Char.GetNumericValue(splitArray[y]); ;
                }
            }
        }

        public void Calculate()
        {
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (DFS(x, y))
                    {
                        howManyIcecream++;
                    }
                }
            }
        }

        public bool DFS(int x, int y)
        {
            if(x < 0 || x >= height || y < 0 || y >= width)
            {
                return false;
            }

            if(iceTray[x,y] == 0)
            {
                iceTray[x, y] = 1;

                DFS(x + 1, y);
                DFS(x - 1, y);
                DFS(x, y + 1);
                DFS(x, y - 1);
                return true;
            }
            return false;
        }

        public void Log()
        {
            Console.WriteLine($"Result : {howManyIcecream}");
        }
    }
}
