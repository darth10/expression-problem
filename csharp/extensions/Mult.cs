namespace Extensions
{
    public class Mult : IExp
    {
        public IExp Left { get; }
        public IExp Right { get; }

        public Mult(IExp left, IExp right) =>
            (Left, Right) = (left, right);
    }
}
