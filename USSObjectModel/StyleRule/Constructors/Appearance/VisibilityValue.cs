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
                    /// An Enum representation of core Visiblity keywords for style rules that only take <b>visible</b> or <b>hidden</b>. <br></br>
                    /// For Example:
                    /// </summary>
                    public enum VisibilityValue
                    {
                        visible,
                        hidden
                    }

                    /// <summary>
                    /// Convert the provided VisibilityValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "visible" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this VisibilityValue value)
                    {
                        return value switch
                        {
                            VisibilityValue.visible => "visible",
                            VisibilityValue.hidden => "hidden",
                            _ => "visible"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a VisibilityValue enum value. <br></br>
                    /// Defaults to [VisibilityValue.visible] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static VisibilityValue ToVisibilityValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "visible" => VisibilityValue.visible,
                            "hidden" => VisibilityValue.hidden,
                            _ => VisibilityValue.visible
                        };
                    }   
                }
            }
        }
    }
}