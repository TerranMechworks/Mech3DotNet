using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    /// <summary>
    /// Combinator for two <see cref="IQueryOperation"/>.
    ///
    /// This results in a new <see cref="IQueryOperation"/> that can be applied
    /// directly, which is useful for fusing/combining two
    /// <see cref="IQueryOperation"/>.
    /// </summary>
    /// <example>
    /// These two code snippets are equivalent:
    /// <code>
    /// var op1 = new FindByKey("foo");
    /// var op2 = new FindOnly();
    /// var res = query / op1 / op2;
    /// </code>
    /// <code>
    /// var op1 = new FindByKey("foo");
    /// var op2 = new FindOnly();
    /// var op = new Combinator(op1, op2);
    /// var res = query / op;
    /// </code>
    /// However, the benefit of using the combinator is that the operators can
    /// be combined before being applied, which is situationally useful - for
    /// example, if a method returns a <see cref="IQueryOperation"/>.
    /// </example>
    public struct Combinator : IQueryOperation
    {
        private IQueryOperation _op1;
        private IQueryOperation _op2;

        public Combinator(IQueryOperation op1, IQueryOperation op2)
        {
            _op1 = op1;
            _op2 = op2;
        }

        /// <inheritdoc/>
        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            return _op2.Apply(_op1.Apply(value, path), path);
        }
    }
}
