using System;

namespace ObjectAlgebras
{
    // TODO split into files

    public interface IEval
    {
        double Eval();
    }

    public interface IExprAlgebra<T>
    {
        T Const(double value);
        T Add(T left, T right);
    }

    public class ConstEval : IEval
    {
        readonly double _value;
        public ConstEval(double value) =>
            _value = value;

        public double Eval() => _value;
    }

    public class AddEval : IEval
    {
        readonly IEval _left, _right;
        public AddEval(IEval left, IEval right) =>
            (_left, _right) = (left, right);

        public double Eval() =>
            _left.Eval() + _right.Eval();
    }

    public class EvalFactory : IExprAlgebra<IEval>
    {
        public IEval Const(double value) =>
            new ConstEval(value);

        public IEval Add(IEval left, IEval right) =>
            new AddEval(left, right);
    }

    // new type
    //

    public interface IMultExprAlgebra<T> : IExprAlgebra<T>
    {
        T Mult(T left, T right);
    }

    public class MultEval : IEval
    {
        readonly IEval _left, _right;
        public MultEval(IEval left, IEval right) =>
            (_left, _right) = (left, right);

        public double Eval() =>
            _left.Eval() * _right.Eval();
    }

    public class MultEvalFactory : EvalFactory, IMultExprAlgebra<IEval>
    {
        public IEval Mult(IEval left, IEval right) =>
            new MultEval(left, right);
    }

    // new operation

    public interface IView
    {
        string View();
    }

    public class ConstView : IView
    {
        readonly double _value;
        public ConstView(double value) =>
            _value = value;

        public string View() =>
            _value.ToString();
    }

    public class AddView : IView
    {
        readonly IView _left, _right;
        public AddView(IView left, IView right) =>
            (_left, _right) = (left, right);

        public string View() =>
            $"({_left.View()} + {_right.View()})";
    }

    public class MultView : IView
    {
        readonly IView _left, _right;
        public MultView(IView left, IView right) =>
            (_left, _right) = (left, right);

        public string View() =>
            $"({_left.View()} * {_right.View()})";
    }

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
