using System;
using System.Diagnostics.CodeAnalysis;
using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Flag-Enumeration: AddressType.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "OK.")]
    [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
    [Flags]
    public enum AddressType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None = 0x00,

        /// <summary>
        /// The address indicates that the returned result is a precise geocode for which we have
        /// location information accurate down to street address precision. - With floor and door, if specified.
        /// </summary>
        Address = 0x01,

        /// <summary>
        /// The access address indicates that the returned result is a precise geocode for which we have
        /// location information accurate down to street address precision. - No floor and door.
        /// </summary>
        /// <remarks>
        /// Same as RoofTop from Google.
        /// </remarks>
        AccessAddress = 0x02,

        /// <summary>
        /// The preliminary address - same as AccessAddress, but preliminary.
        /// </summary>
        PreliminaryAddress = 0x04,

        /// <summary>
        /// The preliminary access address - same as Address, but preliminary.
        /// </summary>
        PreliminaryAccessAddress = 0x08,

        /// <summary>
        /// The range interpolated indicates that the returned result reflects an approximation (usually on a road)
        /// interpolated between two precise points (such as intersections).
        /// Interpolated results are generally returned when rooftop geocodes are unavailable for a street address.
        /// </summary>
        RangeInterpolated = 0x10,

        /// <summary>
        /// The geometric center indicates that the returned result is the geometric center
        /// of a result such as a polyline (for example, a street) or polygon (region).
        /// </summary>
        GeometricCenter = 0x20,

        /// <summary>
        /// The approximate indicates that the returned result is approximate.
        /// </summary>
        Approximate = 0x40,

        /// <summary>
        /// The partial indicates that this not an full-validated-address, but a more approximate address - based on country and city.
        /// </summary>
        Partial = 0x80,

        /// <summary>
        /// All regularly
        /// </summary>
        AllRegularly = Address | AccessAddress,

        /// <summary>
        /// All preliminary
        /// </summary>
        AllPreliminary = PreliminaryAddress | PreliminaryAccessAddress,

        /// <summary>
        /// All
        /// </summary>
        [LocalizedDescription("All", typeof(EnumResources))]
        All = Address | AccessAddress | PreliminaryAddress | PreliminaryAccessAddress
    }
}