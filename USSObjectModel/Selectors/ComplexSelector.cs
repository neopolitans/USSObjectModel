using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using Cappuccino.Core;
using System.Linq;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// A representation of a USS Complex Selector. <br></br><br></br>
                /// <see langword="Behaviour Note:"/> Complex Selectors cannot contain pseudoclasses as the pseudoclasses would only apply to the last simple selector in the list <br></br>
                /// and are themselves simple selectors. Add pseudoclasses to the simple selector you wish to define.
                /// </summary>
                public class ComplexSelector : Selector
                {
                    /// <summary>
                    /// The type of complex selector.
                    /// </summary>
                    public ComplexType type;

                    /// <summary>
                    /// All the simple selectors contained under this Complex Selector. <br></br>
                    /// Each simple selector may have it's own pseudoclasses.
                    /// </summary>
                    public List<SimpleSelector> underlyingSelectors = new List<SimpleSelector>();

                    /// <summary>
                    /// Create a complex selector that cannot contain style rules.<br></br>
                    /// <see langword="Cappuccino:"/> This constructor is private as to prevent incorrect Selector construction.
                    /// </summary>
                    /// <param name="type">The selector type.</param>
                    /// <param name="simpleSelectors">The simple selectors within the complex selector.</param>
                    private ComplexSelector(ComplexType type, SimpleSelector[] simpleSelectors)
                    {
                        this.type = type;
                        underlyingSelectors = simpleSelectors.ToList();
                        canContainStyleRules = false;
                        isContainable = true;
                    }

                    /// <summary>
                    /// Create a complex selector.<br></br>
                    /// <see langword="Cappuccino:"/> This constructor is private as to prevent incorrect Selector construction.
                    /// </summary>
                    /// <param name="type">The selector type.</param>
                    /// <param name="simpleSelectors">The simple selectors within the complex selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    private ComplexSelector(ComplexType type, SimpleSelector[] simpleSelectors, params StyleRule[] styleRules)
                    {
                        this.type = type;
                        underlyingSelectors = simpleSelectors.ToList();
                        rules = styleRules.ToList();
                        isContainable = true;
                    }

                    /// <summary>
                    /// Create a complete name based on the underlying selectors.
                    /// </summary>
                    /// <returns></returns>
                    public override string USSName()
                    {
                        string result = "";

                        switch (type)
                        {
                            default:
                                break;

                            case ComplexType.Multiple:
                                for (int i = 0; i < underlyingSelectors.Count; i++)
                                {
                                    if (underlyingSelectors[i].type is SimpleType.Type && i > 0)
                                    {
                                        Diag.Violation("A type selector has been defined after the initial index. This case has been caught and skipped over.");
                                        continue;
                                    }

                                    result += underlyingSelectors[i].USSName();
                                }
                                break;

                            case ComplexType.Descendant:
                                for (int i = 0; i < underlyingSelectors.Count; i++)
                                {
                                    result += underlyingSelectors[i].USSName();

                                    if (i < underlyingSelectors.Count - 1)
                                    {
                                        result += " ";
                                    }
                                }
                                break;

                            case ComplexType.Child:
                                for (int i = 0; i < underlyingSelectors.Count; i++)
                                {
                                    result += underlyingSelectors[i].USSName();

                                    if (i < underlyingSelectors.Count - 1)
                                    {
                                        result += " > ";
                                    }
                                }
                                break;
                        }

                        return result;
                    }

                    // Selector List Manipulation

                    /// <summary>
                    /// Add a selector to the list of simple selectors.
                    /// </summary>
                    /// <param name="selector"></param>
                    /// <returns></returns>
                    public bool AddSelector(SimpleSelector selector)
                    {
                        if (underlyingSelectors == null || selector == null || underlyingSelectors.Contains(selector))
                        {
                            return false;
                        }
                        else
                        {
                            underlyingSelectors.Add(selector);
                            return true;
                        }
                    }

                    /// <summary>
                    /// Remove a selector from the list of simple selectors.
                    /// </summary>
                    /// <param name="selector"></param>
                    /// <returns></returns>
                    public bool RemoveSelector(SimpleSelector selector) 
                    {
                        if (underlyingSelectors == null || selector == null || !underlyingSelectors.Contains(selector))
                        {
                            return false;
                        }
                        else
                        {
                            underlyingSelectors.Remove(selector);
                            return true;
                        }
                    }

                    // Public Constructors

                    /// <summary>
                    /// Create a Descendant Selector that cannot contain style rules. For use with selector lists.
                    /// </summary>
                    /// <param name="selectors">The simple selectors that compose the complex selector.</param>
                    /// <returns></returns>
                    public static ComplexSelector Descendant(SimpleSelector[] selectors)
                    {
                        return new ComplexSelector(ComplexType.Descendant, selectors);
                    }

                    /// <summary>
                    /// Create a Descendant Selector with style rules.
                    /// </summary>
                    /// <param name="selectors">The simple selectors that compose the complex selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static ComplexSelector Descendant(SimpleSelector[] selectors, params StyleRule[] styleRules)
                    {
                        return new ComplexSelector(ComplexType.Descendant, selectors, styleRules);
                    }

                    /// <summary>
                    /// Create a Child Selector that cannot contain style rules. For use with selector lists.
                    /// </summary>
                    /// <param name="selectors">The simple selectors that compose the complex selector.</param>
                    /// <returns></returns>
                    public static ComplexSelector Child(SimpleSelector[] selectors)
                    {
                        return new ComplexSelector(ComplexType.Child, selectors);
                    }

                    /// <summary>
                    /// Create a Child Selector with style rules.
                    /// </summary>
                    /// <param name="selectors">The simple selectors that compose the complex selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static ComplexSelector Child(SimpleSelector[] selectors, params StyleRule[] styleRules)
                    {
                        return new ComplexSelector(ComplexType.Child, selectors, styleRules);
                    }

                    /// <summary>
                    /// Create a Multiple Selector that cannot contain style rules. For use with selector lists.
                    /// </summary>
                    /// <param name="selectors">The simple selectors that compose the complex selector.</param>
                    /// <returns></returns>
                    public static ComplexSelector Multiple(SimpleSelector[] selectors)
                    {
                        return new ComplexSelector(ComplexType.Multiple, selectors);
                    }

                    /// <summary>
                    /// Create a Multiple Selector with style rules.
                    /// </summary>
                    /// <param name="selectors">The simple selectors that compose the complex selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static ComplexSelector Multiple(SimpleSelector[] selectors, params StyleRule[] styleRules)
                    {
                        return new ComplexSelector(ComplexType.Multiple, selectors, styleRules);
                    }
                }   
            }
        }
    }
}