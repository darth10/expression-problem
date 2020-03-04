namespace PartialClasses.Types
{
    public partial class Mult
    {
        public double Eval() =>
            Left.Eval() * Right.Eval();
    }
}
