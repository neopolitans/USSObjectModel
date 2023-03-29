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
                    /// Create a USS Property by hand, with a directly specified string value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="value">The directly</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, string value)
                    {
                        return new StyleRule(variableName, value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with a Hexadecimal (#RRGGBB) value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="hex">The hexadecimal color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, ColorHex hex)
                    {
                        return new StyleRule(variableName, hex.value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with an rgb(r, g, b) USS function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="rgb">The RGB color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, ColorRGB rgb)
                    {
                        return new StyleRule(variableName, rgb.value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with an rgba(r, g, b, a) USS function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="rgba">The RGBA color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, ColorRGBA rgba)
                    {
                        return new StyleRule(variableName, rgba.value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with a &lt;color&gt; Keyword value.  <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="keyword">The Color Keyword being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, ColorKeyword keyword)
                    {
                        return new StyleRule(variableName, keyword.value, RuleType.Variable);
                    }
                }
            }
        }
    }
}