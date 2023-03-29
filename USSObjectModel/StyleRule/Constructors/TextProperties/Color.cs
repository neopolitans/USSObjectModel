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
                    /// Create a Color Style Rule with a Hexadecimal (#RRGGBB) value. <br></br><br></br>
                    /// <see langword="Unity USS:"/> This style rule sets the color of text.<br></br><br></br>
                    /// <see langword="Cappuccino:"/> Not to be confused with the data-type &lt;color&gt;.
                    /// </summary>
                    /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                    public static StyleRule Color(ColorHex hexColor)
                    {
                        return new StyleRule(RuleType.color, hexColor.value);
                    }

                    /// <summary>
                    /// Create a Color Style Rule with an rgb(r, g, b) USS function value. <br></br><br></br>
                    /// <see langword="Unity USS:"/> This style rule sets the color of text.<br></br><br></br>
                    /// <see langword="Cappuccino:"/> Not to be confused with the data-type &lt;color&gt;.
                    /// </summary>
                    /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                    public static StyleRule Color(ColorRGB rgbColor)
                    {
                        return new StyleRule(RuleType.color, rgbColor.value);
                    }

                    /// <summary>
                    /// Create a Color Style Rule with an rgba(r, g, b, a) USS function value. <br></br><br></br>
                    /// <see langword="Unity USS:"/> This style rule sets the color of text.<br></br><br></br>
                    /// <see langword="Cappuccino:"/> Not to be confused with the data-type &lt;color&gt;.
                    /// </summary>
                    /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                    public static StyleRule Color(ColorRGBA rgbaColor)
                    {
                        return new StyleRule(RuleType.color, rgbaColor.value);
                    }

                    /// <summary>
                    /// Create a Color Style Rule with a &lt;color&gt; Keyword value. <br></br><br></br>
                    /// <see langword="Unity USS:"/> This style rule sets the color of text.<br></br><br></br>
                    /// <see langword="Cappuccino:"/> Not to be confused with the data-type &lt;color&gt;.
                    /// </summary>
                    /// <param name="keyword"> The color keyword to use as a string.</param>
                    public static StyleRule Color(ColorKeyword keyword)
                    {
                        return new StyleRule(RuleType.color, keyword.value);
                    }
                }
            }
        }
    }
}