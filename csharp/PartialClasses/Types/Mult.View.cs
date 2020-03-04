namespace PartialClasses.Types
{
    public partial class Mult
    {
        public string View() =>
            $"({Left.View()} * {Right.View()})";
    }
}
