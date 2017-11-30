namespace Task5.Solution
{
    public class BoldText : AbstractDocumentPart
    {
        public override void Accept(IDocumentPartVisitor documentPartVisitor)
        {
            documentPartVisitor.Visit(this);
        }
    }
}