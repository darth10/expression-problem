using PartialClasses.Operations;

namespace PartialClasses.Types
{
    public partial class Mult : IExpr
    {
        public IExpr Left { get; }
        public IExpr Right { get; }

        public Mult(IExpr left, IExpr right) =>
            (Left, Right) = (left, right);
    }
}
