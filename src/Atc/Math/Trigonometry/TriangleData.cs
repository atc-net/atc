using System.Diagnostics.CodeAnalysis;

// ReSharper disable InconsistentNaming
namespace Atc.Math.Trigonometry
{
    /// <summary>
    /// Triangle Data
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "OK.")]
    [SuppressMessage("Naming", "CA1708:Identifiers should differ by more than case", Justification = "OK.")]
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "OK.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:Accessible fields should begin with upper-case letter", Justification = "OK.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "OK.")]
    [SuppressMessage("Minor Code Smell", "S1104:Fields should not have public accessibility", Justification = "OK.")]
    public class TriangleData
    {
        /// <summary>
        /// Angle A - known as big 'A'
        /// </summary>
        public double A;

        /// <summary>
        /// Angle B - known as big 'B'
        /// </summary>
        public double B;

        /// <summary>
        /// Angle C - known as big 'C'
        /// </summary>
        public double C;

        /// <summary>
        /// Side A - known as little 'a'
        /// </summary>
        public double a;

        /// <summary>
        /// Side B - known as little 'b'
        /// </summary>
        public double b;

        /// <summary>
        /// Side C - known as little 'c'
        /// </summary>
        public double c;

        /// <inheritdoc/>
        public override string ToString() => $"{nameof(A)}: {this.A}, {nameof(B)}: {this.B}, {nameof(C)}: {this.C}, {nameof(a)}: {this.a}, {nameof(b)}: {this.b}, {nameof(c)}: {this.c}";
    }
}