using Extensions.Operations;

namespace Extensions.Types
{
    public class Add : IExpr
    {
        public IExpr Left { get; }
        public IExpr Right { get; }

        public Add(IExpr left, IExpr right) =>
            (Left, Right) = (left, right);
    }
}
