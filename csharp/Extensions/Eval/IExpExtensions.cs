using Extensions.Types;
using System;

namespace Extensions.Eval
{
    public static class IExpExtensions
    {
        public static double Eval(this IExp e) => e switch {
            Const c => c.Value,
            Add a => a.Left.Eval() + a.Right.Eval(),
            _ => throw new NotImplementedException()
        };
    }
}
