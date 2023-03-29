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
                    /// Create a Background Position Style Rule with a keyword value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with an Image Alignment keyword that is not 'center', the image aligns to that edge. <br></br>
                    /// The other dimension value is then set to 50%. If the keyword value is 'center', the image is centered.<br></br><br></br>
                    /// <see langword="Cappuccino:"/> Supports use of the "center" keyword. Only BackgroundPosition constructor that supports this keyword.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Background Position. Restricted to only the compatible keywords.</param>
                    public static StyleRule BackgroundPosition(Alignment keyword)
                    {
                        return new StyleRule(RuleType.backgroundPosition, keyword.Name());
                    }

                    /// <summary>
                    /// Create a Background Position Style Rule with a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with a length value, the value is used for the X coordinate from the left edge. <br></br>
                    /// The Y corodinate is set to 50% as the default, centering the image.<br></br><br></br>
                    /// </summary>
                    public static StyleRule BackgroundPosition(Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("background-position rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPosition, length.ToString(), false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.backgroundPosition, length.ToString());
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Style Rule with two length values. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with two length values, the first value is used for the offset from the left edge (X) and the second value is used for the offset from the top edge (Y).
                    /// </summary>
                    /// <param name="x">The offset from left side.</param>
                    /// <param name="y">The offset from top side.</param>
                    public static StyleRule BackgroundPosition(Length x, Length y)
                    {
                        if (x.isAuto || y.isAuto)
                        {
                            Diag.Violation("background-position rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPosition, $"{x} {y}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.backgroundPosition, $"{x} {y}");
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Style Rule with a keyword value and a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with a keyword value and a length values: <br></br>
                    /// - The first value is the keyword that defines one of the two axis sides.<br></br>
                    /// - The second value is used for the offset from default value of the other axis. <br></br>
                    /// </summary>
                    /// <param name="keyword">The keyword that defines one of the axis sides which the image will be placed against.</param>
                    /// <param name="length">The offset from other axis side. If the keyword is an X axis keyword (left/right), this will apply to the Y axis and vice versa.</param>
                    public static StyleRule BackgroundPosition(AlignmentMultiple keyword, Length length)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("background-position rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPosition, $"{keyword.Name()} {length}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.backgroundPosition, $"{keyword.Name()} {length}");
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Style Rule with a keyword value and a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with a keyword value and a length values: <br></br>
                    /// - The first value is used for the offset from default value of whichever axis isn't assigned to in the second value. <br></br> 
                    /// - The second value is the keyword that defines one of the two axis sides. <br></br>
                    /// </summary>
                    /// <param name="length">The offset from other axis side. If the keyword is an X axis keyword (left/right), this will apply to the Y axis and vice versa.</param>
                    /// <param name="keyword">The keyword that defines one of the axis sides which the image will be placed against.</param>
                    public static StyleRule BackgroundPosition(Length length, AlignmentMultiple keyword)
                    {
                        if (length.isAuto)
                        {
                            Diag.Violation("background-position rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPosition, $"{length} {keyword.Name()}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.backgroundPosition, $"{length} {keyword.Name()}");
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Style Rule with two keywords and a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with two keywords and a length value: <br></br>
                    ///  - The first and third values are ImageAlignment keywords which dictate which edge to place the image(s) against. One must represent X and the other Y otherwise the style rule is invalidated. <br></br>
                    ///  - The second value, the length, dicates the offset from the edge defined in the first value.
                    /// </summary>
                    /// <param name="firstEdge">The first edge keyword which defines the edge that the image is placed against. Can be X or Y.</param>
                    /// <param name="length">The offset from the first edge.</param>
                    /// <param name="secondEdge">The second edge keyword which defines the edge that the image is placed against. Must an X-axis keyword if the first is a Y-axis keyword and vice versa.</param>
                    /// <returns></returns>
                    public static StyleRule BackgroundPosition(AlignmentMultiple firstEdge, Length length, AlignmentMultiple secondEdge)
                    {
                        if (firstEdge.Conflicts(secondEdge))
                        {
                            Diag.Violation("The first axis keyword and the second axis keyword conflicts in this background-position rule. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {length} {secondEdge.Name()}", false);
                        }
                        else
                        {
                            if (length.isAuto)
                            {
                                Diag.Violation("background-position rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {length} {secondEdge.Name()}", false);
                            }
                            else
                            {
                                return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {length} {secondEdge.Name()}");
                            }
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Style Rule with two keywords and a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with two keywords and a length value: <br></br>
                    ///  - The first and second values are ImageAlignment keywords which dictate which edge to place the image(s) against. One must represent X and the other Y otherwise the style rule is invalidated. <br></br>
                    ///  - The third value, the length, dicates the offset from the edge defined in the first value.
                    /// </summary>
                    /// <param name="firstEdge">The first edge keyword which defines the edge that the image is placed against. Can be X or Y.</param>
                    /// <param name="length">The offset from the first edge.</param>
                    /// <param name="secondEdge">The second edge keyword which defines the edge that the image is placed against. Must an X-axis keyword if the first is a Y-axis keyword and vice versa.</param>
                    public static StyleRule BackgroundPosition(AlignmentMultiple firstEdge, AlignmentMultiple secondEdge, Length length)
                    {
                        if (firstEdge.Conflicts(secondEdge))
                        {
                            Diag.Violation("The first axis keyword and the second axis keyword conflicts in this background-position rule. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {secondEdge.Name()} {length}", false);
                        }
                        else
                        {
                            if (length.isAuto)
                            {
                                Diag.Violation("background-position rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {secondEdge.Name()} {length}", false);
                            }
                            else
                            {
                                return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {secondEdge.Name()} {length}");
                            }
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Style Rule with two keywords and two length values. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When provided with two keywords and two length values: <br></br>
                    ///  - The first and third values are ImageAlignment keywords which dictate which edge to place the image(s) against. One must represent X and the other Y otherwise the style rule is invalidated. <br></br>
                    ///  - The second and fourth value are the length values which dicate the offset from the edge defined by the preceding keyword value.
                    /// </summary>
                    /// <param name="firstEdge">The first edge keyword which defines the edge that the image is placed against. Can be X or Y.</param>
                    /// <param name="firstLength">The offset from the first edge.</param>
                    /// <param name="secondEdge">The second edge keyword which defines the edge that the image is placed against. Must an X-axis keyword if the first is a Y-axis keyword and vice versa.</param>
                    /// <param name="secondLength">The offset from the second edge.</param>
                    public static StyleRule BackgroundPosition(AlignmentMultiple firstEdge, Length firstLength ,AlignmentMultiple secondEdge, Length secondLength)
                    {
                        if (firstEdge.Conflicts(secondEdge))
                        {
                            Diag.Violation("The first axis keyword and the second axis keyword conflicts in this background-position rule. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {firstLength} {secondEdge.Name()} {secondLength}", false);
                        }
                        else
                        {
                            if (firstLength.isAuto || secondLength.isAuto)
                            {
                                Diag.Violation("background-position rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                                return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {firstLength} {secondEdge.Name()} {secondLength}", false);
                            }
                            else
                            {
                                return new StyleRule(RuleType.backgroundPosition, $"{firstEdge.Name()} {firstLength} {secondEdge.Name()} {secondLength}");
                            }
                        }
                    }

                    /// <summary>
                    /// Create a Background Position Style Rule with multiple ImagePosition objects. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> An ImagePosition object is constructed the same way as any other variation of the background-position style rule. <br></br>
                    /// The only difference is that each value contained within each image position is separated by a comma in the final compiled style rule.
                    /// </summary>
                    /// <param name="allImagePositions">The ImagePosition objects to concatenate into a larger style rule value.</param>
                    public static StyleRule BackgroundPosition(params ImagePosition[] allImagePositions)
                    {
                        if (allImagePositions.Length > 0)
                        {
                            string endValue = "";
                            int i = 0, invalidObjects = 0;

                            foreach (ImagePosition ip in allImagePositions)
                            {
                                i++;
                                if (!ip.valid)
                                { invalidObjects++; continue; }

                                endValue = endValue + (i < allImagePositions.Length - 1 ? ip.value + ", " : ip.value);
                            }

                            if (invalidObjects == allImagePositions.Length)
                            {
                                Diag.Violation("There are no valid ImagePosition objects for this background-position rule and no compiled string could be generated. No style rule created.");
                                return null;
                            }
                            else
                            {
                                return new StyleRule(RuleType.backgroundPosition, endValue);
                            }

                        }
                        else
                        {
                            Diag.Violation("There are no ImagePosition objects for this background-position rule. No style rule created.");
                            return null;
                        }
                    }
                }
            }
        }
    }
}
#endif