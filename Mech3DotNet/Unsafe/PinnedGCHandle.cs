using System;
using System.Runtime.InteropServices;

namespace Mech3DotNet.Unsafe
{
    public class PinnedGCHandle : IDisposable
    {
        private GCHandle handle;

        public PinnedGCHandle(object value)
        {
            this.handle = GCHandle.Alloc(value ?? throw new ArgumentNullException(nameof(value)), GCHandleType.Pinned);
        }

        public static implicit operator IntPtr(PinnedGCHandle handle)
        {
            return handle.handle.AddrOfPinnedObject();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.handle.IsAllocated)
                this.handle.Free();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~PinnedGCHandle()
        {
            this.Dispose(false);
        }
    }
}
