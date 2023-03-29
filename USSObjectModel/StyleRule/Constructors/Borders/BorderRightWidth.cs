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
                /// This class defines any and every supported style rule constructor currently known. <br></br>
                /// </summary>
                public static partial class Rules
                {
                    /// <summary>
                    /// Create a border-right-width style rule with a length value.
                    /// </summary>
                    /// <param name="length"></param>
                    /// <returns></returns>
                    public static StyleRule BorderRightWidth(Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("border-right-width rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.borderRightWidth, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.borderRightWidth, length.ToString());
                        }
                    }
                }
            }
        }
    }
}