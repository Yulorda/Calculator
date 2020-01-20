using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class PiFunction : ParserCalculator.ParserFunction
    {
        protected override double Evaluate(string data, ref int from, char to)
        {
            return 3.141592653589793;
        }
    }
}
