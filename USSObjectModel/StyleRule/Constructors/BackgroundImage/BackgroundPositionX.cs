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
                    // ImageAlignmentX Enum

                    /// <summary>
                    /// An Enum representation of all the keywords that background-position-x style rules can be have, if one keyword value is provided.
                    /// </summary>
                    public enum ImageAlignmentX
                    {
                        /// <summary>
                        /// USS: "left" keyword.
                        /// </summary>
                        left,
                        
                        /// <summary>
                        /// USS: "center" keyword.
                        /// </summary>
                        center,
                        
                        /// <summary>
                        /// USS: "right" keyword.
                        /// </summary>
                        right
                    }

                    /// <summary>
                    /// Convert the provided ImageAlignmentX enum value to it's string representation in USS. <br></br>
                    /// Defaults to "left" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this ImageAlignmentX value)
                    {
                        return value switch
                        {
                            ImageAlignmentX.left => "left",
                            ImageAlignmentX.center => "center",
                            ImageAlignmentX.right => "right",
                            _ => "left"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a ImageAlignmentX enum value. <br></br>
                    /// Defaults to [ImageAlignmentX.left] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static ImageAlignmentX ToImageAlignmentX(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "left" => ImageAlignmentX.left,
                            "center" => ImageAlignmentX.center,
                            "right" => ImageAlignmentX.right,
                            _ => ImageAlignmentX.left
                        };
                    }

                    // ImagePositionX

                    /// <summary>
                    /// An object representing image position parameters for each image's horizontal axis when there are multiple present. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This object is exclusively used for background-position-x, for dealing with multiple images. <br></br> 
                    /// It shares all the same constructors as background-position-x does, minus the params <see cref="ImagePositionX"/>[] variant.
                    /// </summary>
                    public class ImagePositionX
                    {
                        public string value;
                        public bool valid;

                        /// <summary>
                        /// Create an ImagePositionX object with a keyword value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a keyword value, the value is used to define which edge the background image is placed against.<br></br>
                        /// </summary>
                        public ImagePositionX(ImageAlignmentX keyword)
                        {
                            value = keyword.Name();
                        }

                        /// <summary>
                        /// Create an ImagePositionX object with a length value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a length value, the value is used for the offset from the left edge. <br></br>
                        /// </summary>
                        public ImagePositionX(Length length)
                        {
                            if (length.isAuto)
                            {
                                Diag.Violation("ImagePositionX objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                valid = true;
                            }
                            value = length.ToString();
                        }

                        /// <summary>
                        /// Create an ImagePositionX object with a keyword value and a length. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a keyword value and a length value: <br></br>
                        /// - The first value is used to define which edge the background image is placed against.<br></br>
                        /// - The second value is used for the offset from the edge defined in the preceeding keyword.
                        /// </summary>
                        public ImagePositionX(ImageAlignmentX keyword, Length length)
                        {
                            if (length.isAuto)
                            {
                                Diag.Violation("ImagePositionX objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                valid = true;
                            }
                            value = $"{keyword.Name()} {length}";
                        }
                    }

                    // background-position-x Style Rule Constructors

                    /// <summary>
                    /// Create a Background Position X Style Rule with a keyword value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> The edge alignment along the X axis for the background image - left, center or right.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Background Position X. Restricted to only the compatible keywords.</param>
                    public static StyleRule BackgroundPositionX(ImageAlignmentX keyword)
                    {
                        return new StyleRule(RuleType.backgroundPositionX, keyword.Name());
                    }

                    /// <summary>
                    /// Create a Background Position X Style Rule with a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with a length value, the value is used for the offset from the left edge.
                    /// </summary>
                    public static StyleRule BackgroundPositionX(Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("background-position-x rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPositionX, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.backgroundPositionX, length.ToString());
                        }
                    }

                    /// <summary>
                    /// Create a Background Position X Style Rule with a keyword value and a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with a keyword value and a length values: <br></br>
                    /// - The first value is used to define which edge the background image is placed against.<br></br>
                    /// - The second value is used for the offset from side defined in the preceeding keyword. <br></br>
                    /// </summary>
                    /// <param name="keyword">The keyword that defines one of the three valid options - left, center or right.</param>
                    /// <param name="length">The offset from the specified alignment keyword.</param>
                    public static StyleRule BackgroundPositionX(ImageAlignmentX keyword, Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("background-position-x rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPositionX, $"{keyword.Name()} {length}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.backgroundPositionX, $"{keyword.Name()} {length}");
                        }
                    }

                    /// <summary>
                    /// Create a Background Position X Style Rule with multiple ImagePositionX objects. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> An ImagePositionX object is constructed the same way as any other variation of the background-position-x style rule. <br></br>
                    /// The only difference is that each value contained within each image position is separated by a comma in the final compiled style rule.
                    /// </summary>
                    /// <param name="allImagePositions">The ImagePosition objects to concatenate into a larger style rule value.</param>
                    public static StyleRule BackgroundPositionX(params ImagePositionX[] allImagePositions)
                    {
                        if (allImagePositions.Length > 0)
                        {
                            string endValue = "";
                            int i = 0, invalidObjects = 0;

                            foreach (ImagePositionX ip in allImagePositions)
                            {
                                i++;
                                if (!ip.valid)
                                { invalidObjects++; continue; }

                                endValue = endValue + (i < allImagePositions.Length - 1 ? ip.value + ", " : ip.value);
                            }

                            if (invalidObjects == allImagePositions.Length)
                            {
                                Diag.Violation("There are no valid ImagePositionX objects for this background-position-x rule and no compiled string could be generated. No style rule created.");
                                return null;
                            }
                            else
                            {
                                return new StyleRule(RuleType.backgroundPositionX, endValue);
                            }
                        }
                        else
                        {
                            Diag.Violation("There are no ImagePositionX objects for this background-position-x rule. No style rule created.");
                            return null;
                        }
                    }
                }
            }
        }
    }
}
#endif