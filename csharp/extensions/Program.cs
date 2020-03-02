using System;
using Extensions.MultEvalExtensions;

namespace Extensions
{
    class Program
    {
        // TODO add ViewExtensions
        // TODO move to tests
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var c1 = new Const(2);
            var a1 = new Add(c1, new Const(3));
            var a2 = new Add(new Const(5), a1);

            var m1 = new Mult(new Const(5), a1);
            var m2 = new Mult(c1, new Const(3));

            var a3 = new Add(new Const(5), m1);

            Console.WriteLine(c1.Eval());
            Console.WriteLine(a1.Eval());
            Console.WriteLine(a2.Eval());
            Console.WriteLine(m1.Eval());
            Console.WriteLine(m2.Eval());
            Console.WriteLine(a3.Eval()); // fails
        }
    }
}
