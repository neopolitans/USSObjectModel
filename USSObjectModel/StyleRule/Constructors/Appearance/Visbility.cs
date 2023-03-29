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
                    /// Create a Visbility Style Rule with the default 'visible' value. <br></br>
                    /// The Default value has been assumed based on Unity Engine 2023.1 documentation, where hidden is first in the list.
                    /// </summary>
                    public static StyleRule Visbility()
                    {
                        return new StyleRule(RuleType.visibility, VisibilityValue.visible.Name());
                    }

                    /// <summary>
                    /// Create a Visbility Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Visbility. Restricted to only the compatible keywords.</param>
                    public static StyleRule Visbility(VisibilityValue keyword)
                    {
                        return new StyleRule(RuleType.visibility, keyword.Name());
                    }
                }
            }
        }
    }
}