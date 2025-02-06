#if UNITY_2022_2_OR_NEWER
using Cappuccino.Core;
using UnityEngine.UIElements;

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
                    // ImageAlignmentX Enum

                    /// <summary>
                    /// An Enum representation of all the keywords that background-position-y style rules can be have, if one keyword value is provided.
                    /// </summary>
                    public enum ImageAlignmentY
                    {
                        /// <summary>
                        /// USS: "top" keyword.
                        /// </summary>
                        top,
                        
                        /// <summary>
                        /// USS: "center" keyword.
                        /// </summary>
                        center,

                        /// <summary>
                        /// USS: "bottom" keyword.
                        /// </summary>
                        bottom
                    }

                    /// <summary>
                    /// Convert the provided ImageAlignmentY enum value to it's string representation in USS. <br></br>
                    /// Defaults to "top" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this ImageAlignmentY value)
                    {
                        return value switch
                        {
                            ImageAlignmentY.top => "top",
                            ImageAlignmentY.center => "center",
                            ImageAlignmentY.bottom => "bottom",
                            _ => "top"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a ImageAlignmentY enum value. <br></br>
                    /// Defaults to [ImageAlignmentY.top] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static ImageAlignmentY ToImageAlignmentY(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "top" => ImageAlignmentY.top,
                            "center" => ImageAlignmentY.center,
                            "bottom" => ImageAlignmentY.bottom,
                            _ => ImageAlignmentY.top
                        };
                    }

                    // ImagePositionX

                    /// <summary>
                    /// An object representing image position parameters for each image's vertical axis when there are multiple present. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This object is exclusively used for background-position-y, for dealing with multiple images. <br></br> 
                    /// It shares all the same constructors as background-position-y does, minus the params <see cref="ImagePositionY"/>[] variant.
                    /// </summary>
                    public class ImagePositionY
                    {
                        public string value;
                        public bool valid;

                        /// <summary>
                        /// Create an ImagePositionY object with a keyword value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a keyword value, the value is used to define which edge the background image is placed against.<br></br>
                        /// </summary>
                        public ImagePositionY(ImageAlignmentY keyword)
                        {
                            value = keyword.Name();
                        }

                        /// <summary>
                        /// Create an ImagePositionY object with a length value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a length value, the value is used for the offset from the top edge. <br></br>
                        /// </summary>
                        public ImagePositionY(Length length)
                        {
                            if (length.IsAuto())
                            {
                                Diag.Violation("ImagePositionY objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                valid = true;
                            }
                            value = length.ToString();
                        }

                        /// <summary>
                        /// Create an ImagePositionY object with a keyword value and a length. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a keyword value and a length value: <br></br>
                        /// - The first value is used to define which edge the background image is placed against.<br></br>
                        /// - The second value is used for the offset from the edge defined in the preceeding keyword.
                        /// </summary>
                        public ImagePositionY(ImageAlignmentY keyword, Length length)
                        {
                            if (length.IsAuto())
                            {
                                Diag.Violation("ImagePositionY objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                valid = true;
                            }
                            value = $"{keyword.Name()} {length}";
                        }
                    }

                    // background-position-y Style Rule Constructors

                    /// <summary>
                    /// Create a Background Position Y Style Rule with a keyword value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> The edge alignment along the Y axis for the background image - top, center or bottom.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Background Position Y. Restricted to only the compatible keywords.</param>
                    public static StyleRule BackgroundPositionX(ImageAlignmentY keyword)
                    {
                        return new StyleRule(RuleType.backgroundPositionY, keyword.Name());
                    }

                    /// <summary>
                    /// Create a Background Position Y Style Rule with a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with a length value, the value is used for the offset from the top edge.
                    /// </summary>
                    public static StyleRule BackgroundPositionY(Length length)
                    {
                        if (length.IsAuto())
                        {
                            Diag.Violation("background-position-y rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPositionY, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.backgroundPositionY, length.ToString());
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Y Style Rule with a keyword value and a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with a keyword value and a length values: <br></br>
                    /// - The first value is used to define which edge the background image is placed against.<br></br>
                    /// - The second value is used for the offset from side defined in the preceeding keyword. <br></br>
                    /// </summary>
                    /// <param name="keyword">The keyword that defines one of the three valid options - top, center or bottom.</param>
                    /// <param name="length">The offset from the specified alignment keyword.</param>
                    public static StyleRule BackgroundPositionY(ImageAlignmentY keyword, Length length)
                    {
                        if (length.IsAuto())
                        {
                            Diag.Violation("background-position-y rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPositionY, $"{keyword.Name()} {length}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.backgroundPositionY, $"{keyword.Name()} {length}");
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Y Style Rule with multiple ImagePositionY objects. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> An ImagePositionY object is constructed the same way as any other variation of the background-position-y style rule. <br></br>
                    /// The only difference is that each value contained within each image position is separated by a comma in the final compiled style rule.
                    /// </summary>
                    /// <param name="allImagePositions">The ImagePosition objects to concatenate into a larger style rule value.</param>
                    public static StyleRule BackgroundPositionY(params ImagePositionY[] allImagePositions)
                    {
                        if (allImagePositions.Length > 0)
                        {
                            string endValue = "";
                            int i = 0, invalidObjects = 0;

                            foreach (ImagePositionY ip in allImagePositions)
                            {
                                i++;
                                if (!ip.valid)
                                { invalidObjects++; continue; }

                                endValue = endValue + (i < allImagePositions.Length - 1 ? ip.value + ", " : ip.value);
                            }

                            if (invalidObjects == allImagePositions.Length)
                            {
                                Diag.Violation("There are no valid ImagePositionY objects for this background-position-y rule and no compiled string could be generated. No style rule created.");
                                return null;
                            }
                            else
                            {
                                return new StyleRule(RuleType.backgroundPositionY, endValue);
                            }
                        }
                        else
                        {
                            Diag.Violation("There are no ImagePositionY objects for this background-position-y rule. No style rule created.");
                            return null;
                        }
                    }
                }
            }
        }
    }
}
#endif