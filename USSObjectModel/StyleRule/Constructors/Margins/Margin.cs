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
                    /// Create a Margin style rule. <br></br>
                    /// Applies the "auto" keyword for all margin sides.
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Margin()
                    {
                        return new StyleRule(RuleType.margin, "auto");
                    }
                    
                    /// <summary>
                    /// Create a Margin with a single length value that applies to all margin sides. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When one length values are supplied, it applies to all four sides.<br></br>
                    /// <b><i>margin</i> : {all}</b>; <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> To create an "auto" entry, create a Length value with no parameters.
                    /// </summary>
                    /// <param name="all">The length value to apply to all margins.</param>
                    /// <returns></returns>
                    public static StyleRule Margin(Len all)
                    {
                        return new StyleRule(RuleType.margin, all.ToString());
                    }

                    /// <summary>
                    /// Create a Margin with two length value that applies vertically then horizontally. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When two length values are supplied, the first value is applied to the top and bottom (vertically) and the second value is applied to the left and right (horizontally)..<br></br>
                    /// <b><i>margin</i> : {vertical} {horizontal}</b>; <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> To create an "auto" entry, create a Length value with no parameters.
                    /// </summary>
                    /// <param name="vertical">The length value to apply to the top and bottom margins.</param>
                    /// <param name="horizontal">The length value to apply to the left and right margins.</param>
                    /// <returns></returns>
                    public static StyleRule Margin(Len vertical, Len horizontal)
                    {
                        return new StyleRule(RuleType.margin, $"{vertical} {horizontal}");
                    }

                    /// <summary>
                    /// Create a Margin with a three length values that applies to the top, sides and bottom. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When three length values are supplied, the first value is used for the top margin, the second for the left and right margins and the third for the bottom margin.<br></br>
                    /// <b><i>margin</i> : {top} {sides} {bottom}</b>; <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> To create an "auto" entry, create a Length value with no parameters.
                    /// </summary>
                    /// <param name="top">The length value to apply to the top margin.</param>
                    /// <param name="sides">The length value to apply to the left and right margins.</param>
                    /// <param name="bottom">The length value to apply to the bottom margin.</param>
                    /// <returns></returns>
                    public static StyleRule Margin(Len top, Len sides, Len bottom)
                    {
                        return new StyleRule(RuleType.margin, $"{top} {sides} {bottom}");
                    }

                    /// <summary>
                    /// Create a Margin with four length values that applies to the top, right, bottom and left. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When four length values are supplied, they are applied in clock-wise order.<br></br>
                    /// <b><i>margin</i> : {top} {right} {bottom} {left}</b>; <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> To create an "auto" entry, create a Length value with no parameters.
                    /// </summary>
                    /// <param name="top">The length value to apply to the top margin.</param>
                    /// <param name="right">The length value to apply to the right margin.</param>
                    /// <param name="bottom">The length value to apply to the bottom margin.</param>
                    /// <param name="left">The length value to apply to the left margin.</param>
                    /// <returns></returns>
                    public static StyleRule Margin(Len top, Len right, Len bottom, Len left)
                    {
                        return new StyleRule(RuleType.margin, $"{top} {left} {right} {bottom}");
                    }
                }
            }
        }
    }
}