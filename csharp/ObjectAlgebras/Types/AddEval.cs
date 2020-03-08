using ObjectAlgebras.Operations;

namespace ObjectAlgebras.Types
{
    public class AddEval : IEval
    {
        readonly IEval _left, _right;

        public AddEval(IEval left, IEval right) =>
            (_left, _right) = (left, right);

        public double Eval() =>
            _left.Eval() + _right.Eval();
    }
}
