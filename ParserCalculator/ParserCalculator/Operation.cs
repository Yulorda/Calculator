using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserCalculator
{
    class Operation
    {
        public Func<double, double, double> func;
        public int priority;

        public Operation()
        {
        }

        public Operation(int priority, Func<double, double, double> func)
        {
            this.priority = priority;
            this.func = func;
        }
    }
}
