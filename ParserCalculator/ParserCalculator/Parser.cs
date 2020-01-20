using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserCalculator
{
    public class Parser
    {
        internal const char END = '=';

        static Dictionary<char, char> brackets = new Dictionary<char, char>();

        static Dictionary<char, Operation> operation = new Dictionary<char, Operation>();

        static Parser()
        {
            operation.Add('*', new Operation(3, (a, b) => a * b));
            operation.Add('/', new Operation(3, (a, b) => a / b));
            operation.Add('+', new Operation(2, (a, b) => a + b));
            operation.Add('-', new Operation(2, (a, b) => a - b));

            brackets.Add('(', ')');

        }

        static public double Start(string expression)
        {
            var index = 0;
            return SplitAndCalculate(expression, ref index, END).Value;
        }

        //Разбивает на токены-операции, производит сляние
        internal static Monomial SplitAndCalculate(string data, ref int from, char to)
        {
            var result = new Monomial();
            var listToMerge = new List<Monomial>();
            var item = new StringBuilder();
            var index = 1;
            char currentSymbol = to;
            
            if (from >= data.Length)
                throw new ArgumentException("Некорректное выражение " + data);

            do
            {
                currentSymbol = data[from++];
                if (IsCorrectSymbol(item.ToString(), currentSymbol))
                {
                    item.Append(currentSymbol);
                    if (from < data.Length)
                        continue;
                }

                if (brackets.ContainsKey(currentSymbol))
                {
                    result = SplitAndCalculate(data, ref from, brackets[currentSymbol]);
                    result.Action = UpdateAction(data, ref from, to);
                }
                else
                {
                    ParserFunction func = new ParserFunction(data, item.ToString(), ref from, to);
                    double value = func.GetValue(data, ref from, to);
                    result = new Monomial(value, currentSymbol);
                }

                currentSymbol = result.Action;
                listToMerge.Add(result);
                item.Clear();

            } while (from < data.Length && currentSymbol != to);

            return Merge(listToMerge[0], listToMerge, ref index);
        }

        static bool IsCorrectSymbol(string item, char symbol)
        {
            if (item.Length == 0 && symbol == '-')
                return true;

            if (ValidOperation(symbol))
                return false;

            foreach (var bracket in brackets.Values)
            {
                if (bracket == symbol)
                {
                    return false;
                }
            }

            foreach (var bracket in brackets.Keys)
            {
                if (bracket == symbol)
                {
                    return false;
                }
            }
            return true;
        }

        static bool ValidOperation(char symbol)
        {
            foreach (var op in operation.Keys)
            {
                if (op == symbol)
                    return true;
            }
            return false;
        }

        static char UpdateAction(string item, ref int from, char to)
        {
            if (from >= item.Length || item[from] == to)
            {
                from++;
                return to;
            }
            
            int index = from;
            char res = to;

            while (!ValidOperation(res) && index < item.Length)
            {
                res = item[index++];
            }

            from = ValidOperation(res) ? index : index > from ? index - 1 : from;
            return res;
        }

        #region MERGE
        static Monomial Merge(Monomial current, List<Monomial> listToMerge, ref int index, bool mergeOneOnly = false)
        {
            while (index < listToMerge.Count)
            {
                Monomial next = listToMerge[index++];
                while (!CanMergeMonomial(current, next))
                {
                    Merge(next, listToMerge, ref index, true);
                }

                MergeMonomial(current, next);
                if (mergeOneOnly)
                {
                    return current;
                }
            }
            return current;
        }

        static bool CanMergeMonomial(Monomial leftMonomial, Monomial rightMonomial)
        {
            return GetPriority(leftMonomial.Action) >= GetPriority(rightMonomial.Action);
        }

        static void MergeMonomial(Monomial leftMonomial, Monomial rightMonomial)
        {
            //Console.WriteLine($"{leftMonomial.Value} {leftMonomial.Action} {rightMonomial.Value} {rightMonomial.Action}");
            leftMonomial.Value = operation[leftMonomial.Action].func(leftMonomial.Value, rightMonomial.Value);
            leftMonomial.Action = rightMonomial.Action;
        }

        private static int GetPriority(char action)
        {
            var result = new Operation();
            if (operation.TryGetValue(action, out result))
                return result.priority;

            return 0;
        }
        #endregion
    }
}
