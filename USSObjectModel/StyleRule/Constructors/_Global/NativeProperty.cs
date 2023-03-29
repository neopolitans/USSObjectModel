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
                    /// <param name="property">The USS Property.</param>
                    /// <param name="value">The directly specified string which will be output without change to the .uss file.</param>
                    /// <returns></returns>
                    public static StyleRule Native(string property, string value)
                    {
                        return new StyleRule(property, value, RuleType.NativeProperty);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with a directly specified int value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="property">The USS Property.</param>
                    /// <param name="value">The directly specified int which will be output without change to the .uss file.</param>
                    /// <returns></returns>
                    public static StyleRule Native(string property, int value)
                    {
                        return new StyleRule(property, value.ToString(), RuleType.NativeProperty);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with a Hexadecimal (#RRGGBB) value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="property">The USS Property.</param>
                    /// <param name="hex">The hexadecimal color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Native(string property, ColorHex hex)
                    {
                        return new StyleRule(property, hex.value, RuleType.NativeProperty);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with an rgb(r, g, b) USS function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="property">The USS Property.</param>
                    /// <param name="rgb">The RGB color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Native(string property, ColorRGB rgb)
                    {
                        return new StyleRule(property, rgb.value, RuleType.NativeProperty);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with an rgba(r, g, b, a) USS function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="property">The USS Property.</param>
                    /// <param name="rgba">The RGBA color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Native(string property, ColorRGBA rgba)
                    {
                        return new StyleRule(property, rgba.value, RuleType.NativeProperty);
                    }

                    /// <summary>
                    /// Create a USS Property by hand, with a &lt;color&gt; Keyword value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Only use this if your version of Unity Engine has one or more new property types currently not supported by the USS Object Model.
                    /// </summary>
                    /// <param name="property">The USS Property.</param>
                    /// <param name="keyword">The Color Keyword being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Native(string property, ColorKeyword keyword)
                    {
                        return new StyleRule(property, keyword.value, RuleType.NativeProperty);
                    }
                }
            }
        }
    }
}