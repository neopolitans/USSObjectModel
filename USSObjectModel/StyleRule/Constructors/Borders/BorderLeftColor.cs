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
                    /// Create a Border-Left-Color Style Rule with a Hexadecimal (#RRGGBB) value. <br></br><br></br>
                    /// <b><see langword="Notice:"/></b> The usage of this style rule is inferred from <see langword="MDN CSS Documentation"/> with <see langword="Unity USS"/> specific color value definitions. <br></br>
                    /// <b><i>That is to say, it might not work as intended.</i></b>
                    /// </summary>
                    /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                    public static StyleRule BorderLeftColor(ColorHex hexColor)
                    {
                        return new StyleRule(RuleType.borderLeftColor, hexColor.value);
                    }

                    /// <summary>
                    /// Create a Border-Left-Color Style Rule with an rgb(r, g, b) USS function value.<br></br><br></br>
                    /// <b><see langword="Notice:"/></b> The usage of this style rule is inferred from <see langword="MDN CSS Documentation"/> with <see langword="Unity USS"/> specific color value definitions. <br></br>
                    /// <b><i>That is to say, it might not work as intended.</i></b>
                    /// </summary>
                    /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                    public static StyleRule BorderLeftColor(ColorRGB rgbColor)
                    {
                        return new StyleRule(RuleType.borderLeftColor, rgbColor.value);
                    }

                    /// <summary>
                    /// Create a Border-Left-Color Style Rule with an rgba(r, g, b, a) USS function value.<br></br><br></br>
                    /// <b><see langword="Notice:"/></b> The usage of this style rule is inferred from <see langword="MDN CSS Documentation"/> with <see langword="Unity USS"/> specific color value definitions. <br></br>
                    /// <b><i>That is to say, it might not work as intended.</i></b>
                    /// </summary>
                    /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                    public static StyleRule BorderLeftColor(ColorRGBA rgbaColor)
                    {
                        return new StyleRule(RuleType.borderLeftColor, rgbaColor.value);
                    }

                    /// <summary>
                    /// Create a Border-Left-Color Style Rule with a &lt;color&gt; Keyword value.<br></br><br></br>
                    /// <b><see langword="Notice:"/></b> The usage of this style rule is inferred from <see langword="MDN CSS Documentation"/> with <see langword="Unity USS"/> specific color value definitions. <br></br>
                    /// <b><i>That is to say, it might not work as intended.</i></b>
                    /// </summary>
                    /// <param name="keyword"> The color keyword to use as a string.</param>
                    public static StyleRule BorderLeftColor(ColorKeyword keyword)
                    {
                        return new StyleRule(RuleType.borderLeftColor, keyword.value);
                    }
                }
            }
        }
    }
}