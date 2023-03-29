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
                    /// Create a padding-top style rule with a length value.
                    /// </summary>
                    /// <param name="length"></param>
                    /// <returns></returns> 
                    public static StyleRule PaddingTop(Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("padding-top rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.paddingTop, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.paddingTop, length.ToString());
                        }
                    }
                }
            }
        }
    }
}