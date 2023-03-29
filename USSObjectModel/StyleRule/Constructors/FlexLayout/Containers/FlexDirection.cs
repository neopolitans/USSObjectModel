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
                    /// An Enum representation of all the keywords that the flex-direction style rule's value can be assigned.
                    /// </summary>
                    public enum FlexDirectionValue
                    {
                        /// <summary>
                        /// USS: "row" keyword.
                        /// </summary>
                        row,

                        /// <summary>
                        /// USS: "row-reverse" keyword.
                        /// </summary>
                        rowReverse,

                        /// <summary>
                        /// USS: "column" keyword.
                        /// </summary>
                        column,

                        /// <summary>
                        /// USS: "column-reverse" keyword.
                        /// </summary>
                        columnReverse
                    }

                    /// <summary>
                    /// Convert the provided FlexDirectionValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "row" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this FlexDirectionValue value)
                    {
                        return value switch
                        {
                            FlexDirectionValue.row => "row",
                            FlexDirectionValue.rowReverse => "row-reverse",
                            FlexDirectionValue.column => "column",
                            FlexDirectionValue.columnReverse => "column-reverse",
                            _ => "row"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into an FlexDirectionValue enum value. <br></br>
                    /// Defaults to [FlexDirectionValue.row] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static FlexDirectionValue ToFlexDirectionValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "row" => FlexDirectionValue.row,
                            "row-reverse" => FlexDirectionValue.rowReverse,
                            "column" => FlexDirectionValue.column,
                            "column-reverse" => FlexDirectionValue.columnReverse,
                            _ => FlexDirectionValue.row
                        };
                    }

                    /// <summary>
                    /// Create a Flex-Direction Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Flex Direction. Restricted to only the compatible keywords.</param>
                    public static StyleRule FlexDirection(FlexDirectionValue keyword)
                    {
                        return new StyleRule(RuleType.flexDirection, keyword.Name());
                    }
                
                }
            }
        }
    }
}