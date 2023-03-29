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
                    /// Create a Font Size Style Rule with a number value.
                    /// </summary>
                    public static StyleRule FontSize(Number number)
                    {
                        return new StyleRule(RuleType.fontSize, number.ToString());
                    }

                }
            }
        }
    }
}