using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class HtmlConverter : AbstractDocumentConverter
    {
        public override void Visit(BoldText boldText)
        {
            ConvertedDocument += "<b>" + boldText.Text + "</b>" + Environment.NewLine;
        }

        public override void Visit(Hyperlink hyperlink)
        {
            ConvertedDocument += "<a href=\"" + hyperlink.Url + "\">" + hyperlink.Text + "</a>" + Environment.NewLine;
        }

        public override void Visit(PlainText plainText)
        {
            ConvertedDocument += plainText.Text + Environment.NewLine;
        }
    }
}
