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
                    /// Create a Rotate style rule. The value is created with the "none" keyword by default.
                    /// </summary>
                    public static StyleRule Rotate()
                    {
                        return new StyleRule(RuleType.rotate, "none");
                    }

                    /// <summary>
                    /// Create a Rotate style rule with an angle value. <br></br>
                    /// Defaults to the <i>'none'</i> keyword if no angle value is given.
                    /// </summary>
                    /// <param name="angle">The rotation of a visual element to apply.</param>
                    public static StyleRule Translate(Angle angle)
                    {
                        return new StyleRule(RuleType.rotate, angle != null ? angle.ToString() : "none");
                    }
                }
            }
        }
    }
}