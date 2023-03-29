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
                /// The Complex Types that the selector can be.
                /// </summary>
                public enum ComplexType
                {
                    None = -1,

                    /// <summary>
                    /// Declares the related selector to be a <b>Descendant Selector</b>. <br></br>
                    /// A selector that matches with elements that are descendant of an element.
                    /// </summary>
                    Descendant,

                    /// <summary>
                    /// Declares the related selector to be a <b>Child Selector</b>. <br></br>
                    /// A selector that matches with elements that are a child of another element in a visual tree. <br></br><br></br>
                    /// <i>Not to be confused with Descendant Selector.</i>
                    /// </summary>
                    Child,

                    /// <summary>
                    /// Declares the related selector to be a <b>Multiple Selector</b>. <br></br>
                    /// A selector that is a combination of multiple simple selectors. <br></br><br></br>
                    /// <i>Can only use one Class selector and must be the first in the selector definitions.</i>
                    /// </summary>
                    Multiple
                }
            }
        }
    }
}