using Cappuccino.Core;

// Flex is one of the more confusing ones to wrap your head around. This script references these two as additional resources:
//  -   https://developer.mozilla.org/en-US/docs/Web/CSS/flex
//  -   https://css-tricks.com/snippets/css/a-guide-to-flexbox/

// The *structure* of flex appears as:
//     - flex: none | [ <'flex-grow'> <'flex-shrink'>? || <'flex-basis'> ]
//
// what this roughly translates to is - flex can be none or it can be:
//      flex-grow
//      flex-basis
//      flex-grow & flex-shrink
//      flex-grow & flex-basis
//      flex-grow , flex-shrink & flex-basis

// That is to say [only "none", flex-grow or flex-basis can be solo], [flex-glow and (flex-shrink or flex-basis) must occur for two values] or [all three values must be present (except none)]

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
                    /// Create a Flex Style Rule with no value. <br></br>
                    /// Assumes the "none" keyword.
                    /// </summary>
                    public static StyleRule Flex()
                    {
                        return new StyleRule(RuleType.flex, "none");
                    }

                    /// <summary>
                    /// Create a Flex Style Rule with only the flex-grow value. <br></br><br></br>
                    /// <see langword="Flexbox CSS:"/> When only the flex-grow value is supplied, the shorthand (flex) sets the other values automatically.<br></br>
                    /// <b><i>flex</i> : {flexgrow}</b>;
                    /// </summary>
                    /// <param name="flexgrow">The number representing the flex-grow value.</param>
                    public static StyleRule Flex(Number flexgrow)
                    {
                        return new StyleRule(RuleType.flex, flexgrow.ToString());
                    }

                    /// <summary>
                    /// Create a Flex Style Rule with only the flex-basis value. <br></br><br></br>
                    /// <see langword="Flexbox CSS:"/> When only the flex-basis value is supplied, the shorthand (flex) sets the other values automatically.<br></br>
                    /// <b><i>flex</i> : {flexbasis}</b>;
                    /// </summary>
                    /// <param name="flexbasis">The number representing the flex-basis value.</param>
                    public static StyleRule Flex(Len flexbasis)
                    {
                        return new StyleRule(RuleType.flex, flexbasis.ToString());
                    }

                    /// <summary>
                    /// Create a Flex Style Rule with only the flex-grow and optional flex-shrink value. <br></br><br></br>
                    /// <see langword="Flexbox CSS:"/> When only the flex-grow and flex-shrink values are supplied, the shorthand (flex) sets flex-basis automatically (to 0%).<br></br>
                    /// <b><i>flex</i> : {flexgrow} {flexshrink} </b>;
                    /// </summary>
                    /// <param name="flexgrow">The number representing the flex-grow value.</param>
                    /// <param name="flexshrink">The number representing the flex-shrink value.</param>
                    public static StyleRule Flex(Number flexgrow, Number flexshrink)
                    {
                        return new StyleRule(RuleType.flex, $"{flexgrow} {flexshrink}");
                    }

                    /// <summary>
                    /// Create a Flex Style Rule with only the flex-grow and optional flex-basis value. <br></br><br></br>
                    /// <see langword="Flexbox CSS:"/> When only the flex-grow and flex-basis values are supplied, the shorthand (flex) sets flex-shrink automatically (to 1).<br></br>
                    /// <b><i>flex</i> : {flexgrow} {flexbasis} </b>;
                    /// </summary>
                    /// <param name="flexgrow">The number representing the flex-grow value.</param>
                    /// <param name="flexbasis">The number representing the flex-basis value.</param>
                    public static StyleRule Flex(Number flexgrow, Len flexbasis)
                    {
                        return new StyleRule(RuleType.flex, $"{flexgrow} {flexbasis}");
                    }

                    /// <summary>
                    /// Create a Flex Style Rule with only the flex-grow and optional flex-basis value. <br></br><br></br>
                    /// <see langword="Flexbox CSS:"/> All three values are supplied.<br></br>
                    /// <b><i>flex</i> : {flexgrow} {flexshrink} {flexbasis} </b>;
                    /// </summary>
                    /// <param name="flexgrow">The number representing the flex-grow value.</param>
                    /// <param name="flexshrink">The number representing the flex-shrink value.</param>
                    /// <param name="flexbasis">The number representing the flex-basis value.</param>
                    public static StyleRule Flex(Number flexgrow, Number flexshrink, Len flexbasis)
                    {
                        return new StyleRule(RuleType.flex, $"{flexgrow} {flexshrink} {flexbasis}");
                    }
                }
            }
        }
    }
}