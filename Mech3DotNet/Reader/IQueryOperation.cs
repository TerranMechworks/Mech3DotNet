using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    /// <summary>
    /// Implemented by operations to query a <see cref="ReaderValue"/>,
    /// usually a <see cref="ReaderList"/>.
    /// </summary>
    public interface IQueryOperation
    {
        /// <summary>
        /// Apply the operation to the <see cref="ReaderValue"/>, and modify
        /// the path appropriately.
        ///
        /// This method is not usually called manually, but is called when the
        /// operation is applied to a <see cref="Query"/>.
        /// </summary>
        ReaderValue Apply(ReaderValue value, List<string> path);
    }
}
