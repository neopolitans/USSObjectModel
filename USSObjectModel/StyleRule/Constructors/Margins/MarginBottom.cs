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
                    /// Create a margin-bottom style rule. <br></br>
                    /// Assumes the value is "auto".
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule MarginBottom()
                    {
                        return new StyleRule(RuleType.marginBottom, "auto");
                    }

                    /// <summary>
                    /// Create a margin-bottom style rule with a length value. <br></br>
                    /// <br></br><see langword="Cappuccino:"/> To create an "auto" entry, create a Length value with no parameters (or use the parameterless static constructor).
                    /// </summary>
                    /// <param name="length"></param>
                    /// <returns></returns>
                    public static StyleRule MarginBottom(Len length)
                    {
                        return new StyleRule(RuleType.marginBottom, length.ToString());
                    }
                }
            }
        }
    }
}