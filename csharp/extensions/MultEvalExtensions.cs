// TODO move to directory
namespace Extensions.MultEvalExtensions
{
    // Cannot exist in same namespace.
    // Also, if (new Add(...)).Eval() is invoked with using this namespace,
    // it will fail if any objects in left/right are type Mult.
    public static class MoreEvalExtensions
    {
        public static double Eval(this IExp e) => e switch {
            Mult m => m.Left.Eval() * m.Right.Eval(),
            _ => EvalExtensions.EvalExtensions.Eval(e)
        };
    }
}
