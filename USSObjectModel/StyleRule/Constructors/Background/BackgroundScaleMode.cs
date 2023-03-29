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
                    /// An Enum representation of all the keywords that the -unity-background-scale-mode style rule's value can be assigned.
                    /// </summary>
                    public enum ScaleModeValue
                    {
                        stretchToFill,
                        scaleAndCrop,
                        scaleToFit
                    }

                    /// <summary>
                    /// Convert the provided ScaleModeValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "stretch-to-fill" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this ScaleModeValue value)
                    {
                        return value switch
                        {
                            ScaleModeValue.stretchToFill => "stretch-to-fill",
                            ScaleModeValue.scaleAndCrop => "scale-and-crop",
                            ScaleModeValue.scaleToFit => "scale-to-fit",
                            _ => "stretch-to-fill"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a ScaleModeValue enum value. <br></br>
                    /// Defaults to [ScaleModeValue.stretchToFill] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static ScaleModeValue ToScaleModeValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "stretch-to-fill" => ScaleModeValue.stretchToFill,
                            "scale-and-crop" => ScaleModeValue.scaleAndCrop,
                            "scale-to-fit" => ScaleModeValue.scaleToFit,
                            _ => ScaleModeValue.stretchToFill
                        };
                    }

                    /// <summary>
                    /// Create a Unity Background Scale Mode Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to -unity-background-scale-mode. Restricted to only the compatible keywords.</param>
                    public static StyleRule BackgroundScaleMode(ScaleModeValue keyword)
                    {
                        return new StyleRule(RuleType.unityBackgroundScaleMode, keyword.Name());
                    }

                }
            }
        }
    }
}