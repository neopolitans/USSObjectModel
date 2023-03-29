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
                    /// An Enum representation of all the keywords that the text-overflow style rule can be assigned.
                    /// </summary>
                    public enum OverflowDisplayType
                    {
                        clip,
                        elipsis
                    }

                    /// <summary>
                    /// Convert the provided OverflowDisplayType enum value to it's string representation in USS. <br></br>
                    /// Defaults to "elipsis" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this OverflowDisplayType value)
                    {
                        return value switch
                        {
                            OverflowDisplayType.clip => "clip",
                            OverflowDisplayType.elipsis => "elipsis",
                            _ => "elipsis"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a OverflowDisplayType enum value. <br></br>
                    /// Defaults to [OverflowDisplayType.elipsis] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static OverflowDisplayType ToOverflowDisplayType(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "clip" => OverflowDisplayType.clip,
                            "elipsis" => OverflowDisplayType.elipsis,
                            _ => OverflowDisplayType.elipsis
                        };
                    }

                    /// <summary>
                    /// Create a Text Overflow Style Rule with a keyword value.<br></br><br></br>
                    /// <b><see langword="Notice:"/></b> The usage of this style rule is inferred from <see langword="MDN CSS Documentation"/>. Experimental features (e.g. the fade function) were not included as a precaution. <br></br>
                    /// <b><i>That is to say, it might not work as intended.</i></b>
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Unity Text Overflow Position. Restricted to only the compatible keywords.</param>
                    public static StyleRule TextOverflow(OverflowDisplayType keyword)
                    {
                        return new StyleRule(RuleType.textOverflow, keyword.Name());
                    }
                }
            }
        }
    }
}