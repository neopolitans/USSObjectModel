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
                    /// <summary>
                    /// An object representing image position parameters for each image when there are multiple present. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This object is exclusively used for background-position, for dealing with multiple images. <br></br> 
                    /// It shares all the same constructors as background-position does, minus the params <see cref="ImagePosition"/>[] variant.
                    /// </summary>
                    public class ImagePosition
                    {
                        public string value;
                        public readonly bool valid;

                        /// <summary>
                        /// Create an ImagePosition object with a keyword value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with an Image Alignment keyword that is not 'center', the image aligns to that edge. <br></br>
                        /// The other dimension value is then set to 50%. If the keyword value is 'center', the image is centered.<br></br><br></br>
                        /// <see langword="Cappuccino:"/> Supports use of the "center" keyword. Only BackgroundPosition constructor that supports this keyword.
                        /// </summary>
                        /// <param name="keyword">The USS keyword to be applied to Background Position. Restricted to only the compatible keywords.</param>
                        public ImagePosition(Alignment keyword)
                        {
                            valid = true;
                            value = keyword.Name();
                        }

                        /// <summary>
                        /// Create an ImagePosition object with a length value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a length value, the value is used for the X coordinate from the left edge. <br></br>
                        /// The Y corodinate is set to 50% as the default, centering the image.<br></br><br></br>
                        /// </summary>
                        public ImagePosition(Length length)
                        {
                            if (length.IsAuto())
                            {
                                Diag.Violation("ImagePosition objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                valid = true;
                            }
                            value = length.ToString();
                        }

                        /// <summary>
                        /// Create an ImagePosition object with two length values. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with two length values, the first value is used for the offset from the left edge (X) and the second value is used for the offset from the top edge (Y).
                        /// </summary>
                        /// <param name="x">The offset from left side.</param>
                        /// <param name="y">The offset from top side.</param>
                        public ImagePosition(Length x, Length y)
                        {
                            if (x.IsAuto() || y.IsAuto())
                            {
                                Diag.Violation("ImagePosition objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                valid = true;
                            }
                            value = $"{x} {y}";
                        }

                        /// <summary>
                        /// Create an ImagePosition object with a keyword value and a length value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a keyword value and a length values: <br></br>
                        /// - The first value is the keyword that defines one of the two axis sides.<br></br>
                        /// - The second value is used for the offset from default value of the other axis. <br></br>
                        /// </summary>
                        /// <param name="keyword">The keyword that defines one of the axis sides which the image will be placed against.</param>
                        /// <param name="length">The offset from other axis side. If the keyword is an X axis keyword (left/right), this will apply to the Y axis and vice versa.</param>
                        public ImagePosition(AlignmentMultiple keyword, Length length)
                        {
                            if (length.IsAuto())
                            {
                                Diag.Violation("ImagePosition objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                valid = true;
                            }
                            value = $"{keyword.Name()} {length}";
                        }

                        /// <summary>
                        /// Create an ImagePosition object with a keyword value and a length value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with a keyword value and a length values: <br></br>
                        /// - The first value is used for the offset from default value of whichever axis isn't assigned to in the second value. <br></br> 
                        /// - The second value is the keyword that defines one of the two axis sides. <br></br>
                        /// </summary>
                        /// <param name="length">The offset from other axis side. If the keyword is an X axis keyword (left/right), this will apply to the Y axis and vice versa.</param>
                        /// <param name="keyword">The keyword that defines one of the axis sides which the image will be placed against.</param>
                        public ImagePosition(Length length, AlignmentMultiple keyword)
                        {
                            if (length.IsAuto())
                            {
                                Diag.Violation("ImagePosition objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                valid = true;
                            }
                            value = $"{length} {keyword.Name()}";
                        }

                        /// <summary>
                        /// Create an ImagePosition object with two keywords and a length value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with two keywords and a length value: <br></br>
                        ///  - The first and third values are ImageAlignment keywords which dictate which edge to place the image(s) against. One must represent X and the other Y otherwise the style rule is invalidated. <br></br>
                        ///  - The second value, the length, dicates the offset from the edge defined in the first value.
                        /// </summary>
                        /// <param name="firstEdge">The first edge keyword which defines the edge that the image is placed against. Can be X or Y.</param>
                        /// <param name="length">The offset from the first edge.</param>
                        /// <param name="secondEdge">The second edge keyword which defines the edge that the image is placed against. Must an X-axis keyword if the first is a Y-axis keyword and vice versa.</param>
                        /// <returns></returns>
                        public ImagePosition(AlignmentMultiple firstEdge, Length length, AlignmentMultiple secondEdge)
                        {
                            if (firstEdge.Conflicts(secondEdge))
                            {
                                Diag.Violation("The first axis keyword and the second axis keyword conflicts in this ImagePosition object. This ImagePosition object has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                if (length.IsAuto())
                                {
                                    Diag.Violation("ImagePosition objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                    valid = false;
                                }
                                else
                                {
                                    valid = true;
                                }
                            }

                            value = $"{firstEdge.Name()} {length} {secondEdge.Name()}";
                        }

                        /// <summary>
                        /// Create an ImagePosition object with two keywords and a length value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with two keywords and a length value: <br></br>
                        ///  - The first and second values are ImageAlignment keywords which dictate which edge to place the image(s) against. One must represent X and the other Y otherwise the style rule is invalidated. <br></br>
                        ///  - The third value, the length, dicates the offset from the edge defined in the first value.
                        /// </summary>
                        /// <param name="firstEdge">The first edge keyword which defines the edge that the image is placed against. Can be X or Y.</param>
                        /// <param name="length">The offset from the first edge.</param>
                        /// <param name="secondEdge">The second edge keyword which defines the edge that the image is placed against. Must an X-axis keyword if the first is a Y-axis keyword and vice versa.</param>
                        public ImagePosition(AlignmentMultiple firstEdge, AlignmentMultiple secondEdge, Length length)
                        {
                            if (firstEdge.Conflicts(secondEdge))
                            {
                                Diag.Violation("The first axis keyword and the second axis keyword conflicts in this ImagePosition object. This ImagePosition object has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                if (length.IsAuto())
                                {
                                    Diag.Violation("ImagePosition objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                    valid = false;
                                }
                                else
                                {
                                    valid = true;
                                }
                            }

                            value = $"{firstEdge.Name()} {secondEdge.Name()} {length}";
                        }

                        /// <summary>
                        /// Create an ImagePosition object with two keywords and two length values. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When provided with two keywords and two length values: <br></br>
                        ///  - The first and third values are ImageAlignment keywords which dictate which edge to place the image(s) against. One must represent X and the other Y otherwise the style rule is invalidated. <br></br>
                        ///  - The second and fourth value are the length values which dicate the offset from the edge defined by the preceding keyword value.
                        /// </summary>
                        /// <param name="firstEdge">The first edge keyword which defines the edge that the image is placed against. Can be X or Y.</param>
                        /// <param name="firstLength">The offset from the first edge.</param>
                        /// <param name="secondEdge">The second edge keyword which defines the edge that the image is placed against. Must an X-axis keyword if the first is a Y-axis keyword and vice versa.</param>
                        /// <param name="secondLength">The offset from the second edge.</param>
                        public ImagePosition(AlignmentMultiple firstEdge, Length firstLength, AlignmentMultiple secondEdge, Length secondLength)
                        {
                            if (firstEdge.Conflicts(secondEdge))
                            {
                                Diag.Violation("The first axis keyword and the second axis keyword conflicts in this ImagePosition object. This ImagePosition object has been marked as invalid.");
                                valid = false;
                            }
                            else
                            {
                                if (firstLength.IsAuto() || secondLength.IsAuto())
                                {
                                    Diag.Violation("ImagePosition objects do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                    valid = false;
                                }
                                else
                                {
                                    valid = true;
                                }
                            }

                            value = $"{firstEdge.Name()} {firstLength} {secondEdge.Name()} {secondLength}";
                        }
                    }
                }
            }
        }
    }
}
#endif