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
                    /// Create an Opacity Style Rule with a number value. <br></br>
                    /// <see langword="Unity USS:"/> Parent Element opacity affects the perceived opacity of child elements.
                    /// </summary>
                    public static StyleRule Opacity(Number number)
                    {
                        return new StyleRule(RuleType.opacity, number.ToString());
                    }
                }
            }
        }
    }
}