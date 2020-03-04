using Extensions.Operations;

namespace Extensions.Types
{
    public class Const : IExpr
    {
        public double Value { get; }

        public Const(double value) =>
            Value = value;
    }
}
