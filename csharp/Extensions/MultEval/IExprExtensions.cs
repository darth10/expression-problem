using Extensions.Operations;
using Extensions.Types;

namespace Extensions.MultEval
{
    // Cannot exist in same namespace.
    // Also, if (new Add(...)).Eval() is invoked with using this namespace,
    // it will fail if any objects in left/right are type Mult.
    public static class IExprExtensions
    {
        public static double Eval(this IExpr e) => e switch {
            Mult m => m.Left.Eval() * m.Right.Eval(),
            _ => Extensions.Eval.IExprExtensions.Eval(e)
        };
    }
}
