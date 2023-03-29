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
                    // Transition Property Keyword was provided in the event that someone needs to use none or initial keywords. all is included within the AnimatableProperty enumerator.
                    // none and initial, however, cannot be used by these 
                    /// <summary>
                    /// An Enum representing the keyword values that a transition-property style rule can be supplied, if one value is supplied. <br></br>
                    /// For multiple values, see: <see cref="AnimatableProperty">Animatable Properties</see>.
                    /// </summary>
                    public enum TransitionPropertyKeyword
                    {
                        all,
                        initial,
                        none
                    }

                    /// <summary>
                    /// Convert the provided TransitionPropertyKeyword enum value to it's string representation in USS. <br></br>
                    /// Defaults to "initial" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this TransitionPropertyKeyword value)
                    {
                        return value switch
                        {
                            TransitionPropertyKeyword.all => "all",
                            TransitionPropertyKeyword.initial => "initial",
                            TransitionPropertyKeyword.none => "none",
                            _ => "initial"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a TransitionPropertyKeyword enum value. <br></br>
                    /// Defaults to [TransitionPropertyKeyword.initial] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static TransitionPropertyKeyword ToTransitionPropertyKeyword(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "all" => TransitionPropertyKeyword.all,
                            "initial" => TransitionPropertyKeyword.initial,
                            "none" => TransitionPropertyKeyword.none,
                            _ => TransitionPropertyKeyword.initial
                        };
                    }

                    /// <summary>
                    /// Create a Transition-Property style rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be used as the value of Transition Property. Restricted to only the compatible keywords.</param>
                    public static StyleRule TransitionProperty(TransitionPropertyKeyword keyword)
                    {
                        return new StyleRule(RuleType.transitionProperty, keyword.Name());
                    }

                    /// <summary>
                    /// Create a Transition-Property style rule with a USS Property as the value.
                    /// </summary>
                    /// <param name="property">The USS property that will be affected by other transition-related style rules. <br></br> Restricted to only animatable (discrete or full) properties.</param>
                    public static StyleRule TransitionProperty(AnimatableProperty property)
                    {
                        return new StyleRule(RuleType.transitionProperty, property.Name());
                    }

                    /// <summary>
                    /// Create a Transition-Property style rule with one or more USS Properties as the value.
                    /// </summary>
                    /// <param name="properties">The USS property/properties that  will be affected by other transition-related style rules. <br></br> Restricted to only animatable (discrete or full) properties.</param>
                    public static StyleRule TransitionProperty(params AnimatableProperty[] properties)
                    {
                        if (properties.Length >= 1)
                        {
                            string value = "";
                            int i = 0;

                            foreach (AnimatableProperty ap in properties)
                            {
                                i++;
                                value = value + (i < properties.Length - 1 ? ap.ToString() + ", " : ap.ToString());
                            }

                            return new StyleRule(RuleType.transitionProperty, value);
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