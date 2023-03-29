using Cappuccino.Core;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// This class defines any and every supported style rule constructor currently known.
                /// </summary>
                public static partial class Rules
                {
                    /// <summary>
                    /// An Enum representation of all the keywords that any style rule can be have, if they take purely alignment based keywords.
                    /// </summary>
                    public enum Alignment
                    {
                        /// <summary>
                        /// USS: "top" keyword.
                        /// </summary>
                        top,

                        /// <summary>
                        /// USS: "bottom" keyword.
                        /// </summary>
                        bottom,

                        /// <summary>
                        /// USS: "left" keyword.
                        /// </summary>
                        left,

                        /// <summary>
                        /// USS: "right" keyword.
                        /// </summary>
                        right,

                        /// <summary>
                        /// USS: "center" keyword.
                        /// </summary>
                        center
                    }

                    /// <summary>
                    /// An Enum representation of all the keywords that any style rule can be have, if they take purely alignment based keywords and multiple keyword values are provided. <br></br>
                    /// Used exclusively for background-position, due to restrictions.
                    /// </summary>
                    public enum AlignmentMultiple
                    {
                        /// <summary>
                        /// USS: "top" keyword.
                        /// </summary>
                        top,

                        /// <summary>
                        /// USS: "bottom" keyword.
                        /// </summary>
                        bottom,

                        /// <summary>
                        /// USS: "left" keyword.
                        /// </summary>
                        left,

                        /// <summary>
                        /// USS: "right" keyword.
                        /// </summary>
                        right
                    }

                    // ImageAlignment Methods and Extensions

                    /// <summary>
                    /// Convert the provided Alignment enum value to it's string representation in USS. <br></br>
                    /// Defaults to "top" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this Alignment value)
                    {
                        return value switch
                        {
                            Alignment.top => "top",
                            Alignment.bottom => "bottom",
                            Alignment.left => "left",
                            Alignment.right => "right",
                            Alignment.center => "center",
                            _ => "top"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a ToAlignment enum value. <br></br>
                    /// Defaults to [ToAlignment.top] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static Alignment ToAlignment(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "top" => Alignment.top,
                            "bottom" => Alignment.bottom,
                            "left" => Alignment.left,
                            "right" => Alignment.right,
                            "center" => Alignment.center,
                            _ => Alignment.top
                        };
                    }

                    /// <summary>
                    /// Whether or not the Alignment value is a horziontal value. (left or right) 
                    /// </summary>
                    public static bool IsHorizontal(this Alignment value)
                    {
                        return value is Alignment.left || value is Alignment.right;
                    }

                    /// <summary>
                    /// Whether or not the Alignment value is a vertical value. (top or bottom) 
                    /// </summary>
                    public static bool IsVertical(this Alignment value)
                    {
                        return value is Alignment.top || value is Alignment.bottom;
                    }

                    /// <summary>
                    /// Whether or not the current Alignment value conflicts with the comparative ImageAlignmentSingle value.
                    /// </summary>
                    public static bool Conflicts(this Alignment value, Alignment comparative)
                    {
                        return (value.IsVertical() && comparative.IsVertical()) || (value.IsHorizontal() && comparative.IsHorizontal());
                    }

                    // ImageAlignmentMultiple Methods and Extensions

                    /// <summary>
                    /// Convert the provided AlignmentMultiple enum value to it's string representation in USS. <br></br>
                    /// Defaults to "top" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this AlignmentMultiple value)
                    {
                        return value switch
                        {
                            AlignmentMultiple.top => "top",
                            AlignmentMultiple.bottom => "bottom",
                            AlignmentMultiple.left => "left",
                            AlignmentMultiple.right => "right",
                            _ => "top"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a AlignmentMultiple enum value. <br></br>
                    /// Defaults to [AlignmentMultiple.top] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static AlignmentMultiple ToAlignmentMultiple(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "top" => AlignmentMultiple.top,
                            "bottom" => AlignmentMultiple.bottom,
                            "left" => AlignmentMultiple.left,
                            "right" => AlignmentMultiple.right,
                            _ => AlignmentMultiple.top
                        };
                    }

                    /// <summary>
                    /// Whether or not the AlignmentMultiple value is a horziontal value. (left or right) 
                    /// </summary>
                    public static bool IsHorizontal(this AlignmentMultiple value)
                    {
                        return value is AlignmentMultiple.left || value is AlignmentMultiple.right;
                    }

                    /// <summary>
                    /// Whether or not the AlignmentMultiple value is a vertical value. (top or bottom) 
                    /// </summary>
                    public static bool IsVertical(this AlignmentMultiple value)
                    {
                        return value is AlignmentMultiple.top || value is AlignmentMultiple.bottom;
                    }

                    /// <summary>
                    /// Whether or not the current AlignmentMultiple value conflicts with the comparative AlignmentMultiple value.
                    /// </summary>
                    public static bool Conflicts(this AlignmentMultiple value, AlignmentMultiple comparative)
                    {
                        return (value.IsVertical() && comparative.IsVertical()) || (value.IsHorizontal() && comparative.IsHorizontal());
                    }

                    /// <summary>
                    /// Convert an AlignmentMultiple value to an Alignment value. <br></br>
                    /// <see langword="Cappuccino:"/> This is used for ImagePosition objects so that multiple images can be altered. <br></br>
                    /// Defaults to [Alignment.top] if an invalid value is provided.
                    /// </summary>
                    /// <param name="value">The ImageAlignmentMultiple value to convert.</param>
                    /// <returns><see cref="Alignment"/> equivalent value.</returns>
                    public static Alignment Convert(this AlignmentMultiple value)
                    {
                        return value switch
                        {
                            AlignmentMultiple.top => Alignment.top,
                            AlignmentMultiple.bottom => Alignment.bottom,
                            AlignmentMultiple.left => Alignment.left,
                            AlignmentMultiple.right => Alignment.right,
                            _ => Alignment.top
                        };
                    }
                }
            }
        }
    }
}