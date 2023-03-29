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
                    /// Create an Align-Items Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Align Items. Restricted to only the compatible keywords.</param>
                    public static StyleRule AlignItems(FlexAlignmentValue keyword)
                    {
                        return new StyleRule(RuleType.alignItems, keyword.Name());
                    }
                }
            }
        }
    }
}