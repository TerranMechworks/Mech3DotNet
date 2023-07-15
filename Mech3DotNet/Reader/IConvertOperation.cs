using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    /// <summary>
    /// Implemented by operations to convert a <see cref="ReaderValue"/> to a
    /// specific type.
    /// </summary>
    public interface IConvertOperation<T>
    {
        /// <summary>
        /// Apply the operation to the <see cref="ReaderValue"/>.
        ///
        /// This method is not usually called manually, but is called when the
        /// operation is applied to a <see cref="Query"/>.
        /// </summary>
        T ConvertTo(ReaderValue value, IEnumerable<string> path);
    }
}
