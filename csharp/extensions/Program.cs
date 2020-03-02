using System;
using Extensions.MultEvalExtensions;

namespace Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var c1 = new Const(2);
            // var a1 = new Add(c1, new Const(3));
            var a1 = new Mult(c1, new Const(3));
            var a2 = new Mult(new Const(5), a1);
            var a3 = new Add(new Const(5), a1);

            Console.WriteLine(c1.Eval());
            Console.WriteLine(a2.Eval());
            Console.WriteLine(a3.Eval());
        }
    }
}
