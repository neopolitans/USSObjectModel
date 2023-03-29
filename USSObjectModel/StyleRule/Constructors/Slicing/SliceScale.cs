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
                    /// Create a Unity-Slice-Scale Style Rule with a length value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    public static StyleRule SliceScale(Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("-unity-slice-scale rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.unitySliceScale, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.unitySliceScale, length.ToString());
                        }
                    }
                }
            }
        }
    }
}