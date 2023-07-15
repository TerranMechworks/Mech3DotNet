namespace Mech3DotNet
{
    /// <summary>Implemented by all root ZBD types that can be written.</summary>
    public interface IWritable
    {
        void Write(string path);
    }
}
