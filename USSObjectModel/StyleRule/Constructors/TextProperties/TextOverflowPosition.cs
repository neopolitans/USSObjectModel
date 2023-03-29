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
                    /// An Enum representation of all the keywords that the -unity-text-overflow-position style rule's value can be assigned.
                    /// </summary>
                    public enum OverflowPositionValue
                    {
                        start,
                        middle,
                        end
                    }

                    /// <summary>
                    /// Convert the provided OverflowPositionValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "start" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this OverflowPositionValue value)
                    {
                        return value switch
                        {
                            OverflowPositionValue.start => "start",
                            OverflowPositionValue.middle => "middle",
                            OverflowPositionValue.end => "end",
                            _ => "start"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a OverflowPositionValue enum value. <br></br>
                    /// Defaults to [OverflowPositionValue.start] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static OverflowPositionValue ToOverflowPositionValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "start" => OverflowPositionValue.start,
                            "middle" => OverflowPositionValue.middle,
                            "end" => OverflowPositionValue.end,
                            _ => OverflowPositionValue.start
                        };
                    }

                    /// <summary>
                    /// Create a Unity Text Overflow Position Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Unity Text Overflow Position. Restricted to only the compatible keywords.</param>
                    public static StyleRule TextOverflowPosition(OverflowPositionValue keyword)
                    {
                        return new StyleRule(RuleType.unityTextOverflowPosition, keyword.Name());
                    }
                }
            }
        }
    }
}