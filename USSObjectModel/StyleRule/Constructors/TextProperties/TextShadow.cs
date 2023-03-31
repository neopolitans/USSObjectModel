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
                    /// Create a Text-Shadow style rule with two integers representing offsets, which get converted into pixel length values. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Percentage Length values and auto keyword not supported, as stated in <see langword="MDN CSS Documentation"/> . 
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <returns></returns>
                    public static StyleRule TextShadow(int offsetX, int offsetY)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow style rule with three integers. <br></br> 
                    /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Percentage Length values and auto keyword not supported, as stated in <see langword="MDN CSS Documentation"/> . 
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                    /// <returns></returns>
                    public static StyleRule TextShadow(int offsetX, int offsetY, int blurRadius)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with a Hexadecimal (#RRGGBB) value and two integers representing offsets, which get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, ColorHex hexColor)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {hexColor.value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with an rgb(r, g, b) USS function value and two integers representing offsets, which get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, ColorRGB rgbColor)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {rgbColor.value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with an rgba(r, g, b, a) USS function value and two integers representing offsets, which get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, ColorRGBA rgbaColor)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {rgbaColor.value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with a &lt;color&gt; Keyword value and two integers representing offsets, which get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="keyword"> The color keyword to use as a string.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, USSColorKeyword keyword)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {new ColorKeyword(keyword).value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with a UnityEngine Color value and two integers representing offsets, which get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="color">The UnityEnigne color to convert to a USS-compatible rgba() function.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, Color color)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {new ColorRGBA( ((byte)((int)Mathf.Clamp(color.r * 255, 0f, 255f))), ((byte)((int)Mathf.Clamp(color.g * 255, 0f, 255f))), ((byte)((int)Mathf.Clamp(color.b * 255, 0f, 255f))), color.a).value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with a Hexadecimal (#RRGGBB) value and three integers. <br></br> 
                    /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                    /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, int blurRadius, ColorHex hexColor)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {hexColor.value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with an rgb(r, g, b) USS function value and three integers. <br></br> 
                    /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                    /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, int blurRadius, ColorRGB rgbColor)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {rgbColor.value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with an rgba(r, g, b, a) USS function value and three integers. <br></br> 
                    /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                    /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, int blurRadius, ColorRGBA rgbaColor)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {rgbaColor.value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with a &lt;color&gt; Keyword value and three integers. <br></br> 
                    /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                    /// <param name="keyword"> The color keyword to use as a string.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, int blurRadius, USSColorKeyword keyword)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {new ColorKeyword(keyword).value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with a UnityEngine color value and three integers. <br></br> 
                    /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                    /// </summary>
                    /// <param name="offsetX">The horizontal offset of the shadow.</param>
                    /// <param name="offsetY">The vertical offset of the shadow.</param>
                    /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                    /// <param name="color">The UnityEnigne color to convert to a USS-compatible rgba() function.</param>
                    public static StyleRule TextShadow(int offsetX, int offsetY, int blurRadius, Color color)
                    {
                        return new StyleRule(RuleType.textShadow, $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {new ColorRGBA(((byte)((int)Mathf.Clamp(color.r * 255, 0f, 255f))), ((byte)((int)Mathf.Clamp(color.g * 255, 0f, 255f))), ((byte)((int)Mathf.Clamp(color.b * 255, 0f, 255f))), color.a).value}");
                    }

                    /// <summary>
                    /// Create a Text-Shadow Style Rule with one or more <see cref="ShadowValue"/> values. <br></br>
                    /// Each ShadowValue represents one text-value style rule and multiple can be applied at once (according to <see langword="MDN CSS Documentation"/>, which Unity states hat USS acts the same to). 
                    /// </summary>
                    /// <param name="allShadows">The ShadowValue objects to concatenate into a larger style rule value.</param>
                    public static StyleRule TextShadow(params ShadowValue[] allShadows)
                    {
                        if (allShadows.Length > 0)
                        {
                            string endValue = "";
                            int i = 0;

                            foreach (ShadowValue sv in allShadows)
                            {
                                i++;
                                endValue = endValue + (i < allShadows.Length - 1 ? sv.value + ", " : sv.value);
                            }

                            return new StyleRule(RuleType.textShadow, endValue);
                        }
                        else
                        {
                            Diag.Violation("There are no ShadowValue objects for this text-shadow rule. No style rule created.");
                            return null;
                        }
                    }
                }
            }
        }
    }
}