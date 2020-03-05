using Extensions.Operations;
using Extensions.Types;

namespace Extensions.MultView
{
    // Cannot exist in same namespace as Extensions.View.IExprExtensions.
    // Also, if (new Add(...)).View() is invoked with using this namespace,
    // it will fail if any objects in left/right are type Mult.
    public static class IExprExtensions
    {
        public static string View(this IExpr e) => e switch {
            Mult m => $"({m.Left.View()} * {m.Right.View()})",
            _ => Extensions.View.IExprExtensions.View(e)
        };
    }
}
