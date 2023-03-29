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
                    /// Create a Unity Text Outline Width Style Rule with a length value.
                    /// </summary>
                    public static StyleRule TextOutlineWidth(Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("-unity-text-outline-width rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.unityTextOutlineWidth, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.unityTextOutlineWidth, length.ToString());
                        }
                    }
                }
            }
        }
    }
}