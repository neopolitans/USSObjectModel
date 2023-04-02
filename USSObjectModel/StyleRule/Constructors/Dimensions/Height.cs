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
                    /// Create a height style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Height()
                    {
                        return new StyleRule(RuleType.height, "auto");
                    }

                    /// <summary>
                    /// Create a height style rule with a length value.
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Height(Len length)
                    {
                        return new StyleRule(RuleType.height, length.ToString());
                    }
                }
            }
        }
    }
}