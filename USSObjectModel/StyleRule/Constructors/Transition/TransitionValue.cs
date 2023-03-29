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
                    /// A representation of a single transition to be used in a transition style rule which defines multiple transitions at once.
                    /// </summary>
                    public class TransitionValue
                    {
                        public string value;

                        /// <summary>
                        /// Create a TransitionValue with a property and a duration value for the transition duration. <br></br>
                        /// <b><see langword="Docs Conflict:"/></b> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transition">MDN CSS Documentation</see> specifies the first duration value as being for the transition-duration,<br></br> 
                        /// whereas <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-Transitions.html">Unity USS Documentation</see> specifies the first duration value as being for the transition-delay. <br></br><br></br>
                        /// <b><see langword="If any new resource(s) or documentation changes come to light which clarify the order - the order specified there will used."/></b>
                        /// </summary>
                        /// <returns></returns>
                        public TransitionValue(AnimatableProperty property, Duration duration)
                        {
                            value = $"{property.Name()} {duration}";
                        }

                        /// <summary>
                        /// Create a TransitionValue with a property, a duration value for the transition duration and easing style. <br></br>
                        /// <b><see langword="Docs Conflict:"/></b> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transition">MDN CSS Documentation</see> specifies the first duration value as being for the transition-duration,<br></br> 
                        /// whereas <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-Transitions.html">Unity USS Documentation</see> specifies the first duration value as being for the transition-delay. <br></br><br></br>
                        /// <b><see langword="If any new resource(s) or documentation changes come to light which clarify the order - the order specified there will used."/></b>
                        /// </summary>
                        /// <returns></returns>
                        public TransitionValue(AnimatableProperty property, Duration duration, EasingValue easingStyle)
                        {
                            value = $"{property.Name()} {duration} {easingStyle.Name()}";
                        }

                        /// <summary>
                        /// Create a TransitionValue with a property and two duration values. <br></br>
                        /// The first duration value specifies the length of the animation, the second duration value specifies the delay before starting the transition. <br></br><br></br>
                        /// <b><see langword="Docs Conflict:"/></b> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transition">MDN CSS Documentation</see> specifies the first duration value as being for the transition-duration,<br></br> 
                        /// whereas <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-Transitions.html">Unity USS Documentation</see> specifies the first duration value as being for the transition-delay. <br></br><br></br>
                        /// <b><see langword="If any new resource(s) or documentation changes come to light which clarify the order - the order specified there will used."/></b>
                        /// </summary>
                        /// <returns></returns>
                        public TransitionValue(AnimatableProperty property, Duration duration, Duration delay)
                        {
                            value = $"{property.Name()} {duration} {delay}";
                        }

                        /// <summary>
                        /// Create a TransitionValue with a property, two duration values and easing style. <br></br>
                        /// The first duration value specifies the length of the animation, the second duration value specifies the delay before starting the transition. <br></br><br></br>
                        /// <b><see langword="Docs Conflict:"/></b> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transition">MDN CSS Documentation</see> specifies the first duration value as being for the transition-duration,<br></br> 
                        /// whereas <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-Transitions.html">Unity USS Documentation</see> specifies the first duration value as being for the transition-delay. <br></br><br></br>
                        /// <b><see langword="If any new resource(s) or documentation changes come to light which clarify the order - the order specified there will used."/></b>
                        /// </summary>
                        /// <returns></returns>
                        public TransitionValue(AnimatableProperty property, Duration duration, Duration delay, EasingValue easingStyle)
                        {
                            value = $"{property.Name()} {duration} {delay} {easingStyle.Name()}";
                        }
                    }
                }
            }
        }
    }
}