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
                    /// An Enum representation of all the keywords that the flex-wrap style rule's value can be assigned.
                    /// </summary>
                    public enum FlexWrapValue
                    {
                        /// <summary>
                        /// USS: "nowrap" keyword
                        /// </summary>
                        noWrap,

                        /// <summary>
                        /// USS: "wrap" keyword
                        /// </summary>
                        wrap,

                        /// <summary>
                        /// USS: "wrap-reverse" keyword.
                        /// </summary>
                        wrapReverse
                    }

                    /// <summary>
                    /// Convert the provided FlexWrapValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "nowrap" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this FlexWrapValue value)
                    {
                        return value switch
                        {
                            FlexWrapValue.noWrap => "nowrap",
                            FlexWrapValue.wrap => "wrap",
                            FlexWrapValue.wrapReverse => "wrap-reverse",
                            _ => "nowrap"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into an FlexWrapValue enum value. <br></br>
                    /// Defaults to [FlexWrapValue.noWrap] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static FlexWrapValue ToFlexWrapValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "nowrap" => FlexWrapValue.noWrap,
                            "wrap" => FlexWrapValue.wrap,
                            "wrap-reverse" => FlexWrapValue.wrapReverse,
                            _ => FlexWrapValue.noWrap
                        };
                    }

                    /// <summary>
                    /// Create a Flex-Wrap Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Flex Direction. Restricted to only the compatible keywords.</param>
                    public static StyleRule FlexWrap(FlexWrapValue keyword)
                    {
                        return new StyleRule(RuleType.flexWrap, keyword.Name());
                    }

                }
            }
        }
    }
}