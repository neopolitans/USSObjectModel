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
                    /// An Enum representation of all the keywords that the -unity-text-align style rule's value can be assigned.
                    /// </summary>
                    public enum TextAlignValue
                    {
                        /// <summary>
                        /// USS: "upper-left" keyword.
                        /// </summary>
                        upperLeft,

                        /// <summary>
                        /// USS: "middle-left" keyword.
                        /// </summary>
                        middleLeft,

                        /// <summary>
                        /// USS: "lower-left" keyword.
                        /// </summary>
                        lowerLeft,

                        /// <summary>
                        /// USS: "upper-center" keyword.
                        /// </summary>
                        upperCenter,

                        /// <summary>
                        /// USS: "middle-center" keyword.
                        /// </summary>
                        middleCenter,

                        /// <summary>
                        /// USS: "lower-center" keyword.
                        /// </summary>
                        lowerCenter,

                        /// <summary>
                        /// USS: "upper-right" keyword.
                        /// </summary>
                        upperRight,

                        /// <summary>
                        /// USS: "middle-right" keyword.
                        /// </summary>
                        middleRight,

                        /// <summary>
                        /// USS: "lower-right" keyword.
                        /// </summary>
                        lowerRight
                    }

                    /// <summary>
                    /// Convert the provided TextAlignValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "upper-left" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this TextAlignValue value)
                    {
                        return value switch
                        {
                            TextAlignValue.upperLeft => "upper-left",
                            TextAlignValue.middleLeft => "middle-left",
                            TextAlignValue.lowerLeft => "lower-left",
                            TextAlignValue.upperCenter => "upper-center",
                            TextAlignValue.middleCenter => "middle-center",
                            TextAlignValue.lowerCenter => "lower-center",
                            TextAlignValue.upperRight => "upper-right",
                            TextAlignValue.middleRight => "middle-right",
                            TextAlignValue.lowerRight => "lower-right",
                            _ => "upper-left"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a TextAlignValue enum value. <br></br>
                    /// Defaults to [TextAlignValue.upperLeft] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static TextAlignValue ToTextAlignValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "upper-left" => TextAlignValue.upperLeft,
                            "middle-left" => TextAlignValue.middleLeft,
                            "lower-left" => TextAlignValue.lowerLeft,
                            "upper-center" => TextAlignValue.upperCenter,
                            "middle-center" => TextAlignValue.middleCenter,
                            "lower-center" => TextAlignValue.lowerCenter,
                            "upper-right" => TextAlignValue.upperRight,
                            "middle-right" => TextAlignValue.middleRight,
                            "lower-right" => TextAlignValue.lowerRight,
                            _ => TextAlignValue.upperLeft
                        };
                    }

                    /// <summary>
                    /// Create a Unity Text Align Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Justify Content. Restricted to only the compatible keywords.</param>
                    public static StyleRule TextAlign(TextAlignValue keyword)
                    {
                        return new StyleRule(RuleType.unityTextAlign, keyword.Name());
                    }
                }
            }
        }
    }
}