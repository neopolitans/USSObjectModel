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
                    /// An Enum representation of all the keywords that the white-space style rule's value can be assigned.
                    /// </summary>
                    public enum WhitespaceValue
                    {
                        normal,
                        nowrap
                    }

                    /// <summary>
                    /// Convert the provided WhitespaceValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "normal" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this WhitespaceValue value)
                    {
                        return value switch
                        {
                            WhitespaceValue.normal => "normal",
                            WhitespaceValue.nowrap => "nowrap",
                            _ => "normal"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a WhitespaceValue enum value. <br></br>
                    /// Defaults to [WhitespaceValue.normal] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static WhitespaceValue ToWhitespaceValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "nowrap" => WhitespaceValue.normal,
                            "middle" => WhitespaceValue.nowrap,
                            _ => WhitespaceValue.normal
                        };
                    }

                    /// <summary>
                    /// Create a White Space Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to White Space. Restricted to only the compatible keywords.</param>
                    public static StyleRule Whitespace(WhitespaceValue keyword)
                    {
                        return new StyleRule(RuleType.whiteSpace, keyword.Name());
                    }
                }
            }
        }
    }
}