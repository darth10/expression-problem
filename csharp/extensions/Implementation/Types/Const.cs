namespace Extensions.Implementation.Types
{
    public class Const : IExp
    {
        public double Value { get; }

        public Const(double value) =>
            Value = value;
    }
}
