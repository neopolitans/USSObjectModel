// Numeric defines the two USS/CSS datatypes:
//  - <Number>
//  - <Integer>

// This is done to make it easier to understand what the USS documentation says.
// These values can never be substituted with the "auto" keyword.

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// A representation of the &lt;number&gt; data type for USS. <br></br>
                /// <see langword="Cappuccino:"/> Number values are fixed as a floating-point value. They can never be substituted with auto.
                /// </summary>
                public class Number
                {
                    /// <summary>
                    /// The &lt;number&gt; value is a floating point.
                    /// </summary>
                    public float value;

                    /// <summary>
                    /// Create a &lt;number&gt; object with a floating point value. <br></br>
                    /// </summary>
                    /// <param name="value">The floating point value.</param>
                    public Number(float value)
                    {
                        this.value = value;
                    }

                    /// <summary>
                    /// Convert the number to a string. <br></br>
                    /// Will return the floating point value as a string.
                    /// </summary>
                    public override string ToString() => value.ToString();
                }
            }
        }
    }
}

/*  This was redundant - it's kept here just in some odd event it's needed again temporarily. Right now the C# int type does everything this does, and more.

                /// <summary>
                /// A representation of the &lt;integer&gt; data type for USS. <br></br>
                /// <see langword="Cappuccino:"/> Integer values are fixed as an integer literal value. They can never be substituted with auto.
                /// </summary>
                public class Integer
                {
                    /// <summary>
                    /// The &lt;integer&gt; value is a floating point.
                    /// </summary>
                    public int value;

                    /// <summary>
                    /// Create a &lt;integer&gt; object with an integer literal value. <br></br>
                    /// </summary>
                    /// <param name="value">The floating point value.</param>
                    public Integer(int value)
                    {
                        this.value = value;
                    }

                    /// <summary>
                    /// Convert the integer to a string. <br></br>
                    /// Will return the integer literal value as a string.
                    /// </summary>
                    public override string ToString() => value.ToString();
                }
*/