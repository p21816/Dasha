namespace Task5.Solution
{
    public class PlainText : AbstractDocumentPart
    {
        public override void Accept(IDocumentPartVisitor documentPartVisitor)
        {
            documentPartVisitor.Visit(this);
        }
    }
}
