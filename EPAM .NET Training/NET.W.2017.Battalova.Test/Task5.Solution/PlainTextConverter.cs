using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class PlainTextConverter : AbstractDocumentConverter
    {
        public override void Visit(BoldText boldText)
        {
            ConvertedDocument += "**" + boldText.Text + "**" + Environment.NewLine;
        }

        public override void Visit(Hyperlink hyperlink)
        {
            ConvertedDocument += hyperlink.Text + " [" + hyperlink.Url + "]" + Environment.NewLine;
        }

        public override void Visit(PlainText plainText)
        {
            ConvertedDocument += plainText.Text + Environment.NewLine;
        }
    }
}
