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
                    /// An Enum representation of all the keywords that the align-self style rule's value can be assigned.
                    /// </summary>
                    public enum AlignSelfValue
                    {
                        /// <summary>
                        /// USS: "auto" keyword.
                        /// </summary>
                        auto,

                        /// <summary>
                        /// USS: "flex-start" keyword.
                        /// </summary>
                        flexStart,

                        /// <summary>
                        /// USS: "flex-end" keyword.
                        /// </summary>
                        flexEnd,

                        /// <summary>
                        /// USS: "center" keyword.
                        /// </summary>
                        center,

                        /// <summary>
                        /// USS: "stretch" keyword.
                        /// </summary>
                        stretch
                    }

                    /// <summary>
                    /// Convert the provided AlignSelfValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "auto" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this AlignSelfValue value)
                    {
                        return value switch
                        {
                            AlignSelfValue.auto => "auto",
                            AlignSelfValue.flexStart => "flex-start",
                            AlignSelfValue.flexEnd => "flex-end",
                            AlignSelfValue.center => "center",
                            AlignSelfValue.stretch => "stretch",
                            _ => "auto"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into an AlignSelfValue enum value. <br></br>
                    /// Defaults to [AlignSelfValue.auto] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static AlignSelfValue ToAlignSelfValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "auto" => AlignSelfValue.auto,
                            "flex-start" => AlignSelfValue.flexStart,
                            "flex-end" => AlignSelfValue.flexEnd,
                            "center" => AlignSelfValue.center,
                            "stretch" => AlignSelfValue.stretch,
                            _ => AlignSelfValue.auto
                        };
                    }

                    /// <summary>
                    /// Create an Align-Self Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Align Self. Restricted to only the compatible keywords.</param>
                    public static StyleRule AlignSelf(AlignSelfValue keyword)
                    {
                        return new StyleRule(RuleType.alignSelf, keyword.Name());
                    }
                }
            }
        }
    }
}