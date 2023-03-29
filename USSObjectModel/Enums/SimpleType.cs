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
                /// The Simple Types that the selector can be.
                /// </summary>
                public enum SimpleType
                {
                    None = -1,

                    /// <summary>
                    /// Declares the related selector to be a <b>Type Selector</b>. <br></br>
                    /// A selector that matches with elements based on their element type.
                    /// </summary>
                    Type,

                    /// <summary>
                    /// Declares the related selector to be a <b>Class Selector</b>. <br></br>
                    /// A selector that matches with elements that have assigned USS Classes.
                    /// </summary>
                    Class,

                    /// <summary>
                    /// Declares the related selector to be a <b>Name Selector</b>. <br></br>
                    /// A selector that matches with elements that have the element name specified.
                    /// </summary>
                    Name,

                    /// <summary>
                    /// Declares the selector to be a <b>Universal Selector</b>. <br></br>
                    /// A selector that matches with any element.
                    /// </summary>
                    Universal,

                    /// <summary>
                    /// A Pseudo-clas Selector that matches to the root visual element of a USS document. <br></br><br></br>
                    /// <see langword="Notice:"/> As this Pseudo-class matches to the root visual element of a document, it is provided as a broad-style selector. <br></br>
                    /// For other pseudo-classes which can be chained to apply style rules to an element when it enters specific states, see <see cref="Languages.USS.Pseudoclass">Pseudoclass</see>.
                    /// </summary>
                    Root
                }
            }
        }
    }
}