using Cappuccino.Core;
using Codice.CM.Client.Differences.Graphic;

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
                    // Length Only

                    /// <summary>
                    /// Create a Unity Text Outline style rule with a length value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see>  page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur.
                    /// </summary>
                    public static StyleRule TextOutline(Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("-unity-text-outline rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.unityTextOutline, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.unityTextOutline, length.ToString());
                        }
                    }

                    // Color Value Only

                    /// <summary>
                    /// Create a Unity Text Outline Style Rule with a Hexadecimal (#RRGGBB) value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see>  page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur.
                    /// </summary>
                    /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                    public static StyleRule TextOutline(ColorHex hexColor)
                    {
                        return new StyleRule(RuleType.unityTextOutline, hexColor.value);
                    }

                    /// <summary>
                    /// Create a Unity Text Outline Style Rule with an rgb(r, g, b) USS function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see>  page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur.
                    /// </summary>
                    /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                    public static StyleRule TextOutline(ColorRGB rgbColor)
                    {
                        return new StyleRule(RuleType.unityTextOutline, rgbColor.value);    
                    }

                    /// <summary>
                    /// Create a Unity Text Outline Style Rule with an rgba(r, g, b, a) USS function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see>  page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur.
                    /// </summary>
                    /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                    public static StyleRule TextOutline(ColorRGBA rgbaColor)
                    {
                        return new StyleRule(RuleType.unityTextOutline, rgbaColor.value);
                    }

                    /// <summary>
                    /// Create a Unity Text Outline Style Rule with a &lt;color&gt; Keyword value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see>  page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur.
                    /// </summary>
                    /// <param name="keyword"> The color keyword to use as a string.</param>
                    public static StyleRule TextOutline(ColorKeyword keyword)
                    {
                        return new StyleRule(RuleType.unityTextOutline, keyword.value);
                    }

                    // Dual Value

                    /// <summary>
                    /// Create a Unity Text Outline Style Rule with a length value and a Hexadecimal (#RRGGBB) value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur.
                    /// </summary>
                    /// <param name="hexColor"> The hexadecimal color to use as a string.</param>
                    public static StyleRule TextOutline(Length length, ColorHex hexColor)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("-unity-text-outline rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.unityTextOutline, $"{length} {hexColor.value}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.unityTextOutline, $"{length} {hexColor.value}");
                        }
                    }

                    /// <summary>
                    /// Create a Unity Text Outline Style Rule with a length value and an rgb(r, g, b) USS function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur.
                    /// </summary>
                    /// <param name="rgbColor"> The RGB Color to use as a string.</param>
                    public static StyleRule TextOutline(Length length, ColorRGB rgbColor)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("-unity-text-outline rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.unityTextOutline, $"{length} {rgbColor.value}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.unityTextOutline, $"{length} {rgbColor.value}");
                        }
                    }

                    /// <summary>
                    /// Create a Unity Text Outline Style Rule with a length value and an rgba(r, g, b, a) USS function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur.
                    /// </summary>
                    /// <param name="rgbaColor"> The RGBA Color to use as a string.</param>
                    public static StyleRule TextOutline(Length length, ColorRGBA rgbaColor)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("-unity-text-outline rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.unityTextOutline, $"{length} {rgbaColor.value}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.unityTextOutline, $"{length} {rgbaColor.value}");
                        }
                    }

                    /// <summary>
                    /// Create a Unity Text Outline Style Rule with a length value and a &lt;color&gt; Keyword value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This method is supplied, inferring the functionality using the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page's description of -unity-text-outline. <br></br>
                    /// The <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties</see> page displays &lt;length&gt; or &lt;color&gt; must occur whilst the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">USS Properties Reference</see> page states both occur.
                    /// </summary>
                    /// <param name="keyword"> The color keyword to use as a string.</param>
                    public static StyleRule TextOutline(Length length, ColorKeyword keyword)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("-unity-text-outline rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.unityTextOutline, $"{length} {keyword.value}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.unityTextOutline, $"{length} {keyword.value}");
                        }
                    }
                }
            }
        }
    }
}