﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public abstract class AbstractDocumentPart
    {
        public string Text { get; set; }
        public abstract void Accept(IDocumentPartVisitor documentPartVisitor);
    }
}
