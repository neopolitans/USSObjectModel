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
                    /// An object representing text-shadow parameters for each text shadow when there are multiple present. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This object is exclusively used for text-shadow, for dealing with multiple text shadows. <br></br> 
                    /// It shares all the same constructors as text-shadow does, minus the params <see cref="ShadowValue"/>[] variant.
                    /// </summary>
                    public class ShadowValue
                    {
                        public string value;

                        /// <summary>
                        /// Create a ShadowValue object with two integers representing offsets, which get converted into pixel length values. <br></br><br></br>
                        /// <see langword="Cappuccino:"/> Percentage Length values and auto keyword not supported, as stated in <see langword="MDN CSS Documentation"/> . 
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <returns></returns>
                        public ShadowValue(int offsetX, int offsetY)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with three integers. <br></br> 
                        /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values. <br></br><br></br>
                        /// <see langword="Cappuccino:"/> Percentage Length values and auto keyword not supported, as stated in <see langword="MDN CSS Documentation"/> . 
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                        /// <returns></returns>
                        public ShadowValue(int offsetX, int offsetY, int blurRadius)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with a Hexadecimal (#RRGGBB) value and two integers representing offsets, which get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, ColorHex hexColor)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {hexColor.value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with an rgb(r, g, b) USS function value and two integers representing offsets, which get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, ColorRGB rgbColor)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {rgbColor.value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with an rgba(r, g, b, a) USS function value and two integers representing offsets, which get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, ColorRGBA rgbaColor)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {rgbaColor.value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with a &lt;color&gt; Keyword value and two integers representing offsets, which get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="keyword"> The color keyword to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, ColorKeyword keyword)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {keyword.value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with a &lt;color&gt; Keyword value and two integers representing offsets, which get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="keyword"> The color keyword to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, USSColorKeyword keyword)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new ColorKeyword(keyword).value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with a UnityEngine color value and two integers representing offsets, which get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="color">The UnityEnigne color to convert to a USS-compatible rgba() function.</param>
                        public ShadowValue(int offsetX, int offsetY, Color color)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new ColorRGBA(((byte)((int)Mathf.Clamp(color.r * 255, 0f, 255f))), ((byte)((int)Mathf.Clamp(color.g * 255, 0f, 255f))), ((byte)((int)Mathf.Clamp(color.b * 255, 0f, 255f))), color.a).value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with a Hexadecimal (#RRGGBB) value and three integers. <br></br> 
                        /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                        /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, int blurRadius, ColorHex hexColor)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {hexColor.value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with an rgb(r, g, b) USS function value and three integers. <br></br> 
                        /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                        /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, int blurRadius, ColorRGB rgbColor)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {rgbColor.value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with an rgba(r, g, b, a) USS function value and three integers. <br></br> 
                        /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                        /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, int blurRadius, ColorRGBA rgbaColor)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {rgbaColor.value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with a &lt;color&gt; Keyword value and three integers. <br></br> 
                        /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                        /// <param name="keyword"> The color keyword to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, int blurRadius, ColorKeyword keyword)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {keyword.value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with a &lt;color&gt; Keyword value and three integers. <br></br> 
                        /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                        /// <param name="keyword"> The color keyword to use as a string.</param>
                        public ShadowValue(int offsetX, int offsetY, int blurRadius, USSColorKeyword keyword)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {new ColorKeyword(keyword).value}";
                        }

                        /// <summary>
                        /// Create a ShadowValue object with a UnityEngine color value and three integers. <br></br> 
                        /// Two are representing offests on the X and Y axis while one represents blur radius. All get converted into pixel length values.
                        /// </summary>
                        /// <param name="offsetX">The horizontal offset of the shadow.</param>
                        /// <param name="offsetY">The vertical offset of the shadow.</param>
                        /// <param name="blurRadius">The radius in pixels of the shadow blur.</param>
                        /// <param name="color">The UnityEnigne color to convert to a USS-compatible rgba() function.</param>
                        public ShadowValue(int offsetX, int offsetY, int blurRadius, Color color)
                        {
                            value = $"{new Length(offsetX)} {new Length(offsetY)} {new Length(blurRadius)} {new ColorRGBA(((byte)((int)Mathf.Clamp(color.r * 255, 0f, 255f))), ((byte)((int)Mathf.Clamp(color.g * 255, 0f, 255f))), ((byte)((int)Mathf.Clamp(color.b * 255, 0f, 255f))), color.a).value}";
                        }
                    }
                }
            }
        }
    }
}