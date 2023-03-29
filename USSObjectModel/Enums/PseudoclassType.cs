using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// A Bitflag Enumerator representing all pseudoclasses supporting USS. <br></br>
                /// <see langword="Notice:"/> :root is a type of Simple Selector instead as it targets the root visual element.
                /// </summary>
                public enum PseudoclassType
                {
                    None = 0,

                    /// <summary>
                    /// The Pseudo-class state [:hover].
                    /// </summary>
                    hover,

                    /// <summary>
                    /// The Pseudo-class state [:active].
                    /// </summary>
                    active,

                    /// <summary>
                    /// The Pseudo-class state [:inactive].
                    /// </summary>
                    inactive,

                    /// <summary>
                    /// The Pseudo-class state [:focus].
                    /// </summary>
                    focus,

                    /// <summary>
                    /// The Pseudo-class state [:selected].
                    /// </summary>
                    selected,

                    /// <summary>
                    /// The Pseudo-class state [:disabled].
                    /// </summary>
                    disabled,

                    /// <summary>
                    /// The Pseudo-class state [:enabled].
                    /// </summary>
                    enabled,

                    /// <summary>
                    /// The Pseudo-class state [:checked]. <br></br>
                    /// The only unique pseudo-class with a prefix due to the C# keyword "checked" existing for value overflows.
                    /// </summary>
                    uss_checked
                }
            }
        }
    }
}