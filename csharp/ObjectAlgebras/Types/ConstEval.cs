using ObjectAlgebras.Operations;

namespace ObjectAlgebras.Types
{
    public class ConstEval : IEval
    {
        readonly double _value;

        public ConstEval(double value) =>
            _value = value;

        public double Eval() => _value;
    }
}
