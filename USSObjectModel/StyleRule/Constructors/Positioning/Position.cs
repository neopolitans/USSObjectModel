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
                    /// An Enum representation of all the keywords that the position style rule's value can be assigned.
                    /// </summary>
                    public enum PositionValue
                    {
                        /// <summary>
                        /// USS: "relative" keyword. <br></br>
                        /// <see langword="USS Docs:"/> 'relative' is the default value which positions the element based on it's parent.
                        /// </summary>
                        relative,

                        /// <summary>
                        /// USS: "absolute" keyword. <br></br>
                        /// <see langword="USS Docs:"/> 'absolute' positions the element based on the parent bounds, leaving than the parent element.
                        /// </summary>
                        absolute
                    }

                    /// <summary>
                    /// Convert the provided PositionValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "relative" if an invalid value is prvoided. <br></br><br></br>
                    /// <see langword="USS Docs:"/> 'relative' is the default value which positions the element based on it's parent.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this PositionValue value)
                    {
                        return value switch
                        {
                            PositionValue.relative => "relative",
                            PositionValue.absolute => "absolute",
                            _ => "relative"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a PositionValue enum value. <br></br>
                    /// Defaults to [PositionValue.relative] if an invalid value is provided.<br></br><br></br>
                    /// <see langword="USS Docs:"/> 'relative' is the default value which positions the element based on it's parent.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static PositionValue ToPositionValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "relative" => PositionValue.relative,
                            "absolute" => PositionValue.absolute,
                            _ => PositionValue.relative
                        };
                    }

                    /// <summary>
                    /// Create a Position Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Position. Restricted to only the compatible keywords.</param>
                    public static StyleRule Position(PositionValue keyword)
                    {
                        return new StyleRule(RuleType.position, keyword.Name());
                    }
                }
            }
        }
    }
}