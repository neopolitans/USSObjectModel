#if UNITY_2022_2_OR_NEWER
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
                    /// An Enum representation of all the keywords that the background-repeat style rule's value can be assigned, if one parameter is provided.
                    /// </summary>
                    public enum RepeatValue
                    {
                        /// <summary>
                        /// USS: "repeat-x" keyword.
                        /// </summary>
                        repeatX,

                        /// <summary>
                        /// USS: "repeat-y" keyword.
                        /// </summary>
                        repeatY,

                        /// <summary>
                        /// USS: "repeat" keyword.
                        /// </summary>
                        repeat,

                        /// <summary>
                        /// USS: "space" keyword.
                        /// </summary>
                        space,

                        /// <summary>
                        /// USS: "round" keyword.
                        /// </summary>
                        round,

                        /// <summary>
                        /// USS: "no-repeat" keyword.
                        /// </summary>
                        noRepeat
                    }

                    /// <summary>
                    /// Convert the provided RepeatValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "repeat" if an invalid value is prvoided. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat">background-repeat</see> has an initial value of 'repeat'. This is used as the default value.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this RepeatValue value)
                    {
                        return value switch
                        {
                            RepeatValue.repeatX => "repeat-x",
                            RepeatValue.repeatY => "repeat-y",
                            RepeatValue.repeat => "repeat",
                            RepeatValue.space => "space",
                            RepeatValue.round => "round",
                            RepeatValue.noRepeat => "no-repeat",
                            _ => "repeat"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a RepeatValue enum value. <br></br>
                    /// Defaults to [RepeatValue.repeat] if an invalid value is provided. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat">background-repeat</see> has an initial value of 'repeat'. This is used as the default value.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static RepeatValue ToRepeatValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "repeat-x" => RepeatValue.repeatX,
                            "repeat-y" => RepeatValue.repeatY,
                            "repeat" => RepeatValue.repeat,
                            "space" => RepeatValue.space,
                            "round" => RepeatValue.round,
                            "no-repeat" => RepeatValue.noRepeat,
                            _ => RepeatValue.repeat
                        };
                    }

                    /// <summary>
                    /// An Enum representation of all the keywords that the background-repeat style rule's value can be assigned per axis, if two parameters are provided.
                    /// </summary>
                    public enum RepeatSingleValue
                    {
                        /// <summary>
                        /// USS: "repeat" keyword.
                        /// </summary>
                        repeat,

                        /// <summary>
                        /// USS: "space" keyword.
                        /// </summary>
                        space,

                        /// <summary>
                        /// USS: "round" keyword.
                        /// </summary>
                        round,

                        /// <summary>
                        /// USS: "no-repeat" keyword.
                        /// </summary>
                        noRepeat
                    }

                    /// <summary>
                    /// Convert the provided RepeatSingleValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "repeat" if an invalid value is prvoided. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat">background-repeat</see> has an initial value of 'repeat'. This is used as the default value.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this RepeatSingleValue value)
                    {
                        return value switch
                        {
                            RepeatSingleValue.repeat => "repeat",
                            RepeatSingleValue.space => "space",
                            RepeatSingleValue.round => "round",
                            RepeatSingleValue.noRepeat => "no-repeat",
                            _ => "repeat"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a RepeatSingleValue enum value. <br></br>
                    /// Defaults to [RepeatSingleValue.repeat] if an invalid value is provided. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat">background-repeat</see> has an initial value of 'repeat'. This is used as the default value.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static RepeatSingleValue ToRepeatSingleValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "repeat" => RepeatSingleValue.repeat,
                            "space" => RepeatSingleValue.space,
                            "round" => RepeatSingleValue.round,
                            "no-repeat" => RepeatSingleValue.noRepeat,
                            _ => RepeatSingleValue.repeat
                        };
                    }

                    /// <summary>
                    /// Create a Background-Repeat Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Background Repeat. Restricted to only the compatible keywords.</param>
                    public static StyleRule BackgroundRepeat(RepeatValue keyword)
                    {
                        return new StyleRule(RuleType.backgroundRepeat, keyword.Name());
                    }

                    /// <summary>
                    /// Create a Background-Repeat Style Rule with two keyword values.
                    /// </summary>
                    /// <param name="horizontal">The keyword value which defines how the background-image repeats horizontally.</param>
                    /// <param name="horizontal">The keyword value which defines how the background-image repeats vertically.</param>
                    public static StyleRule BackgroundRepeat(RepeatSingleValue horizontal, RepeatSingleValue vertical)
                    {
                        return new StyleRule(RuleType.backgroundRepeat, $"{horizontal.Name()} {vertical.Name()}");
                    }
                }
            }
        }
    }
}
#endif