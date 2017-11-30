using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public abstract class AbstractDocumentConverter : IDocumentPartVisitor
    {
        private string convertedDocument = string.Empty;

        public string ConvertedDocument
        {
            get { return convertedDocument; }
            protected set { convertedDocument = value; }
        }

        public abstract void Visit(BoldText boldText);

        public abstract void Visit(Hyperlink hyperlink);

        public abstract void Visit(PlainText plainText);

        public string ConvertDocument(IEnumerable<AbstractDocumentPart> parts)
        {
            foreach (var part in parts)
            {                
                part.Accept(this);
            }

            return ConvertedDocument;
        }
    }
}
