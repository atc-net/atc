using System;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Flag-Enumeration: CardinalDirectionType.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "OK.")]
    [SuppressMessage("Minor Code Smell", "S2342:Enumeration types should comply with a naming convention", Justification = "OK.")]
    [Flags]
    public enum CardinalDirectionType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        None = 0,

        /// <summary>
        /// North.
        /// </summary>
        North = 0x01,

        /// <summary>
        /// NorthNorthEast.
        /// </summary>
        NorthNorthEast = 0x02,

        /// <summary>
        /// NorthEast.
        /// </summary>
        NorthEast = 0x04,

        /// <summary>
        /// EastNorthEast.
        /// </summary>
        EastNorthEast = 0x08,

        /// <summary>
        /// East.
        /// </summary>
        East = 0x10,

        /// <summary>
        /// EastSouthEast.
        /// </summary>
        EastSouthEast = 0x20,

        /// <summary>
        /// SouthEast.
        /// </summary>
        SouthEast = 0x40,

        /// <summary>
        /// SouthSouthEast.
        /// </summary>
        SouthSouthEast = 0x80,

        /// <summary>
        /// South.
        /// </summary>
        South = 0x200,

        /// <summary>
        /// SouthSouthWest.
        /// </summary>
        SouthSouthWest = 0x100,

        /// <summary>
        /// SouthWest.
        /// </summary>
        SouthWest = 0x400,

        /// <summary>
        /// WestSouthWest.
        /// </summary>
        WestSouthWest = 0x800,

        /// <summary>
        /// West.
        /// </summary>
        West = 0x1000,

        /// <summary>
        /// WestNorthWest.
        /// </summary>
        WestNorthWest = 0x2000,

        /// <summary>
        /// NorthWest
        /// </summary>
        NorthWest = 0x4000,

        /// <summary>
        /// NorthNorthWest.
        /// </summary>
        NorthNorthWest = 0x8000,

        /// <summary>
        /// Simple = North | East | South | West.
        /// </summary>
        Simple = North | East | South | West,

        /// <summary>
        /// Medium = North | NorthEast | East | SouthEast | South | SouthWest | West | NorthWest.
        /// </summary>
        Medium = North | NorthEast | East | SouthEast | South | SouthWest | West | NorthWest,

        /// <summary>
        /// Advanced = North | NorthNorthEast | NorthEast | EastNorthEast | East | EastSouthEast | SouthEast | SouthSouthEast | South | SouthSouthWest | SouthWest | WestSouthWest | West | WestNorthWest | NorthWest | NorthNorthWest.
        /// </summary>
        Advanced = North | NorthNorthEast | NorthEast | EastNorthEast | East | EastSouthEast | SouthEast | SouthSouthEast | South | SouthSouthWest | SouthWest | WestSouthWest | West | WestNorthWest | NorthWest | NorthNorthWest
    }
}