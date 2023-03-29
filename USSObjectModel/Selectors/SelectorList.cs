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
                /// A representation of a USS Selector List. <br></br><br></br>
                /// <see langword="Behaviour Note:"/> Selector Lists cannot contain pseudoclasses as the pseudoclasses would only apply to the last simple selector in the list <br></br>
                /// and are themselves simple selectors. Add pseudoclasses to the simple selectors contained within either the SelectorList or complex selectors in the SelectorList.
                /// </summary>
                public class SelectorList : Selector
                {
                    /// <summary>
                    /// All the simple and complex selectors contained under this Selector List. <br></br>
                    /// Each simple selector may have it's own pseudoclasses.
                    /// </summary>
                    List<Selector> underlyingSelectors = new List<Selector>();

                    /// <summary>
                    /// Create a selector list.
                    /// </summary>
                    /// <param name="selectors">The selectors that are contained within the list.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    public SelectorList(Selector[] selectors, params StyleRule[] styleRules)
                    {
                        rules = styleRules.ToList();
                        foreach (Selector s in selectors)
                        {
                            if (!s.isContainable)
                            {
                                Diag.Violation("A selector passed is not a containable selector (is a SelectorList or Pseudoclass). This case has been caught and skipped.");
                                continue;
                            }

                            underlyingSelectors.Add(s);
                        }
                    }

                    /// <summary>
                    /// Create a selector list. Used internally for SelectorList.Join().
                    /// </summary>
                    /// <param name="selectors">The selectors that are contained within the list.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    private SelectorList(List<Selector> selectors, List<StyleRule> styleRules)
                    {
                        rules = styleRules;
                        underlyingSelectors = selectors;
                    }

                    /// <summary>
                    /// Create a complete name based on the underlying selectors.
                    /// </summary>
                    /// <returns></returns>
                    public override string Name()
                    {
                        string result = "";

                        for (int i = 0; i < underlyingSelectors.Count; i++)
                        {
                            result += underlyingSelectors[i].Name();
                            if (i < underlyingSelectors.Count - 1)
                            {
                                result += ", ";
                            }
                        }

                        return result;
                    }

                    // Selector List Manipulation
                    /// <summary>
                    /// Add a simple selector to the list of selectors.
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
                    /// Remove a simple selector from the list of simple selectors.
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

                    /// <summary>
                    /// Add a complex selector to the list of selectors.
                    /// </summary>
                    /// <param name="selector"></param>
                    /// <returns></returns>
                    public bool AddSelector(ComplexSelector selector)
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
                    /// Remove a complex selector from the list of simple selectors.
                    /// </summary>
                    /// <param name="selector"></param>
                    /// <returns></returns>
                    public bool RemoveSelector(ComplexSelector selector)
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

                    /// <summary>
                    /// Join two or more selector lists together. 
                    /// </summary>
                    /// <param name="lists"></param>
                    /// <returns></returns>
                    public static SelectorList Join(params SelectorList[] lists)
                    {
                        List<Selector> selectors = new List<Selector>();
                        List<StyleRule> rules = new List<StyleRule>();

                        foreach (SelectorList l in lists)
                        {
                            foreach (Selector s in l.underlyingSelectors)
                            {
                                selectors.Add(s);
                            }

                            foreach (StyleRule sr in l.rules)
                            {
                                rules.Add(sr);
                            }
                        }

                        return new SelectorList(selectors, rules);
                    }
                }
            }
        }
    }
}