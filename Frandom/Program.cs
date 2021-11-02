using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frandom
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            uint[] weights = new uint[] { 19365, 61200, 11944, 20000 };
            uint wSum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                wSum += weights[i];
            }

            Console.WriteLine("預期機率為");
            for (int i = 0; i < weights.Length; i++)
            {
                Console.Write($"{weights[i] * 1.0 / wSum,6:P2},");
            }
            Console.WriteLine();
            Test(weights, wSum, AlgorithmType.Default);
            Test(weights, wSum, AlgorithmType.CMWC);
            Test(weights, wSum, AlgorithmType.BlumMicali);
            Console.ReadLine();
        }

        private static void Test(uint[] weights, uint wSum, AlgorithmType al)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            RNG rng = new RNG(al);
            decimal[] counts = new decimal[weights.Length];

            int loop = 10000;
            for (int l = 0; l < loop; l++)
            {
                uint v = rng.Next(wSum - 1);
                for (int j = 0; j < weights.Length; j++)
                {
                    if (v < weights[j])
                    {
                        counts[j]++;
                        break;
                    }
                    v -= weights[j];
                }
            }
            Console.WriteLine($"使用 {rng.Name()} 演算法獲得的機率分布為");
            for (int i = 0; i < weights.Length; i++)
            {
                Console.Write($"{counts[i] / loop,6:P2},");
            }
            sw.Stop();
            Console.WriteLine($"耗時{sw.ElapsedMilliseconds}ms");
        }
    }
}