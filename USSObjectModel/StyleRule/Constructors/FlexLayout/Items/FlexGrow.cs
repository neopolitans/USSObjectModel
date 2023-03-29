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
                    /// Create a flex-grow style rule. <br></br>
                    /// Only takes a &lt;number&gt; value.
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule FlexGrow(Number number)
                    {
                        return new StyleRule(RuleType.flexGrow, number.ToString());
                    }
                }
            }
        }
    }
}