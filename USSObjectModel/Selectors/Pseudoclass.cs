using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

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
                /// An object representing a Pseudoclass under the USS standard, which may feature behaviour derivative of <i>CSS Selectors Level 3</i>. <br></br><br></br>
                /// 
                /// <b><see langword="Specification Info:"/></b> <br></br> 
                /// CSS Selectors Level 3 <b>(§6.6)</b> and Level 4 <b>(§3.5)</b> define the ability for pseudoclasses to be placed in complex selectors like simple selectors. <br></br>
                /// As Unity uses ExCSS for their USS importer, Cappuccino assumes this behaviour is present. <br></br><br></br>
                /// 
                /// <b><see langword="Notice:"/> Pseudoclasses are not user-creatable. They are strictly defined in the USS specification.</b> <br></br>
                /// <i> - :root is handled as a Simple Selector.</i>
                /// </summary>
                public class Pseudoclass : Selector
                {
                    public PseudoclassType type;

                    /// <summary>
                    /// Convert the underlying pseudoclass type to a string.
                    /// </summary>
                    /// <returns></returns>
                    public override string ToString()
                    {
                        return type switch
                        {
                            PseudoclassType.hover => ":hover",
                            PseudoclassType.active => ":active",
                            PseudoclassType.inactive => ":inactive",
                            PseudoclassType.focus => ":focus",
                            PseudoclassType.selected => ":selected",
                            PseudoclassType.disabled => ":disabled",
                            PseudoclassType.enabled => ":enabled",
                            PseudoclassType.uss_checked => ":checked",
                            _ => ""
                        };
                    }

                    /// <summary>
                    /// <see langword="Cappuccino:"/> This method lets you directly supply a pseudoclass type. <br></br> 
                    /// Using the constructor is not recommended over the static methods provided.
                    /// </summary>
                    /// <param name="type"></param>
                    public Pseudoclass(PseudoclassType type)
                    {
                        this.type = type;
                        isPseudoclass = true;
                    }

                    /// <summary>
                    /// Create a pseudoclass instance that represents the pseudo-class [:hover]
                    /// </summary>
                    public static Pseudoclass Hover() => new Pseudoclass(PseudoclassType.hover);

                    /// <summary>
                    /// Create a pseudoclass instance that represents the pseudo-class [:active]
                    /// </summary>
                    public static Pseudoclass Active() => new Pseudoclass(PseudoclassType.active);

                    /// <summary>
                    /// Create a pseudoclass instance that represents the pseudo-class [:inactive]
                    /// </summary>
                    public static Pseudoclass Inactive() => new Pseudoclass(PseudoclassType.inactive);

                    /// <summary>
                    /// Create a pseudoclass instance that represents the pseudo-class [:focus]
                    /// </summary>
                    public static Pseudoclass Focus() => new Pseudoclass(PseudoclassType.focus);

                    /// <summary>
                    /// Create a pseudoclass instance that represents the pseudo-class [:selected]
                    /// </summary>
                    public static Pseudoclass Selected() => new Pseudoclass(PseudoclassType.selected);

                    /// <summary>
                    /// Create a pseudoclass instance that represents the pseudo-class [:disabled]
                    /// </summary>
                    public static Pseudoclass Disabled() => new Pseudoclass(PseudoclassType.disabled);

                    /// <summary>
                    /// Create a pseudoclass instance that represents the pseudo-class [:enabled]
                    /// </summary>
                    public static Pseudoclass Enabled() => new Pseudoclass(PseudoclassType.enabled);

                    /// <summary>
                    /// Create a pseudoclass instance that represents the pseudo-class [:checked]
                    /// </summary>
                    public static Pseudoclass Checked() => new Pseudoclass(PseudoclassType.uss_checked);
                }
            }
        }
    }
}