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
                    /// Create a Unity-Slice-Bottom Style Rule with an integer value.
                    /// </summary>
                    public static StyleRule SliceBottom(int integer)
                    {
                        return new StyleRule(RuleType.unitySliceBottom, integer.ToString());
                    }
                }
            }
        }
    }
}