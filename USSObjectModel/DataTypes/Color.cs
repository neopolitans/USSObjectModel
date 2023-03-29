using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using Cappuccino.Core;
using System.Linq;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// Create a Color Hex value.
                /// </summary>
                public class ColorHex
                {
                    public string value;

                    /// <summary>
                    /// Convert 3 hex bytes representing RGBA into RGB
                    /// </summary>
                    /// <param name="r">Red - Hexadecimal Byte</param>
                    /// <param name="g">Green - Hexadecimal Byte</param>
                    /// <param name="b">Blue - Hexadecimal Byte</param>
                    public ColorHex(byte r, byte g, byte b)
                    {
                        value = ("#" + System.BitConverter.ToString(new byte[] { r, g, b })).Replace("-", "");
                    }

                    /// <summary>
                    /// Return the Hex Value string generated on object creation.
                    /// </summary>
                    public override string ToString() => value;
                }

                /// <summary>
                /// Create a Color rgb() USS function value.
                /// </summary>
                public class ColorRGB
                {
                    public string value;

                    public ColorRGB(byte r, byte g, byte b)
                    {
                        value = $"rgb({r}, {g}, {b})";
                    }

                    /// <summary>
                    /// Return the rgb(r, g, b) USS function string generated on object creation.
                    /// </summary>
                    public override string ToString() => value;
                }

                /// <summary>
                /// Create a Color rgba() USS function value.
                /// </summary>
                public class ColorRGBA
                {
                    public string value;

                    public ColorRGBA(byte r, byte g, byte b, float a)
                    {
                        value = $"rgba({r}, {g}, {b}, {Mathf.Clamp(a, 0.0f, 1.0f)})";
                    }

                    /// <summary>
                    /// Return the rgba(r, g, b, f) USS function string generated on object creation.
                    /// </summary>
                    public override string ToString() => value;
                }

                /// <summary>
                /// Create a Color value for a color keyword.
                /// </summary>
                public class ColorKeyword
                {
                    public string value;

                    public ColorKeyword(USSColorKeyword keyword)
                    {
                        value = keyword.ToString();
                    }

                    /// <summary>
                    /// Return the color keyword string generated on object creation.
                    /// </summary>
                    public override string ToString() => value;
                }
            }
        }
    }
}