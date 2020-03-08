using ObjectAlgebras.Operations;
using ObjectAlgebras.Types;

namespace ObjectAlgebras.Factory
{
    public class EvalFactory : IExprAlgebra<IEval>
    {
        public IEval Const(double value) =>
            new ConstEval(value);

        public IEval Add(IEval left, IEval right) =>
            new AddEval(left, right);
    }
}
