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
                /// A representation of the &lt;length&gt; data type for USS. <br></br>
                /// <see langword="Cappuccino:"/> As length values can be suffixed with px or %, this data type is necessary.
                /// </summary>
                public class Len
                {
                    /// <summary>
                    /// The integer value that will be represented in the &lt;length&gt; data type.
                    /// </summary>
                    public int value;

                    /// <summary>
                    /// Whether or not the integer value represents a percentage (e.g. 50%).
                    /// </summary>
                    public bool isPercent;

                    /// <summary>
                    /// Whether or not the value should return as the "auto" keyword instead (where supported). <br></br>
                    /// Precedes any other checks and while true, ToString will return "auto".
                    /// </summary>
                    public bool isAuto;

                    /// <summary>
                    /// Create a &lt;length&gt; object with no value. <br></br>
                    /// When the resulting length object's ToString method is called, it will return "auto".
                    /// </summary>
                    public Len()
                    {
                        value = 0;
                        isPercent = false;
                        isAuto = true;
                    }

                    /// <summary>
                    /// Create a &lt;length&gt; object with an integer value. <br></br>
                    /// When ToString is called, it will return a pixels value. (e.g. 50px)
                    /// </summary>
                    public Len(int value)
                    {
                        this.value = value;
                        isPercent = false;
                    }

                    /// <summary>
                    /// Create a &lt;length&gt; object with integer value and a bool value to determine whether or not it is a percentage. <br></br>
                    /// When ToString is called, it will return a percentage if the bool value is true (e.g. 50%), otherwise it will return a pixels value (e.g. 50px).
                    /// </summary>
                    public Len(int value, bool isPercentage)
                    {
                        this.value = value;
                        this.isPercent = isPercentage;
                    }

                    /// <summary>
                    /// Convert the length to a string. <br></br>
                    /// Will return "auto" if isAuto is true, otherwise isPercent will determine the conversion type.
                    /// </summary>
                    public override string ToString()
                    {
                        return isAuto ? "auto" : isPercent ? $"{value}%" : $"{value}px";
                    }
                }

            }
        }
    }
}