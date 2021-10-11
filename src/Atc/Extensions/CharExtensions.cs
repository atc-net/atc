// ReSharper disable once CheckNamespace
namespace System
{
    public static class CharExtensions
    {
        public static bool IsAscii(this char value)
        {
            return value <= sbyte.MaxValue;
        }
    }
}