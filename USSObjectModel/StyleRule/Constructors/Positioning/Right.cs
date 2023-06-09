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
                    /// Create a Right Style Rule with a length value.
                    /// </summary>
                    public static StyleRule Right(Len length)
                    {
                        return new StyleRule(RuleType.right, length.ToString());
                    }
                }
            }
        }
    }
}