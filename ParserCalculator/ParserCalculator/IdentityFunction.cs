using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserCalculator
{
    class IdentityFunction : ParserFunction
    {
        protected override double Evaluate(string data, ref int from,char to)
        {
            return Parser.SplitAndCalculate(data, ref from, to).Value;
        }
    }
}
