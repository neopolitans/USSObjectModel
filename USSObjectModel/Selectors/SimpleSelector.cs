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
                /// A representation of a USS Simple Selector. <br></br><br></br>
                /// </summary>
                public class SimpleSelector : Selector
                {
                    /// <summary>
                    /// The simple selector's name.
                    /// </summary>
                    public string name;

                    /// <summary>
                    /// The type of simple selector.
                    /// </summary>
                    public SimpleType type;

                    /// <summary>
                    /// The pseudoclasses that affect whether or not the selector matches with elements based on the element state.
                    /// </summary>
                    public List<Pseudoclass> pseudoclasses = new List<Pseudoclass>();

                    // Private Constructors

                    /// <summary>
                    /// Construct a simple selector that cannot take style rules. For use with complex selectors and selector lists. <br></br>
                    /// <see langword="Cappuccino:"/> This constructor is private as to prevent incorrect Selector construction.
                    /// </summary>
                    /// <param name="name">The selector name.</param>
                    /// <param name="type">The selector type.</param>
                    private SimpleSelector(string name, SimpleType type)
                    {
                        this.name = name;
                        this.type = type;
                        canContainStyleRules = false;
                        isContainable = true;
                    }

                    /// <summary>
                    /// Construct a simple selector. <br></br>
                    /// <see langword="Cappuccino:"/> This constructor is private as to prevent incorrect Selector construction.
                    /// </summary>
                    /// <param name="name">The selector name.</param>
                    /// <param name="type">The selector type.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    private SimpleSelector(string name, SimpleType type,  params StyleRule[] styleRules)
                    {
                        this.name = name;
                        this.type = type;
                        rules = styleRules.ToList();
                        isContainable = true;
                    }

                    /// <summary>
                    /// Construct a simple selector.
                    /// <see langword="Cappuccino:"/> This constructor is private as to prevent incorrect Selector construction.
                    /// </summary>
                    /// <param name="name">The selector name.</param>
                    /// <param name="type">The selector type.</param>
                    /// <param name="pseudoclasses">The pseudoclasses that affect what states result in elements matching with the selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    private SimpleSelector(string name, SimpleType type, Pseudoclass[] pseudoclasses, params StyleRule[] styleRules)
                    {
                        this.name = name;
                        this.type = type;
                        this.pseudoclasses = pseudoclasses.ToList();
                        rules = styleRules.ToList();
                        isContainable = true;
                    }

                    // Translators
                    /// <summary>
                    /// Construct a string for all the pseudoclasses attached to this selector.
                    /// </summary>
                    /// <returns></returns>
                    public string PseudoclassString()
                    {
                        string result = "";

                        foreach (Pseudoclass p in pseudoclasses)
                        {
                            result += p.ToString();
                        }

                        return result;
                    }

                    /// <summary>
                    /// Get the selector definition.
                    /// </summary>
                    /// <returns></returns>
                    public override string USSName() => name + PseudoclassString();

                    // Public Constructors

                    /// <summary>
                    /// Create a Class Selector that cannot contain style rules. <br></br>
                    /// If the name doesn't start with '.', it will be prefixed.
                    /// </summary>
                    /// <param name="name">The name of the Class Selector.</param>
                    /// <returns></returns>
                    public static SimpleSelector Class(string name)
                    {
                        if (!name.StartsWith('.'))
                        {
                            name = '.' + name;
                        }
                        return new SimpleSelector(name, SimpleType.Class);
                    }

                    /// <summary>
                    /// Create a Name Selector that cannot contain style rules. <br></br>
                    /// If the name doesn't start with '#', it will be prefixed.
                    /// </summary>
                    /// <param name="name">The name of the Name Selector.</param>
                    public static SimpleSelector Name(string name)
                    {
                        if (!name.StartsWith('#'))
                        {
                            name = '#' + name;
                        }
                        return new SimpleSelector(name, SimpleType.Name);
                    }

                    /// <summary>
                    /// Create a Type Selector that cannot contain style rules.
                    /// </summary>
                    /// <param name="name">The name of the Type Selector.</param>
                    public static SimpleSelector Type(string name)
                    {
                        return new SimpleSelector(name, SimpleType.Name);
                    }

                    /// <summary>
                    /// Create a Universal Selector that cannot contain style rules. Only creates a universal selector represented with an asterisk. <br></br>
                    /// Does not support CSS-specific behaviours of Namespace Universal Selectors.
                    /// </summary>
                    /// <returns></returns>
                    public static SimpleSelector Universal()
                    {
                        return new SimpleSelector("*", SimpleType.Universal);
                    }

                    /// <summary>
                    /// Create a Root Selector that cannot contain style rules.<br></br>
                    /// <b>:root</b> is a special pseudoclass which directly references the root visual element.
                    /// </summary>
                    /// <returns></returns>
                    public static SimpleSelector Root()
                    {
                        return new SimpleSelector(":root", SimpleType.Root);
                    }

                    /// <summary>
                    /// Create a Class Selector. <br></br>
                    /// If the name doesn't start with '.', it will be prefixed.
                    /// </summary>
                    /// <param name="name">The name of the Class Selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static SimpleSelector Class(string name, params StyleRule[] styleRules)
                    {
                        if (!name.StartsWith('.'))
                        {
                            name = '.' + name;
                        }
                        return new SimpleSelector(name, SimpleType.Class, styleRules);
                    }

                    /// <summary>
                    /// Create a Name Selector. <br></br>
                    /// If the name doesn't start with '#', it will be prefixed.
                    /// </summary>
                    /// <param name="name">The name of the Name Selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    public static SimpleSelector Name(string name, params StyleRule[] styleRules)
                    {
                        if (!name.StartsWith('#'))
                        {
                            name = '#' + name;
                        }
                        return new SimpleSelector(name, SimpleType.Name, styleRules);
                    }

                    /// <summary>
                    /// Create a Type Selector.
                    /// </summary>
                    /// <param name="name">The name of the Type Selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    public static SimpleSelector Type(string name, params StyleRule[] styleRules)
                    {
                        return new SimpleSelector(name, SimpleType.Name, styleRules);
                    }

                    /// <summary>
                    /// Create a Universal Selector. Only creates a universal selector represented with an asterisk. <br></br>
                    /// Does not support CSS-specific behaviours of Namespace Universal Selectors.
                    /// </summary>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static SimpleSelector Universal(params StyleRule[] styleRules)
                    {
                        return new SimpleSelector("*", SimpleType.Universal, styleRules);
                    }

                    /// <summary>
                    /// Create a Root Selector.<br></br>
                    /// <b>:root</b> is a special pseudoclass which directly references the root visual element.
                    /// </summary>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static SimpleSelector Root(params StyleRule[] styleRules)
                    {
                        return new SimpleSelector(":root", SimpleType.Root, styleRules);
                    }

                    /// <summary>
                    /// Create a Class Selector. <br></br>
                    /// If the name doesn't start with '.', it will be prefixed.
                    /// </summary>
                    /// <param name="name">The name of the Class Selector.</param>
                    /// <param name="pseudoclasses">The pseudoclasses that affect what states result in elements matching with the selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static SimpleSelector Class(string name, Pseudoclass[] pseudoclasses, params StyleRule[] styleRules)
                    {
                        if (!name.StartsWith('.'))
                        {
                            name = '.' + name;
                        }
                        return new SimpleSelector(name, SimpleType.Class, pseudoclasses, styleRules);
                    }

                    /// <summary>
                    /// Create a Name Selector. <br></br>
                    /// If the name doesn't start with '#', it will be prefixed.
                    /// </summary>
                    /// <param name="name">The name of the Name Selector.</param>
                    /// <param name="pseudoclasses">The pseudoclasses that affect what states result in elements matching with the selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    public static SimpleSelector Name(string name, Pseudoclass[] pseudoclasses, params StyleRule[] styleRules)
                    {
                        if (!name.StartsWith('#'))
                        {
                            name = '#' + name;
                        }
                        return new SimpleSelector(name, SimpleType.Name, pseudoclasses, styleRules);
                    }

                    /// <summary>
                    /// Create a Type Selector.
                    /// </summary>
                    /// <param name="name">The name of the Type Selector.</param>
                    /// <param name="pseudoclasses">The pseudoclasses that affect what states result in elements matching with the selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    public static SimpleSelector Type(string name, Pseudoclass[] pseudoclasses, params StyleRule[] styleRules)
                    {
                        return new SimpleSelector(name, SimpleType.Name, pseudoclasses, styleRules);
                    }

                    /// <summary>
                    /// Create a Universal Selector. Only creates a universal selector represented with an asterisk. <br></br>
                    /// Does not support CSS-specific behaviours of Namespace Universal Selectors.
                    /// </summary>
                    /// <param name="pseudoclasses">The pseudoclasses that affect what states result in elements matching with the selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static SimpleSelector Universal(Pseudoclass[] pseudoclasses, params StyleRule[] styleRules)
                    {
                        return new SimpleSelector("*", SimpleType.Universal, pseudoclasses, styleRules);
                    }

                    /// <summary>
                    /// Create a Root Selector.<br></br>
                    /// <b>:root</b> is a special pseudoclass which directly references the root visual element.
                    /// </summary>
                    /// <param name="pseudoclasses">The pseudoclasses that affect what states result in elements matching with the selector.</param>
                    /// <param name="styleRules">The style rules that get applied to matched elements.</param>
                    /// <returns></returns>
                    public static SimpleSelector Root(Pseudoclass[] pseudoclasses, params StyleRule[] styleRules)
                    {
                        return new SimpleSelector(":root", SimpleType.Root, pseudoclasses, styleRules);
                    }
                }
            }
        }
    }
}