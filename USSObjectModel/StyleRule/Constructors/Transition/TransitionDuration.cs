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
                    /// Create a Transition-Duration style rule with no supplied value. Defaults to 'initial' keyword. <br></br>
                    /// This is applied to specified property in the transition-property value.
                    /// </summary>
                    public static StyleRule TransitionDuration()
                    {
                        return new StyleRule(RuleType.transitionDuration, "initial");
                    }

                    /// <summary>
                    /// Create a Transition-Duration style rule with a duration value. <br></br>
                    /// This is applied to specified property in the transition-property value.
                    /// </summary>
                    /// <param name="duration">The duration for the property specified in transition-property.</param>
                    public static StyleRule TransitionDuration(Duration duration)
                    {
                        return new StyleRule(RuleType.transitionDuration, duration.ToString());
                    }

                    /// <summary>
                    /// Create a Transition-Duration style rule with multiple duration values. <br></br>
                    /// This is applied to specified property/properties in the transition-property value.
                    /// </summary>
                    /// <param name="durations">The durations for the property/properties specified in transition-property.</param>
                    /// <returns></returns>
                    public static StyleRule TransitionDuration(params Duration[] durations)
                    {
                        if (durations.Length >= 1)
                        {
                            string value = "";
                            int i = 0;

                            foreach (Duration dv in durations)
                            {
                                i++;
                                value = value + (i < durations.Length - 1 ? dv.ToString() + ", " : dv.ToString());
                            }

                            return new StyleRule(RuleType.transitionDuration, value);
                        }
                        else
                        {
                            Diag.Violation("There are no duration values for this transition-duration rule. No style rule created.");
                            return null;
                        }
                    }
                }
            }
        }
    }
}