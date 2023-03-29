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
                    /// Create a margin-left style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MarginLeft()
                    {
                        return new StyleRule(RuleType.marginLeft, "auto");
                    }

                    /// <summary>
                    /// Create a margin-left style rule with a length value.
                    /// </summary>
                    /// <param name="length"></param>
                    /// <returns></returns>
                    public static StyleRule MarginLeft(Length length)
                    {
                        return new StyleRule(RuleType.marginLeft, length.ToString());
                    }
                }
            }
        }
    }
}