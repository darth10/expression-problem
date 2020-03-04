namespace PartialClasses.Types
{
    public partial class Add
    {
        public string View() =>
            $"({Left.View()} + {Right.View()})";
    }
}
