﻿namespace Task5.Console
{
    using System.Collections.Generic;
    using System;
    using Task5;
    using Task5.Solution;

    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractDocumentPart> parts = new List<AbstractDocumentPart>
                {
                    new PlainText {Text = "Some plain text"},
                    new Hyperlink {Text = "google.com", Url = "https://www.google.by/"},
                    new BoldText {Text = "Some bold text"}
                };

            Document document = new Document(parts);

            Console.WriteLine(document.Convert(new HtmlConverter()));
            Console.WriteLine(document.Convert(new LaTeXConverter()));
            Console.WriteLine(document.Convert(new PlainTextConverter()));
        }
    }
}
