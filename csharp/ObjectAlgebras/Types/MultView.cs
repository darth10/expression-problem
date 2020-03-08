using ObjectAlgebras.Operations;

namespace ObjectAlgebras.Types
{
    public class MultView : IView
    {
        readonly IView _left, _right;

        public MultView(IView left, IView right) =>
            (_left, _right) = (left, right);

        public string View() =>
            $"({_left.View()} * {_right.View()})";
    }
}
