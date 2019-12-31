using System;

namespace Manger
{
    class Program
    {
        static void Main(string[] args)
        {
            int j, i, k;
            for (j = 0; j <= 20; j++)
            {
                for (i = 0; i <= 33; i++)
                {
                    for (k = 0; k <= 100; k++)
                    {
                        if ((j + i + k == 100) && (j * 5 + i * 3 + k / 3 == 100) && k % 3 == 0)
                        {
                            Console.WriteLine("{0},{1},{2}", j, i, k);
                            Console.ReadLine();
                        }
                    }
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
