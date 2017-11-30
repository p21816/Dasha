using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class BoldTextConverter: IConverter 
    {
        public string ToHtml(DocumentPart part)
        {
            return "<b>" + part.Text + "</b>";
        }
        public string ToPlainText(DocumentPart part)
        {
            return "**" + part.Text + "**";
        }
        public string ToLaTeX(DocumentPart part)
        {
            return "\\textbf{" + part.Text + "}";
        }
    }
}
