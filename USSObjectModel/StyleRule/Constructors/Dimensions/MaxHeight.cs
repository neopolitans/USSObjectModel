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
                    /// Create a max-heigth style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MaxHeight()
                    {
                        return new StyleRule(RuleType.maxHeight, "auto");
                    }

                    /// <summary>
                    /// Create a max-height style rule with a length value.
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MaxHeight(Len length)
                    {
                        return new StyleRule(RuleType.maxHeight, length.ToString());
                    }
                }
            }
        }
    }
}