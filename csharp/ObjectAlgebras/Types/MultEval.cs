using ObjectAlgebras.Operations;

namespace ObjectAlgebras.Types
{
    public class MultEval : IEval
    {
        readonly IEval _left, _right;

        public MultEval(IEval left, IEval right) =>
            (_left, _right) = (left, right);

        public double Eval() =>
            _left.Eval() * _right.Eval();
    }
}
