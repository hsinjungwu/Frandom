using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frandom.Algorithms;

namespace Frandom
{
    public class RNG
    {
        private Algorithm algorithm;

        public RNG(AlgorithmType al)
        {
            switch (al)
            {
                case AlgorithmType.BlumMicali:
                    algorithm = new AlgoBlumMicali();
                    break;

                case AlgorithmType.CMWC:
                    algorithm = new AlgoCMWC();
                    break;

                default:
                    algorithm = new AlgoCSP();
                    break;
            }
        }

        public uint Next()
        {
            return algorithm.Next();
        }

        public uint Next(uint max)
        {
            return algorithm.Next(max);
        }

        public uint Next(uint min, uint max)
        {
            if (max < min)
            {
                uint tmp = min;
                min = max;
                max = tmp;
            }

            return Next(max - min) + min;
        }

        public string Name()
        {
            return algorithm.Name;
        }
    }
}