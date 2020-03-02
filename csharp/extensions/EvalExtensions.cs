using System;

// TODO move to directory
namespace Extensions.EvalExtensions
{
    public static class EvalExtensions
    {
        public static double Eval(this IExp e) => e switch {
            Const c => c.Value,
            Add a => a.Left.Eval() + a.Right.Eval(),
            _ => throw new NotImplementedException() // add this
        };
    }
}
