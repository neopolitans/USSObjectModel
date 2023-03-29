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
                    /// Create a margin-top style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MarginTop()
                    {
                        return new StyleRule(RuleType.marginTop, "auto");
                    }

                    /// <summary>
                    /// Create a margin-top style rule with a length value.
                    /// </summary>
                    /// <param name="length"></param>
                    /// <returns></returns>
                    public static StyleRule MarginTop(Length length)
                    {
                        return new StyleRule(RuleType.marginTop, length.ToString());
                    }
                }
            }
        }
    }
}