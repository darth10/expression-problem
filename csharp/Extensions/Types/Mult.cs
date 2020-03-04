using Extensions.Operations;

namespace Extensions.Types
{
    public class Mult : IExpr
    {
        public IExpr Left { get; }
        public IExpr Right { get; }

        public Mult(IExpr left, IExpr right) =>
            (Left, Right) = (left, right);
    }
}
