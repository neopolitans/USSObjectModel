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
                    /// Create a min-height style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MinHeight()
                    {
                        return new StyleRule(RuleType.minHeight, "auto");
                    }

                    /// <summary>
                    /// Create a min-height style rule with a length value.
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MinHeight(Len length)
                    {
                        return new StyleRule(RuleType.minHeight, length.ToString());
                    }
                }
            }
        }
    }
}