using System;

namespace 삽입정렬
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve solve = new Solve();

            solve.Log();
            solve.Calculate();
            solve.Log();
        }
    }

    public class Solve
    {
        int n = 10;
        int[] target = new int[10]{7,5,9,0,3,1,6,2,4,8};


        public void Calculate()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if(target[j] < target[j-1])
                    {
                        Swap(j, j-1);
                    }
                }
            }
        }

        public void Swap(int swapTargetIndexA, int swapTargetIndexB)
        {
            int tmp = target[swapTargetIndexA];
            target[swapTargetIndexA] = target[swapTargetIndexB];
            target[swapTargetIndexB] = tmp;
        }

        public void Log()
        {
            for(int i=0;i<n;i++)
            {
                Console.Write($"{target[i]}");
            }
            Console.WriteLine("");
        }
    }
}
