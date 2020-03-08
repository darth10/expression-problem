using ObjectAlgebras.Factory;
using ObjectAlgebras.Operations;
using Xunit;

namespace ObjectAlgebras.Tests
{
    public class ViewTests
    {
        readonly IView
            _constExpr1, _constExpr2, _constExpr3,
            _addExpr1, _addExpr2, _multExpr1, _multExpr2;

        public ViewTests()
        {
            var factory = new ViewFactory();

            _constExpr1 = factory.Const(7);
            _constExpr2 = factory.Const(2);
            _constExpr3 = factory.Const(3);

            _addExpr1 = factory.Add(_constExpr1, _constExpr2);

            _multExpr1 = factory.Mult(_constExpr1, _constExpr2);
            _multExpr2 = factory.Mult(_constExpr2, _constExpr3);

            _addExpr2 = factory.Add(_multExpr1, _multExpr2);
        }

        [Fact]
        public void ConstViewTest1() =>
            Assert.Equal(7.ToString(), _constExpr1.View());

        [Fact]
        public void AddViewTest1() =>
            Assert.Equal("(7 + 2)", _addExpr1.View());

        [Fact]
        public void MultViewTest1() =>
            Assert.Equal("(7 * 2)", _multExpr1.View());

        [Fact]
        public void AddViewTest2() =>
            Assert.Equal("((7 * 2) + (2 * 3))", _addExpr2.View());
    }
}
