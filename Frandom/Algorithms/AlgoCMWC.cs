using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frandom.Algorithms
{
    internal class AlgoCMWC : Algorithm
    {
        private const uint Cycle = 4096; // as Marsaglia recommends
        private const uint C_MAX = 809430660;    // as Marsaglia recommends

        private uint[] Q = new uint[Cycle];
        private uint c; // must be limited with CMWC_C_MAX
        private uint qIndex;

        internal AlgoCMWC()
        {
            var csp = new AlgoCSP();
            c = csp.Next(C_MAX);
            for (int i = 0; i < Q.Length; i++)
            {
                Q[i] = csp.Next();
            }
            qIndex = Cycle - 1;
        }

        public override string Name => "CMWC";

        public override uint Next()
        {
            ulong a = 18782;   // as Marsaglia recommends
            uint m = 0xfffffffe;	// as Marsaglia recommends
            qIndex = (qIndex + 1) & (Cycle - 1);
            ulong t = a * Q[qIndex] + c;
            c = (uint)(t >> 32);
            uint x = (uint)(t + c); //may overflow
            if (x < c)
            {
                x++;
                c++;
            }
            uint retVal = m - x;
            Q[qIndex] = retVal;

            return retVal;
        }
    }
}