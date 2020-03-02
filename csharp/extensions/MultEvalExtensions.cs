// TODO move to directory
namespace Extensions.MultEvalExtensions
{
    // cannot exist in same namespace
    // if (new Add(...)).Eval() is invoked with using this namespace,
    // it will fail if any objects in left/right are Mult
    public static class MoreEvalExtensions
    {
        public static double Eval(this IExp e) => e switch {
            Mult m => m.Left.Eval() * m.Right.Eval(),
            _ => EvalExtensions.EvalExtensions.Eval(e)
        };
    }
}
