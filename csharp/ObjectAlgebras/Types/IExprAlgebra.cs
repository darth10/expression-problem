namespace ObjectAlgebras.Types
{
    public interface IExprAlgebra<T>
    {
        T Const(double value);
        T Add(T left, T right);
    }
}
