using Cappuccino.Core;
using UnityEngine;

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
                    /// Create a USS Variable, with a directly specified string value. <br></br>
                    /// Providing a string prefixed with "--" is not necessary as it is added in the event the prefix is missing.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="value">The directly specified string which will be output without change to the .uss file.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, string value)
                    {
                        if (!variableName.StartsWith("--"))
                        {
                            variableName = "--" + variableName;
                        }
                        return new StyleRule(variableName, value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Variable, with a directly specified int value. <br></br>
                    /// Providing a string prefixed with "--" is not necessary as it is added in the event the prefix is missing.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="value">The directly specified int which will be output without change to the .uss file.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, int value)
                    {
                        if (!variableName.StartsWith("--"))
                        {
                            variableName = "--" + variableName;
                        }
                        return new StyleRule(variableName, value.ToString(), RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Variable, with a Hexadecimal (#RRGGBB) value. <br></br>
                    /// Providing a string prefixed with "--" is not necessary as it is added in the event the prefix is missing.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="hex">The hexadecimal color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, ColorHex hex)
                    {
                        if (!variableName.StartsWith("--"))
                        {
                            variableName = "--" + variableName;
                        }
                        return new StyleRule(variableName, hex.value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a Variable, with an rgb(r, g, b) USS function value. <br></br>
                    /// Providing a string prefixed with "--" is not necessary as it is added in the event the prefix is missing.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="rgb">The RGB color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, ColorRGB rgb)
                    {
                        if (!variableName.StartsWith("--"))
                        {
                            variableName = "--" + variableName;
                        }
                        return new StyleRule(variableName, rgb.value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Variable, with an rgba(r, g, b, a) USS function value. <br></br>
                    /// Providing a string prefixed with "--" is not necessary as it is added in the event the prefix is missing.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="rgba">The RGBA color being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, ColorRGBA rgba)
                    {
                        if (!variableName.StartsWith("--"))
                        {
                            variableName = "--" + variableName;
                        }
                        return new StyleRule(variableName, rgba.value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Variable, with a &lt;color&gt; Keyword value. <br></br>
                    /// Providing a string prefixed with "--" is not necessary as it is added in the event the prefix is missing.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="keyword">The Color Keyword being assigned to this style rule.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, USSColorKeyword keyword)
                    {
                        if (!variableName.StartsWith("--"))
                        {
                            variableName = "--" + variableName;
                        }
                        return new StyleRule(variableName, new ColorKeyword(keyword).value, RuleType.Variable);
                    }

                    /// <summary>
                    /// Create a USS Variable, with a UnityEngine color value. <br></br>
                    /// Providing a string prefixed with "--" is not necessary as it is added in the event the prefix is missing.
                    /// </summary>
                    /// <param name="variableName">The variable name.</param>
                    /// <param name="color">The UnityEnigne color to convert to a USS-compatible rgba() function.</param>
                    /// <returns></returns>
                    public static StyleRule Variable(string variableName, Color color)
                    {
                        if (!variableName.StartsWith("--"))
                        {
                            variableName = "--" + variableName;
                        }
                        return new StyleRule(variableName, new ColorRGBA(
                            ((byte)((int)Mathf.Clamp(color.r * 255, 0f, 255f))),
                            ((byte)((int)Mathf.Clamp(color.g * 255, 0f, 255f))),
                            ((byte)((int)Mathf.Clamp(color.b * 255, 0f, 255f))),
                            color.a).value, RuleType.Variable);
                    }
                }
            }
        }
    }
}