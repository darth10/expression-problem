using Extensions.Operations;
using Extensions.Types;
using System;

namespace Extensions.Eval
{
    public static class IExprExtensions
    {
        public static double Eval(this IExpr e) => e switch {
            Const c => c.Value,
            Add a => a.Left.Eval() + a.Right.Eval(),
            _ => throw new NotImplementedException()
        };
    }
}
