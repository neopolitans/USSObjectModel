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
                    /// Create a width style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Width()
                    {
                        return new StyleRule(RuleType.width, "auto");
                    }

                    /// <summary>
                    /// Create a width style rule with a length value.
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Width(Length length)
                    {
                        return new StyleRule(RuleType.width, length.ToString());
                    }
                }
            }
        }
    }
}