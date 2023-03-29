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
                    /// Create a Border-Color Style Rule with a Hexadecimal (#RRGGBB) value.
                    /// </summary>
                    /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                    public static StyleRule BorderColor(ColorHex hexColor)
                    {
                        return new StyleRule(RuleType.borderColor, hexColor.value);
                    }

                    /// <summary>
                    /// Create a Border-Color Style Rule with an rgb(r, g, b) USS function value.
                    /// </summary>
                    /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                    public static StyleRule BorderColor(ColorRGB rgbColor)
                    {
                        return new StyleRule(RuleType.borderColor, rgbColor.value);
                    }

                    /// <summary>
                    /// Create a Border-Color Style Rule with an rgba(r, g, b, a) USS function value.
                    /// </summary>
                    /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                    public static StyleRule BorderColor(ColorRGBA rgbaColor)
                    {
                        return new StyleRule(RuleType.borderColor, rgbaColor.value);
                    }

                    /// <summary>
                    /// Create a Border-Color Style Rule with a &lt;color&gt; Keyword value.
                    /// </summary>
                    /// <param name="keyword"> The color keyword to use as a string.</param>
                    public static StyleRule BorderColor(ColorKeyword keyword)
                    {
                        return new StyleRule(RuleType.borderColor, keyword.value);
                    }
                }
            }
        }
    }
}