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
                    /// Create a Padding rule with a single length value that applies to all padding sides. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When one length values are supplied, it applies to all four sides.<br></br>
                    /// <b><i>padding</i> : {all}</b>; <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    /// <param name="all">The length value to apply to all padding sides.</param>
                    /// <returns></returns>
                    public static StyleRule Padding(Length all)
                    {
                        if (all.isAuto)
                        {
                            Diag.Violation("padding rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.padding, all.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.padding, all.ToString());
                        }
                    }

                    /// <summary>
                    /// Create a Padding rule with two length value that applies vertically then horizontally. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When two length values are supplied, the first value is applied to the top and bottom (vertically) and the second value is applied to the left and right (horizontally)..<br></br>
                    /// <b><i>padding</i> : {vertical} {horizontal}</b>; <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    /// <param name="vertical">The length value to apply to the top and bottom padding sides.</param>
                    /// <param name="horizontal">The length value to apply to the left and right padding sides.</param>
                    /// <returns></returns>
                    public static StyleRule Padding(Length vertical, Length horizontal)
                    {
                        if (vertical.isAuto || horizontal.isAuto)
                        {
                            Diag.Violation("padding rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.padding, $"{vertical} {horizontal}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.padding, $"{vertical} {horizontal}");
                        }
                    }

                    /// <summary>
                    /// Create a Padding rule with a three length values that applies to the top, sides and bottom. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When three length values are supplied, the first value is used for the top side, the second for the left and right sides and the third for the bottom side.<br></br>
                    /// <b><i>padding</i> : {top} {sides} {bottom}</b>; <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    /// <param name="top">The length value to apply to the top padding side.</param>
                    /// <param name="sides">The length value to apply to the left and right padding sides.</param>
                    /// <param name="bottom">The length value to apply to the bottom padding side.</param>
                    /// <returns></returns>
                    public static StyleRule Padding(Length top, Length sides, Length bottom)
                    {
                        if (top.isAuto || sides.isAuto || bottom.isAuto)
                        {
                            Diag.Violation("padding rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.padding, $"{top} {sides} {bottom}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.padding, $"{top} {sides} {bottom}");
                        }
                    }

                    /// <summary>
                    /// Create a Padding rule with four length values that applies to the top, right, bottom and left. <br></br><br></br>
                    /// 
                    /// <see langword="MDN CSS:"/> When four length values are supplied, they are applied in clock-wise order.<br></br>
                    /// <b><i>padding</i> : {top} {right} {bottom} {left}</b>; <br></br><br></br>
                    /// 
                    /// <br></br><see langword="Cappuccino:"/> Does not support "auto".
                    /// </summary>
                    /// <param name="top">The length value to apply to the top padding side.</param>
                    /// <param name="right">The length value to apply to the right padding side.</param>
                    /// <param name="bottom">The length value to apply to the bottom padding side.</param>
                    /// <param name="left">The length value to apply to the left padding side.</param>
                    /// <returns></returns>
                    public static StyleRule Padding(Length top, Length right, Length bottom, Length left)
                    {
                        if (top.isAuto || right.isAuto || bottom.isAuto || left.isAuto)
                        {
                            Diag.Violation("padding rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.padding, $"{top} {left} {right} {bottom}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.padding, $"{top} {left} {right} {bottom}");
                        }
                    }
                }
            }
        }
    }
}