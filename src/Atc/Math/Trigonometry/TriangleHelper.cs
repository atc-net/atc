using System;
using Atc.Helpers;

// ReSharper disable InvertIf
namespace Atc.Math.Trigonometry
{
    /// <summary>
    /// The TrianglesHelper module contains procedures used to preform math operations on a triangle.
    /// </summary>
    public static class TriangleHelper
    {
        /// <summary>
        /// Calculate sines and cosines.
        /// </summary>
        /// <param name="angleA">The angle A.</param>
        /// <param name="angleB">The angle B.</param>
        /// <param name="angleC">The angle C.</param>
        /// <param name="sideA">The side A.</param>
        /// <param name="sideB">The side B.</param>
        /// <param name="sideC">The side C.</param>
        public static TriangleData SinesAndCosines(double? angleA, double? angleB, double? angleC, double? sideA, double? sideB, double? sideC)
        {
            if (Convert.ToInt32(angleA.HasValue) + Convert.ToInt32(angleB.HasValue) + Convert.ToInt32(angleC.HasValue) +
                Convert.ToInt32(sideA.HasValue) + Convert.ToInt32(sideB.HasValue) + Convert.ToInt32(sideC.HasValue) != 3)
            {
                throw new ArithmeticException("3 and only 3 argument have to be null.");
            }

            if (Convert.ToInt32(angleA.HasValue) + Convert.ToInt32(angleB.HasValue) + Convert.ToInt32(angleC.HasValue) == 0)
            {
                throw new ArithmeticException("At least 1 angle argument have to be null.");
            }

            if (Convert.ToInt32(sideA.HasValue) + Convert.ToInt32(sideB.HasValue) + Convert.ToInt32(sideC.HasValue) == 0)
            {
                throw new ArithmeticException("At least 1 side argument have to be null.");
            }

            var result = new TriangleData();
            if (angleA.HasValue)
            {
                result.A = (double)angleA;
            }

            if (angleB.HasValue)
            {
                result.B = (double)angleB;
            }

            if (angleC.HasValue)
            {
                result.C = (double)angleC;
            }

            if (sideA.HasValue)
            {
                result.a = (double)sideA;
            }

            if (sideB.HasValue)
            {
                result.b = (double)sideB;
            }

            if (sideC.HasValue)
            {
                result.c = (double)sideC;
            }

            result = CalculateAnglesAndSides(result);
            return result;
        }

        private static bool IsAngleAndSidesCalculated(TriangleData result)
        {
            return !MathHelper.IsEqualToZero(result.A)
                && !MathHelper.IsEqualToZero(result.B)
                && !MathHelper.IsEqualToZero(result.C)
                && !MathHelper.IsEqualToZero(result.a)
                && !MathHelper.IsEqualToZero(result.b)
                && !MathHelper.IsEqualToZero(result.c);
        }

        /// <summary>
        /// Calculates the angles and sides.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <remarks>
        /// http://cossincalc.com/
        /// </remarks>
        private static TriangleData CalculateAnglesAndSides(TriangleData data)
        {
            // A
            if (MathHelper.IsEqualToZero(data.A))
            {
                if (!MathHelper.IsEqualToZero(data.B) && !MathHelper.IsEqualToZero(data.C))
                {
                    data.A = 180 - data.B - data.C;
                }
                else if (!MathHelper.IsEqualToZero(data.B) && !MathHelper.IsEqualToZero(data.a) && !MathHelper.IsEqualToZero(data.b))
                {
                    data.A = MathHelper.Asin(MathHelper.Sin(data.B) * data.a / data.b);
                }
                else if (!MathHelper.IsEqualToZero(data.B) && !MathHelper.IsEqualToZero(data.b) && !MathHelper.IsEqualToZero(data.c))
                {
                    if (MathHelper.IsEqualToZero(data.C))
                    {
                        data.C = MathHelper.Asin(MathHelper.Sin(data.B) * data.c / data.b);
                    }

                    data.A = 180 - data.B - data.C;
                }
                else if (!MathHelper.IsEqualToZero(data.B) && !MathHelper.IsEqualToZero(data.a) && !MathHelper.IsEqualToZero(data.c))
                {
                    double a2 = data.a * data.a;
                    double c2 = data.c * data.c;
                    if (MathHelper.IsEqualToZero(data.b))
                    {
                        data.b = System.Math.Sqrt(a2 + c2 - (2 * data.a * data.c * MathHelper.Cos(data.B)));
                    }

                    double b2 = data.b * data.b;
                    data.A = MathHelper.Acos((b2 + c2 - a2) / (2 * data.b * data.c));
                }
                else if (!MathHelper.IsEqualToZero(data.C) && !MathHelper.IsEqualToZero(data.a) && !MathHelper.IsEqualToZero(data.b))
                {
                    double a2 = data.a * data.a;
                    double b2 = data.b * data.b;
                    if (MathHelper.IsEqualToZero(data.c))
                    {
                        data.c = System.Math.Sqrt(a2 + b2 - (2 * data.a * data.b * MathHelper.Cos(data.C)));
                    }

                    double c2 = data.c * data.c;
                    data.A = MathHelper.Acos((b2 + c2 - a2) / (2 * data.b * data.c));
                }
                else if (!MathHelper.IsEqualToZero(data.C) && !MathHelper.IsEqualToZero(data.a) && !MathHelper.IsEqualToZero(data.c))
                {
                    if (MathHelper.IsEqualToZero(data.A))
                    {
                        data.A = MathHelper.Asin(MathHelper.Sin(data.C) * data.a / data.c);
                    }

                    data.B = 180 - data.A - data.C;
                }
                else if (!MathHelper.IsEqualToZero(data.C) && !MathHelper.IsEqualToZero(data.b) && !MathHelper.IsEqualToZero(data.c))
                {
                    if (MathHelper.IsEqualToZero(data.B))
                    {
                        data.B = MathHelper.Asin(MathHelper.Sin(data.C) * data.b / data.c);
                    }

                    data.A = 180 - data.B - data.C;
                }
                else
                {
                    throw new ArithmeticException("This scenario is not implemented yet.");
                }
            }

            // B
            if (MathHelper.IsEqualToZero(data.B))
            {
                if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.C))
                {
                    data.B = 180 - data.A - data.C;
                }
                else if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.a) && !MathHelper.IsEqualToZero(data.b))
                {
                    data.B = MathHelper.Asin(MathHelper.Sin(data.A) * data.b / data.a);
                }
                else if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.b) && !MathHelper.IsEqualToZero(data.c))
                {
                    double b2 = data.b * data.b;
                    double c2 = data.c * data.c;
                    if (MathHelper.IsEqualToZero(data.a))
                    {
                        data.a = System.Math.Sqrt(b2 + c2 - (2 * data.b * data.c * MathHelper.Cos(data.A)));
                    }

                    double a2 = data.a * data.a;
                    data.B = MathHelper.Acos((a2 + c2 - b2) / (2 * data.a * data.c));
                }
                else if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.a) && !MathHelper.IsEqualToZero(data.c))
                {
                    if (MathHelper.IsEqualToZero(data.C))
                    {
                        data.C = MathHelper.Asin(MathHelper.Sin(data.A) * data.c / data.a);
                    }

                    data.B = 180 - data.A - data.C;
                }
                else
                {
                    throw new ArithmeticException("This scenario is not implemented yet.");
                }
            }

            // C
            if (MathHelper.IsEqualToZero(data.C))
            {
                if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.B))
                {
                    data.C = 180 - data.A - data.B;
                }
                else
                {
                    throw new ArithmeticException("This scenario is not implemented yet.");
                }
            }

            // a
            if (MathHelper.IsEqualToZero(data.a))
            {
                if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.B) && !MathHelper.IsEqualToZero(data.b))
                {
                    data.a = MathHelper.Sin(data.A) * data.b / MathHelper.Sin(data.B);
                }
                else if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.C) && !MathHelper.IsEqualToZero(data.c))
                {
                    data.a = MathHelper.Sin(data.A) * data.c / MathHelper.Sin(data.C);
                }
                else
                {
                    throw new ArithmeticException("This scenario is not implemented yet.");
                }
            }

            // b
            if (MathHelper.IsEqualToZero(data.b))
            {
                if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.B) && !MathHelper.IsEqualToZero(data.a))
                {
                    data.b = MathHelper.Sin(data.B) * data.a / MathHelper.Sin(data.A);
                }
                else
                {
                    throw new ArithmeticException("This scenario is not implemented yet.");
                }
            }

            // c
            if (MathHelper.IsEqualToZero(data.c))
            {
                if (!MathHelper.IsEqualToZero(data.A) && !MathHelper.IsEqualToZero(data.C) && !MathHelper.IsEqualToZero(data.a))
                {
                    data.c = MathHelper.Sin(data.C) * data.a / MathHelper.Sin(data.A);
                }
                else
                {
                    throw new ArithmeticException("This scenario is not implemented yet.");
                }
            }

            return IsAngleAndSidesCalculated(data)
                ? data
                : CalculateAnglesAndSides(data);
        }
    }
}