using ObjectAlgebras.Factory;
using ObjectAlgebras.Operations;
using Xunit;

namespace ObjectAlgebras.Tests
{
    public class EvalTests
    {
        readonly IEval
            _constExpr1, _constExpr2, _constExpr3,
            _addExpr1, _addExpr2, _multExpr1, _multExpr2;

        public EvalTests()
        {
            var factory = new MultEvalFactory();

            _constExpr1 = factory.Const(7);
            _constExpr2 = factory.Const(2);
            _constExpr3 = factory.Const(3);

            _addExpr1 = factory.Add(_constExpr1, _constExpr2);

            _multExpr1 = factory.Mult(_constExpr1, _constExpr2);
            _multExpr2 = factory.Mult(_constExpr2, _constExpr3);

            _addExpr2 = factory.Add(_multExpr1, _multExpr2);
        }

        [Fact]
        public void ConstEvalTest1() =>
            Assert.Equal(7, _constExpr1.Eval());

        [Fact]
        public void AddEvalTest1() =>
            Assert.Equal(9, _addExpr1.Eval());

        [Fact]
        public void MultEvalTest1() =>
            Assert.Equal(14, _multExpr1.Eval());

        [Fact]
        public void AddEvalTest2() =>
            Assert.Equal(20, _addExpr2.Eval());
    }
}
