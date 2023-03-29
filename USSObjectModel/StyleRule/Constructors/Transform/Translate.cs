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
                    /// Create a Translate style rule with a length value for a translation along the x axis. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> The USS documentation states that y can be omitted if it equals X. <br></br> 
                    /// <b><i>The stated "one value for two axes" behaviour may not work as <see langword="MDN CSS"/> states only X would be moved.</i></b>
                    /// </summary>
                    /// <param name="x">The translaton along the X axis in pixels or percentage.</param>
                    public static StyleRule Translate(Length x)
                    {
                        return new StyleRule(RuleType.translate, x.ToString());
                    }

                    /// <summary>
                    /// Create a Translate style rule with two length values for a translation along the x and y axes.
                    /// </summary>
                    /// <param name="x">The translaton along the X axis in pixels or percentage.</param>
                    /// <param name="y">The translaton along the Y axis in pixels or percentage.</param>
                    public static StyleRule Translate(Length x, Length y)
                    {
                        return new StyleRule(RuleType.translate, $"{x} {y}");
                    }
                }
            }
        }
    }
}