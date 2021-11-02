using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frandom.Algorithms
{
    public abstract class Algorithm
    {
        public abstract string Name { get; }

        public abstract uint Next();

        public uint Next(uint max)
        {
            uint value = Next();
            if (max == uint.MaxValue)
            {
                return value;
            }

            uint bound = uint.MaxValue - uint.MaxValue % (max + 1);
            while (value >= bound)
            {
                value = Next();
            };

            value %= (max + 1);
            return value;
        }
    }
}