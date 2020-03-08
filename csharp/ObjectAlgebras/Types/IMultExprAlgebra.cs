namespace ObjectAlgebras.Types
{
    public interface IMultExprAlgebra<T> : IExprAlgebra<T>
    {
        T Mult(T left, T right);
    }
}
