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
                    /// Create a Overflow Style Rule with the default 'hidden' value.<br></br>
                    /// The Default value has been assumed based on Unity Engine 2023.1 documentation, where visible is first in the list.
                    /// </summary>
                    public static StyleRule Overflow()
                    {
                        return new StyleRule(RuleType.overflow, VisibilityValue.hidden.Name());
                    }

                    /// <summary>
                    /// Create a Overflow Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Overflow. Restricted to only the compatible keywords.</param>
                    public static StyleRule Overflow(VisibilityValue keyword)
                    {
                        return new StyleRule(RuleType.overflow, keyword.Name());
                    }
                }
            }
        }
    }
}