using System;
using System.Collections.Generic;
namespace Mech3DotNet.Reader
{
    public struct Combinator : IQueryOperation
    {
        private IQueryOperation _op1;
        private IQueryOperation _op2;

        public Combinator(IQueryOperation op1, IQueryOperation op2)
        {
            _op1 = op1;
            _op2 = op2;
        }

        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            return _op2.Apply(_op1.Apply(value, path), path);
        }
    }
}
