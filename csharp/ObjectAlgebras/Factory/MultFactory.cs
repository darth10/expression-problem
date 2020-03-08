using ObjectAlgebras.Operations;
using ObjectAlgebras.Types;

namespace ObjectAlgebras.Factory
{
    public class MultEvalFactory : IMultExprAlgebra<IEval>
    {
        readonly EvalFactory _evalFactory = new EvalFactory();

        public IEval Const(double value) =>
            _evalFactory.Const(value);

        public IEval Add(IEval left, IEval right) =>
            _evalFactory.Add(left, right);

        public IEval Mult(IEval left, IEval right) =>
            new MultEval(left, right);
    }
}
