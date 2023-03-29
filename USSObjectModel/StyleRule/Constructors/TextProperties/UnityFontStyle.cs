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
                    /// An Enum representation of all the keywords that the -unity-font-style style rule's value can be assigned.
                    /// </summary>
                    public enum FontStyleValue
                    {
                        /// <summary>
                        /// USS: "normal" keyword.
                        /// </summary>
                        normal,

                        /// <summary>
                        /// USS: "italic" keyword.
                        /// </summary>
                        italic,

                        /// <summary>
                        /// USS: "bold" keyword.
                        /// </summary>
                        bold,

                        /// <summary>
                        /// USS: "bold-and-italic" keyword.
                        /// </summary>
                        boldAndItalic
                    }

                    /// <summary>
                    /// Convert the provided FontStyleValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "normal" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this FontStyleValue value)
                    {
                        return value switch
                        {
                            FontStyleValue.normal => "normal",
                            FontStyleValue.italic => "italic",
                            FontStyleValue.bold => "bold",
                            FontStyleValue.boldAndItalic => "bold-and-italic",
                            _ => "normal"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a FontStyleValue enum value. <br></br>
                    /// Defaults to [FontStyleValue.normal] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static FontStyleValue ToFontStyleValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "normal" => FontStyleValue.normal,
                            "italic" => FontStyleValue.italic,
                            "bold" => FontStyleValue.bold,
                            "bold-and-italic" => FontStyleValue.boldAndItalic,
                            _ => FontStyleValue.normal
                        };
                    }

                    /// <summary>
                    /// Create a Unity Font Style Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Unity Font Style. Restricted to only the compatible keywords.</param>
                    public static StyleRule UnityFontStyle(FontStyleValue keyword)
                    {
                        return new StyleRule(RuleType.unityFontStyle, keyword.Name());
                    }

                }
            }
        }
    }
}