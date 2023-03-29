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
                    /// An Enum representation of all the keywords that the display style rule's value can be assigned.
                    /// </summary>
                    public enum DisplayValue
                    {
                        /// <summary>
                        /// USS: "flex" keyword.
                        /// </summary>
                        flex,

                        /// <summary>
                        /// USS: "none" keyword.
                        /// </summary>
                        none
                    }

                    /// <summary>
                    /// Convert the provided DisplayValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "flex" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this DisplayValue value)
                    {
                        return value switch
                        {
                            DisplayValue.flex => "flex",
                            DisplayValue.none => "none",
                            _ => "flex"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a DisplayValue enum value. <br></br>
                    /// Defaults to [DisplayValue.flex] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static DisplayValue ToDisplayValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "flex" => DisplayValue.flex,
                            "none" => DisplayValue.none,
                            _ => DisplayValue.flex
                        };
                    }

                    /// <summary>
                    /// Create a Display Style Rule with a keyword value. <br></br><br></br>
                    /// <see langword="Unity USS:"/> Setting the value to 'none' removes the visual element.<br></br>
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Justify Content. Restricted to only the compatible keywords.</param>
                    public static StyleRule Display(DisplayValue keyword)
                    {
                        return new StyleRule(RuleType.display, keyword.Name());
                    }
                }
            }
        }
    }
}