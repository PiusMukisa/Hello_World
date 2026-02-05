using System;
using System.Runtime.InteropServices;

namespace Hello_World.Models
{
    /// <summary>
    /// Demonstrates a union-like layout in C# using explicit layout.
    /// This is not commonly used in high-level C# code but satisfies
    /// the assignment requirement to show a union-like type.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ValueUnion
    {
        [FieldOffset(0)]
        public int IntValue;

        [FieldOffset(0)]
        public double DoubleValue;
    }
}
