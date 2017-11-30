using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class LaTeXConverter : AbstractDocumentConverter
    {
        public override void Visit(BoldText boldText)
        {
            ConvertedDocument += "\\textbf{" + boldText.Text + "}" + Environment.NewLine;
        }

        public override void Visit(Hyperlink hyperlink)
        {
            ConvertedDocument += "\\href{" + hyperlink.Url + "}{" + hyperlink.Text + "}" + Environment.NewLine;
        }

        public override void Visit(PlainText plainText)
        {
            ConvertedDocument += plainText.Text + Environment.NewLine;
        }
    }
}
