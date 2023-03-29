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
                   /// An Enum representation of all the cursor keywords. Uses the USS Cursor Keywords. <br></br><br></br>
                   /// 
                   /// <see langword="MDN CSS"/> Indicates the type of cursor to use or the fallback cursor to use if the specified icons (resource/url for USS) fails to load.
                   /// </summary>
                    public enum CursorIconType
                    {
                        arrow,
                        text,
                        resizeVertical,
                        resizeHorizontal,
                        link,
                        slideArrow,
                        resizeUpRight,
                        resizeUpLeft,
                        moveArrow,
                        rotateArrow,
                        scaleArrow,
                        arrowPlus,
                        arrowMinus,
                        pan,
                        orbit,
                        zoom,
                        fps,
                        splitResizeUpDown,
                        splitResizeLeftRight
                    }

                    /// <summary>
                    /// Convert the provided CursorIconType enum value to it's string representation in USS. <br></br>
                    /// Defaults to "arrow" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this CursorIconType value)
                    {
                        return value switch
                        {
                            CursorIconType.arrow => "arrow",
                            CursorIconType.text => "text",
                            CursorIconType.resizeVertical => "resize-vertical",
                            CursorIconType.resizeHorizontal => "resize-horizontal",
                            CursorIconType.link => "link",
                            CursorIconType.slideArrow => "slide-arrow",
                            CursorIconType.resizeUpRight => "resize-up-right",
                            CursorIconType.resizeUpLeft => "resize-up-left",
                            CursorIconType.moveArrow => "move-arrow",
                            CursorIconType.rotateArrow => "rotate-arrow",
                            CursorIconType.scaleArrow => "scale-arrow",
                            CursorIconType.arrowPlus => "arrow-plus",
                            CursorIconType.arrowMinus => "arow-minus",
                            CursorIconType.pan => "pan",
                            CursorIconType.orbit => "orbit",
                            CursorIconType.zoom => "zoom",
                            CursorIconType.fps => "fps",
                            CursorIconType.splitResizeUpDown => "split-resize-up-down",
                            CursorIconType.splitResizeLeftRight => "split-resize-left-right",
                            _ => "arrow"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a CursorIconType enum value. <br></br>
                    /// Defaults to [CursorIconType.arrow] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static CursorIconType ToCursorIconType(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "arrow" => CursorIconType.arrow,
                            "text" => CursorIconType.text,
                            "resize-vertical" => CursorIconType.resizeVertical,
                            "resize-horizontal" => CursorIconType.resizeHorizontal,
                            "link" => CursorIconType.link,
                            "slide-arrow" => CursorIconType.slideArrow,
                            "resize-up-right" => CursorIconType.resizeUpRight,
                            "resize-up-left" => CursorIconType.resizeUpLeft,
                            "move-arrow" => CursorIconType.moveArrow,
                            "rotate-arrow" => CursorIconType.rotateArrow,
                            "scale-arrow" => CursorIconType.scaleArrow,
                            "arrow-plus" => CursorIconType.arrowPlus,
                            "arrow-minus" => CursorIconType.arrowMinus,
                            "pan" => CursorIconType.pan,
                            "orbit" => CursorIconType.orbit,
                            "zoom" => CursorIconType.zoom,
                            "fps" => CursorIconType.fps,
                            "split-resize-up-down" => CursorIconType.splitResizeUpDown,
                            "split-resize-left-right" => CursorIconType.splitResizeLeftRight,
                            _ => CursorIconType.arrow
                        };
                    }

                    /// <summary>
                    /// Create a Cursor Style Rule with a USS resource function value and cursor keyword value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This functionality is inferred from the <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/cursor">MDN CSS Cursor Documentation</see> in tandem with the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties Documentation</see>.
                    /// </summary>
                    /// <param name="resource">The Resource asset to use as the first value.</param>
                    /// <param name="iconType">The Icon Type to define the cursor type and for which cursor to use as a fallback cursor if the resource fails to load.</param>
                    /// <returns></returns>
                    public static StyleRule Cursor(ResourceAsset resource, CursorIconType iconType)
                    {
                        return new StyleRule(RuleType.cursor, $"{resource}, {iconType.Name()}");
                    }

                    /// <summary>
                    /// Create a Cursor Style Rule with a USS url function value and cursor keyword value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This functionality is inferred from the <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/cursor">MDN CSS Cursor Documentation</see> in tandem with the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties Documentation</see>.
                    /// </summary>
                    /// <param name="url">The URL asset to use as the first value.</param>
                    /// <param name="iconType">The Icon Type to define the cursor type and for which cursor to use as a fallback cursor if the resource fails to load.</param>
                    /// <returns></returns>
                    public static StyleRule Cursor(URLAsset url, CursorIconType iconType)
                    {
                        return new StyleRule(RuleType.cursor, $"{url}, {iconType.Name()}");
                    }

                    /// <summary>
                    /// Create a Cursor Style Rule with a USS resource function value, two integer values for the x and y coordinates indicating the cursor hotspot and cursor keyword value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This functionality is inferred from the <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/cursor">MDN CSS Cursor Documentation</see> in tandem with the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties Documentation</see>.
                    /// </summary>
                    /// <param name="resource">The Resource asset to use as the first value.</param>
                    /// <param name="x">The x coordinate within the cursor which is the point that the cursor is interacting with elements from.<br></br> E.G. the tip of the Arrow Cursor.<br></br><br></br> For more info, see the <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/cursor">MDN CSS Cursor Documentation</see>.</param>
                    /// <param name="y">The y coordinate within the cursor which is the point that the cursor is interacting with elements from.<br></br> E.G. the tip of the Arrow Cursor.<br></br><br></br> For more info, see the <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/cursor">MDN CSS Cursor Documentation</see>.</param>
                    /// <param name="iconType">The Icon Type to define the cursor type and for which cursor to use as a fallback cursor if the resource fails to load.</param>
                    /// <returns></returns>
                    public static StyleRule Cursor(ResourceAsset resource, int x, int y, CursorIconType iconType)
                    {
                        return new StyleRule(RuleType.cursor, $"{resource} {x} {y}, {iconType.Name()}");
                    }

                    /// <summary>
                    /// Create a Cursor Style Rule with a USS resource function value, two integer values for the x and y coordinates indicating the cursor hotspot and cursor keyword value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This functionality is inferred from the <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/cursor">MDN CSS Cursor Documentation</see> in tandem with the <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html">USS Common Properties Documentation</see>.
                    /// </summary>
                    /// <param name="url">The URL asset to use as the first value.</param>
                    /// <param name="x">The x coordinate within the cursor which is the point that the cursor is interacting with elements from.<br></br> E.G. the tip of the Arrow Cursor.<br></br><br></br> For more info, see the <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/cursor">MDN CSS Cursor Documentation</see>.</param>
                    /// <param name="y">The y coordinate within the cursor which is the point that the cursor is interacting with elements from.<br></br> E.G. the tip of the Arrow Cursor.<br></br><br></br> For more info, see the <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/cursor">MDN CSS Cursor Documentation</see>.</param>
                    /// <param name="iconType">The Icon Type to define the cursor type and for which cursor to use as a fallback cursor if the resource fails to load.</param>
                    /// <returns></returns>
                    public static StyleRule Cursor(URLAsset url, int x, int y, CursorIconType iconType)
                    {
                        return new StyleRule(RuleType.cursor, $"{url} {x} {y}, {iconType.Name()}");
                    }
                }
            }
        }
    }
}