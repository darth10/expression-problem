namespace PartialClasses.Types
{
    public partial class Add
    {
        public double Eval() =>
            Left.Eval() + Right.Eval();
    }
}
