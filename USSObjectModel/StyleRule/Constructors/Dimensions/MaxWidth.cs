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
                    /// Create a max-width style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MaxWidth()
                    {
                        return new StyleRule(RuleType.maxWidth, "auto");
                    }

                    /// <summary>
                    /// Create a max-width style rule with a length value.
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MaxWidth(Length length)
                    {
                        return new StyleRule(RuleType.maxWidth, length.ToString());
                    }
                }
            }
        }
    }
}