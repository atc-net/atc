using System;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable InvertIf
// ReSharper disable SwitchStatementMissingSomeEnumCasesNoDefault
// ReSharper disable once CheckNamespace
namespace Atc.Helpers
{
    /// <summary>
    /// Enumeration Helper: CardinalDirectionTypeHelper.
    /// </summary>
    public static class CardinalDirectionTypeHelper
    {
        /// <summary>
        /// Gets the when rotate right.
        /// </summary>
        /// <param name="cardinalDirectionTypeToInclude">The cardinal direction type to include.</param>
        /// <param name="cardinalDirectionType">Type of the cardinal direction.</param>
        /// <param name="rotationNumber">The rotation number.</param>
        public static CardinalDirectionType GetWhenRotateRight(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType, int rotationNumber)
        {
            if (rotationNumber < 1)
            {
                // ReSharper disable once LocalizableElement
                throw new ArgumentException("Number have to be grater then 0", nameof(rotationNumber));
            }

            var tmp = cardinalDirectionType;
            for (var i = 0; i < rotationNumber; i++)
            {
                tmp = GetWhenRotateRight(cardinalDirectionTypeToInclude, tmp);
            }

            return tmp;
        }

        /// <summary>
        /// Gets the when rotate right.
        /// </summary>
        /// <param name="cardinalDirectionTypeToInclude">The cardinal direction type to include.</param>
        /// <param name="cardinalDirectionType">Type of the cardinal direction.</param>
        public static CardinalDirectionType GetWhenRotateRight(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
        {
            var returnValue = CardinalDirectionType.None;
            if (cardinalDirectionTypeToInclude == CardinalDirectionType.Simple ||
                cardinalDirectionTypeToInclude == CardinalDirectionType.Medium ||
                cardinalDirectionTypeToInclude == CardinalDirectionType.Advanced)
            {
                switch (cardinalDirectionTypeToInclude)
                {
                    case CardinalDirectionType.Simple:
                        returnValue = cardinalDirectionType switch
                        {
                            CardinalDirectionType.North => CardinalDirectionType.East,
                            CardinalDirectionType.East => CardinalDirectionType.South,
                            CardinalDirectionType.South => CardinalDirectionType.West,
                            CardinalDirectionType.West => CardinalDirectionType.North,
                            _ => returnValue
                        };

                        break;
                    case CardinalDirectionType.Medium:
                        returnValue = cardinalDirectionType switch
                        {
                            CardinalDirectionType.North => CardinalDirectionType.NorthEast,
                            CardinalDirectionType.NorthEast => CardinalDirectionType.East,
                            CardinalDirectionType.East => CardinalDirectionType.SouthEast,
                            CardinalDirectionType.SouthEast => CardinalDirectionType.South,
                            CardinalDirectionType.South => CardinalDirectionType.SouthWest,
                            CardinalDirectionType.SouthWest => CardinalDirectionType.West,
                            CardinalDirectionType.West => CardinalDirectionType.NorthWest,
                            CardinalDirectionType.NorthWest => CardinalDirectionType.North,
                            _ => returnValue
                        };

                        break;
                    case CardinalDirectionType.Advanced:
                        returnValue = cardinalDirectionType switch
                        {
                            CardinalDirectionType.North => CardinalDirectionType.NorthNorthEast,
                            CardinalDirectionType.NorthNorthEast => CardinalDirectionType.NorthEast,
                            CardinalDirectionType.NorthEast => CardinalDirectionType.EastNorthEast,
                            CardinalDirectionType.EastNorthEast => CardinalDirectionType.East,
                            CardinalDirectionType.East => CardinalDirectionType.EastSouthEast,
                            CardinalDirectionType.EastSouthEast => CardinalDirectionType.SouthEast,
                            CardinalDirectionType.SouthEast => CardinalDirectionType.SouthSouthEast,
                            CardinalDirectionType.SouthSouthEast => CardinalDirectionType.South,
                            CardinalDirectionType.South => CardinalDirectionType.SouthSouthWest,
                            CardinalDirectionType.SouthSouthWest => CardinalDirectionType.SouthWest,
                            CardinalDirectionType.SouthWest => CardinalDirectionType.WestSouthWest,
                            CardinalDirectionType.WestSouthWest => CardinalDirectionType.West,
                            CardinalDirectionType.West => CardinalDirectionType.WestNorthWest,
                            CardinalDirectionType.WestNorthWest => CardinalDirectionType.NorthWest,
                            CardinalDirectionType.NorthWest => CardinalDirectionType.NorthNorthWest,
                            CardinalDirectionType.NorthNorthWest => CardinalDirectionType.North,
                            _ => returnValue
                        };

                        break;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the when rotate left.
        /// </summary>
        /// <param name="cardinalDirectionTypeToInclude">The cardinal direction type to include.</param>
        /// <param name="cardinalDirectionType">Type of the cardinal direction.</param>
        /// <param name="rotationNumber">The rotation number.</param>
        public static CardinalDirectionType GetWhenRotateLeft(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType, int rotationNumber)
        {
            if (rotationNumber < 1)
            {
                // ReSharper disable once LocalizableElement
                throw new ArgumentException("Number have to be grater then 0", nameof(rotationNumber));
            }

            var tmp = cardinalDirectionType;
            for (var i = 0; i < rotationNumber; i++)
            {
                tmp = GetWhenRotateLeft(cardinalDirectionTypeToInclude, tmp);
            }

            return tmp;
        }

        /// <summary>
        /// Gets the when rotate left.
        /// </summary>
        /// <param name="cardinalDirectionTypeToInclude">The cardinal direction type to include.</param>
        /// <param name="cardinalDirectionType">Type of the cardinal direction.</param>
        [SuppressMessage("Major Code Smell", "S2589:Boolean expressions should not be gratuitous", Justification = "OK.")]
        public static CardinalDirectionType GetWhenRotateLeft(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
        {
            var returnValue = CardinalDirectionType.None;
            if (cardinalDirectionTypeToInclude == CardinalDirectionType.Simple ||
                cardinalDirectionTypeToInclude == CardinalDirectionType.Medium ||
                cardinalDirectionTypeToInclude == CardinalDirectionType.Advanced)
            {
                if (cardinalDirectionTypeToInclude == CardinalDirectionType.Simple)
                {
                    returnValue = cardinalDirectionType switch
                    {
                        CardinalDirectionType.North => CardinalDirectionType.West,
                        CardinalDirectionType.West => CardinalDirectionType.South,
                        CardinalDirectionType.South => CardinalDirectionType.East,
                        CardinalDirectionType.East => CardinalDirectionType.North,
                        _ => returnValue
                    };
                }
                else if (cardinalDirectionTypeToInclude == CardinalDirectionType.Medium)
                {
                    returnValue = cardinalDirectionType switch
                    {
                        CardinalDirectionType.North => CardinalDirectionType.NorthWest,
                        CardinalDirectionType.NorthWest => CardinalDirectionType.West,
                        CardinalDirectionType.West => CardinalDirectionType.SouthWest,
                        CardinalDirectionType.SouthWest => CardinalDirectionType.South,
                        CardinalDirectionType.South => CardinalDirectionType.SouthEast,
                        CardinalDirectionType.SouthEast => CardinalDirectionType.East,
                        CardinalDirectionType.East => CardinalDirectionType.NorthEast,
                        CardinalDirectionType.NorthEast => CardinalDirectionType.North,
                        _ => returnValue
                    };
                }
                else if (cardinalDirectionTypeToInclude == CardinalDirectionType.Advanced)
                {
                    returnValue = cardinalDirectionType switch
                    {
                        CardinalDirectionType.North => CardinalDirectionType.NorthNorthWest,
                        CardinalDirectionType.NorthNorthWest => CardinalDirectionType.NorthWest,
                        CardinalDirectionType.NorthWest => CardinalDirectionType.WestNorthWest,
                        CardinalDirectionType.WestNorthWest => CardinalDirectionType.West,
                        CardinalDirectionType.West => CardinalDirectionType.WestSouthWest,
                        CardinalDirectionType.WestSouthWest => CardinalDirectionType.SouthWest,
                        CardinalDirectionType.SouthWest => CardinalDirectionType.SouthSouthWest,
                        CardinalDirectionType.SouthSouthWest => CardinalDirectionType.South,
                        CardinalDirectionType.South => CardinalDirectionType.SouthSouthEast,
                        CardinalDirectionType.SouthSouthEast => CardinalDirectionType.SouthEast,
                        CardinalDirectionType.SouthEast => CardinalDirectionType.EastSouthEast,
                        CardinalDirectionType.EastSouthEast => CardinalDirectionType.East,
                        CardinalDirectionType.East => CardinalDirectionType.EastNorthEast,
                        CardinalDirectionType.EastNorthEast => CardinalDirectionType.NorthEast,
                        CardinalDirectionType.NorthEast => CardinalDirectionType.NorthNorthEast,
                        CardinalDirectionType.NorthNorthEast => CardinalDirectionType.North,
                        _ => returnValue
                    };
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the when rotate180.
        /// </summary>
        /// <param name="cardinalDirectionTypeToInclude">The cardinal direction type to include.</param>
        /// <param name="cardinalDirectionType">Type of the cardinal direction.</param>
        [SuppressMessage("Major Code Smell", "S2589:Boolean expressions should not be gratuitous", Justification = "OK.")]
        public static CardinalDirectionType GetWhenRotate180(CardinalDirectionType cardinalDirectionTypeToInclude, CardinalDirectionType cardinalDirectionType)
        {
            var returnValue = CardinalDirectionType.None;
            if (cardinalDirectionTypeToInclude == CardinalDirectionType.Simple ||
                cardinalDirectionTypeToInclude == CardinalDirectionType.Medium ||
                cardinalDirectionTypeToInclude == CardinalDirectionType.Advanced)
            {
                if (cardinalDirectionTypeToInclude == CardinalDirectionType.Simple)
                {
                    returnValue = cardinalDirectionType switch
                    {
                        CardinalDirectionType.North => CardinalDirectionType.South,
                        CardinalDirectionType.East => CardinalDirectionType.West,
                        CardinalDirectionType.South => CardinalDirectionType.North,
                        CardinalDirectionType.West => CardinalDirectionType.East,
                        _ => returnValue
                    };
                }
                else if (cardinalDirectionTypeToInclude == CardinalDirectionType.Medium)
                {
                    returnValue = cardinalDirectionType switch
                    {
                        CardinalDirectionType.North => CardinalDirectionType.South,
                        CardinalDirectionType.NorthEast => CardinalDirectionType.SouthWest,
                        CardinalDirectionType.East => CardinalDirectionType.West,
                        CardinalDirectionType.SouthEast => CardinalDirectionType.NorthWest,
                        CardinalDirectionType.South => CardinalDirectionType.North,
                        CardinalDirectionType.SouthWest => CardinalDirectionType.NorthEast,
                        CardinalDirectionType.West => CardinalDirectionType.East,
                        CardinalDirectionType.NorthWest => CardinalDirectionType.SouthEast,
                        _ => returnValue
                    };
                }
                else if (cardinalDirectionTypeToInclude == CardinalDirectionType.Advanced)
                {
                    returnValue = cardinalDirectionType switch
                    {
                        CardinalDirectionType.North => CardinalDirectionType.South,
                        CardinalDirectionType.NorthNorthEast => CardinalDirectionType.SouthSouthWest,
                        CardinalDirectionType.NorthEast => CardinalDirectionType.SouthWest,
                        CardinalDirectionType.EastNorthEast => CardinalDirectionType.WestSouthWest,
                        CardinalDirectionType.East => CardinalDirectionType.West,
                        CardinalDirectionType.EastSouthEast => CardinalDirectionType.WestNorthWest,
                        CardinalDirectionType.SouthEast => CardinalDirectionType.NorthWest,
                        CardinalDirectionType.SouthSouthEast => CardinalDirectionType.NorthNorthWest,
                        CardinalDirectionType.South => CardinalDirectionType.North,
                        CardinalDirectionType.SouthSouthWest => CardinalDirectionType.NorthNorthEast,
                        CardinalDirectionType.SouthWest => CardinalDirectionType.NorthEast,
                        CardinalDirectionType.WestSouthWest => CardinalDirectionType.EastNorthEast,
                        CardinalDirectionType.West => CardinalDirectionType.East,
                        CardinalDirectionType.WestNorthWest => CardinalDirectionType.EastSouthEast,
                        CardinalDirectionType.NorthWest => CardinalDirectionType.SouthEast,
                        CardinalDirectionType.NorthNorthWest => CardinalDirectionType.SouthSouthEast,
                        _ => returnValue
                    };
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Gets the closest by angle.
        /// </summary>
        /// <param name="combinedCardinalDirectionType">Type of the combined cardinal direction.</param>
        /// <param name="angle">The angle.</param>
        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static CardinalDirectionType GetTheClosestByAngle(CardinalDirectionType combinedCardinalDirectionType, double angle)
        {
            if (angle < 0 || angle > 360)
            {
                throw new ArgumentOutOfRangeException("Angle: " + angle);
            }

            switch (combinedCardinalDirectionType)
            {
                case CardinalDirectionType.Simple:
                    if (angle > 315 || angle <= 45)
                    {
                        return CardinalDirectionType.East;
                    }

                    if (angle > 45 && angle <= 135)
                    {
                        return CardinalDirectionType.South;
                    }

                    if (angle > 135 && angle <= 225)
                    {
                        return CardinalDirectionType.West;
                    }

                    if (angle > 225 && angle <= 315)
                    {
                        return CardinalDirectionType.North;
                    }

                    break;
                case CardinalDirectionType.Medium:
                    if (angle > 337.5 || angle <= 22.5)
                    {
                        return CardinalDirectionType.East;
                    }

                    if (angle > 22.5 && angle <= 67.5)
                    {
                        return CardinalDirectionType.SouthEast;
                    }

                    if (angle > 67.5 && angle <= 112.5)
                    {
                        return CardinalDirectionType.South;
                    }

                    if (angle > 112.5 && angle <= 157.5)
                    {
                        return CardinalDirectionType.SouthWest;
                    }

                    if (angle > 157.5 && angle <= 202.5)
                    {
                        return CardinalDirectionType.West;
                    }

                    if (angle > 202.5 && angle <= 247.5)
                    {
                        return CardinalDirectionType.NorthWest;
                    }

                    if (angle > 247.5 && angle <= 292.5)
                    {
                        return CardinalDirectionType.North;
                    }

                    if (angle > 292.5 && angle <= 337.5)
                    {
                        return CardinalDirectionType.NorthEast;
                    }

                    break;
                case CardinalDirectionType.Advanced:
                    if (angle > 348.75 || angle <= 11.25)
                    {
                        return CardinalDirectionType.East;
                    }

                    if (angle > 11.25 && angle <= 33.75)
                    {
                        return CardinalDirectionType.EastSouthEast;
                    }

                    if (angle > 33.75 && angle <= 56.25)
                    {
                        return CardinalDirectionType.SouthEast;
                    }

                    if (angle > 56.25 && angle <= 78.75)
                    {
                        return CardinalDirectionType.SouthSouthEast;
                    }

                    if (angle > 78.75 && angle <= 101.25)
                    {
                        return CardinalDirectionType.South;
                    }

                    if (angle > 101.25 && angle <= 123.75)
                    {
                        return CardinalDirectionType.SouthSouthWest;
                    }

                    if (angle > 123.75 && angle <= 146.25)
                    {
                        return CardinalDirectionType.SouthWest;
                    }

                    if (angle > 146.25 && angle <= 168.75)
                    {
                        return CardinalDirectionType.WestSouthWest;
                    }

                    if (angle > 168.75 && angle <= 191.25)
                    {
                        return CardinalDirectionType.West;
                    }

                    if (angle > 191.25 && angle <= 213.75)
                    {
                        return CardinalDirectionType.WestNorthWest;
                    }

                    if (angle > 213.75 && angle <= 236.25)
                    {
                        return CardinalDirectionType.NorthWest;
                    }

                    if (angle > 236.25 && angle <= 258.75)
                    {
                        return CardinalDirectionType.NorthNorthWest;
                    }

                    if (angle > 258.75 && angle <= 281.25)
                    {
                        return CardinalDirectionType.North;
                    }

                    if (angle > 281.25 && angle <= 303.75)
                    {
                        return CardinalDirectionType.NorthNorthEast;
                    }

                    if (angle > 303.75 && angle <= 326.25)
                    {
                        return CardinalDirectionType.NorthEast;
                    }

                    if (angle > 326.25 && angle <= 348.75)
                    {
                        return CardinalDirectionType.EastNorthEast;
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException("CombinedCardinalDirectionType: " + combinedCardinalDirectionType);
            }

            return CardinalDirectionType.None;
        }

        /// <summary>
        /// Gets the by rotation number clockwise using medium.
        /// </summary>
        /// <param name="rotationNumber">The rotation number.</param>
        /// <remarks>
        /// 0 => North
        /// 1 => NorthEast
        /// 2 => East
        /// 3 => SouthEast
        /// 4 => South
        /// 5 => SouthWest
        /// 6 => West
        /// 7 => NorthWest.
        /// </remarks>
        public static CardinalDirectionType GetByRotationNumberClockwiseUsingMedium(int rotationNumber)
        {
            if (rotationNumber < 0 || rotationNumber > 7)
            {
                throw new ArgumentOutOfRangeException("RotationNumber should be between/include 0 and 7: " + rotationNumber);
            }

            var tmp1 = GetTheClosestByAngle(CardinalDirectionType.Medium, rotationNumber * 45);
            return GetWhenRotateLeft(CardinalDirectionType.Medium, tmp1, 2);
        }

        /// <summary>
        /// Gets the target cardinal direction by grid cells.
        /// </summary>
        /// <param name="sourceGridCell">The source grid cell.</param>
        /// <param name="targetGridCell">The target grid cell.</param>
        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static CardinalDirectionType GetTargetCardinalDirectionByGridCells(GridCell sourceGridCell, GridCell targetGridCell)
        {
            if (targetGridCell.X < sourceGridCell.X && targetGridCell.Y < sourceGridCell.Y)
            {
                return CardinalDirectionType.NorthWest;
            }

            if (targetGridCell.X == sourceGridCell.X && targetGridCell.Y < sourceGridCell.Y)
            {
                return CardinalDirectionType.North;
            }

            if (targetGridCell.X > sourceGridCell.X && targetGridCell.Y < sourceGridCell.Y)
            {
                return CardinalDirectionType.NorthEast;
            }

            if (targetGridCell.X < sourceGridCell.X && targetGridCell.Y == sourceGridCell.Y)
            {
                return CardinalDirectionType.West;
            }

            if (targetGridCell.X > sourceGridCell.X && targetGridCell.Y == sourceGridCell.Y)
            {
                return CardinalDirectionType.East;
            }

            if (targetGridCell.X < sourceGridCell.X && targetGridCell.Y > sourceGridCell.Y)
            {
                return CardinalDirectionType.SouthWest;
            }

            if (targetGridCell.X == sourceGridCell.X && targetGridCell.Y > sourceGridCell.Y)
            {
                return CardinalDirectionType.South;
            }

            if (targetGridCell.X > sourceGridCell.X && targetGridCell.Y > sourceGridCell.Y)
            {
                return CardinalDirectionType.SouthEast;
            }

            return CardinalDirectionType.None;
        }

        /// <summary>
        /// Gets the target cardinal direction by point2 ds.
        /// </summary>
        /// <param name="sourceGridCell">The source grid cell.</param>
        /// <param name="targetGridCell">The target grid cell.</param>
        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static CardinalDirectionType GetTargetCardinalDirectionByPoint2Ds(Point2D sourceGridCell, Point2D targetGridCell)
        {
            if (targetGridCell.X < sourceGridCell.X && targetGridCell.Y < sourceGridCell.Y)
            {
                return CardinalDirectionType.NorthWest;
            }

            if (targetGridCell.X.IsEqual(sourceGridCell.X) && targetGridCell.Y < sourceGridCell.Y)
            {
                return CardinalDirectionType.North;
            }

            if (targetGridCell.X > sourceGridCell.X && targetGridCell.Y < sourceGridCell.Y)
            {
                return CardinalDirectionType.NorthEast;
            }

            if (targetGridCell.X < sourceGridCell.X && targetGridCell.Y.IsEqual(sourceGridCell.Y))
            {
                return CardinalDirectionType.West;
            }

            if (targetGridCell.X > sourceGridCell.X && targetGridCell.Y.IsEqual(sourceGridCell.Y))
            {
                return CardinalDirectionType.East;
            }

            if (targetGridCell.X < sourceGridCell.X && targetGridCell.Y > sourceGridCell.Y)
            {
                return CardinalDirectionType.SouthWest;
            }

            if (targetGridCell.X.IsEqual(sourceGridCell.X) && targetGridCell.Y > sourceGridCell.Y)
            {
                return CardinalDirectionType.South;
            }

            if (targetGridCell.X > sourceGridCell.X && targetGridCell.Y > sourceGridCell.Y)
            {
                return CardinalDirectionType.SouthEast;
            }

            return CardinalDirectionType.None;
        }
    }
}