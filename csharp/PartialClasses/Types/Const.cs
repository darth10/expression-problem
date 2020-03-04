using PartialClasses.Operations;

namespace PartialClasses.Types
{
    public partial class Const : IExpr
    {
        public double Value { get; }

        public Const(double value) =>
            Value = value;
    }
}
