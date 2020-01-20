using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserCalculator
{
    class StringToDoubleFunction : ParserFunction
    {
        protected override double Evaluate(string data, ref int from, char to)
        {
            double num;
            if (!Double.TryParse(Item, out num))
            {
                throw new ArgumentException("Could not parse token [" + Item + "]");
            }
            return num;
        }
        public string Item { private get; set; }
    }
}
