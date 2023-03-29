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
                    /// An Enum representation of all the keywords that the justify-content style rule's value can be assigned.
                    /// </summary>
                    public enum JustifyContentValue
                    {
                        /// <summary>
                        /// USS: "flex-start" keyword.
                        /// </summary>
                        flexStart,

                        /// <summary>
                        /// USS: "flex-end" keyword.
                        /// </summary>
                        flexEnd,

                        /// <summary>
                        /// USS: "center" keyword.
                        /// </summary>
                        center,

                        /// <summary>
                        /// USS: "space-around" keyword.
                        /// </summary>
                        spaceAround,

                        /// <summary>
                        /// USS: "space-between" keyword.
                        /// </summary>
                        spaceBetween
                    }

                    /// <summary>
                    /// Convert the provided JustifyContentValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "flex-start" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this JustifyContentValue value)
                    {
                        return value switch
                        {
                            JustifyContentValue.flexStart => "flex-start",
                            JustifyContentValue.flexEnd => "flex-end",
                            JustifyContentValue.center => "center",
                            JustifyContentValue.spaceBetween => "space-between",
                            JustifyContentValue.spaceAround => "space-around",
                            _ => "flex-start"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a JustifyContentValue enum value. <br></br>
                    /// Defaults to [JustifyContentValue.flexStart] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static JustifyContentValue ToJustifyContentValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "flex-start" => JustifyContentValue.flexStart,
                            "flex-end" => JustifyContentValue.flexEnd,
                            "center" => JustifyContentValue.center,
                            "space-between" => JustifyContentValue.spaceBetween,
                            "space-around" => JustifyContentValue.spaceAround,
                            _ => JustifyContentValue.flexStart
                        };
                    }

                    /// <summary>
                    /// Create a Justify-Content Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Justify Content. Restricted to only the compatible keywords.</param>
                    public static StyleRule JustifyContent(JustifyContentValue keyword)
                    {
                        return new StyleRule(RuleType.justifyContent, keyword.Name());
                    }
                }
            }
        }
    }
}