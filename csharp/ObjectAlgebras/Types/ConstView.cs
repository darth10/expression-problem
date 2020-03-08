using ObjectAlgebras.Operations;

namespace ObjectAlgebras.Types
{
    public class ConstView : IView
    {
        readonly double _value;

        public ConstView(double value) =>
            _value = value;

        public string View() =>
            _value.ToString();
    }
}
