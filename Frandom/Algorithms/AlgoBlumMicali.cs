using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Frandom.Algorithms
{
    /// <summary>
    /// ref https://www.codeproject.com/Tips/820896/The-Blum-Micali-Algorithm-and-Cryptographically-Se
    /// </summary>
    internal class AlgoBlumMicali : Algorithm
    {
        private BigInteger prime;// should be a large prime number
        private BigInteger root; //primitive root modulo prime
        private BigInteger seed;

        internal AlgoBlumMicali()
        {
            prime = BigInteger.Parse("2305843009213693951"); //Mersenne prime M9 = 2^61-1
            root = BigInteger.Parse("37"); // ref https://oeis.org/A096393
            seed = BigInteger.Zero;
            BigInteger tp = BigInteger.One;
            AlgoCSP csp = new AlgoCSP();
            for (int i = 0; i < 61; i++)
            {
                if (csp.Next(1) == 1) seed += tp;
                tp *= 2;
            }
        }

        public override string Name => "Blum Micali";

        public override uint Next()
        {
            uint value = 0;
            uint tp = 1;
            for (uint i = 0; i < 32; i++)
            {
                BigInteger nextSeed = BigInteger.ModPow(root, seed, prime);
                if (nextSeed < ((prime - 1) / 2)) value += tp;
                seed = nextSeed;
                tp *= 2;
            }
            return value;
        }

        private BigInteger ModPow(BigInteger v, BigInteger e, BigInteger m)
        {
            BigInteger res = BigInteger.One;

            v %= m;

            while (e > 0)
            {
                if (e % 2 == 1)
                {
                    res = (res * v) % m;
                }

                e /= 2;
                v = (v * v) % m;
            }
            return res;
        }
    }
}