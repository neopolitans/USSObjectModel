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
                    /// An Enum representation of all the keywords that the transition-timing-function style rule can be assigned.
                    /// </summary>
                    public enum EasingValue
                    {
                        /// <summary>
                        /// USS Easing Function: ease
                        /// </summary>
                        ease,

                        /// <summary>
                        /// USS Easing Function: ease-in
                        /// </summary>
                        easeIn,

                        /// <summary>
                        /// USS Easing Function: ease-out
                        /// </summary>
                        easeOut,

                        /// <summary>
                        /// USS Easing Function: ease-in-out
                        /// </summary>
                        easeInOut,

                        /// <summary>
                        /// USS Easing Function: linear
                        /// </summary>
                        linear,

                        /// <summary>
                        /// USS Easing Function: ease-in-sine
                        /// </summary>
                        easeInSine,

                        /// <summary>
                        /// USS Easing Function: ease-out-sine
                        /// </summary>
                        easeOutSine,

                        /// <summary>
                        /// USS Easing Function: ease-in-out-sine
                        /// </summary>
                        easeInOutSine,

                        /// <summary>
                        /// USS Easing Function: ease-in-cubic
                        /// </summary>
                        easeInCubic,

                        /// <summary>
                        /// USS Easing Function: ease-out-cubic
                        /// </summary>
                        easeOutCubic,

                        /// <summary>
                        /// USS Easing Function: ease-in-out-cubic
                        /// </summary>
                        easeInOutCubic,

                        /// <summary>
                        /// USS Easing Function: ease-in-circ
                        /// </summary>
                        easeInCirc,

                        /// <summary>
                        /// USS Easing Function: ease-out-circ
                        /// </summary>
                        easeOutCirc,

                        /// <summary>
                        /// USS Easing Function: ease-in-out-circ
                        /// </summary>
                        easeInOutCirc,

                        /// <summary>
                        /// USS Easing Function: ease-in-elastic
                        /// </summary>
                        easeInElastic,

                        /// <summary>
                        /// USS Easing Function: ease-out-elastic
                        /// </summary>
                        easeOutElastic,

                        /// <summary>
                        /// USS Easing Function: ease-in-out-elastic
                        /// </summary>
                        easeInOutElastic,

                        /// <summary>
                        /// USS Easing Function: ease-in-back
                        /// </summary>
                        easeInBack,

                        /// <summary>
                        /// USS Easing Function: ease-out-back
                        /// </summary>
                        easeOutBack,

                        /// <summary>
                        /// USS Easing Function: ease-in-out-back
                        /// </summary>
                        easeInOutBack,

                        /// <summary>
                        /// USS Easing Function: ease-in-bounce
                        /// </summary>
                        easeInBounce,

                        /// <summary>
                        /// USS Easing Function: ease-out-bounce
                        /// </summary>
                        easeOutBounce,

                        /// <summary>
                        /// USS Easing Function: ease-in-out-bounce
                        /// </summary>
                        easeInOutBounce
                    }

                    /// <summary>
                    /// Convert the provided EasingValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "ease" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this EasingValue value)
                    {
                        return value switch
                        {
                            EasingValue.ease => "ease",
                            EasingValue.easeIn => "ease-in",
                            EasingValue.easeOut => "ease-out",
                            EasingValue.easeInOut => "ease-in-out",
                            EasingValue.linear => "linear",
                            EasingValue.easeInSine => "ease-in-sine",
                            EasingValue.easeOutSine => "ease-out-sine",
                            EasingValue.easeInOutSine => "ease-in-out-sine",
                            EasingValue.easeInCubic => "ease-in-cubic",
                            EasingValue.easeOutCubic => "ease-out-cubic",
                            EasingValue.easeInOutCubic => "ease-in-out-cublic",
                            EasingValue.easeInCirc => "ease-in-circ",
                            EasingValue.easeOutCirc => "ease-out-circ",
                            EasingValue.easeInOutCirc => "ease-in-out-circ",
                            EasingValue.easeInElastic => "ease-in-elastic",
                            EasingValue.easeOutElastic => "ease-out-elastic",
                            EasingValue.easeInOutElastic => "ease-in-out-elastic",
                            EasingValue.easeInBack => "ease-in-back",
                            EasingValue.easeOutBack => "ease-out-back",
                            EasingValue.easeInOutBack => "ease-in-out-back",
                            EasingValue.easeInBounce => "ease-in-bounce",
                            EasingValue.easeOutBounce => "ease-out-bounce",
                            EasingValue.easeInOutBounce => "ease-in-out-bounce",
                            _ => "ease"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a EasingValue enum value. <br></br>
                    /// Defaults to [EasingValue.ease] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static EasingValue ToEasingValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "ease" => EasingValue.ease,
                            "ease-in" => EasingValue.easeIn,
                            "ease-out" => EasingValue.easeOut,
                            "ease-in-out" => EasingValue.easeInOut,
                            "linear" => EasingValue.linear,
                            "ease-in-sine" => EasingValue.easeInSine,
                            "ease-out-sine" => EasingValue.easeOutSine,
                            "ease-in-out-sine" => EasingValue.easeInOutSine,
                            "ease-in-cubic" => EasingValue.easeInCubic,
                            "ease-out-cubic" => EasingValue.easeOutCubic,
                            "ease-in-out-cublic" => EasingValue.easeInOutCubic,
                            "ease-in-circ" => EasingValue.easeInCirc,
                            "ease-out-circ" => EasingValue.easeOutCirc,
                            "ease-in-out-circ" => EasingValue.easeInOutCirc,
                            "ease-in-elastic" => EasingValue.easeInElastic,
                            "ease-out-elastic" => EasingValue.easeOutElastic,
                            "ease-in-out-elastic" => EasingValue.easeInOutElastic,
                            "ease-in-back" => EasingValue.easeInBack,
                            "ease-out-back" => EasingValue.easeOutBack,
                            "ease-in-out-back" => EasingValue.easeInOutBack,
                            "ease-in-bounce" => EasingValue.easeInBounce,
                            "ease-out-bounce" => EasingValue.easeOutBounce,
                            "ease-in-out-bounce" => EasingValue.easeInOutBounce,
                            _ => EasingValue.ease
                        };
                    }

                    /// <summary>
                    /// Create a Transition-Timing-Function Style Rule with the 'initial' keyword. <br></br>
                    /// <see langword="Unity USS:"/> 'initial' is equal to the value EasingValue.ease. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This constructor is provided separately as the initial keyword is the only supported keyword for transition-timing-function <br></br>
                    /// and it cannot be supplied within a comma separated list of easing functions.
                    /// </summary>
                    public static StyleRule TransitionTimingFunction()
                    {
                        return new StyleRule(RuleType.transitionTimingFunction, "initial");
                    }

                    /// <summary>
                    /// Create a Transition-Timing-Function Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Transition Timing Function. Restricted to only the compatible keywords.</param>
                    public static StyleRule TransitionTimingFunction(EasingValue keyword)
                    {
                        return new StyleRule(RuleType.transitionTimingFunction, keyword.Name());
                    }

                    /// <summary>
                    /// Create a Transition-Timing-Function Style Rule with one or more keyword values.
                    /// </summary>
                    /// <param name="keywords">The USS keywords to be concatenated and applied to Transition Timing Function. Restricted to only the compatible keywords.</param>
                    public static StyleRule TransitionTimingFunction(params EasingValue[] keywords)
                    {
                        if (keywords.Length >= 1)
                        {
                            string value = "";
                            int i = 0;

                            foreach (EasingValue ev in keywords)
                            {
                                i++;
                                value = value + (i < keywords.Length - 1 ? ev.Name() + ", " : ev.Name());
                            }

                            return new StyleRule(RuleType.transitionTimingFunction, value);
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