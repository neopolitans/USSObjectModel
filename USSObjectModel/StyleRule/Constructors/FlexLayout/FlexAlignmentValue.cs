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
                    /// An Enum representation of core Alignment Value keywords for style rules that only take <b>{flex-start}</b>, <b>{flex-end}</b>, <b>{center}</b> or <b>{stretch}</b>.<br></br>
                    /// For example: "align-content" or "align-items".
                    /// </summary>
                    public enum FlexAlignmentValue
                    {
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
                    /// Convert the provided AlignmentValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "flex-start" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this FlexAlignmentValue value)
                    {
                        return value switch
                        {
                            FlexAlignmentValue.flexStart => "flex-start",
                            FlexAlignmentValue.flexEnd => "flex-end",
                            FlexAlignmentValue.center => "center",
                            FlexAlignmentValue.stretch => "stretch",
                            _ => "flex-start"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into an AlignmentValue enum value. <br></br>
                    /// Defaults to [AlignmentValue.flexStart] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static FlexAlignmentValue ToAlignmentValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "flex-start" => FlexAlignmentValue.flexStart,
                            "flex-end" => FlexAlignmentValue.flexEnd,
                            "center" => FlexAlignmentValue.center,
                            "stretch" => FlexAlignmentValue.stretch,
                            _ => FlexAlignmentValue.flexStart
                        };
                    }
                }
            }
        }
    }
}