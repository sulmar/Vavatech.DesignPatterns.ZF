using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.InterpreterDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string expression = "2 3 + 1 - 2 *";

            var parser = new Parser();

            var result = parser.Evaluate(expression);

            Console.WriteLine(result);


        }

    }


    interface IExpression
    {
        void Interpret(Stack<int> s);
    }

    public class NumberExpression : IExpression
    {
        private int number;

        public NumberExpression(int number)
        {
            this.number = number;
        }

        public void Interpret(Stack<int> s)
        {
            s.Push(number);
        }
    }

    public class PlusExpression : IExpression
    {
        public void Interpret(Stack<int> s)
        {
            s.Push(s.Pop() + s.Pop());
        }
    }

    public class MinusExpression : IExpression
    {
        public void Interpret(Stack<int> s)
        {
            s.Push(-s.Pop() + s.Pop());
        }
    }

    public class MultiplyExpression : IExpression
    {
        public void Interpret(Stack<int> s)
        {
            s.Push(s.Pop() * s.Pop());
        }
    }

    class Parser
    {
        private IList<IExpression> parseTree = new List<IExpression>();


        private void Parse(string s)
        {
            var tokens = s.Split(' ');

            foreach (var token in tokens)
            {
                if (token == "+")
                    parseTree.Add(new PlusExpression());
                else
                if (token == "-")
                    parseTree.Add(new MinusExpression());
                else
                if (token == "*")
                    parseTree.Add(new MultiplyExpression());
                else
                    parseTree.Add(new NumberExpression(int.Parse(token)));
            }
        }

        public int Evaluate(string s)
        {
            Parse(s);

            var context = new Stack<int>();

            foreach (var expression in parseTree)
            {
                expression.Interpret(context);
            }

            return context.Pop();

        }
    }


}
