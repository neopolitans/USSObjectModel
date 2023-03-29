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
                    /// Create a Transition style rule with a property and a duration value for the transition duration. <br></br>
                    /// <b><see langword="Docs Conflict:"/></b> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transition">MDN CSS Documentation</see> specifies the first duration value as being for the transition-duration,<br></br> 
                    /// whereas <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-Transitions.html">Unity USS Documentation</see> specifies the first duration value as being for the transition-delay. <br></br><br></br>
                    /// <b><see langword="If any new resource(s) or documentation changes come to light which clarify the order - the order specified there will used."/></b>
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Transition(AnimatableProperty property, Duration duration)
                    {
                        return new StyleRule(RuleType.transition, $"{property.Name()} {duration}");
                    }

                    /// <summary>
                    /// Create a Transition style rule with a property, a duration value for the transition duration and easing style. <br></br>
                    /// <b><see langword="Docs Conflict:"/></b> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transition">MDN CSS Documentation</see> specifies the first duration value as being for the transition-duration,<br></br> 
                    /// whereas <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-Transitions.html">Unity USS Documentation</see> specifies the first duration value as being for the transition-delay. <br></br><br></br>
                    /// <b><see langword="If any new resource(s) or documentation changes come to light which clarify the order - the order specified there will used."/></b>
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Transition(AnimatableProperty property, Duration duration, EasingValue easingStyle)
                    {
                        return new StyleRule(RuleType.transition, $"{property.Name()} {duration} {easingStyle.Name()}");
                    }

                    /// <summary>
                    /// Create a Transition style rule with a property and two duration values. <br></br>
                    /// The first duration value specifies the length of the animation, the second duration value specifies the delay before starting the transition. <br></br><br></br>
                    /// <b><see langword="Docs Conflict:"/></b> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transition">MDN CSS Documentation</see> specifies the first duration value as being for the transition-duration,<br></br> 
                    /// whereas <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-Transitions.html">Unity USS Documentation</see> specifies the first duration value as being for the transition-delay. <br></br><br></br>
                    /// <b><see langword="If any new resource(s) or documentation changes come to light which clarify the order - the order specified there will used."/></b>
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Transition(AnimatableProperty property, Duration duration, Duration delay)
                    {
                        return new StyleRule(RuleType.transition, $"{property.Name()} {duration} {delay}");
                    }

                    /// <summary>
                    /// Create a Transition style rule with a property, two duration values and easing style. <br></br>
                    /// The first duration value specifies the length of the animation, the second duration value specifies the delay before starting the transition. <br></br><br></br>
                    /// <b><see langword="Docs Conflict:"/></b> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transition">MDN CSS Documentation</see> specifies the first duration value as being for the transition-duration,<br></br> 
                    /// whereas <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-Transitions.html">Unity USS Documentation</see> specifies the first duration value as being for the transition-delay. <br></br><br></br>
                    /// <b><see langword="If any new resource(s) or documentation changes come to light which clarify the order - the order specified there will used."/></b>
                    /// </summary>
                    /// <returns></returns>
                    public static StyleRule Transition(AnimatableProperty property, Duration duration, Duration delay, EasingValue easingStyle)
                    {
                        return new StyleRule(RuleType.transition, $"{property.Name()} {duration} {delay} {easingStyle.Name()}");
                    }

                    public static StyleRule Transition(params TransitionValue[] transitions)
                    {
                        if (transitions.Length >= 1)
                        {
                            string value = "";
                            int i = 0;

                            foreach (TransitionValue tv in transitions)
                            {
                                i++;
                                value = value + (i < transitions.Length - 1 ? tv.value + ", " : tv.value);
                            }

                            return new StyleRule(RuleType.transition, value);
                        }
                        else
                        {
                            Diag.Violation("There are no ImagePosition objects for this transition-timing-function rule. No style rule created.");
                            return null;
                        }
                    }
                }
            }
        }
    }
}