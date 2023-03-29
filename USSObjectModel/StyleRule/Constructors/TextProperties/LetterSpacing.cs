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
                    /// Create a Letter-Spacing Rule with the 'normal' keyword as the default value. <br></br><br></br>
                    /// <b><see langword="Notice:"/></b> The usage of this style rule is inferred from <see langword="MDN CSS Documentation"/>. <br></br>
                    /// <b><i>That is to say, it might not work as intended.</i></b>
                    /// </summary>
                    public static StyleRule LetterSpacing()
                    {
                        return new StyleRule(RuleType.letterSpacing, "normal");
                    }

                    /// <summary>
                    /// Create a Letter-Spacing Rule with an integer value which gets created into a length (pixels) value. <br></br><br></br>
                    /// <b><see langword="Notice:"/></b> The usage of this style rule is inferred from <see langword="MDN CSS Documentation"/> with <see langword="Unity USS"/> specific length definitions. <br></br>
                    /// <b><i>That is to say, it might not work as intended.</i></b> <br></br><br></br>
                    /// 
                    /// <see langword="Cappuccino:"/> Percentage Length values and auto keyword not supported, as stated in CSS. 
                    /// </summary>
                    /// <param name="spacing"> The horizontal text spacing between the charcaters.</param>
                    public static StyleRule LetterSpacing(int spacing)
                    {
                        return new StyleRule(RuleType.letterSpacing, new Length(spacing).ToString());
                    }
                }
            }
        }
    }
}