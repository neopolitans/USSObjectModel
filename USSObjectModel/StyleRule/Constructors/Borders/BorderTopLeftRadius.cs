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
                    /// Create a Border-Top-Left-Radius Style Rule with a length value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    public static StyleRule BorderTopLeftRadius(Len length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("border-top-left-radius rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.borderTopLeftRadius, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.borderTopLeftRadius, length.ToString());
                        }
                    }
                }
            }
        }
    }
}