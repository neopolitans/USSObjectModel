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
                    /// Create a Transition-Delay style rule with no supplied value. Defaults to 'initial' keyword. <br></br>
                    /// This is applied to specified property in the transition-property value.
                    /// </summary>
                    public static StyleRule TransitionDelay()
                    {
                        return new StyleRule(RuleType.transitionDelay, "initial");
                    }

                    /// <summary>
                    /// Create a Transition-Delay style rule with a duration value. <br></br>
                    /// This is applied to specified property in the transition-property value.
                    /// </summary>
                    /// <param name="duration">The delay before starting the transition that's applied to the property specified in transition-property.</param>
                    public static StyleRule TransitionDelay(Duration duration)
                    {
                        return new StyleRule(RuleType.transitionDelay, duration.ToString());
                    }

                    /// <summary>
                    /// Create a Transition-Delay style rule with multiple duration values. <br></br>
                    /// This is applied to specified property/properties in the transition-property value.
                    /// </summary>
                    /// <param name="durations">The delay before starting the transition that's applied to the property/properties specified in transition-property.</param>
                    /// <returns></returns>
                    public static StyleRule TransitionDelay(params Duration[] durations)
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

                            return new StyleRule(RuleType.transitionDelay, value);
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