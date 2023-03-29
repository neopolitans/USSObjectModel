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
                    /// Create a Left Style Rule with a length value.
                    /// </summary>
                    public static StyleRule Left(Length length)
                    {
                        return new StyleRule(RuleType.left, length.ToString());
                    }
                }
            }
        }
    }
}