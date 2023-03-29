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
                    /// Create a min-width style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MinWidth()
                    {
                        return new StyleRule(RuleType.minWidth, "auto");
                    }

                    /// <summary>
                    /// Create a min-width style rule with a length value.
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MinWidth(Length length)
                    {
                        return new StyleRule(RuleType.minWidth, length.ToString());
                    }
                }
            }
        }
    }
}