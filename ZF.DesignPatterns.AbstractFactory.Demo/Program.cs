using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.AbstractFactory.Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            string expression = "2 3 + 1 - 2 *";

            var parser = new Parser(new ExpressionFactory());

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
        private readonly IList<IExpression> parseTree = new List<IExpression>();
        private readonly IExpressionFactory factory;

        public Parser(IExpressionFactory factory)
        {
            this.factory = factory;
        }
        private void Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(nameof(s));
            }



            var tokens = s.Split(' ');

            foreach (var token in tokens)
            {
                // Product
                var expression = factory.Create(token);

                parseTree.Add(expression);
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

    // Abstract Factory
    interface IExpressionFactory
        
    {
        IExpression Create(string token);
    }

    interface IGenericFactory
    {
        T Create<T>() where T : class, new();
    }

    class Factory : IGenericFactory
    {
        public T Create<T>() where T : class, new()
        {
            return new T();
        }
    }



    // Concret Factory
    class ExpressionFactory : IExpressionFactory
    {
        public IExpression Create(string token)
        {
            switch(token)
            {
                case "+": return new PlusExpression(); break;
                case "-": return new MinusExpression(); break;
                case "*": return new MultiplyExpression(); break;

                default: return new NumberExpression(int.Parse(token));
            }
        }
    }
}
