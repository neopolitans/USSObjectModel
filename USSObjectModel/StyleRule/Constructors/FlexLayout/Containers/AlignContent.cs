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
                    /// Create an Align-Content Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Align Content. Restricted to only the compatible keywords.</param>
                    public static StyleRule AlignContent(FlexAlignmentValue keyword)
                    {
                        return new StyleRule(RuleType.alignContent, keyword.Name());
                    }
                }
            }
        }
    }
}