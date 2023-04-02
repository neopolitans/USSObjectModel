using Cappuccino.Core;

// Notes about transform-origin:
//  - MDN CSS lists the ability for three-value syntax {x - length or keyword, y - length or keyword, z - length}.
//  - Unity USS only lists the ability for one keyword or two values (x - length or keyword, y - length or keyword).
//  
//  If any further clarifications are found regarding transform-origin in Unity USS, these missing properites will be instated.

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
                    /// Create a Transform Origin style rule with a keyword value. <br></br>
                    /// <see langword="Cappuccino:"/> A single keyword will be used for either the center (short for center, center) or the center of the specified edge {left center, right center, top center, bottom center}.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Justify Content. Restricted to only the compatible keywords.</param>
                    /// <returns></returns>
                    public static StyleRule TransformOrigin(Alignment keyword)
                    {
                        return new StyleRule(RuleType.transformOrigin, keyword.Name());
                    }

                    /// <summary>
                    /// Create a Transform Origin style rule with two keyword value. <br></br>
                    /// <see langword="Cappuccino:"/> Two keyword will be used for both axes. Only one horizontal and one vertical keyword is permitted at a time. 'center' is permitted in both.
                    /// </summary>
                    /// <param name="firstEdge">The first edge keyword which defines transform origin. Can be X or Y keyword.</param>
                    /// <param name="secondEdge">The second edge keyword which defines transform origin. Must an X-axis keyword if the first is a Y-axis keyword and vice versa.</param>
                    /// <returns></returns>
                    public static StyleRule TransformOrigin(Alignment firstEdge, Alignment secondEdge)
                    {
                        if (firstEdge.Conflicts(secondEdge))
                        {
                            Diag.Violation("The first axis keyword and the second axis keyword conflicts in this transform-origin rule. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.transformOrigin, $"{firstEdge.Name()} {secondEdge.Name()}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.transformOrigin, $"{firstEdge.Name()} {secondEdge.Name()}");
                        }
                    }

                    /// <summary>
                    /// Create a Transform Origin style rule with two length value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> When two length values are provided: <br></br>
                    ///  - The first length value defines the x position of the transform origin. <br></br>
                    ///  - The second length value defines the y position of the transform origin.
                    /// </summary>
                    /// <param name="x">The x coordinate of the transform origin.</param>
                    /// <param name="y">The y coordinate of the transform origin.</param>
                    /// <returns></returns>
                    public static StyleRule TransformOrigin(Len x, Len y)
                    {
                        if (x.isAuto || y.isAuto)
                        {
                            Diag.Violation("transform-origin rules do not support the \"auto\" keyword. This style rule has been marked as invalid.");
                            return new StyleRule(RuleType.transformOrigin, $"{x} {y}", false);
                        }
                        else
                        {
                            return new StyleRule(RuleType.transformOrigin, $"{x} {y}");
                        }
                    }

                }
            }
        }
    }
}