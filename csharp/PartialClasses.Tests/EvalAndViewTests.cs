using System;
using PartialClasses.Operations;
using PartialClasses.Types;
using Xunit;

namespace PartialClasses.Tests
{
    public class EvalAndViewTests
    {
        readonly IExpr
            _constExpr1, _constExpr2, _constExpr3,
            _addExpr1, _addExpr2, _multExpr1, _multExpr2;

        public EvalAndViewTests()
        {
            _constExpr1 = new Const(7);
            _constExpr2 = new Const(2);
            _constExpr3 = new Const(3);

            _addExpr1 = new Add(_constExpr1, _constExpr2);

            _multExpr1 = new Mult(_constExpr1, _constExpr2);
            _multExpr2 = new Mult(_constExpr2, _constExpr3);

            _addExpr2 = new Add(_multExpr1, _multExpr2);
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
