namespace Extensions
{
    public interface IExp {};

    public class Const : IExp
    {
        public double Value { get; }

        public Const(double value) =>
            Value = value;
    }

    public class Add : IExp
    {
        public IExp Left { get; }
        public IExp Right { get; }

        public Add(IExp left, IExp right) =>
            (Left, Right) = (left, right);
    }
}
