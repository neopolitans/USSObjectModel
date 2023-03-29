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
                    /// Create a Scale style rule with an integer value for the X axis. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> The USS documentation states that Y can be omitted if it equals X. <br></br> 
                    /// <b><i>The stated "one value for two axes" behaviour may not work as <see langword="MDN CSS"/> states only X would be moved.</i></b>
                    /// </summary>
                    /// <param name="x">The scale percentage value along the X axis.</param>
                    public static StyleRule Scale(int x)
                    {
                        return new StyleRule(RuleType.scale, new Length(x, true).ToString());
                    }

                    /// <summary>
                    /// Create a Scale style rule with an number value for the X axis. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> The USS documentation states that Y can be omitted if it equals X. <br></br> 
                    /// <b><i>The stated "one value for two axes" behaviour may not work as <see langword="MDN CSS"/> states only X would be moved.</i></b>
                    /// </summary>
                    /// <param name="x">The scale floating point value along the X axis.</param>
                    public static StyleRule Scale(Number x)
                    {
                        return new StyleRule(RuleType.scale, x.ToString());
                    }

                    /// <summary>
                    /// Create a Scale style rule with two integer values for a percentage scale for the x and y axes.
                    /// </summary>
                    /// <param name="x">The scale percentage value along the X axis.</param>
                    /// <param name="y">The scale percentage value along the Y axis.</param>
                    public static StyleRule Scale(int x, int y)
                    {
                        return new StyleRule(RuleType.scale, $"{new Length(x, true)} {new Length(y, true)}");
                    }

                    /// <summary>
                    /// Create a Scale style rule with one number value and one integer value for a floating point scale for the x axis and percentage for the y axis.
                    /// </summary>
                    /// <param name="x">The scale floating point value along the X axis.</param>
                    /// <param name="y">The scale percentage value along the Y axis.</param>
                    public static StyleRule Scale(Number x, int y)
                    {
                        return new StyleRule(RuleType.scale, $"{x} {new Length(y, true)}");
                    }

                    /// <summary>
                    /// Create a Scale style rule with one integer value and one number value for a percentage scale for the x axis and floating point for the y axis.
                    /// </summary>
                    /// <param name="x">The scale percentage value along the X axis.</param>
                    /// <param name="y">The scale floating point value along the Y axis.</param>
                    public static StyleRule Scale(int x, Number y)
                    {
                        return new StyleRule(RuleType.scale, $"{new Length(x, true)} {y}");
                    }

                    /// <summary>
                    /// Create a Scale style rule with two number values for a floating point scale for the x and y axes.
                    /// </summary>
                    /// <param name="x">The scale floating point value along the X axis.</param>
                    /// <param name="y">The scale floating point value along the Y axis.</param>
                    public static StyleRule Scale(Number x, Number y)
                    {
                        return new StyleRule(RuleType.scale, $"{x} {y}");
                    }
                }
            }
        }
    }
}