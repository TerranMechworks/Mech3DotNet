using System;
using System.Collections.Generic;
namespace Mech3DotNet.Reader
{
    public struct Combinator : IQueryOperation
    {
        private IQueryOperation op1;
        private IQueryOperation op2;

        public Combinator(IQueryOperation op1, IQueryOperation op2)
        {
            this.op1 = op1;
            this.op2 = op2;
        }

        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            return op2.Apply(op1.Apply(value, path), path);
        }
    }
}
