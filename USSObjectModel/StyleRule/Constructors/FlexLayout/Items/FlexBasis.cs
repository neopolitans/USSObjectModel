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
                    /// Create a flex-basis style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule FlexBasis()
                    {
                        return new StyleRule(RuleType.flexBasis, "auto");
                    }

                    /// <summary>
                    /// Create a flex-basis style rule with a length value. <br></br>
                    /// <br></br><see langword="Cappuccino:"/> To create an "auto" entry, create a Length value with no parameters (or use the parameterless static constructor).
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule FlexBasis(Len length)
                    {
                        return new StyleRule(RuleType.flexBasis, length.ToString());
                    }
                }
            }
        }
    }
}