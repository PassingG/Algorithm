using System;
using System.Numerics;
using System.Collections.Generic;

namespace 미로탈출
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
        int[,] maze;

        int N,M;

        public void Init()
        {
            // Input N, M
            string inputLine = System.Console.ReadLine();

            string[] split = inputLine.Split(" ");

            if (split.Length != 2)
            {
                Console.WriteLine("Wrong input");
                return;
            }

            N = Int32.Parse(split[0]);
            M = Int32.Parse(split[1]);

            maze = new int[N, M];

            // Input maze
            for (int x = 0; x < N; x++)
            {
                inputLine = System.Console.ReadLine();

                char[] splitArray = inputLine.ToCharArray();

                if (splitArray.Length != M)
                {
                    Console.WriteLine($"Wrong input {splitArray.Length} {M}");
                    return;
                }

                for (int y = 0; y < M; y++)
                {
                    maze[x, y] = (int)Char.GetNumericValue(splitArray[y]); ;
                }
            }
        }

        public void Calculate()
        {
            BFS(0,0);
        }

        public void BFS(int x, int y)
        {
            Vector2Int[] dir = new Vector2Int[]
            {
                // Up
                new Vector2Int(1, 0),
                // Down
                new Vector2Int(-1, 0),
                // Left
                new Vector2Int(0, -1),
                // Right
                new Vector2Int(0, 1),
            };

            Queue<Vector2Int> queue = new Queue<Vector2Int>();

            queue.Enqueue(new Vector2Int(x,y));

            while(queue.Count != 0)
            {
                Vector2Int pos = queue.Dequeue();

                for(int i=0;i<dir.Length;i++)
                {
                    Vector2Int movePos = new Vector2Int(pos.x + dir[i].x, pos.y + dir[i].y);

                    if(movePos.x < 0 || movePos.x >= N || movePos.y < 0 || movePos.y >= M || maze[movePos.x, movePos.y] != 1)
                    {
                        continue;
                    }

                    maze[movePos.x, movePos.y] = maze[pos.x, pos.y] + 1;

                    queue.Enqueue(movePos);
                }
            }
        }

        public void Log()
        {
            Console.WriteLine($"Result : {maze[N-1,M-1]}");
        }
    }

    public struct Vector2Int
    {
        public int x;
        public int y;

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
