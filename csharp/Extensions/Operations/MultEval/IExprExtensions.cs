using Extensions.Types;

namespace Extensions.Operations.MultEval
{
    // Cannot exist in same namespace as Extensions.Eval.IExprExtensions.
    // Also, if (new Add(...)).Eval() is invoked with using this namespace,
    // it will fail if any objects in left/right are type Mult.
    public static class IExprExtensions
    {
        public static double Eval(this IExpr e) => e switch {
            Mult m => m.Left.Eval() * m.Right.Eval(),
            _ => Operations.Eval.IExprExtensions.Eval(e)
        };
    }
}
