using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserCalculator
{
    public class ParserFunction
    {
        private static Dictionary<string, ParserFunction> function = new Dictionary<string, ParserFunction>();
        private static StringToDoubleFunction stringToDoubleFunc = new StringToDoubleFunction();
        private static IdentityFunction identityFunс = new IdentityFunction();
        private ParserFunction implementationFunc;

        public ParserFunction()
        {
            implementationFunc = this;
        }

        internal ParserFunction(string data, string item, ref int from, char to)
        {
            if (item.Length == 0)
            {
                implementationFunc = identityFunс;
                return;
            }

            if (function.TryGetValue(item, out implementationFunc))
            {
                return;
            }

            stringToDoubleFunc.Item = item;
            implementationFunc = stringToDoubleFunc; //попытка преобразовать в число, если функция не была определена
        }

        public static void AddFunction(string name, ParserFunction function)
        {
            ParserFunction.function[name] = function;
        }

        public double GetValue(string data, ref int from, char to)
        {
            return implementationFunc.Evaluate(data, ref from, to);
        }

        protected virtual double Evaluate(string data, ref int from, char to)
        {
            return 0;
        }

      

    }
}
