using Extensions.Types;
using System;

namespace Extensions.Operations.View
{
    public static class IExprExtensions
    {
        public static string View(this IExpr e) => e switch {
            Const c => c.Value.ToString(),
            Add a => $"({a.Left.View()} + {a.Right.View()})",
            _ => throw new NotImplementedException()
        };
    }
}
