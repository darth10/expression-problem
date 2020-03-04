namespace Extensions.Implementation.Types
{
    public class Add : IExp
    {
        public IExp Left { get; }
        public IExp Right { get; }

        public Add(IExp left, IExp right) =>
            (Left, Right) = (left, right);
    }
}
