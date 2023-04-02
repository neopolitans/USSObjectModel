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
                    /// Create a Border-Radius rule with a single length value that applies to all padding sides. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When one length values are supplied, it applies to all four sides.<br></br>
                    /// <b><i>border-radius</i> : {all}</b>; <br></br><br></br>
                    /// 
                    /// <see langword="Unity USS:"/> USS has no support for the second-radius shortand division featured in CSS border-radius. <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    /// <param name="all">The length value to apply to all padding sides.</param>
                    public static StyleRule BorderRadius(Len all)
                    {
                        if (all.isAuto)
                        {
                            Diag.Violation("border-radius rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.borderRadius, all.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.borderRadius, all.ToString());
                        }
                    }

                    /// <summary>
                    /// Create a Border-Radius rule with two length values that applies to the top left and bottom right radii then to the top right and bottom left radii. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When two length values are supplied, the first value applies to the top left and bottom right radii and the second value is applied to the top right and bottom left radii.<br></br>
                    /// <b><i>border-radius</i> : {topLeftBottomRight} {bottomLeftTopRight}</b>; <br></br><br></br>
                    /// 
                    /// <see langword="Unity USS:"/> USS has no support for the second-radius shortand division featured in CSS border-radius. <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    /// <param name="topLeftBottomRight">The length value to apply to the top left and bottom right raidus corners.</param>
                    /// <param name="topRightAndBottomLeft">The length value to apply to the bottom left and top right raidus corners.</param>
                    public static StyleRule BorderRadius(Len topLeftBottomRight, Len topRightAndBottomLeft)
                    {
                        if (topLeftBottomRight.isAuto || topRightAndBottomLeft.isAuto)
                        {
                            Diag.Violation("border-radius rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.borderRadius, $"{topLeftBottomRight} {topRightAndBottomLeft}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.borderRadius, $"{topLeftBottomRight} {topRightAndBottomLeft}");
                        }
                    }

                    /// <summary>
                    /// Create a Border-Radius rule with three length values that apply to the top left radius then the top right and bottom left radii then the bottom right radius. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When three length values are supplied, the first value applies to the top left radius, the second value applies to the top right and bottom left radii <br></br> 
                    /// and the third value to the bottom right radius.<br></br>
                    /// <b><i>border-radius</i> : {topLeft} {topRightAndBottomLeft} {bottomRight}</b>; <br></br><br></br>
                    /// 
                    /// <see langword="Unity USS:"/> USS has no support for the second-radius shortand division featured in CSS border-radius. <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    /// <param name="topLeft">The length value to apply to the top left raidus.</param>
                    /// <param name="topRightAndBottomLeft">The length value to apply to the top right raidus and bottom left.</param>
                    /// <param name="bottomRight">The length value to apply to the bottom right radius.</param>
                    public static StyleRule BorderRadius(Len topLeft, Len topRightAndBottomLeft, Len bottomRight)
                    {
                        if (topLeft.isAuto || topRightAndBottomLeft.isAuto || bottomRight.isAuto)
                        {
                            Diag.Violation("border-radius rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.borderRadius, $"{topLeft} {topRightAndBottomLeft} {bottomRight}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.borderRadius, $"{topLeft} {topRightAndBottomLeft} {bottomRight}");
                        }
                    }

                    /// <summary>
                    /// Create a Border-Radius rule with four length values that apply to the top left radius then the top right radius then the bottom right radius then the bottom left radius. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When three length values are supplied, the first value applies to the top left radius, the second value applies the top right radius, <br></br>
                    /// the third value applies the bottom right radius, finally the fourth value applies the bottom left radius.<br></br>
                    /// <b><i>border-radius</i> : {topLeft} {topRight} {bottomRight} {bottomLeft}</b>; <br></br><br></br>
                    /// 
                    /// <see langword="Unity USS:"/> USS has no support for the second-radius shortand division featured in CSS border-radius. <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    /// <param name="topLeft">The length value to apply to the top left raidus.</param>
                    /// <param name="topRight">The length value to apply to the top right raidus.</param>
                    /// <param name="bottomRight">The length value to apply to the bottom right radius.</param>
                    /// <param name="bottomLeft">The length value to apply to the top right raidus.</param>
                    public static StyleRule BorderRadius(Len topLeft, Len topRight, Len bottomRight, Len bottomLeft)
                    {
                        if (topLeft.isAuto || topRight.isAuto|| bottomRight.isAuto || bottomLeft.isAuto)
                        {
                            Diag.Violation("border-radius rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.borderRadius, $"{topLeft} {topRight} {bottomRight} {bottomLeft}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.borderRadius, $"{topLeft} {topRight} {bottomRight} {bottomLeft}");
                        }
                    }
                }
            }
        }
    }
}