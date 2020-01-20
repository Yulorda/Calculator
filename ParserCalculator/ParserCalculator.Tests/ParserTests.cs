using NUnit.Framework;
using ParserCalculator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace ParserCalculator.Tests
{
    public class ParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RandomExpressionTest()
        {
            for(int i=0;i<100;i++)
            {
                var result = 0.0;
                var expression = GetExpression(out result);
                var parserResult = Parser.Start(expression);
                Assert.AreEqual(result, parserResult);
            }
        }

        [Test]
        public void Test01()
        {
            var expression = "(((2-1)*2-1/(2-1))*5)-4";
            Assert.AreEqual(Parser.Start(expression), 1);
        }

        public string GetExpression(out double result)
        {
            var random = new Random();
            result = 0.0;
            var operation = new Dictionary<char, Func<double, double, double>>();
            operation.Add('*', (a, b) => a * b);
            operation.Add('/', (a, b) => a / b);
            operation.Add('+', (a, b) => a + b);
            operation.Add('-', (a, b) => a - b);

            var charOperation = operation.Keys.ToArray();

            StringBuilder sb = new StringBuilder();
            char op1 = ' ';

            for (int i = 0; i < random.Next(2, 10); i++)
            {
                double a = random.Next(0, 100);
                double b = random.Next(0, 100);

                char op2 = charOperation[random.Next(0, charOperation.Length-1)];

                if (op1 != ' ')
                {
                    result = operation[op1](result, operation[op2](a, b));
                    sb.Append(op1);
                }
                else
                {
                    result = operation[op2](a, b);
                }

                op1 = charOperation[random.Next(2, charOperation.Length-1)];

                sb.Append('(');
                sb.Append(a);
                sb.Append(op2);
                sb.Append(b);
                sb.Append(')');
            }

            return sb.ToString();
        }
    }
}