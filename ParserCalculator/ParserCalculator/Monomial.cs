using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserCalculator
{
    class Monomial
    {
        internal Monomial()
        {
            Value = 0;
            Action = '+';
        }

        internal Monomial(double value, char action)
        {
            Value = value;
            Action = action;
        }

        internal double Value { get; set; }
        internal char Action { get; set; }
    }
}
