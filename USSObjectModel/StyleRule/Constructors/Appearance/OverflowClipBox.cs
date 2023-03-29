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
                    /// An Enum representation of all the keywords that the -unity-overflow-clip-box style rule's value can be assigned.
                    /// </summary>
                    public enum OverflowClipBoxValue
                    {
                        /// <summary>
                        /// USS: "padding-box" keyword.
                        /// </summary>
                        paddingBox,

                        /// <summary>
                        /// USS: "content-box" keyword.
                        /// </summary>
                        contentBox
                    }

                    /// <summary>
                    /// Convert the provided OverflowClipBoxValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "padding-box" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this OverflowClipBoxValue value)
                    {
                        return value switch
                        {
                            OverflowClipBoxValue.paddingBox => "padding-box",
                            OverflowClipBoxValue.contentBox => "content-box",
                            _ => "padding-box"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a OverflowClipBoxValue enum value. <br></br>
                    /// Defaults to [OverflowClipBoxValue.paddingBox] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static OverflowClipBoxValue ToOverflowClipBoxValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "padding-box" => OverflowClipBoxValue.paddingBox,
                            "content-box" => OverflowClipBoxValue.contentBox,
                            _ => OverflowClipBoxValue.paddingBox
                        };
                    }

                    /// <summary>
                    /// Create a Unity Overflow Clip Box Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Unity Overflow Clip Box. Restricted to only the compatible keywords.</param>
                    public static StyleRule OverflowClipBox(OverflowClipBoxValue keyword)
                    {
                        return new StyleRule(RuleType.unityOverflowClipBox, keyword.Name());
                    }
                }
            }
        }
    }
}