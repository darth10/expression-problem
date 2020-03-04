using Extensions.Implementation.Types;

namespace Extensions.Implementation.MultEval
{
    // Cannot exist in same namespace.
    // Also, if (new Add(...)).Eval() is invoked with using this namespace,
    // it will fail if any objects in left/right are type Mult.
    public static class IExpExtensions
    {
        public static double Eval(this IExp e) => e switch {
            Mult m => m.Left.Eval() * m.Right.Eval(),
            _ => Implementation.Eval.IExpExtensions.Eval(e)
        };
    }
}
