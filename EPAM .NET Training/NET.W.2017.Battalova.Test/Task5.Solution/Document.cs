using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class Document
    {
        private readonly IEnumerable<AbstractDocumentPart> parts;
        public Document(IEnumerable<AbstractDocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException();
            }

            this.parts = new List<AbstractDocumentPart>(parts);
        }

        public string Convert(AbstractDocumentConverter converter)
        {
            return converter.ConvertDocument(parts);        
        }
    }
}
