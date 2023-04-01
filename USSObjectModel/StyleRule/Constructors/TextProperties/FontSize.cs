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
                    /// <b><see langword="[DEPRECATED]"/></b> <br></br>
                    /// Create a Font Size Style Rule with a number value. <br></br><br></br>
                    /// UnityEngine states the use of &lt;number&gt; in this method constructor. <br></br>
                    /// CSS advises font-relative length values. <br></br><br></br>
                    /// For the timebeing, this constructor is deprecated and a <see cref="Length"/>-based constructor is provided instead. <br></br>
                    /// The new constructor does not provide any log warnings in console. <br></br><br></br>
                    /// <b>This issue is known to affect documentation between 2021.3 and 2023.2</b>
                    /// </summary>
                    public static StyleRule FontSize(Number number)
                    {
                        return new StyleRule(RuleType.fontSize, number.ToString());
                    }

                    /// <summary>
                    /// Create a Font Size Style Rule with a length value.
                    /// </summary>
                    public static StyleRule FontSize(Length length)
                    {
                        return new StyleRule(RuleType.fontSize, length.ToString());
                    }

                }
            }
        }
    }
}