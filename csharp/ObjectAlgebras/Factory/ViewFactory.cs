using ObjectAlgebras.Operations;
using ObjectAlgebras.Types;

namespace ObjectAlgebras.Factory
{
    public class ViewFactory : IMultExprAlgebra<IView>
    {
        public IView Const(double value) =>
            new ConstView(value);

        public IView Add(IView left, IView right) =>
            new AddView(left, right);

        public IView Mult(IView left, IView right) =>
            new MultView(left, right);
    }
}
